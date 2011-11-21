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
        /// Clear fragments in url.
        /// </summary>
        void ClearFragments();
    }
}