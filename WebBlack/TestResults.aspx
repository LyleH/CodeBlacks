<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TestResults.aspx.cs" Inherits="TestResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingOne">
                <h4 class="panel-title">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#collapseOne" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">Failed Tests
                    </a>
                </h4>
            </div>
            <div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <div class="panel-body">
                    <asp:Repeater ItemType="System.string" runat="server" ID="repeaterPassed" SelectMethod="testsPassed">
                        <ItemTemplate>
                            <p><%# Item %></p>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingTwo">
                <h4 class="panel-title">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#collapseTwo" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">Passed Tests
                    </a>
                </h4>
            </div>
            <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                <div class="panel-body">
                    <asp:Repeater ItemType="System.string" runat="server" ID="repeater1" SelectMethod="testsFailed">
                        <ItemTemplate>
                            <p><%# Item %></p>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>

    <br />
    <div class="panel-group" id="accordion2" role="tablist" aria-multiselectable="true">
        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingOne2">
                <h4 class="panel-title">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#collapseOne2" href="#collapseOne2" aria-expanded="false" aria-controls="collapseOne2">Failed Tests
                    </a>
                </h4>
            </div>
            <div id="collapseOne2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne2">
                <div class="panel-body">
                    <asp:Repeater ItemType="System.string" runat="server" ID="repeater2" SelectMethod="testsPassed">
                        <ItemTemplate>
                            <p><%# Item %></p>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingTwo2">
                <h4 class="panel-title">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#collapseTwo2" href="#collapseTwo2" aria-expanded="false" aria-controls="collapseTwo2">Passed Tests
                    </a>
                </h4>
            </div>
            <div id="collapseTwo2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo2">
                <div class="panel-body">
                    <asp:Repeater ItemType="System.string" runat="server" ID="repeater3" SelectMethod="testsFailed">
                        <ItemTemplate>
                            <p><%# Item %></p>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>


</asp:Content>


