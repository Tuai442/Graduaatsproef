﻿#pragma checksum "..\..\..\..\Paginas\BedrijfSelecteren.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A78BACDBDEF6EDE235C7AEC884D85940A6E6A584"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BezoekerApp.Paginas;
using Components;
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


namespace BezoekerApp.Paginas {
    
    
    /// <summary>
    /// BedrijfSelecteren
    /// </summary>
    public partial class BedrijfSelecteren : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 54 "..\..\..\..\Paginas\BedrijfSelecteren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Components.ZoekbareComboBox bedrijfComboBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Paginas\BedrijfSelecteren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Components.ZoekbareComboBox contactComboBox;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Paginas\BedrijfSelecteren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Components.Knop AanmeldKnop;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Paginas\BedrijfSelecteren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Components.Knop TerugKnopAanmeldScherm;
        
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
            System.Uri resourceLocater = new System.Uri("/BezoekerApp;V1.0.0.0;component/paginas/bedrijfselecteren.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Paginas\BedrijfSelecteren.xaml"
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
            this.bedrijfComboBox = ((Components.ZoekbareComboBox)(target));
            return;
            case 2:
            this.contactComboBox = ((Components.ZoekbareComboBox)(target));
            return;
            case 3:
            this.AanmeldKnop = ((Components.Knop)(target));
            return;
            case 4:
            this.TerugKnopAanmeldScherm = ((Components.Knop)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

