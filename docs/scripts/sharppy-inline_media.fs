module ConvertedFiles.Scripts.InlineMediaPy

let file = System.String.Join("\"\"\"", [|
    """#!/usr/bin/env python3
"""
    """
Modular media inliner for Zensical-built sites.

Usage:
    # Inline ALL media across the entire site
    python scripts/inline_media.py all

    # Inline only specific media types
    python scripts/inline_media.py picture   # images only (.png .jpg .svg .ico .webp .gif)
    python scripts/inline_media.py video     # video only (.mp4 .webm .ogv)
    python scripts/inline_media.py audio     # audio only (.mp3 .ogg .wav .flac .m4a)
    python scripts/inline_media.py document  # documents only (.pdf)
    python scripts/inline_media.py font      # fonts only (.woff2 .woff .ttf .otf)
    python scripts/inline_media.py css       # CSS url() references only

    # Target a specific HTML page (relative to site/)
    python scripts/inline_media.py page getting_started/quickstart/index.html

    # Target a specific file (HTML or CSS)
    python scripts/inline_media.py file assets/stylesheets/extra.css

    # Target multiple specific files
    python scripts/inline_media.py page zensical_authoring/code-blocks/index.html
    python scripts/inline_media.py page zensical_authoring/images/index.html

    # Combine: inline pictures on a specific page only
    python scripts/inline_media.py picture --page getting_started/quickstart/index.html

Configuration (edit at top of file):
    MAX_SIZE: max file size to inline (default 2MB)
    SITE_DIR: path to the built site/ directory
    VERBOSE: print each inlined file
"""
    """

import os
import sys
import re
import base64
import mimetypes
import argparse
from pathlib import Path
from urllib.parse import unquote
from fnmatch import fnmatch

# ---------------------------------------------------------------------------
# Configuration
# ---------------------------------------------------------------------------

SCRIPT_DIR = Path(__file__).parent.resolve()
SITE_DIR = SCRIPT_DIR.parent / "site"
MAX_SIZE = 2 * 1024 * 1024  # 2 MB
VERBOSE = True

# ---------------------------------------------------------------------------
# Media type filters
# ---------------------------------------------------------------------------

MEDIA_FILTERS = {
    "picture":  {".png", ".jpg", ".jpeg", ".gif", ".svg", ".webp", ".ico", ".bmp"},
    "video":    {".mp4", ".webm", ".ogv", ".mov"},
    "audio":    {".mp3", ".ogg", ".wav", ".flac", ".m4a", ".aac"},
    "document": {".pdf"},
    "font":     {".woff2", ".woff", ".ttf", ".otf", ".eot"},
}

# Framework assets to skip
SKIP_PATTERNS = [
    "assets/stylesheets/classic/",
    "assets/stylesheets/modern/",
    "assets/javascripts/bundle",
    "assets/javascripts/worker",
    "assets/javascripts/vendor",
    "assets/images/favicon.png",
    "assets/images/logo.svg",
]

# HTML tag/attribute pairs to scan
HTML_ATTRS = [
    ("img", "src"),
    ("video", "src"),
    ("audio", "src"),
    ("source", "src"),
    ("embed", "src"),
    ("object", "data"),
    ("iframe", "src"),
    ("track", "src"),
    ("link", "href"),
    ("input", "src"),
]

# Regex patterns
CSS_URL_RE = re.compile(r"url\s*\(\s*['\"]?([^'\"\)]+)['\"]?\s*\)", re.I)
SVG_HREF_RE = re.compile(
    r'<(?:image|use|a)\s+[^>]*?(?:href|xlink:href)=[\'"]([^\'"]+)[\'"]', re.I
)

# ---------------------------------------------------------------------------
# Core helpers
# ---------------------------------------------------------------------------

def should_skip(url: str, allowed_exts: set | None = None) -> bool:
    """
    """Check if URL should be skipped."""
    """
    if not url:
        return True
    url_lower = url.lower()
    # Skip external URLs
    if any(url_lower.startswith(p) for p in ("http://", "https://", "//", "data:", "#", "javascript:")):
        return True
    # Skip framework assets
    for pat in SKIP_PATTERNS:
        if pat in url:
            return True
    # Skip if extension not in allowed set
    if allowed_exts is not None:
        for ext in allowed_exts:
            if url_lower.endswith(ext):
                return False
        return True
    return False


def resolve_url(url: str, base_dir: Path, site_dir: Path) -> Path | None:
    """
    """Resolve a relative URL to an absolute file path."""
    """
    if should_skip(url):
        return None
    url_clean = unquote(url.split("?")[0].split("#")[0])
    if url_clean.startswith("/"):
        candidate = (site_dir / url_clean.lstrip("/")).resolve()
    else:
        candidate = (base_dir / url_clean).resolve()
    try:
        candidate.relative_to(site_dir.resolve())
    except ValueError:
        return None
    return candidate if candidate.is_file() and candidate.stat().st_size <= MAX_SIZE else None


def to_data_uri(file_path: Path) -> str:
    """
    """Convert a file to base64 data URI."""
    """
    mime, _ = mimetypes.guess_type(str(file_path))
    if not mime:
        ext = file_path.suffix.lower()
        mime_map = {
            ".woff2": "font/woff2", ".woff": "font/woff", ".ttf": "font/ttf",
            ".otf": "font/otf", ".eot": "application/vnd.ms-fontobject",
            ".ico": "image/x-icon", ".ogv": "video/ogg",
            ".flac": "audio/flac", ".m4a": "audio/mp4",
        }
        mime = mime_map.get(ext, "application/octet-stream")
    with open(file_path, "rb") as f:
        return f"data:{mime};base64,{base64.b64encode(f.read()).decode('ascii')}"


# ---------------------------------------------------------------------------
# Inline processors
# ---------------------------------------------------------------------------

def inline_html_file(html_path: Path, site_dir: Path, allowed_exts: set | None = None) -> int:
    """
    """Process a single HTML file. Returns count of inlines."""
    """
    html_dir = html_path.parent
    content = html_path.read_text(encoding="utf-8")
    original = content
    count = 0

    # 1. HTML tag attributes
    for tag, attr in HTML_ATTRS:
        pattern = re.compile(
            rf'(<{re.escape(tag)}\s+[^>]*?{re.escape(attr)}=[\'"])([^\'"]+)([\'"])',
            re.IGNORECASE,
        )

        def repl(match, _dir=html_dir, _site=site_dir, _exts=allowed_exts):
            nonlocal count, content
            url = match.group(2)
            file_path = resolve_url(url, _dir, _site)
            if file_path is None:
                # Check extension filter manually
                if _exts and not any(url.lower().endswith(e) for e in _exts):
                    return match.group(0)
                return match.group(0)
            if _exts and not any(str(file_path).lower().endswith(e) for e in _exts):
                return match.group(0)
            try:
                data_uri = to_data_uri(file_path)
                count += 1
                if VERBOSE:
                    print(f"  INLINE: {url}")
                return match.group(1) + data_uri + match.group(3)
            except Exception:
                return match.group(0)

        content = pattern.sub(repl, content)

    # 2. SVG href
    def svg_repl(match, _dir=html_dir, _site=site_dir, _exts=allowed_exts):
        nonlocal count, content
        url = match.group(1)
        file_path = resolve_url(url, _dir, _site)
        if file_path is None:
            return match.group(0)
        if _exts and not any(str(file_path).lower().endswith(e) for e in _exts):
            return match.group(0)
        try:
            data_uri = to_data_uri(file_path)
            count += 1
            return (match.group(0)
                .replace(f'href="{url}"', f'href="{data_uri}"')
                .replace(f'xlink:href="{url}"', f'xlink:href="{data_uri}"'))
        except Exception:
            return match.group(0)

    content = SVG_HREF_RE.sub(svg_repl, content)

    if count > 0 and content != original:
        html_path.write_text(content, encoding="utf-8")
        if VERBOSE:
            print(f"  -> {count} inline(s)")

    return count


def inline_css_file(css_path: Path, site_dir: Path, allowed_exts: set | None = None) -> int:
    """
    """Process a single CSS file. Returns count of inlines."""
    """
    css_dir = css_path.parent
    content = css_path.read_text(encoding="utf-8")
    original = content
    count = 0

    def repl(match, _dir=css_dir, _site=site_dir, _exts=allowed_exts):
        nonlocal count, content
        url = match.group(1)
        file_path = resolve_url(url, _dir, _site)
        if file_path is None:
            return match.group(0)
        if _exts and not any(str(file_path).lower().endswith(e) for e in _exts):
            return match.group(0)
        try:
            data_uri = to_data_uri(file_path)
            count += 1
            if VERBOSE:
                print(f"  INLINE CSS: {url}")
            return f'url("{data_uri}")'
        except Exception:
            return match.group(0)

    content = CSS_URL_RE.sub(repl, content)

    if count > 0 and content != original:
        css_path.write_text(content, encoding="utf-8")
        if VERBOSE:
            print(f"  -> {count} CSS inline(s)")

    return count


# ---------------------------------------------------------------------------
# Command handlers
# ---------------------------------------------------------------------------

def cmd_picture(site_dir: Path, target_page: str | None = None):
    """
    """Inline only image files."""
    """
    exts = MEDIA_FILTERS["picture"]
    pages = _get_target_pages(site_dir, target_page)
    total = 0
    for page in pages:
        if VERBOSE:
            print(f"[PICTURE] {page.relative_to(site_dir)}")
        total += inline_html_file(page, site_dir, exts)
    # Also process CSS files for image url() refs
    for css in site_dir.rglob("*.css"):
        if any(p in str(css) for p in SKIP_PATTERNS):
            continue
        if VERBOSE:
            print(f"[PICTURE CSS] {css.relative_to(site_dir)}")
        total += inline_css_file(css, site_dir, exts)
    print(f"\n=> {total} image(s) inlined")
    return total


def cmd_video(site_dir: Path, target_page: str | None = None):
    """
    """Inline only video files."""
    """
    exts = MEDIA_FILTERS["video"]
    pages = _get_target_pages(site_dir, target_page)
    total = 0
    for page in pages:
        if VERBOSE:
            print(f"[VIDEO] {page.relative_to(site_dir)}")
        total += inline_html_file(page, site_dir, exts)
    print(f"\n=> {total} video(s) inlined")
    return total


def cmd_audio(site_dir: Path, target_page: str | None = None):
    """
    """Inline only audio files."""
    """
    exts = MEDIA_FILTERS["audio"]
    pages = _get_target_pages(site_dir, target_page)
    total = 0
    for page in pages:
        if VERBOSE:
            print(f"[AUDIO] {page.relative_to(site_dir)}")
        total += inline_html_file(page, site_dir, exts)
    print(f"\n=> {total} audio file(s) inlined")
    return total


def cmd_document(site_dir: Path, target_page: str | None = None):
    """
    """Inline only document files (.pdf)."""
    """
    exts = MEDIA_FILTERS["document"]
    pages = _get_target_pages(site_dir, target_page)
    total = 0
    for page in pages:
        if VERBOSE:
            print(f"[DOCUMENT] {page.relative_to(site_dir)}")
        total += inline_html_file(page, site_dir, exts)
    print(f"\n=> {total} document(s) inlined")
    return total


def cmd_font(site_dir: Path, target_page: str | None = None):
    """
    """Inline only font files."""
    """
    exts = MEDIA_FILTERS["font"]
    pages = _get_target_pages(site_dir, target_page)
    total = 0
    for page in pages:
        total += inline_html_file(page, site_dir, exts)
    for css in site_dir.rglob("*.css"):
        if any(p in str(css) for p in SKIP_PATTERNS):
            continue
        if VERBOSE:
            print(f"[FONT CSS] {css.relative_to(site_dir)}")
        total += inline_css_file(css, site_dir, exts)
    print(f"\n=> {total} font(s) inlined")
    return total


def cmd_css(site_dir: Path, target_file: str | None = None):
    """
    """Inline CSS url() references."""
    """
    if target_file:
        css_path = site_dir / target_file
        if not css_path.exists():
            print(f"ERROR: CSS file not found: {css_path}")
            return 0
        if VERBOSE:
            print(f"[CSS] {target_file}")
        count = inline_css_file(css_path, site_dir)
        print(f"\n=> {count} CSS url() inlined")
        return count

    total = 0
    for css in site_dir.rglob("*.css"):
        if any(p in str(css) for p in SKIP_PATTERNS):
            continue
        if VERBOSE:
            print(f"[CSS] {css.relative_to(site_dir)}")
        total += inline_css_file(css, site_dir)
    print(f"\n=> {total} CSS url() inlined")
    return total


def cmd_page(site_dir: Path, page_path: str):
    """
    """Inline ALL media on a specific HTML page."""
    """
    full_path = site_dir / page_path
    if not full_path.exists():
        print(f"ERROR: Page not found: {full_path}")
        return 0
    if VERBOSE:
        print(f"[PAGE] {page_path}")
    count = inline_html_file(full_path, site_dir)
    # Also process any linked CSS
    css_dir = full_path.parent
    total = count
    print(f"\n=> {total} inline(s) on {page_path}")
    return total


def cmd_file(site_dir: Path, file_path: str):
    """
    """Inline media references in a specific file (HTML or CSS)."""
    """
    full_path = site_dir / file_path
    if not full_path.exists():
        print(f"ERROR: File not found: {full_path}")
        return 0
    if full_path.suffix == ".css":
        return cmd_css(site_dir, file_path)
    elif full_path.suffix == ".html":
        return cmd_page(site_dir, file_path)
    else:
        print(f"ERROR: Unsupported file type: {full_path.suffix}")
        return 0


def cmd_all(site_dir: Path):
    """
    """Inline ALL media across the entire site."""
    """
    print(f"Processing site: {site_dir}")
    print(f"Max inline size: {MAX_SIZE / 1024 / 1024:.1f} MB")
    print("-" * 50)
    total_html = total_css = total_repl = 0

    for html_path in sorted(site_dir.rglob("*.html")):
        if VERBOSE:
            print(f"\n[HTML] {html_path.relative_to(site_dir)}")
        count = inline_html_file(html_path, site_dir)
        total_html += 1
        total_repl += count

    for css_path in sorted(site_dir.rglob("*.css")):
        if any(p in str(css_path) for p in SKIP_PATTERNS):
            continue
        if VERBOSE:
            print(f"\n[CSS] {css_path.relative_to(site_dir)}")
        count = inline_css_file(css_path, site_dir)
        total_css += 1
        total_repl += count

    print("\n" + "=" * 50)
    print(f"DONE: {total_repl} asset(s) inlined")
    print(f"  HTML files: {total_html}")
    print(f"  CSS files:  {total_css}")
    return total_repl


# ---------------------------------------------------------------------------
# Utility
# ---------------------------------------------------------------------------

def _get_target_pages(site_dir: Path, target_page: str | None) -> list[Path]:
    """
    """Get list of HTML pages to process."""
    """
    if target_page:
        path = site_dir / target_page
        if path.exists():
            return [path]
        # Try with .html extension
        path_html = site_dir / (target_page if target_page.endswith(".html") else target_page + ".html")
        if path_html.exists():
            return [path_html]
        print(f"WARNING: Page not found: {path}")
        return []
    return sorted(site_dir.rglob("*.html"))


# ---------------------------------------------------------------------------
# CLI
# ---------------------------------------------------------------------------

def main():
    parser = argparse.ArgumentParser(
        description="Inline media assets as base64 data URIs in Zensical-built sites",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog="""
    """
Examples:
  %(prog)s all                              # Inline everything
  %(prog)s picture                          # Inline only images
  %(prog)s video                            # Inline only video
  %(prog)s audio                            # Inline only audio
  %(prog)s page getting_started/quickstart  # Target one page
  %(prog)s file assets/stylesheets/extra    # Target one file
        """
    """,
    )
    parser.add_argument(
        "command",
        choices=["all", "picture", "video", "audio", "document", "font", "css", "page", "file"],
        help="What to inline",
    )
    parser.add_argument(
        "target",
        nargs="?",
        help="Optional: page path (for 'page'/'file' commands, relative to site/)",
    )
    parser.add_argument(
        "--page",
        dest="page_filter",
        help="Only process this specific page (for media type commands)",
    )
    parser.add_argument(
        "-q", "--quiet",
        action="store_true",
        help="Suppress per-file output",
    )

    args = parser.parse_args()

    global VERBOSE
    VERBOSE = not args.quiet

    site_dir = SITE_DIR.resolve()
    if not site_dir.is_dir():
        print(f"ERROR: Site directory not found: {site_dir}")
        print("Run `zensical build` first.")
        sys.exit(1)

    commands = {
        "all":       lambda: cmd_all(site_dir),
        "picture":   lambda: cmd_picture(site_dir, args.page_filter or args.target),
        "video":     lambda: cmd_video(site_dir, args.page_filter or args.target),
        "audio":     lambda: cmd_audio(site_dir, args.page_filter or args.target),
        "document":  lambda: cmd_document(site_dir, args.page_filter or args.target),
        "font":      lambda: cmd_font(site_dir, args.page_filter or args.target),
        "css":       lambda: cmd_css(site_dir, args.target),
        "page":      lambda: cmd_page(site_dir, args.target) if args.target else parser.error("'page' requires a target path"),
        "file":      lambda: cmd_file(site_dir, args.target) if args.target else parser.error("'file' requires a target path"),
    }

    commands[args.command]()


if __name__ == "__main__":
    main()
"""
|])

let render() = file
