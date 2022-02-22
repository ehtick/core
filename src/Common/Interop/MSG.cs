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

using System.Runtime.InteropServices;

namespace BadEcho.Interop;

/// <summary>
/// Provides message information from a thread's message queue.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct MSG
{
    /// <summary>
    /// A handle to the window whose window procedure receives the message.
    /// </summary>
    /// <remarks>This member is null when the message is a thread message.</remarks>
    public IntPtr hWnd;
    /// <summary>
    /// The message identifier.
    /// </summary>
    public int message;
    /// <summary>
    /// Additional information about the message.
    /// </summary>
    public IntPtr wParam;
    /// <summary>
    /// Additional information about the message.
    /// </summary>
    public IntPtr lParam;
    /// <summary>
    /// The time at which the message was posted.
    /// </summary>
    public int time;
    /// <summary>
    /// The cursor position's x-coordinate.
    /// </summary>
    public int pt_x;
    /// <summary>
    /// The cursor position's y-coordinate.
    /// </summary>
    public int pt_y;
}
