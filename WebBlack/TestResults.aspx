<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TestResults.aspx.cs" Inherits="TestResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h2>Failed Tests</h2>
    <asp:Repeater ItemType="System.string" runat="server" ID="repeaterPassed" SelectMethod="testsPassed">
        <ItemTemplate>
            <p><%# Item %></p>
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <h2>Passed Tests</h2>
    <asp:Repeater ItemType="System.string" runat="server" ID="repeater1" SelectMethod="testsFailed">
        <ItemTemplate>
            <p><%# Item %></p>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

