// Updated by XamlIntelliSenseFileGenerator 29/01/2024 20:26:10
#pragma checksum "..\..\..\ListClassPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AB98579B3908EE0EE9396E4D4FB41102B68CA5CB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Task02;


namespace Task02
{


    /// <summary>
    /// ListPeo
    /// </summary>
    public partial class ListPeoplePage : Task02.FramedPage, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector
    {


#line 16 "..\..\..\ListClassPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvPeople;

#line default
#line hidden


#line 65 "..\..\..\ListClassPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClasses;

#line default
#line hidden


#line 74 "..\..\..\ListClassPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;

#line default
#line hidden


#line 83 "..\..\..\ListClassPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEdit;

#line default
#line hidden


#line 92 "..\..\..\ListClassPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Task02;V1.0.0.0;component/listclasspage.xaml", System.UriKind.Relative);

#line 1 "..\..\..\ListClassPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler)
        {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.lvPeople = ((System.Windows.Controls.ListView)(target));
                    return;
                case 3:
                    this.btnClasses = ((System.Windows.Controls.Button)(target));

#line 68 "..\..\..\ListClassPage.xaml"
                    this.btnClasses.Click += new System.Windows.RoutedEventHandler(this.BtnDelete_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.btnAdd = ((System.Windows.Controls.Button)(target));

#line 77 "..\..\..\ListClassPage.xaml"
                    this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.btnEdit = ((System.Windows.Controls.Button)(target));

#line 86 "..\..\..\ListClassPage.xaml"
                    this.btnEdit.Click += new System.Windows.RoutedEventHandler(this.BtnEdit_Click);

#line default
#line hidden
                    return;
                case 6:
                    this.btnDelete = ((System.Windows.Controls.Button)(target));

#line 95 "..\..\..\ListClassPage.xaml"
                    this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.BtnDelete_Click);

#line default
#line hidden
                    return;
                case 7:

#line 99 "..\..\..\ListClassPage.xaml"
                    ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);

#line default
#line hidden
                    return;
                case 8:

#line 100 "..\..\..\ListClassPage.xaml"
                    ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);

#line default
#line hidden
                    return;
                case 9:

#line 101 "..\..\..\ListClassPage.xaml"
                    ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);

#line default
#line hidden
                    return;
                case 10:

#line 102 "..\..\..\ListClassPage.xaml"
                    ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target)
        {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
                case 2:
                    eventSetter = new System.Windows.EventSetter();
                    eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;

#line 20 "..\..\..\ListClassPage.xaml"
                    eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.BtnEdit_Click);

#line default
#line hidden
                    ((System.Windows.Style)(target)).Setters.Add(eventSetter);
                    break;
            }
        }
    }
}

