﻿

#pragma checksum "C:\Users\ayush's\Documents\Visual Studio 2013\Projects\Roskide Design\Roskide Design\View\GroupedItemsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FDCB08DFB5802E2A11DC58FA5E77F9CE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Roskide_Design
{
    partial class GroupedItemsPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 51 "..\..\View\GroupedItemsPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).DoubleTapped += this.Hotel_DoubleTapped_1;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 66 "..\..\View\GroupedItemsPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).DoubleTapped += this.Weather_DoubleTapped;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 105 "..\..\View\GroupedItemsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.ItemView_ItemClick;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 131 "..\..\View\GroupedItemsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Header_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


