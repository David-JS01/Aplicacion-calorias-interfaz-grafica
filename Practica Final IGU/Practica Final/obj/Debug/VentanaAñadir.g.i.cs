﻿#pragma checksum "..\..\VentanaAñadir.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F140057E8DFC3738911021591C33517AE52F8FA5A6FB6AEE01D9E23BC7EDA01F"
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
    /// VentanaAñadir
    /// </summary>
    public partial class VentanaAñadir : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\VentanaAñadir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar calendario;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\VentanaAñadir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textFecha;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\VentanaAñadir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textCalDesayuno;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\VentanaAñadir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textCalAperitivo;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\VentanaAñadir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textCalComida;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\VentanaAñadir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textCalMerienda;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\VentanaAñadir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textCalCena;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\VentanaAñadir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textCalOtros;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\VentanaAñadir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonOk;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\VentanaAñadir.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Practica Final;component/ventanaa%c3%b1adir.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VentanaAñadir.xaml"
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
            this.calendario = ((System.Windows.Controls.Calendar)(target));
            
            #line 26 "..\..\VentanaAñadir.xaml"
            this.calendario.SelectedDatesChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.calendario_SelectedDatesChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textFecha = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.textCalDesayuno = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\VentanaAñadir.xaml"
            this.textCalDesayuno.KeyDown += new System.Windows.Input.KeyEventHandler(this.numericTextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textCalAperitivo = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\VentanaAñadir.xaml"
            this.textCalAperitivo.KeyDown += new System.Windows.Input.KeyEventHandler(this.numericTextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textCalComida = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\VentanaAñadir.xaml"
            this.textCalComida.KeyDown += new System.Windows.Input.KeyEventHandler(this.numericTextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.textCalMerienda = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\VentanaAñadir.xaml"
            this.textCalMerienda.KeyDown += new System.Windows.Input.KeyEventHandler(this.numericTextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textCalCena = ((System.Windows.Controls.TextBox)(target));
            
            #line 55 "..\..\VentanaAñadir.xaml"
            this.textCalCena.KeyDown += new System.Windows.Input.KeyEventHandler(this.numericTextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.textCalOtros = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\VentanaAñadir.xaml"
            this.textCalOtros.KeyDown += new System.Windows.Input.KeyEventHandler(this.numericTextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.botonOk = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\VentanaAñadir.xaml"
            this.botonOk.Click += new System.Windows.RoutedEventHandler(this.botonOk_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.botonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\VentanaAñadir.xaml"
            this.botonCancel.Click += new System.Windows.RoutedEventHandler(this.botonCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

