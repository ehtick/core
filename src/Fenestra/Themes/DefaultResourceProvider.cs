﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2021 Bad Echo LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Composition;

namespace BadEcho.Fenestra.Themes
{
    /// <summary>
    /// Provides access to Fenestra framework resources from a WPF application.
    /// </summary>
    [Export(typeof(DefaultResourceProvider))]
    internal sealed class DefaultResourceProvider : IResourceProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultResourceProvider"/> class.
        /// </summary>
        public DefaultResourceProvider()
        {
            ResourceUri = PackUri.FromRelativePath<DefaultResourceProvider>("Root.xaml");
        }

        /// <inheritdoc/>
        public Uri ResourceUri 
        { get; }
    }
}