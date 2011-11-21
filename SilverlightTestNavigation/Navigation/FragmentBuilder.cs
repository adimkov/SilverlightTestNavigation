// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FragmentBuilder.cs" author="Anton Dimkov">
//   Copyright (c) Anton Dimkov 2011. All rights reserved.
// </copyright>
// <summary>
//  Builds the fragments.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Practices.Prism.Regions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Builds the fragments.
    /// </summary>
    public class FragmentBuilder : IFragmentBuilder
    {
        /// <summary>
        /// The navigation depth.
        /// </summary>
        private readonly IList<Tuple<string, string>> _navigationDepth = new List<Tuple<string, string>>(2);

        /// <summary>
        /// Actives the view in region.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="region">The region.</param>
        public void ActiveViewInRegion(string view, string region)
        {
            if (!_navigationDepth.Any(x => x.Item1 == region && x.Item2 == view))
            {
                _navigationDepth.Add(Tuple.Create(region, view));
            }
        }

        /// <summary>
        /// Deactivates the region.
        /// </summary>
        /// <param name="region">The region.</param>
        public void DeactivateRegion(string region)
        {
            var deacivatedRegion = _navigationDepth.SingleOrDefault(x => x.Item1 == region);
            if (deacivatedRegion != null)
            {
                var deacivatedIndex = _navigationDepth.IndexOf(deacivatedRegion);

                for (int regionIndex = _navigationDepth.Count - 1; regionIndex >= deacivatedIndex; regionIndex--)
                {
                    _navigationDepth.RemoveAt(regionIndex);
                }
            }
        }

        /// <summary>
        /// Builds the fragments.
        /// </summary>
        /// <returns>Collection of fragments.</returns>
        public IEnumerable<string> BuildFragments()
        {
            return _navigationDepth.Select(x => x.Item2)
                .ToArray();
        }
    }
}