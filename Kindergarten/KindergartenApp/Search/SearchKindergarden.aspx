<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchKindergarden.aspx.cs" Inherits="KindergartenApp.Search.SearchKindergarden" MasterPageFile="../Site.Master" %>
<%@ Import Namespace="Kindergarten.BL.Utils" %>
<%@ Import Namespace="Kindergarten.Domain.Entities" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>חיפוש</h2>
    </hgroup>
    <div>
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

        <asp:Button runat="server" ID="Search" Text="חפש" OnClick="SearchClick"/>
    </div>
    <div>
        <asp:Label runat="server" Text="תוצאות חיפוש:" />
        <asp:DataGrid ID="EntitiesGrid" runat="server" AutoGenerateColumns="False" CssClass="Grid"
             OnItemCommand="GridCommand" DataKeyField="Id">
            <Columns>
                <asp:BoundColumn HeaderText="מזהה" DataField="Id" />
                <asp:BoundColumn HeaderText="שם הגן" DataField="Name" />
                <asp:BoundColumn HeaderText="שם הגננת" DataField="Teacher" />
                <asp:TemplateColumn HeaderText="עיר">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="City" Text='<%# EnumUtils.GetDescriptionOfEnumValue(typeof (Cities),Enum.GetName(typeof (Cities), Eval( "City")))%>'/>
                    </ItemTemplate>
                </asp:TemplateColumn>
                 <asp:BoundColumn HeaderText="מספר ילדים" DataField="ChildQty" />
                <asp:EditCommandColumn HeaderText="ערוך" CancelText="בטל" EditText="ערוך" UpdateText="שמור" />
                <asp:ButtonColumn HeaderText="מחק" CommandName="Delete" Text="מחק"/>
            </Columns>

        </asp:DataGrid>
    </div>
</asp:Content>
