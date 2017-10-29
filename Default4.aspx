<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Sales for the Day : <asp:Label ID="DLabel" runat="server" Visible="false"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" Visible="false"></asp:GridView><br />
      <asp:Label ID="randommm" runat="server"></asp:Label>
    <asp:Label ID="TotalPriceLabel" runat="server" Visible ="false"></asp:Label>
</asp:Content>

