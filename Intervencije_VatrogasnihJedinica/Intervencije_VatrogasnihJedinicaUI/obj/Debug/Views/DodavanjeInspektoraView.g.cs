﻿#pragma checksum "..\..\..\Views\DodavanjeInspektoraView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5109B0458437FCA9B80E61DEF44267CAECB13073B55FCE2354792AD006854689"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Intervencije_VatrogasnihJedinicaUI.Models;
using Intervencije_VatrogasnihJedinicaUI.Views;
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


namespace Intervencije_VatrogasnihJedinicaUI.Views {
    
    
    /// <summary>
    /// DodavanjeInspektoraView
    /// </summary>
    public partial class DodavanjeInspektoraView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Views\DodavanjeInspektoraView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Ime;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Views\DodavanjeInspektoraView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Prezime;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Views\DodavanjeInspektoraView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Telefon;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Views\DodavanjeInspektoraView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DodajIzmeni;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Views\DodavanjeInspektoraView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PorukaGreskeZaIme;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Views\DodavanjeInspektoraView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PorukaGreskeZaPrezime;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Views\DodavanjeInspektoraView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PorukaGreskeZaTelefon;
        
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
            System.Uri resourceLocater = new System.Uri("/Intervencije_VatrogasnihJedinicaUI;component/views/dodavanjeinspektoraview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\DodavanjeInspektoraView.xaml"
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
            this.Ime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Prezime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Telefon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.DodajIzmeni = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.PorukaGreskeZaIme = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.PorukaGreskeZaPrezime = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.PorukaGreskeZaTelefon = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

