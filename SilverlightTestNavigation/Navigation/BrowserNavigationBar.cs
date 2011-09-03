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
        public const string FragmentTemplate = "{0}/";

        /// <summary>
        /// Template of fragment path to add.
        /// </summary>
        public const string AddFragmentTemplate = "{0}/{1}";

        /// <summary>
        /// Adds fragment to url.
        /// </summary>
        /// <param name="fragment">Fragment to add.</param>
        public void AddFragment(string fragment)
        {
            var currentUri = GetUrlBuilder();
            currentUri.Fragment = AddFragmentTemplate.FormatString(currentUri.Fragment, fragment);
            UpdateUri(currentUri.Uri);
        }

        /// <summary>
        /// Remove fragment from url.
        /// </summary>
        /// <param name="fragment">Fragment to remove.</param>
        public void RemoveFragment(string fragment)
        {
            ReplaceFragment(fragment, string.Empty);
        }

        /// <summary>
        /// Replace old fragment by new one.
        /// </summary>
        /// <param name="oldFragment">Fragment that should by replaced.</param>
        /// <param name="newFragment">New fragment.</param>
        public void ReplaceFragment(string oldFragment, string newFragment)
        {
            var currentUri = GetUrlBuilder();
            currentUri.Fragment = currentUri.Fragment.Replace(FragmentTemplate.FormatString(oldFragment), newFragment);
            UpdateUri(currentUri.Uri);
        }

        /// <summary>
        /// Clear fragments in url.
        /// </summary>
        public void ClearFragments()
        {
            var currentUri = GetUrlBuilder();
            if (currentUri.Fragment != string.Empty)
            {
                currentUri.Fragment = string.Empty;
                UpdateUri(currentUri.Uri);
            }
        }

        /// <summary>
        /// Gets current url builder.
        /// </summary>
        /// <returns>The builder of <see cref="Uri"/>.</returns>
        private UriBuilder GetUrlBuilder()
        {
            var uriBuilder   = new UriBuilder(HtmlPage.Document.DocumentUri);
            return uriBuilder;
        }

        /// <summary>
        /// Update browser uri.
        /// </summary>
        /// <param name="uri">New uri for update.</param>
        private void UpdateUri(Uri uri)
        {
            HtmlPage.Window.Navigate(uri);
        }
    }
}