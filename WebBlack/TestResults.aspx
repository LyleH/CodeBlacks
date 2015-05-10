<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TestResults.aspx.cs" Inherits="TestResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    
    <a href="javascript:ReverseDisplay('failList')">
        <h2>Failed Tests</h2>
    </a>
    <div id="failList" style="display: none">
        <asp:Repeater ItemType="System.string" runat="server" ID="repeaterPassed" SelectMethod="testsPassed">
            <ItemTemplate>
                <p><%# Item %></p>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <br />
    <a href="javascript:ReverseDisplay('passList')">
        <h2>Passed Tests</h2>
    </a>
    <div id="passList" style="display: none">
    <asp:Repeater ItemType="System.string" runat="server" ID="repeater1" SelectMethod="testsFailed">
        <ItemTemplate>
            <p><%# Item %></p>
        </ItemTemplate>
    </asp:Repeater>
        </div>
    <script type="text/javascript">
    function HideContent(d) {
        document.getElementById(d).style.display = "none";
    }
    function ShowContent(d) {
        document.getElementById(d).style.display = "block"
    }
    function ReverseDisplay(d) {
        if (document.getElementById(d).style.display == "none") { document.getElementById(d).style.display = "block" }
        else { document.getElementById(d).style.display = "none"; }
    }
    </script>


</asp:Content>


