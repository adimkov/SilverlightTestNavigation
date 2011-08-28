namespace Microsoft.Practices.Prism.Regions
{
    /// <summary>
    /// Contract to navigation bar.
    /// </summary>
    public interface INavigationBar
    {
        /// <summary>
        /// Adds fragment to url.
        /// </summary>
        /// <param name="fragment">Fragment to add.</param>
        void AddFragment(string fragment);

        /// <summary>
        /// Remove fragment from url.
        /// </summary>
        /// <param name="fragment">Fragment to remove.</param>
        void RemoveFragment(string fragment);

        /// <summary>
        /// Replace old fragment by new one.
        /// </summary>
        /// <param name="oldFragment">Fragment that should by replaced.</param>
        /// <param name="newFragment">New fragment.</param>
        void ReplaceFragment(string oldFragment, string newFragment);

        /// <summary>
        /// Clear fragments in url.
        /// </summary>
        void ClearFragments();
    }
}