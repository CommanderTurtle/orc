module Muz.Source.Src.WorkbenchBridgeJs

let file = """import { normalizeProject } from 'muzstatic/project';
import { resolveProjectLink, resolveGist, embeddedFragment } from 'muzstatic/links';
import { toWorkbench } from 'muzstatic/workbench-project';
import { writeHandoff, readHandoff } from 'muzstatic/project-transfer';

let inherited, inheritedId, callbacks;
async function resolve(input, signal) {
  const gist = /^(?:https:\/\/gist\.github\.com\/[^/]+\/)?[a-f\d]{32,40}(?:\/[a-f\d]{40})?\/?$/i.test(input.trim());
  const result = gist ? await resolveGist(input) : (await resolveProjectLink(input, fetch, signal)).project;
  signal?.throwIfAborted();
  return toWorkbench(result);
}
export async function incomingMuzstatic() {
  const url = new URL(location.href), input = url.searchParams.get('source') || url.searchParams.get('url') || url.hash;
  if (!input) return;
  inherited = input.startsWith('#handoff:') ? toWorkbench(await readHandoff(input)) : await resolve(input);
  return inherited;
}
async function snapshot() {
  const project = await callbacks.snapshot();
  if (inherited?.studio && inheritedId === callbacks.projectId() && project.entry === inherited.entry && project.files[inherited.studio.generated] === inherited.files[inherited.studio.generated]) project.studio = inherited.studio;
  return normalizeProject(project);
}
function studioURL(fragment) { const url = new URL('../', document.baseURI); url.search = ''; url.hash = fragment; return url.href; }
export function installMuzstatic(api) {
  callbacks = api; if (inherited) inheritedId = api.projectId();
  if (inheritedId && location.hash.startsWith('#handoff:')) { const url = new URL(location.href); url.hash = ''; history.replaceState(null, '', url); }
  const parent = document.querySelector('.project-actions'); if (!parent) return;
  const notice = document.createElement('span'); notice.setAttribute('role', 'status'); notice.style.cssText = 'font-size:11px;max-width:210px;overflow-wrap:anywhere';
  const button = (label, action) => {
    const el = document.createElement('button'); el.textContent = label;
    el.onclick = async () => { el.disabled = true; try { await action(); } catch (error) { notice.textContent = error.message; notice.title = error.message; } finally { el.disabled = false; } };
    parent.append(el); return el;
  };
  const dialog = document.createElement('dialog'); dialog.setAttribute('aria-label', 'Open muzstatic link');
  dialog.innerHTML = '<form><h2>Open link</h2><p>Raw .muz / project JSON, gist, ln.kr or superlink.</p><label>Link <input name="link" type="text" required autocomplete="off" style="width:100%"></label><p role="status"></p><button type="submit">Open</button> <button type="button">Close</button></form>';
  document.body.append(dialog);
  const form = dialog.querySelector('form'), state = dialog.querySelector('[role=status]');
  let opening, committing = false;
  dialog.addEventListener('close', () => opening?.abort());
  dialog.addEventListener('cancel', event => { if (committing) event.preventDefault(); });
  form.onsubmit = async event => {
    event.preventDefault(); const submit = form.querySelector('[type=submit]'); submit.disabled = true; state.textContent = 'Reading link…';
    opening = new AbortController();
    try { const candidate = await resolve(form.elements.link.value, opening.signal); opening.signal.throwIfAborted(); committing = true; form.querySelector('[type=button]').disabled = true; if (await callbacks.importProject(candidate)) { inherited = candidate; inheritedId = callbacks.projectId(); dialog.close(); notice.textContent = 'Project loaded.'; } else state.textContent = 'Current workspace preserved.'; }
    catch (error) { state.textContent = error.message; } finally { submit.disabled = false; committing = false; form.querySelector('[type=button]').disabled = false; opening = undefined; }
  };
  form.querySelector('[type=button]').onclick = () => dialog.close();
  button('Open link', () => { state.textContent = ''; dialog.showModal(); form.elements.link.focus(); });
  const share = document.createElement('dialog'); share.setAttribute('aria-label', 'Share muzstatic project');
  share.innerHTML = '<h2>Project link</h2><textarea readonly aria-label="Project link" rows="5" style="width:100%"></textarea><p role="status"></p><button>Close</button>';
  document.body.append(share); share.querySelector('button').onclick = () => share.close();
  button('Copy link', async () => {
    const url = studioURL(embeddedFragment(await snapshot())), field = share.querySelector('textarea'); field.value = url; share.showModal();
    try { await navigator.clipboard.writeText(url); share.querySelector('p').textContent = 'Copied.'; }
    catch { field.select(); share.querySelector('p').textContent = 'Select and copy the project link.'; }
  });
  button('Studio ↗', async () => { location.assign(studioURL(await writeHandoff(await snapshot()))); });
  parent.append(notice);
}
"""

let render() = file
