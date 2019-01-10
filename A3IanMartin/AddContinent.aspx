<%@ Page Title="" Language="C#" MasterPageFile="~/A3MasterPage.Master" AutoEventWireup="true" CodeBehind="AddContinent.aspx.cs" Inherits="A3IanMartin.AddContinent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Add Continent:</p>
    <p>
        Continent Name:</p>
    <p>
        <asp:TextBox ID="txtContinent" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContinent" ErrorMessage="Input Continent Name" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Continent" />
    </p>
    <p>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </p>
</asp:Content>
