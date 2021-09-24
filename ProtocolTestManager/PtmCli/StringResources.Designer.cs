﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Protocols.TestManager.CLI {
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
    internal class StringResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Protocols.TestManager.CLI.StringResources", typeof(StringResources).Assembly);
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
        ///   Looks up a localized string similar to ERROR:.
        /// </summary>
        internal static string ErrorMessage {
            get {
                return ResourceManager.GetString("ErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Finish running test cases..
        /// </summary>
        internal static string FinishRunningTips {
            get {
                return ResourceManager.GetString("FinishRunningTips", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specifies the report format.\nValid values are: plain, json, xunit..
        /// </summary>
        internal static string FormatErrorMessage {
            get {
                return ResourceManager.GetString("FormatErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The test result directory does not exist: {0}..
        /// </summary>
        internal static string InvalidTestResultDir {
            get {
                return ResourceManager.GetString("InvalidTestResultDir", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The version of the test suite is invalid.
        /// </summary>
        internal static string InvalidTestSuiteVersion {
            get {
                return ResourceManager.GetString("InvalidTestSuiteVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specifies the outcome of the test cases to be included in the report file.\nValue should be separated by comma or space.\nValid values are: pass, fail, inconclusive..
        /// </summary>
        internal static string OutcomeErrorMessage {
            get {
                return ResourceManager.GetString("OutcomeErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PTM profile has been upgraded. New profile is saved as {0}..
        /// </summary>
        internal static string PtmProfileUpgraded {
            get {
                return ResourceManager.GetString("PtmProfileUpgraded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Report file is generate under {0}.
        /// </summary>
        internal static string ReportFilePath {
            get {
                return ResourceManager.GetString("ReportFilePath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You can find the test results under {0}.
        /// </summary>
        internal static string TestResultPath {
            get {
                return ResourceManager.GetString("TestResultPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown format: {0}..
        /// </summary>
        internal static string UnknownReportFormat {
            get {
                return ResourceManager.GetString("UnknownReportFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown test suite: {0}..
        /// </summary>
        internal static string UnknownTestSuiteMessage {
            get {
                return ResourceManager.GetString("UnknownTestSuiteMessage", resourceCulture);
            }
        }
    }
}
