module ConvertedFiles.Src.Utils.EmailUtilsTs

let file = """export interface MailOptions {
  to: string;
  subject: string;
  body: string;
}

export async function sendPrefilledEmail(opts: MailOptions): Promise<void> {
  const { to, subject, body } = opts;

  // 1. Copy body to clipboard
  await navigator.clipboard.writeText(body);

  // 2. Encode subject + body for mailto
  const subjectEncoded = encodeURIComponent(subject);
  const bodyEncoded = encodeURIComponent(body);

  // 3. Build mailto URL
  const mailto = `mailto:${to}?subject=${subjectEncoded}&body=${bodyEncoded}`;

  // 4. Trigger mail client
  window.location.href = mailto;
}
"""

let render() = file
