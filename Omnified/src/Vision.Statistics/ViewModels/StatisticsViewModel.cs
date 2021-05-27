﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2021 Bad Echo LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using BadEcho.Fenestra.ViewModels;
using BadEcho.Odin;
using BadEcho.Omnified.Vision.Statistics.Properties;

namespace BadEcho.Omnified.Vision.Statistics.ViewModels
{
    /// <summary>
    /// Provides a view model that displays statistics exported from an Omnified game.
    /// </summary>
    internal sealed class StatisticsViewModel : CollectionViewModel<Statistic,IStatisticViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsViewModel"/> class.
        /// </summary>
        /// <param name="options">
        /// A <see cref="CollectionViewModelOptions"/> instance that configures this collection of statistic view model.
        /// </param>
        public StatisticsViewModel(CollectionViewModelOptions options) 
            : base(options)
        { }
        
        /// <inheritdoc/>
        public override IStatisticViewModel CreateChild(Statistic model)
        {
            Require.NotNull(model, nameof(model));

            return model switch
            {
                WholeStatistic whole => new WholeStatisticViewModel(whole),
                FractionalStatistic fractional => new FractionalStatisticViewModel(fractional),
                CoordinateStatistic coordinate => new CoordinateStatisticViewModel(coordinate),
                _ => throw new ArgumentException(Strings.StatisticTypeUnsupportedViewModel, nameof(model))
            };
        }

        /// <inheritdoc/>
        public override void OnChangeCompleted()
        { }
    }
}
