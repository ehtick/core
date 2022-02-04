﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2022 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under a
//		Creative Commons Attribution-NonCommercial 4.0 International License.
//
//		See accompanying file LICENSE.md or a copy at:
//		http://creativecommons.org/licenses/by-nc/4.0/
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.Reflection;
using System.Windows;
using BadEcho.Odin;
using BadEcho.Odin.Extensions;

namespace BadEcho.Fenestra.Markup;

/// <summary>
/// Provides a resource key used to define and statically locate Fenestra resources.
/// </summary>
/// <remarks>
/// <para>
/// For resources exported by Fenestra applications and libraries, I wanted a convenient way to build static collections
/// of keys that could be referenced cross-assembly using static markup extensions, while still providing a level of type safety
/// whenever resources need to be referenced via dynamic references. I found the <see cref="ComponentResourceKey"/> type to be a
/// bit too bulky to use directly, and having our own type allows us to expand functionality later according to our whims.
/// </para>
/// <para>
/// The manner in which Fenestra resource keys are defined and get used was influenced and inspired by the manner in which WPF
/// organizes its own <see cref="SystemColors"/> resource keys.
/// </para>
/// </remarks>
[TypeConverter(typeof(FenestraKeyConverter))]
public sealed class FenestraKey : ResourceKey
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FenestraKey"/> class.
    /// </summary>
    /// <param name="providerType">The type that is registering the resource.</param>
    /// <param name="name">The uniquely identifying name of the resource.</param>
    internal FenestraKey(Type providerType, string name)
    {
        Require.NotNull(providerType, nameof(providerType));

        ProviderType = providerType;
        Name = name;
    }

    /// <inheritdoc/>
    public override Assembly Assembly
        => ProviderType.Assembly;
        
    /// <summary>
    /// Gets the type that registered the resource.
    /// </summary>
    internal Type ProviderType
    { get; }

    /// <summary>
    /// Gets the uniquely identifying name of the resource.
    /// </summary>
    internal string Name
    { get; }

    /// <inheritdoc/>
    /// <remarks>
    /// Resource keys must support value equality comparisons in order to resources to be located correctly.
    /// </remarks>
    public override bool Equals(object? obj)
        => obj is FenestraKey otherKey && otherKey.ProviderType == ProviderType && otherKey.Name == Name;

    /// <inheritdoc/>
    public override int GetHashCode()
        => this.GetHashCode(ProviderType, Name);
}