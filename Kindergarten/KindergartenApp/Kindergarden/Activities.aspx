<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activities.aspx.cs" Inherits="KindergartenApp.Kindergarden.Activities" %>

<%@ Import Namespace="Kindergarten.BL.Utils" %>
<%@ Import Namespace="Kindergarten.Domain.Entities" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>צפיה בפעילויות</h1>
    </hgroup>
    <div>
        <asp:Label runat="server" Text="בחר גן" />
        <asp:DropDownList runat="server" ID="Gardens" DataTextField="Name" DataValueField="Id" />

        <div>
            <asp:Button ID="Show" runat="server" Text="הצג" OnClick="ShowClick" />
        </div>

        <asp:DataGrid ID="ActivitiesGrid" runat="server" AutoGenerateColumns="False" CssClass="Grid">
            <Columns>
                <asp:BoundColumn DataField="Name" HeaderText="שם הפעילות" />
                <asp:TemplateColumn HeaderText="סוג">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="Type" Text='<%# EnumUtils.GetDescriptionOfEnumValue(typeof (ActivityTypes),Enum.GetName(typeof (ActivityTypes),Eval( "Type"))) %>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="גן">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="KindergardenName" Text='<%#Bind("Kindergarden.Name")%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="תאריך">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="KindergardenName" Text='<%# ((DateTime)Eval("Date")).ToShortDateString()%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Info" HeaderText="מידע נוסף" />
            </Columns>
        </asp:DataGrid>
    </div>
</asp:Content>
