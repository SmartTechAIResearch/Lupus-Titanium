/*
 * 2015 Sizing Servers Lab, affiliated with IT bachelor degree NMCT
 * University College of West-Flanders, Department GKG (www.sizingservers.be, www.nmct.be, www.howest.be/en)
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using FastColoredTextBoxNS;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Collections.Concurrent;

namespace Lupus_Titanium {
    /// <summary>
    /// To format content with content type html, javascript, json and xml.
    /// </summary>
    internal static class TextualContentFormatter {
        private static event EventHandler<FormattedEventArgs> Formatted;

        private static ConcurrentDictionary<FastColoredTextBox, Task> _tasks = new ConcurrentDictionary<FastColoredTextBox, Task>();

        private static CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        static TextualContentFormatter() {
            Formatted += TextualContentFormatter_Formatted;
        }

        private static void TextualContentFormatter_Formatted(object sender, FormattedEventArgs e) {
            SynchronizationContextWrapper.SynchronizationContext.Send((state) => {
                e.FCTB.BackColor = System.Drawing.Color.White;
                if (e.FCTB.Text != e.Text) {
                    if (e.ContentTypeHeaderValue.Contains("html")) e.FCTB.Language = Language.HTML;
                    else if (e.ContentTypeHeaderValue.Contains("javascript")) e.FCTB.Language = Language.JS;
                    else if (e.ContentTypeHeaderValue.Contains("json")) e.FCTB.Language = Language.JS;
                    else if (e.ContentTypeHeaderValue.Contains("xml")) e.FCTB.Language = Language.XML;
                    else e.FCTB.Language = Language.Custom;

                    e.FCTB.Text = e.Text;
                    e.FCTB.Selection = new Range(e.FCTB, 0, 0, 0, 0);
                }
            }, null);
        }

        /// <summary>
        /// Formats the given text and put it on the FastColoredTextBox.
        /// if contentTypeHeaderValue != html, javascript, json or xml; formatting will not take place.
        /// </summary>
        /// <param name="fctb"></param>
        /// <param name="text"></param>
        /// <param name="contentTypeHeaderValue"></param>
        /// <returns>True if the text was set. Only set when it is another string then before.</returns>
        public static void Format(FastColoredTextBox fctb, string text, string contentTypeHeaderValue = "") {
            fctb.BackColor = System.Drawing.Color.White;

            Task task;
            if (_tasks.TryRemove(fctb, out task))
                try {
                    task.Dispose();
                }
                catch {
                    //Don't care.
                }

            if (string.IsNullOrEmpty(text)) {
                fctb.Language = Language.Custom;
            }
            else {
                if (contentTypeHeaderValue == null) contentTypeHeaderValue = string.Empty;

                contentTypeHeaderValue = contentTypeHeaderValue.ToLowerInvariant();

                task = new Task(() => {
                    if (contentTypeHeaderValue == null) contentTypeHeaderValue = string.Empty;

                    contentTypeHeaderValue = contentTypeHeaderValue.ToLowerInvariant();
                    if (contentTypeHeaderValue.Contains("html")) text = text.Replace("><", ">\n<");
                    else if (contentTypeHeaderValue.Contains("javascript")) text = text.Replace("{", "{\n").Replace("}", "\n}\n").Replace(";", ";\n");
                    else if (contentTypeHeaderValue.Contains("json")) text = text.Replace(",", ",\n");
                    else if (contentTypeHeaderValue.Contains("xml")) text = text.Replace("><", ">\n<");

                    Formatted?.Invoke(null, new FormattedEventArgs(fctb, text, contentTypeHeaderValue));

                });

                _tasks.TryAdd(fctb, task);

                fctb.BackColor = System.Drawing.Color.LightGray;

                task.Start();                
            }
        }
        private class FormattedEventArgs : EventArgs {
            public FastColoredTextBox FCTB { get; private set; }
            public string Text { get; private set; }
            public string ContentTypeHeaderValue { get; private set; }
            public FormattedEventArgs(FastColoredTextBox fctb, string text, string contentTypeHeaderValue) {
                FCTB = fctb;
                Text = text;
                ContentTypeHeaderValue = contentTypeHeaderValue;
            }
        }
    }
}
