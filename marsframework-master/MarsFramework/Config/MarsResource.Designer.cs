﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarsFramework.Config {
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
    public class MarsResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MarsResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MarsFramework.Config.MarsResource", typeof(MarsResource).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 2.
        /// </summary>
        public static string Browser {
            get {
                return ResourceManager.GetString("Browser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to V:/marsframework-master/marsframework-master/MarsFramework/TestData/LogInData.xlsx.
        /// </summary>
        public static string ExcelPath {
            get {
                return ResourceManager.GetString("ExcelPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to true.
        /// </summary>
        public static string IsLogin {
            get {
                return ResourceManager.GetString("IsLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to V:/marsframework-master/marsframework-master/MarsFramework/TestRports.
        /// </summary>
        public static string ReportPath {
            get {
                return ResourceManager.GetString("ReportPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to V:\marsframework-master\marsframework-master\MarsFramework\ReportXML.
        /// </summary>
        public static string ReportXMLPath {
            get {
                return ResourceManager.GetString("ReportXMLPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to V:/marsframework-master/marsframework-master/MarsFramework/ScreenShots.
        /// </summary>
        public static string ScreenShotPath {
            get {
                return ResourceManager.GetString("ScreenShotPath", resourceCulture);
            }
        }
    }
}