﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2021 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under a
//		Creative Commons Attribution-NonCommercial 4.0 International License.
//
//		See accompanying file LICENSE.md or a copy at:
//		http://creativecommons.org/licenses/by-nc/4.0/
// </copyright>
//-----------------------------------------------------------------------

namespace BadEcho.Omnified.Vision.Statistics
{
    /// <summary>
    /// Defines an individual statistic exported from an Omnified game.
    /// </summary>
    public interface IStatistic
    {
        /// <summary>
        /// Gets or sets the display name of the statistic.
        /// </summary>
        string Name { get; }
    }
}