<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchUser.aspx.cs" Inherits="KindergartenApp.Search.SearchUser" MasterPageFile="../Site.Master" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>חיפוש</h2>
    </hgroup>
    <div>

        <table id="PersonFilter">
            <tr>
                <td>
                    <asp:Label runat="server" Text="תעודת זהות" />
                    <asp:TextBox runat="server" ID="IdFilter" />
                </td>
                <td>
                    <asp:Label runat="server" Text="שם פרטי" />
                    <asp:TextBox runat="server" ID="FirstNameFilter" />
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="שם משפחה" />
                    <asp:TextBox runat="server" ID="LastNameFilter" />
                </td>
                <td>
                    <asp:Label runat="server" Text="תאריך לידה" />
                    <asp:TextBox runat="server" ID="BirthDate" />
                    <cc1:CalendarExtender ID="txtBirthDate_CalendarExtender" runat="server" TargetControlID="BirthDate"
                        FirstDayOfWeek="Sunday" Format="dd/MM/yyyy" />
                </td>
            </tr>
        </table>

        <asp:Button runat="server" ID="Search" Text="חפש" OnClick="SearchClick" />
    </div>
    <div>
        <asp:Label ID="Label4" runat="server" Text="תוצאות חיפוש:" />
        <asp:DataGrid ID="EntitiesGrid" runat="server" AutoGenerateColumns="False" OnDeleteCommand="DeleteUser"
             ShowHeader="True" DataKeyField="Id" OnEditCommand="EditUser">
            <Columns>
                <asp:BoundColumn HeaderText="ת.ז" DataField="IdNum" />
                <asp:BoundColumn HeaderText="שם פרטי" DataField="FirstName" />
                <asp:BoundColumn HeaderText="שם משפחה" DataField="LastName" />
                 <asp:BoundColumn HeaderText="תאריך לידה" DataField="BirthDay"  DataFormatString="{0:dd/MM/yyyy}"  />
                <asp:EditCommandColumn HeaderText="ערוך" CancelText="בטל" EditText="ערוך" UpdateText="שמור" />
                <asp:ButtonColumn HeaderText="מחק" CommandName="Delete"  Text="מחק"/>
            </Columns>
        </asp:DataGrid>
    </div>
</asp:Content>
