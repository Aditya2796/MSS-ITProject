<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Enter Details for the New Medicine :<br /><br />
    Enter Trade Name <asp:textbox runat="server" Id="TNameTxtBox"></asp:textbox><br />
    Enter Generic Name <asp:textbox runat="server" Id="GNameTxtBox"></asp:textbox><br />
    Enter the Quantity <asp:textbox runat="server" Id="qtyTxtBox" TextMode="Number"></asp:textbox><br />
    Enter the Batch Number <asp:textbox runat="server" Id="batchtxtBox" TextMode="Number"></asp:textbox><br />
    Enter the Expiry Date <asp:textbox runat="server" Id="expiryDateTxtBox" TextMode="Date"></asp:textbox><br />
    Enter the Batch Date <asp:TextBox ID="BatchDateTxtBox" runat="server" TextMode="Date"></asp:TextBox><br /><br />
    Choose Vendors from following Options : <br /><br />
    <asp:RadioButtonList ID="VendorRadioList" runat="server"></asp:RadioButtonList>
    <br />
    Enter the Sales Price <asp:TextBox ID="SalesPriceTxtBox" runat="server" TextMode="Number"></asp:TextBox><br />
    Enter the Purchase Price <asp:TextBox ID="PurchasePriceTxtBox" runat="server" TextMode="Number"></asp:TextBox><br /><br />
    <asp:Button ID="AddBtn" runat="server" Text="Add" OnClick="btn_add_new_medicine" />
    <asp:Label ID="ran" runat="server" Visible="false" />   
</asp:Content>

