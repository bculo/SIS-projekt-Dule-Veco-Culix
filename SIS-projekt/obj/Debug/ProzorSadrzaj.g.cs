﻿#pragma checksum "..\..\ProzorSadrzaj.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9F7E1B90DC43FBA836E87F6876633ADEC5E2FE23"
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


namespace SIS_projekt {
    
    
    /// <summary>
    /// ProzorSadrzaj
    /// </summary>
    public partial class ProzorSadrzaj : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\ProzorSadrzaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock informacijeKorisnik;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ProzorSadrzaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button onlineKorisnici;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ProzorSadrzaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button primljeniPoruke;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ProzorSadrzaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button poslanePoruke;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ProzorSadrzaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button odjava;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ProzorSadrzaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.UserControl paneliIzmjena;
        
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
            System.Uri resourceLocater = new System.Uri("/SIS-projekt;component/prozorsadrzaj.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProzorSadrzaj.xaml"
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
            
            #line 9 "..\..\ProzorSadrzaj.xaml"
            ((SIS_projekt.ProzorSadrzaj)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.informacijeKorisnik = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.onlineKorisnici = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\ProzorSadrzaj.xaml"
            this.onlineKorisnici.Click += new System.Windows.RoutedEventHandler(this.onlineKorisnici_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.primljeniPoruke = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\ProzorSadrzaj.xaml"
            this.primljeniPoruke.Click += new System.Windows.RoutedEventHandler(this.primljeniPoruke_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.poslanePoruke = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\ProzorSadrzaj.xaml"
            this.poslanePoruke.Click += new System.Windows.RoutedEventHandler(this.poslanePoruke_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.odjava = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\ProzorSadrzaj.xaml"
            this.odjava.Click += new System.Windows.RoutedEventHandler(this.odjava_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.paneliIzmjena = ((System.Windows.Controls.UserControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
