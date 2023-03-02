﻿//-----------------------------------------------------------------------
// <copyright>
//		Created by Matt Weber <matt@badecho.com>
//		Copyright @ 2023 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under a
//		GNU Affero General Public License v3.0.
//
//		See accompanying file LICENSE.md or a copy at:
//		https://www.gnu.org/licenses/agpl-3.0.html
// </copyright>
//-----------------------------------------------------------------------

namespace BadEcho.Interop;

/// <summary>
/// Specifies the type of balloon icon to display in a notification.
/// </summary>
public enum BalloonIconType
{
    /// <summary>
    /// No icon.
    /// </summary>
    None,
    /// <summary>
    /// An information icon.
    /// </summary>
    Info,
    /// <summary>
    /// A warning icon.
    /// </summary>
    Warning,
    /// <summary>
    /// An error icon.
    /// </summary>
    Error,
    /// <summary>
    /// A loaded custom icon.
    /// </summary>
    Custom
}
