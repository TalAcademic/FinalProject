<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activities.aspx.cs" Inherits="KindergartenApp.Kindergarden.Activities" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>צפיה בפעילויות</h1>
    </hgroup>
    <div>
        <asp:Label runat="server" Text="בחר גן" />
        <asp:DropDownList runat="server" >
            <Items>
                <asp:ListItem Text="גן המגדלור" />
            </Items>
        </asp:DropDownList>
        <div>
            <asp:Button ID="Button1" runat="server" Text="הצג" />

        </div>

        <asp:GridView ID="ActivitiesGrid" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="שם הפעילות" />
                <asp:BoundField DataField="Kindergarden.Name" HeaderText="גן" />
                <asp:BoundField DataField="Type" HeaderText="סוג הפעילות" />
                <asp:BoundField DataField="Date" HeaderText="תאריך הפעילות" />
                <asp:BoundField DataField="Info" HeaderText="מידע נוסף" />
            </Columns>
            <RowStyle HorizontalAlign="Right" />
        </asp:GridView>
    </div>
</asp:Content>
