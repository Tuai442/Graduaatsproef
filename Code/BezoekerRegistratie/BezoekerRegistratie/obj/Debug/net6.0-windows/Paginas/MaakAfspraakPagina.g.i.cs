﻿#pragma checksum "..\..\..\..\Paginas\MaakAfspraakPagina.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24888A7EBA69911644AB82457310063F7A78CD86"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BezoekerRegistratie.Paginas;
using BezoekerRegistratie.UI_Onderdelen;
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


namespace BezoekerRegistratie.Paginas {
    
    
    /// <summary>
    /// MaakAfspraakPagina
    /// </summary>
    public partial class MaakAfspraakPagina : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\..\Paginas\MaakAfspraakPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox voornaam;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Paginas\MaakAfspraakPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox achternaam;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Paginas\MaakAfspraakPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox email;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Paginas\MaakAfspraakPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nummerplaat;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Paginas\MaakAfspraakPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox bedrijfComboBox;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Paginas\MaakAfspraakPagina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BezoekerRegistratie.UI_Onderdelen.CustomButton registreerBezoeker;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BezoekerRegistratie;V1.0.0.0;component/paginas/maakafspraakpagina.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Paginas\MaakAfspraakPagina.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.voornaam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.achternaam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.nummerplaat = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.bedrijfComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 87 "..\..\..\..\Paginas\MaakAfspraakPagina.xaml"
            this.bedrijfComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.bedrijfComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.registreerBezoeker = ((BezoekerRegistratie.UI_Onderdelen.CustomButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

