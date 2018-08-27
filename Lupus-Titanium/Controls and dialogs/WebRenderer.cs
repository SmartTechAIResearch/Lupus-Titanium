/*
 * 2015 Sizing Servers Lab, affiliated with IT bachelor degree NMCT
 * University College of West-Flanders, Department GKG (www.sizingservers.be, www.nmct.be, www.howest.be/en)
 * 
 * Author(s):
 *    Dieter Vandroemme
 */

using mshtml;
using System.Threading;
using System.Windows.Forms;

namespace Lupus_Titanium {
    /// <summary>
    /// Renders a webpage's content without executing scripts or following hrefs.
    /// </summary>
    public class WebRenderer : UserControl {
        private WebBrowser webBrowser;
        private HTMLBody _body;

        /// <summary>
        /// Renders a webpage's content without executing scripts or following hrefs.
        /// </summary>
        public WebRenderer() {
            webBrowser = new WebBrowser();
            SuspendLayout();

            webBrowser.AllowNavigation = false;
            webBrowser.AllowWebBrowserDrop = false;
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.IsWebBrowserContextMenuEnabled = false;
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.WebBrowserShortcutsEnabled = false;

            Controls.Add(this.webBrowser);
            Name = "Browser";
            ResumeLayout(false);
        }
        /// <summary>
        /// Renders a webpage's content without executing scripts or following hrefs.
        /// </summary>
        /// <param name="html"></param>
        public void Render(string html) {
            this.Cursor = Cursors.WaitCursor;
            Init(); // Initiate by navigating to about:blank if _body == null.
            _body.innerHTML = html;
            StripDOM(); // Empty a hrefs, scripts and inputs.
            this.Cursor = Cursors.Default;
        }

        private void Init() {
            if (_body == null) {
                webBrowser.DocumentCompleted += BrowserDocumentComplete;

                webBrowser.Navigate("about:blank");
                while (_body == null) {
                    Application.DoEvents();
                    Thread.Sleep(0);
                }
            }
        }

        private void BrowserDocumentComplete(object sender, WebBrowserDocumentCompletedEventArgs e) {
            webBrowser.DocumentCompleted -= BrowserDocumentComplete;

            var document = (HTMLDocument)this.webBrowser.Document.DomDocument;
            _body = (HTMLBody)document.body;
        }

        private void StripDOM() {
            IHTMLElementCollection anchors = _body.getElementsByTagName("A");
            foreach (IHTMLElement element in anchors)
                try {
                    var anchor = (IHTMLAnchorElement)element;
                    if (anchor.href != null) anchor.href = string.Empty;
                    if (anchor.target != null) anchor.target = string.Empty;
                } catch {
                    //Ignore.
                }

            IHTMLElementCollection scripts = _body.getElementsByTagName("SCRIPT");
            foreach (IHTMLElement element in scripts)
                try {
                    var script = (IHTMLScriptElement)element;
                    if (script.src != null) script.src = string.Empty;
                    if (script.text != null) script.text = string.Empty;
                } catch {
                    //Ignore.
                }

            IHTMLElementCollection forms = _body.getElementsByTagName("FORM");
            foreach (IHTMLElement element in forms)
                try {
                    var form = (IHTMLFormElement)element;
                    if (form.action != null) form.action = string.Empty;
                    if (form.onsubmit != null) form.onsubmit = string.Empty;
                    if (form.onreset != null) form.onreset = string.Empty;
                } catch {
                    //Ignore.
                }
        }
    }
}
