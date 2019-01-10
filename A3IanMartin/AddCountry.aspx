<%@ Page Title="" Language="C#" MasterPageFile="~/A3MasterPage.Master" AutoEventWireup="true" CodeBehind="AddCountry.aspx.cs" Inherits="A3IanMartin.AddCountry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Add Country:</p>
    <p>
        Select Continent:</p>
    <p>
        <asp:DropDownList ID="ddlContinents" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlContinents" ErrorMessage="Please select a Continent" ForeColor="Red" InitialValue="Select a Continent"></asp:RequiredFieldValidator>
    </p>
    <p>
        Country Name:</p>
    <p>
        <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCountry" ErrorMessage="Please input the Country Name" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        Spoken Language:</p>
    <p>
        <asp:TextBox ID="txtLanguage" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLanguage" ErrorMessage="Please input the language" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        Country Flag:</p>
    <p>
        <asp:FileUpload ID="uploadFlag" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uploadFlag" Display="Dynamic" ErrorMessage="Please select an image" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="uploadFlag" Display="Dynamic" ErrorMessage="Invalid file type" ForeColor="Red" ValidationExpression="/\.(gif|jpg|jpeg|png)$/i"></asp:RegularExpressionValidator>
    </p>
    <p>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Country" />
    </p>
    <p>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </p>
</asp:Content>
