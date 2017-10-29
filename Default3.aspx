<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:label runat="server" text="Medicines which have expired" visible="false" ID="expiredlabel"></asp:label><br />
    <asp:gridview runat="server" ID="ExpiredMedicinesGridView" visible="false"></asp:gridview><br /><br />
    List of Vendors :<br />
</asp:Content>

