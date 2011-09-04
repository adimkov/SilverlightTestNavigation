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
            var currentUri = this.GetCurrentUrl();
            currentUri += FragmentTemplate.FormatString(fragment);
            UpdateUri(currentUri);
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
            var currentUri = this.GetCurrentUrl();
            currentUri = currentUri.Replace(FragmentTemplate.FormatString(oldFragment), newFragment);
            UpdateUri(currentUri);
        }

        /// <summary>
        /// Clear fragments in url.
        /// </summary>
        public void ClearFragments()
        {
            var currentUri = this.GetCurrentUrl();
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
        /// Removes the fragment separator from URI.
        /// </summary>
        /// <param name="uriFragment">The URI fragment.</param>
        /// <returns>Fragment without separator.</returns>
        private string RemoveFragmentSeparator(string uriFragment)
        {
            return uriFragment.Replace(FragmgentSeparator, string.Empty);
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