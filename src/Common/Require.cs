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

using System.Diagnostics.CodeAnalysis;
using BadEcho.Properties;

namespace BadEcho;

/// <summary>
/// Provides a set of static methods that perform common runtime checks on method parameters.
/// </summary>
public static class Require
{
    /// <summary>
    /// Ensures the specified parameter's value is not null before allowing execution to continue.
    /// </summary>
    /// <typeparam name="T">The type of the parameter being validated.</typeparam>
    /// <param name="value">The parameter value to validate.</param>
    /// <param name="parameterName">The name of the parameter.</param>
    /// <exception cref="ArgumentNullException"><c>value</c> is null.</exception>
    public static void NotNull<T>([NotNull][NoEnumeration]T? value, string? parameterName)
    {
        if (value == null)
            throw new ArgumentNullException(parameterName);
    }

    /// <summary>
    /// Ensures the specified parameter's value is not null or empty before allowing execution to continue.
    /// </summary>
    /// <param name="value">The parameter value to validate.</param>
    /// <param name="parameterName">The name of the parameter.</param>
    /// <exception cref="ArgumentNullException"><c>value</c> is null.</exception>
    /// <exception cref="ArgumentException"><c>value</c> is empty.</exception>
    public static void NotNullOrEmpty([NotNull]string? value, string? parameterName)
    {
        NotNull(value, parameterName);

        if (0u >= (uint) value.Length)
            throw new ArgumentException(Strings.ArgumentStringEmpty, parameterName);
    }
}