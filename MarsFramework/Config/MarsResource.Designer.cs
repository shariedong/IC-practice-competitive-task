//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarsFramework.Config {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class MarsResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MarsResource() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MarsFramework.Config.MarsResource", typeof(MarsResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性
        ///   重写当前线程的 CurrentUICulture 属性。
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
        ///   查找类似 2 的本地化字符串。
        /// </summary>
        internal static string Browser {
            get {
                return ResourceManager.GetString("Browser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 C:\Users\Hui\source\repos\MARS\Mars_competitive_practice\MarsFramework\ExcelData\TestDataShareSkill.xlsx 的本地化字符串。
        /// </summary>
        internal static string ExcelPath {
            get {
                return ResourceManager.GetString("ExcelPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 true 的本地化字符串。
        /// </summary>
        internal static string IsLogin {
            get {
                return ResourceManager.GetString("IsLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 C:\Users\Hui\source\repos\MARS\Mars_competitive_practice\MarsFramework 的本地化字符串。
        /// </summary>
        internal static string ReportPath {
            get {
                return ResourceManager.GetString("ReportPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 C:\Users\Hui\source\repos\MARS\Mars_competitive_practice\MarsFramework 的本地化字符串。
        /// </summary>
        internal static string ReportXMLPath {
            get {
                return ResourceManager.GetString("ReportXMLPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 C:\Users\Hui\Desktop\1111.txt 的本地化字符串。
        /// </summary>
        internal static string SampleWork {
            get {
                return ResourceManager.GetString("SampleWork", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 C:\Users\Hui\source\repos\MARS\Mars_competitive_practice\MarsFramework 的本地化字符串。
        /// </summary>
        internal static string ScreenShotPath {
            get {
                return ResourceManager.GetString("ScreenShotPath", resourceCulture);
            }
        }
    }
}
