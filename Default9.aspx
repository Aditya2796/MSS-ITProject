<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default9.aspx.cs" Inherits="Default9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Threshold for each of the Medicines : <br />
    <asp:GridView ID="thresholdgridview" runat="server" AutoGenerateColumns="true" Visible="false"></asp:GridView><br />
    <asp:Label ID="r1" runat="server" Visible="false"></asp:Label>
    <br />
    Medicines below Threshold : <br />
    <asp:GridView ID="vendorthresholdmedicine" runat="server" AutoGenerateColumns="true"></asp:GridView><br />
</asp:Content>

