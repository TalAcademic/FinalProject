<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchKindergarden.aspx.cs" Inherits="KindergartenApp.Reports.SearchKindergarden" MasterPageFile="../Site.Master" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>חיפוש</h2>
    </hgroup>
    <div>
       <%-- <asp:Label runat="server" Text="בחר ישות לחיפוש:"></asp:Label>
        <asp:DropDownList runat="server" ID="Entities" />--%>
    </div>
    <table id="KinderGardenFilter" >
        <tr>
            <td>
                <asp:Label runat="server" Text="שם הגן" />
                <asp:TextBox runat="server" ID="GardenNameFilter" />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="עיר" />
                <asp:DropDownList runat="server" ID="CitiesFilter" DataTextField="Value" DataValueField="Key"  />

            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="גננת" />
                <asp:DropDownList runat="server" ID="TeachersFilter"  DataTextField="FullName" DataValueField="Id"/>
            </td>
        </tr>
    </table>
    <div>

        <%--<table id="PersonFilter" >
            <tr>
                <td>
                    <asp:Label runat="server" Text="תעודת זהות" />
                    <asp:TextBox runat="server" ID="IdFilter"  />
                </td>
                <td>
                    <asp:Label runat="server" Text="שם פרטי" />
                    <asp:TextBox runat="server" ID="FirstNameFilter" />
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="שם משפחה" />
                    <asp:TextBox runat="server" ID="LastNameFilter" />
                </td>
            </tr>
        </table>--%>

        <asp:Button runat="server" ID="Search" Text="חפש" OnClick="SearchClick"/>
    </div>
    <div>
        <asp:Label runat="server" Text="תוצאות חיפוש:" />
        <asp:DataGrid ID="EntitiesGrid" runat="server" AutoGenerateColumns="False" OnItemCommand="GridCommand" DataKeyField="Id">
            <Columns>
                <asp:BoundColumn HeaderText="מזהה" DataField="Id" />
                <asp:BoundColumn HeaderText="שם הגן" DataField="Name" />
                <asp:BoundColumn HeaderText="שם הגננת" DataField="Teacher" />
                <asp:BoundColumn HeaderText="עיר" DataField="City" />
                 <asp:BoundColumn HeaderText="מספר ילדים" DataField="ChildQty" />
                <asp:EditCommandColumn HeaderText="ערוך" CancelText="בטל" EditText="ערוך" UpdateText="שמור" />
                <asp:ButtonColumn HeaderText="מחק" CommandName="Delete" Text="מחק"/>
            </Columns>

        </asp:DataGrid>
<%--        <asp:DataGrid ID="EntitiesGrid" runat="server" AutoGenerateColumns="False" ShowHeader="True">
            <Columns>
                <asp:BoundColumn HeaderText="ת.ז" DataField="Id" />
                <asp:BoundColumn HeaderText="שם פרטי" DataField="FirstName" />
                <asp:BoundColumn HeaderText="שם משפחה" DataField="LastName" />
                <asp:EditCommandColumn HeaderText="ערוך" CancelText="בטל" EditText="ערוך" UpdateText="שמור" />
                <asp:ButtonColumn HeaderText="מחק" CommandName="Delete" />
            </Columns>
        </asp:DataGrid>--%>
    </div>
</asp:Content>
