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

using System;
using System.Collections.Generic;
using BadEcho.Fenestra;
using BadEcho.Fenestra.ViewModels;

namespace BadEcho.Omnified.Vision.Apocalypse.ViewModels
{
    /// <summary>
    /// Defines a view model that facilitates the display of an event generated by the Apocalypse system in an Omnified game.
    /// </summary>
    public interface IApocalypseEventViewModel : IViewModel, IModelProvider<ApocalypseEvent>
    {
        /// <summary>
        /// Gets or sets the message describing the nature of the bound Apocalypse event.
        /// </summary>
        string EffectMessage { get; set; }

        /// <summary>
        /// Gets or sets the maximum width constraint of the element responsible for displaying the bound
        /// Apocalypse event's effect message.
        /// </summary>
        double EffectMessageMaxWidth { get; set; }

        /// <summary>
        /// Gets or sets the date and time at which the bound Apocalypse event occurred.
        /// </summary>
        DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the data composing the sound to play upon the occurrence of the bound Apocalypse event.
        /// </summary>
        IEnumerable<byte> EffectSound { get; set; }
    }
}
