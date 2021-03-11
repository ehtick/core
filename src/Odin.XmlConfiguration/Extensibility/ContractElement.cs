﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2021 Bad Echo LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using BadEcho.Odin.Extensibility.Configuration;

namespace BadEcho.Odin.XmlConfiguration.Extensibility
{
    /// <summary>
    /// Provides a configuration element for a contract being segmented by one or more call-routable plugins.
    /// </summary>
    internal sealed class ContractElement : NamedConfigurationElement, IContractConfiguration
    {
        private static readonly Lazy<ConfigurationPropertyCollection> _Properties
            = new(InitializeProperties, LazyThreadSafetyMode.PublicationOnly);

        IEnumerable<IRoutablePluginConfiguration> IContractConfiguration.RoutablePlugins 
            => RoutablePlugins;

        /// <summary>
        /// Gets the collection of call-routable plugins that segment the contract represented by this element.
        /// </summary>
        public GuidElementCollection<RoutablePluginElement> RoutablePlugins
            => (GuidElementCollection<RoutablePluginElement>) base[RoutablePluginChildrenSchema];

        /// <summary>
        /// Gets the schema name for the child collection element containing all of the call-routable plugins for
        /// the contract represented by this element.
        /// </summary>
        internal static string RoutablePluginChildrenSchema
            = "routablePlugins";

        /// <inheritdoc/>
        protected override ConfigurationPropertyCollection Properties
            => _Properties.Value;

        private static ConfigurationPropertyCollection InitializeProperties()
            => new()
               {
                   new ConfigurationProperty(RoutablePluginChildrenSchema,
                                             typeof(GuidElementCollection<RoutablePluginElement>),
                                             null,
                                             null,
                                             new RoutablePluginsValidator(),
                                             ConfigurationPropertyOptions.IsRequired),
                   CreateNameProperty()
               };
    }
}