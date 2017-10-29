<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default8.aspx.cs" Inherits="Default8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Entry for a New Vendor <br />
    Enter the Vendor Name : <asp:TextBox ID="VendorNameTxtBox" runat="server"></asp:TextBox><br />
    Enter the Vendor Address : <asp:TextBox ID="VendorAddressTxtBox" runat="server"></asp:TextBox><br />
    Enter the Vendor Number : <asp:TextBox ID="VendorNUmberTxtBox" runat="server" TextMode="Number"></asp:TextBox><br />
    Choose the Medicine Code : <br />
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceId="source_mcode" AutoPostBack="true" DataTextField="MCode" DataValueField="MCode"></asp:DropDownList><br />
    <asp:SqlDataSource ID="source_mcode" runat="server" ConnectionString="<%$ConnectionStrings:Pubs %>" SelectCommand="Select Mcode from Medicine">
    </asp:SqlDataSource>
    <asp:Button ID="add_vendor" runat="server" Text="Add" onClick="btn_add_vendor"/>
</asp:Content>

