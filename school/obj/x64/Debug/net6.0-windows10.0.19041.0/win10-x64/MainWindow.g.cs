﻿#pragma checksum "C:\Users\ljt_d\Documents\native\Schoolvoetbal4C\school\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "89C298BB57E3C9617C984F492EADC44706EEBDF1270499FB1C6DA9097634A5EE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace school
{
    partial class MainWindow : 
        global::Microsoft.UI.Xaml.Window, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2411")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainWindow.xaml line 38
                {
                    this.FetchTeamsButton = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.FetchTeamsButton).Click += this.FetchTeamsButton_Click;
                }
                break;
            case 3: // MainWindow.xaml line 39
                {
                    this.TeamsListView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListView>(target);
                }
                break;
            case 5: // MainWindow.xaml line 27
                {
                    this.RegisterUsernameTextBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 6: // MainWindow.xaml line 28
                {
                    this.RegisterPasswordBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.PasswordBox>(target);
                }
                break;
            case 7: // MainWindow.xaml line 29
                {
                    this.ConfirmRegisterPasswordBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.PasswordBox>(target);
                }
                break;
            case 8: // MainWindow.xaml line 30
                {
                    this.RegisterErrorTextBlock = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 9: // MainWindow.xaml line 31
                {
                    global::Microsoft.UI.Xaml.Controls.Button element9 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element9).Click += this.RegisterButton_Click;
                }
                break;
            case 10: // MainWindow.xaml line 17
                {
                    this.LoginUsernameTextBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 11: // MainWindow.xaml line 18
                {
                    this.LoginPasswordBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.PasswordBox>(target);
                }
                break;
            case 12: // MainWindow.xaml line 19
                {
                    this.LoginErrorTextBlock = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 13: // MainWindow.xaml line 20
                {
                    global::Microsoft.UI.Xaml.Controls.Button element13 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element13).Click += this.LoginButton_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }


        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2411")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

