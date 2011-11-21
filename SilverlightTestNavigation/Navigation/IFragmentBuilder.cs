// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFragmentBuilder.cs" author="Anton Dimkov">
//   Copyright (c) Anton Dimkov 2011. All rights reserved.
// </copyright>
// <summary>
//  Interface to build the path.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Practices.Prism.Regions
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface to build the path.
    /// </summary>
    public interface IFragmentBuilder
    {
        /// <summary>
        /// Actives the view in region.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="region">The region.</param>
        void ActiveViewInRegion(string view, string region);

        /// <summary>
        /// Deactivates the region.
        /// </summary>
        /// <param name="region">The region.</param>
        void DeactivateRegion(string region);

        /// <summary>
        /// Builds the fragments.
        /// </summary>
        /// <returns>Collection of fragments.</returns>
        IEnumerable<string> BuildFragments();
    }
}