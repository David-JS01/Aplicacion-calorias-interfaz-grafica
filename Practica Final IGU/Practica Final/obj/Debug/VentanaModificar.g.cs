﻿#pragma checksum "..\..\VentanaModificar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "61B238DD6413A6AA6FC8EB17D117243968E70636A016D0CD636762C8349CFA82"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Practica_Final;
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


namespace Practica_Final {
    
    
    /// <summary>
    /// VentanaModificar
    /// </summary>
    public partial class VentanaModificar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\VentanaModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\VentanaModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox calDesayuno;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\VentanaModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox calAperitivo;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\VentanaModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox calComida;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\VentanaModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox calMerienda;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\VentanaModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox calCena;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\VentanaModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox calOtros;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\VentanaModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonOk;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\VentanaModificar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/Practica Final;component/ventanamodificar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VentanaModificar.xaml"
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
            this.combo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\VentanaModificar.xaml"
            this.combo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.combo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.calDesayuno = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\VentanaModificar.xaml"
            this.calDesayuno.KeyDown += new System.Windows.Input.KeyEventHandler(this.numericText_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.calAperitivo = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\VentanaModificar.xaml"
            this.calAperitivo.KeyDown += new System.Windows.Input.KeyEventHandler(this.numericText_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.calComida = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\VentanaModificar.xaml"
            this.calComida.KeyDown += new System.Windows.Input.KeyEventHandler(this.numericText_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.calMerienda = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\VentanaModificar.xaml"
            this.calMerienda.KeyDown += new System.Windows.Input.KeyEventHandler(this.numericText_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.calCena = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\VentanaModificar.xaml"
            this.calCena.KeyDown += new System.Windows.Input.KeyEventHandler(this.numericText_KeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.calOtros = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\VentanaModificar.xaml"
            this.calOtros.KeyDown += new System.Windows.Input.KeyEventHandler(this.numericText_KeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.botonOk = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\VentanaModificar.xaml"
            this.botonOk.Click += new System.Windows.RoutedEventHandler(this.botonOk_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.botonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\VentanaModificar.xaml"
            this.botonCancel.Click += new System.Windows.RoutedEventHandler(this.botonCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

