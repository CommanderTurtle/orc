module ConvertedFiles.Src.Utils.PdfExportTs

let file = """/* ═══════════════════════════════════════════════════════════
   PDF Export Utility — Generates a formatted summary document
   Uses window.print() with structured data injection
   ═══════════════════════════════════════════════════════════ */

export interface PolicyData {
  userName: string;
  userId: string;
  cashValue: number;
  deathBenefit: number;
  annualPremium: number;
  premiumPaid: number;
  policyYear: number;
  totalYears: number;
  growthRate: number;
  generatedAt: string;
}

const DEFAULT_DATA: PolicyData = {
  userName: 'Policyholder',
  userId: 'DEMO',
  cashValue: 47250,
  deathBenefit: 500000,
  annualPremium: 3420,
  premiumPaid: 2310,
  policyYear: 8,
  totalYears: 30,
  growthRate: 4.2,
  generatedAt: new Date().toLocaleDateString('en-US', { year: 'numeric', month: 'long', day: 'numeric' }),
};

function formatCurrency(n: number): string {
  return new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD', minimumFractionDigits: 0, maximumFractionDigits: 0 }).format(n);
}

function formatPercent(n: number): string {
  return `${n.toFixed(1)}%`;
}

/**
 * Generates a styled HTML document for printing/PDF export.
 * Call window.print() after injecting this into a hidden iframe.
 */
export function generatePolicyPDF(data: Partial<PolicyData> = {}): void {
  const d = { ...DEFAULT_DATA, ...data };

  const html = `
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Turtle Protect — Policy Summary</title>
  <style>
    @page { size: letter; margin: 0.75in; }
    * { margin: 0; padding: 0; box-sizing: border-box; }
    body { font-family: 'Georgia', 'Times New Roman', serif; color: #1A1A1A; line-height: 1.6; background: #fff; }
    .header { text-align: center; border-bottom: 3px solid #2D6A4F; padding-bottom: 1.5rem; margin-bottom: 2rem; }
    .header h1 { font-family: Georgia, serif; font-size: 1.75rem; color: #1B4332; letter-spacing: -0.02em; }
    .header .subtitle { font-family: system-ui, sans-serif; font-size: 0.75rem; color: #8A8A8A; margin-top: 0.5rem; text-transform: uppercase; letter-spacing: 0.1em; }
    .meta { display: flex; justify-content: space-between; font-family: system-ui, sans-serif; font-size: 0.8125rem; color: #8A8A8A; margin-bottom: 2rem; padding-bottom: 1rem; border-bottom: 1px solid #F0EDE8; }
    .grid { display: grid; grid-template-columns: 1fr 1fr; gap: 1rem; margin-bottom: 2rem; }
    .card { border: 1px solid #F0EDE8; border-radius: 12px; padding: 1.25rem; background: #FAF6F1; }
    .card.label { font-family: system-ui, sans-serif; font-size: 0.6875rem; text-transform: uppercase; letter-spacing: 0.08em; color: #8A8A8A; margin-bottom: 0.25rem; }
    .card.value { font-family: 'Courier New', monospace; font-size: 1.25rem; font-weight: 700; color: #1A1A1A; }
    .card.sublabel { font-family: system-ui, sans-serif; font-size: 0.75rem; color: #8A8A8A; margin-top: 0.25rem; }
    .progress-section { margin-bottom: 2rem; }
    .progress-section h2 { font-family: Georgia, serif; font-size: 1.125rem; color: #1B4332; margin-bottom: 1rem; }
    .bar-bg { height: 24px; background: #F0EDE8; border-radius: 12px; overflow: hidden; margin-bottom: 0.75rem; }
    .bar-fill { height: 100%; border-radius: 12px; background: linear-gradient(90deg, #2D6A4F, #2A9D8F); display: flex; align-items: center; padding-left: 12px; color: white; font-family: system-ui, sans-serif; font-size: 0.6875rem; font-weight: 600; }
    .disclaimer { font-family: system-ui, sans-serif; font-size: 0.6875rem; color: #8A8A8A; border-top: 1px solid #F0EDE8; padding-top: 1rem; margin-top: 2rem; line-height: 1.5; }
    .footer { text-align: center; font-family: system-ui, sans-serif; font-size: 0.6875rem; color: #8A8A8A; margin-top: 2rem; padding-top: 1rem; border-top: 1px solid #F0EDE8; }
    @media print { body { -webkit-print-color-adjust: exact; print-color-adjust: exact; } }
  </style>
</head>
<body>
  <div class="header">
    <h1>Turtle Protect</h1>
    <p class="subtitle">Policy Summary Report</p>
  </div>

  <div class="meta">
    <span>Prepared for: <strong style="color:#1A1A1A">${d.userName}</strong> (${d.userId})</span>
    <span>Generated: ${d.generatedAt}</span>
  </div>

  <div class="grid">
    <div class="card">
      <div class="label">Cash Value</div>
      <div class="value">${formatCurrency(d.cashValue)}</div>
      <div class="sublabel">Growing at ${d.growthRate}% annually &middot; Tax-deferred</div>
    </div>
    <div class="card">
      <div class="label">Death Benefit</div>
      <div class="value">${formatCurrency(d.deathBenefit)}</div>
      <div class="sublabel">Income tax-free to beneficiaries</div>
    </div>
    <div class="card">
      <div class="label">Annual Premium</div>
      <div class="value">${formatCurrency(d.annualPremium)}</div>
      <div class="sublabel">\$${formatCurrency(d.premiumPaid)} paid this year</div>
    </div>
    <div class="card">
      <div class="label">Policy Progress</div>
      <div class="value">Year ${d.policyYear} of ${d.totalYears}</div>
      <div class="sublabel">${formatPercent((d.policyYear / d.totalYears) * 100)} complete</div>
    </div>
  </div>

  <div class="progress-section">
    <h2>Premium Payment Progress</h2>
    <div class="bar-bg">
      <div class="bar-fill" style="width: ${Math.round((d.premiumPaid / d.annualPremium) * 100)}%">
        ${formatPercent((d.premiumPaid / d.annualPremium) * 100)} paid
      </div>
    </div>
    <div class="bar-bg">
      <div class="bar-fill" style="width: ${Math.round((d.policyYear / d.totalYears) * 100)}%; background: linear-gradient(90deg, #D4A574, #2D6A4F)">
        ${formatPercent((d.policyYear / d.totalYears) * 100)} policy complete
      </div>
    </div>
  </div>

  <div class="disclaimer">
    <strong>Important:</strong> This is an example policy summary for illustrative purposes only. All values shown are projections based on typical policy performance and do not represent guaranteed outcomes. Actual policy values, premiums, and benefits will vary based on the specific terms of your insurance contract, carrier performance, and market conditions. Contact your licensed Turtle Protect agent at (352) 428-4009 for your actual policy details.
  </div>

  <div class="footer">
    Turtle Protect, Inc. &middot; Florida &middot; turtleprotect.org &middot; (352) 428-4009<br>
    This document was generated electronically and is valid without signature.
  </div>
</body>
</html>`;

  // Inject into hidden iframe and print
  const iframe = document.createElement('iframe');
  iframe.style.cssText = 'position:fixed;top:-9999px;left:-9999px;width:1px;height:1px;visibility:hidden;';
  document.body.appendChild(iframe);
  const doc = iframe.contentDocument || iframe.contentWindow?.document;
  if (doc) {
    doc.open();
    doc.write(html);
    doc.close();
    setTimeout(() => {
      iframe.contentWindow?.print();
      setTimeout(() => document.body.removeChild(iframe), 1000);
    }, 300);
  }
}
"""

let render() = file
