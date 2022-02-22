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

using System.Composition;
using BadEcho.Extensibility.Hosting;
using BadEcho.Tests.Extensibility;

namespace BadEcho.Tests.Plugin;

[Export(typeof(IFakePartWithDependencies))]
public class FakePartWithDependencies : IFakePartWithDependencies
{
    [ImportingConstructor]
    public FakePartWithDependencies(IFakeDependency dependency)
    {
        Dependency = dependency;
    }

    public IFakeDependency Dependency { get; }
}

[Export(typeof(IFakePartWithComposedDependencies))]
public class FakePartWithComposedDependencies : IFakePartWithComposedDependencies
{
    private const string DEPENDENCY_CONTRACT 
        = nameof(FakePartWithComposedDependencies) + nameof(LocalDependency);

    [ImportingConstructor]
    public FakePartWithComposedDependencies([Import(DEPENDENCY_CONTRACT)] IFakeDependency dependency)
    {
        Dependency = dependency;
    }

    public IFakeDependency Dependency { get; }

    /// <suppressions>
    /// ReSharper disable ClassNeverInstantiated.Local
    /// </suppressions>
    [Export(typeof(IConventionProvider))]
    private class LocalDependency : DependencyRegistry<IFakeDependency>
    {
        public LocalDependency()
            : base(DEPENDENCY_CONTRACT)
        { }
    }
}