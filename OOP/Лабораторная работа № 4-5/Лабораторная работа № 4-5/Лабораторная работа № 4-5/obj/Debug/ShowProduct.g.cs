﻿#pragma checksum "..\..\ShowProduct.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D85C9D3E9E2FB2F1D6102B5753C7D80109DCE33754473A01C42E1C176FC07B96"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using Лабораторная_работа___4_5;


namespace Лабораторная_работа___4_5 {
    
    
    /// <summary>
    /// ShowProduct
    /// </summary>
    public partial class ShowProduct : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\ShowProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCloseApp;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ShowProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainRoot;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\ShowProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addProduct;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\ShowProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeProduct;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\ShowProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteProduct;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\ShowProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchProduct;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\ShowProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button filtrProduct;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\ShowProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox search;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\ShowProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox filterProduct;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\ShowProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Products;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\ShowProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_filterType;
        
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
            System.Uri resourceLocater = new System.Uri("/Лабораторная работа № 4-5;component/showproduct.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ShowProduct.xaml"
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
            this.ButtonCloseApp = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\ShowProduct.xaml"
            this.ButtonCloseApp.Click += new System.Windows.RoutedEventHandler(this.ButtonCloseApp_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.addProduct = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\ShowProduct.xaml"
            this.addProduct.Click += new System.Windows.RoutedEventHandler(this.addProduct_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ChangeProduct = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\ShowProduct.xaml"
            this.ChangeProduct.Click += new System.Windows.RoutedEventHandler(this.ChangeProduct_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.deleteProduct = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\ShowProduct.xaml"
            this.deleteProduct.Click += new System.Windows.RoutedEventHandler(this.deleteProduct_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.searchProduct = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\ShowProduct.xaml"
            this.searchProduct.Click += new System.Windows.RoutedEventHandler(this.searchProduct_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.filtrProduct = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\ShowProduct.xaml"
            this.filtrProduct.Click += new System.Windows.RoutedEventHandler(this.filtrProduct_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.search = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.filterProduct = ((System.Windows.Controls.ComboBox)(target));
            
            #line 81 "..\..\ShowProduct.xaml"
            this.filterProduct.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.filterProduct_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Products = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.tb_filterType = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

