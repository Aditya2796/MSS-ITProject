<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        Purchasing Counter :
        Enter the Medicine Code : <asp:DropDownList ID="MedicineDropDownList" runat="server" DataSourceID="source_mcodes" DataTextField="MCode" DataValueField="MCode"></asp:DropDownList><br />
        Enter the Quantity : <asp:TextBox ID="D2QuantityTextBox" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="Generate Bill" OnClick="Generate_Bill" /><br />
        <asp:Label ID="billLabel" runat="server"></asp:Label><br />
        <asp:Label ID="verify" runat="server" />
        <asp:SqlDataSource ID="source_mcodes" runat="server" SelectCommand="Select Distinct Mcode from Medicine" ConnectionString="<%$ConnectionStrings:Pubs %>"></asp:SqlDataSource>
    </div>
</asp:Content>

