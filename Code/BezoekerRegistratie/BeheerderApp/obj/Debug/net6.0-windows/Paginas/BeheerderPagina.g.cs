﻿#pragma checksum "..\..\..\..\Paginas\BeheerderPagina.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3A587E194E3A962B56C319449CDD3010A78246F1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BeheerderApp.Paginas;
using Components;
using Components.ZoekForms;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace BeheerderApp.Paginas {
    
    
    /// <summary>
    /// BeheerderPagina
    /// </summary>
    public partial class BeheerderPagina : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\Paginas\BeheerderPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Components.CheckBox bezoekerCheckBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Paginas\BeheerderPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Components.CheckBox werknemerCheckBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Paginas\BeheerderPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Components.CheckBox bedrijfCheckBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Paginas\BeheerderPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Components.CheckBox afspraakCheckBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Paginas\BeheerderPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel formPanel;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Paginas\BeheerderPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel dataGridPanel;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Paginas\BeheerderPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Components.ZoekbaarDataGrid _dataGrid;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\Paginas\BeheerderPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Components.TerugKnop terugKnop;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BeheerderApp;component/paginas/beheerderpagina.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Paginas\BeheerderPagina.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.bezoekerCheckBox = ((Components.CheckBox)(target));
            return;
            case 2:
            this.werknemerCheckBox = ((Components.CheckBox)(target));
            return;
            case 3:
            this.bedrijfCheckBox = ((Components.CheckBox)(target));
            return;
            case 4:
            this.afspraakCheckBox = ((Components.CheckBox)(target));
            return;
            case 5:
            this.formPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.dataGridPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this._dataGrid = ((Components.ZoekbaarDataGrid)(target));
            return;
            case 8:
            this.terugKnop = ((Components.TerugKnop)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
