﻿#pragma checksum "..\..\CategoriesTab.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A85F8D43EBC2B5432354BC938F4EAF8068881763F6FA06F5538E6285C5C1F4CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ShopManager;
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


namespace ShopManager {
    
    
    /// <summary>
    /// CategoriesTab
    /// </summary>
    public partial class CategoriesTab : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\CategoriesTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addNewCategory;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\CategoriesTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reload;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\CategoriesTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\CategoriesTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid itemGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/ShopManager;component/categoriestab.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CategoriesTab.xaml"
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
            
            #line 9 "..\..\CategoriesTab.xaml"
            ((ShopManager.CategoriesTab)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.addNewCategory = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\CategoriesTab.xaml"
            this.addNewCategory.Click += new System.Windows.RoutedEventHandler(this.AddNewCategory_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.reload = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\CategoriesTab.xaml"
            this.reload.Click += new System.Windows.RoutedEventHandler(this.Reload_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.save = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\CategoriesTab.xaml"
            this.save.Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.itemGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 18 "..\..\CategoriesTab.xaml"
            this.itemGrid.AddHandler(System.Windows.Input.CommandManager.PreviewCanExecuteEvent, new System.Windows.Input.CanExecuteRoutedEventHandler(this.itemGrid_PreviewCanExecute));
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

