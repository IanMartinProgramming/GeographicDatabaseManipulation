<%@ Page Title="" Language="C#" MasterPageFile="~/A3MasterPage.Master" AutoEventWireup="true" CodeBehind="AddTown.aspx.cs" Inherits="A3IanMartin.AddTown" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Add Town:</p>
    <p>
        Select Continent:</p>
    <p>
        <asp:DropDownList ID="ddlContinents" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlContinents_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlContinents" ErrorMessage="You Must Select a Continent" ForeColor="Red" InitialValue="Select a Continent"></asp:RequiredFieldValidator>
    </p>
    <p>
        Select Country:</p>
    <p>
        <asp:DropDownList ID="ddlCountries" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCountries" ErrorMessage="You Must Select a Country" ForeColor="Red" InitialValue="Select a Country"></asp:RequiredFieldValidator>
    </p>
    <p>
        Town Name:</p>
    <p>
        <asp:TextBox ID="txtTownName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTownName" ErrorMessage="Input the Town Name" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        Population:</p>
    <p>
        <asp:TextBox ID="txtPopulation" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPopulation" Display="Dynamic" ErrorMessage="Input a valid number (no commas)" ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPopulation" Display="Dynamic" ErrorMessage="Input the Population" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Town" />
    </p>
    <p>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </p>
</asp:Content>
