﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABSpriteEditor.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ErrorStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ABSpriteEditor.Properties.ErrorStrings", typeof(ErrorStrings).Assembly);
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
        ///   Looks up a localized string similar to The file &quot;{0}&quot; contained errors and could not be loaded. An error log has been created at &quot;{1}&quot;..
        /// </summary>
        internal static string FileContainedErrors {
            get {
                return ResourceManager.GetString("FileContainedErrors", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided namespace name is invalid..
        /// </summary>
        internal static string InvalidNamespaceName {
            get {
                return ResourceManager.GetString("InvalidNamespaceName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided sprite name is invalid..
        /// </summary>
        internal static string InvalidSpriteName {
            get {
                return ResourceManager.GetString("InvalidSpriteName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are no open sprite files to export..
        /// </summary>
        internal static string NoFilesToExport {
            get {
                return ResourceManager.GetString("NoFilesToExport", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are no open sprite files to save..
        /// </summary>
        internal static string NoFilesToSave {
            get {
                return ResourceManager.GetString("NoFilesToSave", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The image &quot;{0}&quot; has the wrong dimensions for the target sprite. The sprite&apos;s dimensions are {3}x{4}, the image&apos;s dimensions are {1}x{2}..
        /// </summary>
        internal static string SpriteFileDropInvalidDimensions {
            get {
                return ResourceManager.GetString("SpriteFileDropInvalidDimensions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unexpected exception has occurred. Please show the log file at &quot;{0}&quot; to the software&apos;s current maintainer..
        /// </summary>
        internal static string UnexpectedExceptionLogged {
            get {
                return ResourceManager.GetString("UnexpectedExceptionLogged", resourceCulture);
            }
        }
    }
}
