/*
 * Copyright 2015 (c) Sizing Servers Lab
 * University College of West-Flanders, Department GKG
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using FastColoredTextBoxNS;

namespace Lupus_Titanium {
    /// <summary>
    /// To format content with content type html, javascript, json and xml.
    /// </summary>
    internal static class TextualContentFormatter {
        /// <summary>
        /// Formats the given text and put it on the FastColoredTextBox.
        /// if contentTypeHeaderValue != html, javascript, json or xml; formatting will not take place.
        /// </summary>
        /// <param name="fctb"></param>
        /// <param name="text"></param>
        /// <param name="contentTypeHeaderValue"></param>
        /// <returns>True if the text was set. Only set when it is another string then before.</returns>
        public static void Format(FastColoredTextBox fctb, string text, string contentTypeHeaderValue = "") {
            if (string.IsNullOrEmpty(text)) {
                fctb.Language = Language.Custom;
            } else {
                if (contentTypeHeaderValue == null) contentTypeHeaderValue = string.Empty;

                contentTypeHeaderValue = contentTypeHeaderValue.ToLowerInvariant();
                if (contentTypeHeaderValue.Contains("html")) {
                    fctb.Language = Language.HTML;
                    text = text.Replace("><", ">\n<");
                } else if (contentTypeHeaderValue.Contains("javascript")) {
                    fctb.Language = Language.JS;
                    text = text.Replace("{", "{\n").Replace("}", "\n}\n").Replace(";", ";\n");
                } else if (contentTypeHeaderValue.Contains("json")) {
                    fctb.Language = Language.JS;
                    text = text.Replace(",", ",\n");
                } else if (contentTypeHeaderValue.Contains("xml")) {
                    fctb.Language = Language.XML;
                    text = text.Replace("><", ">\n<");
                } else {
                    fctb.Language = Language.Custom;
                }
            }

            if (fctb.Text != text) {
                fctb.Text = text;

                fctb.SelectAll();
                fctb.DoAutoIndent();
                fctb.Selection = new Range(fctb, 0, 0, 0, 0);
            }
        }
    }
}
