﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BadEcho.Omnified.Vision.Statistics.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BadEcho.Omnified.Vision.Statistics.Properties.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot update the &apos;{0}&apos; statistic as it currently isn&apos;t bound to a child view model..
        /// </summary>
        internal static string CannotUpdateUnboundStatistic {
            get {
                return ResourceManager.GetString("CannotUpdateUnboundStatistic", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The following JSON does not adhere to the Omnified game statistics messaging schema: {0}.
        /// </summary>
        internal static string JsonNotStatisticsSchema {
            get {
                return ResourceManager.GetString("JsonNotStatisticsSchema", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Statistics module had problems parsing the following message file contents:{0}{1}.
        /// </summary>
        internal static string StatisticsReadMessagesFailure {
            get {
                return ResourceManager.GetString("StatisticsReadMessagesFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided Statistic object type lacks support for describing in JSON..
        /// </summary>
        internal static string StatisticTypeUnsupportedJson {
            get {
                return ResourceManager.GetString("StatisticTypeUnsupportedJson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided Statistic object type lacks a supported view model..
        /// </summary>
        internal static string StatisticTypeUnsupportedViewModel {
            get {
                return ResourceManager.GetString("StatisticTypeUnsupportedViewModel", resourceCulture);
            }
        }
    }
}
