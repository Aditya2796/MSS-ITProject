<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Search Either Using Generic Name or Trade Name :<br />
    <div id="texbox-div">
        <link rel="stylesheet" href="css/divTextBox.css" type="text/css" />
    Trade Name  <asp:TextBox ID="TradeNameTxtBox" runat="server"></asp:TextBox>
    Generic Name <asp:TextBox ID="GenericNameTxtBox" runat="server" /><br />
        <asp:Label ID="sth" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Search" onClick="search_submit"/>
     </div><br /><br />
        <asp:GridView runat="server" ID="SearchGridView" Visible="false" AutoGenerateColumns="true"></asp:GridView><br />
    <asp:Label ID="random" runat="server" />
</asp:Content>

