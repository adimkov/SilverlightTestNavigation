namespace Microsoft.Practices.Prism.Regions
{
    using System;
    using System.Windows.Browser;

    /// <summary>
    /// Provide access to browser's navigation bar.
    /// </summary>
    public class BrowserNavigationBar : INavigationBar
    {
        /// <summary>
        /// Fragment separator.
        /// </summary>
        public const string FragmgentSeparator = "#";

        /// <summary>
        /// Template of fragments path.
        /// </summary>
        public const string FragmentTemplate = "/{0}";

        /// <summary>
        /// Adds fragment to url.
        /// </summary>
        /// <param name="fragment">Fragment to add.</param>
        public void AddFragment(string fragment)
        {
            var currentUri = GetCurrentUrl();
            currentUri += FragmentTemplate.FormatString(fragment);
            UpdateUri(currentUri);
        }

        /// <summary>
        /// Clear fragments in url.
        /// </summary>
        public void ClearFragments()
        {
            var currentUri = GetCurrentUrl();
            currentUri = currentUri.Remove(currentUri.IndexOf(FragmgentSeparator)) + FragmgentSeparator;
            UpdateUri(currentUri);
        }

        /// <summary>
        /// Gets current url as <see cref="string"/> with fragment.
        /// </summary>
        /// <returns>The builder of <see cref="Uri"/>.</returns>
        private string GetCurrentUrl()
        {
            var uri = HtmlPage.Document.DocumentUri;
            var uriWithFragment = uri.AbsoluteUri;
            if (uri.Fragment == string.Empty)
            {
                uriWithFragment = uri.AbsoluteUri + FragmgentSeparator;
            }

            return uriWithFragment;
        }

        /// <summary>
        /// Update browser uri.
        /// </summary>
        /// <param name="uri">New uri for update.</param>
        private void UpdateUri(string uri)
        {
            HtmlPage.Window.Navigate(new Uri(uri));
        }
    }
}