﻿#pragma checksum "..\..\theloai.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8FC6EBF96D45F3FBE595EB8C69EEE0D6CFE3E13EFA70D1A10A1A3D43BA0EB1D0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using demobtl;


namespace demobtl {
    
    
    /// <summary>
    /// theloai
    /// </summary>
    public partial class theloai : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\theloai.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid theloai1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\theloai.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button home1;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\theloai.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_search;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\theloai.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button taikhoan;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\theloai.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combodm;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\theloai.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tl;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\theloai.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dangxuat;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\theloai.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listbook;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\theloai.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button kinh_lup;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/demobtl;component/theloai.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\theloai.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\theloai.xaml"
            ((demobtl.theloai)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.theloai1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.home1 = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\theloai.xaml"
            this.home1.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tb_search = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.taikhoan = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\theloai.xaml"
            this.taikhoan.Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            case 6:
            this.combodm = ((System.Windows.Controls.ComboBox)(target));
            
            #line 28 "..\..\theloai.xaml"
            this.combodm.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tl = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\theloai.xaml"
            this.tl.Click += new System.Windows.RoutedEventHandler(this.tl_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dangxuat = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\theloai.xaml"
            this.dangxuat.Click += new System.Windows.RoutedEventHandler(this.dangxuat_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.listbook = ((System.Windows.Controls.ListBox)(target));
            return;
            case 10:
            this.kinh_lup = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\theloai.xaml"
            this.kinh_lup.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

