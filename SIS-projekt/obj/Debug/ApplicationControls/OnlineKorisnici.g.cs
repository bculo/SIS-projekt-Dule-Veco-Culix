﻿#pragma checksum "..\..\..\ApplicationControls\OnlineKorisnici.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38B54FE1E662D0F9F24CB81C67116018ABAF41CB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SIS_projekt;
using SIS_projekt.ApplicationControls;
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


namespace SIS_projekt.ApplicationControls {
    
    
    /// <summary>
    /// OnlineKorisnici
    /// </summary>
    public partial class OnlineKorisnici : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\ApplicationControls\OnlineKorisnici.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button osvjezi;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\ApplicationControls\OnlineKorisnici.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView bindanje;
        
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
            System.Uri resourceLocater = new System.Uri("/SIS-projekt;component/applicationcontrols/onlinekorisnici.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ApplicationControls\OnlineKorisnici.xaml"
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
            this.osvjezi = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\ApplicationControls\OnlineKorisnici.xaml"
            this.osvjezi.Click += new System.Windows.RoutedEventHandler(this.osvjezi_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bindanje = ((System.Windows.Controls.ListView)(target));
            
            #line 26 "..\..\..\ApplicationControls\OnlineKorisnici.xaml"
            this.bindanje.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.bindanje_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

