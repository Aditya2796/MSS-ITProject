<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default7.aspx.cs" Inherits="Default7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Entry for a New Supply : <br />
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="MCode" DataValueField="Mcode" AutoPostBack="true"></asp:DropDownList><br />
    Enter the Quantity : <asp:TextBox ID="SupplyQtyTxtBox" runat="server" TextMode="Number"></asp:TextBox><br />
    Enter the Batch Number : <asp:TextBox ID="SupplyBatchTxtBox" runat="server" TextMode="Number"></asp:TextBox><br />
    Enter the Expiry Date : <asp:TextBox ID="SupplyExpiryDateTxtBox" runat="server" TextMode="Date"></asp:TextBox><br />
    Choose the Vendor : <br /><asp:RadioButtonList ID="RadioButtonList1" runat="server" Visible="false"></asp:RadioButtonList><br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:Pubs %>" SelectCommand="SELECT Mcode from Medicine"></asp:SqlDataSource>
    <asp:Button ID="SupplyBtnAdd" runat="server" Text="Add" OnClick="btn_add_supply" />
    <asp:Label ID="rrr" runat="server" Visible="false" />
    </asp:Content>

