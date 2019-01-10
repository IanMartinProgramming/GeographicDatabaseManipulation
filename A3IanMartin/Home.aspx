<%@ Page Title="" Language="C#" MasterPageFile="~/A3MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="A3IanMartin.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <p>
    Continents:</p>
        <p>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <p>
                    <asp:ListBox ID="lstContinents" runat="server" OnSelectedIndexChanged="lstContinents_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                </p>
                <p>
                    Countries:</p>
                <p>
                    <asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
                    </asp:DropDownList>
                </p>
                <p>
                    Country Flag:</p>
                <p>
                    <asp:Image ID="imgFlag" runat="server" Height="200px" />
                </p>
                <p>
                    Spoken Language:
                    <asp:Label ID="lblLanguage" runat="server"></asp:Label>
                </p>
                <p>
                    Towns within the country:</p>
                <p>
                    <asp:GridView ID="grdTowns" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>
                </p>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
</asp:Content>
