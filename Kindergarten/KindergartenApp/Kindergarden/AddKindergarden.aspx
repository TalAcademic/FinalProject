<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddKindergarden.aspx.cs"
    Inherits="KindergartenApp.AddKindergarden" MasterPageFile="../Site.Master" Title="AddGarden" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>הוספת גן חדש למערכת</h2>
    </hgroup>
    <div>

        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Text="שם:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Name" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="עיר:" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="Cities" DataTextField="Value" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="כמות ילדים:" /></td>
                <td>
                    <asp:TextBox runat="server" ID="ChildrenNum" /></td>

            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="גננת:" /></td>
                <td>
                    <asp:DropDownList runat="server" ID="Teachers" DataTextField="FullName" DataValueField="Id" /></td>

            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="הוסף גן" OnClick="SaveClick" Font-Size="15px" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" Text="ילדים בגן:" />

                </td>
            </tr>
             <tr>
                 <td>
                     <asp:Label ID="Label1" runat="server" Text="בחר ילד" />
                 </td>
                <td>
                    <asp:DropDownList runat="server" ID="ChildrenList" DataTextField="FullName" DataValueField="Id" />
                </td>
                <td>
                    <asp:Button ID="AddChild" runat="server" Text="הוסף לגן" Font-Size="10px" OnClick="AddChildClick" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DataGrid ID="ChildrenGrid" runat="server" AutoGenerateColumns="False" ShowHeader="True" >
                        <Columns>
                            <asp:BoundColumn HeaderText="ת.ז" DataField="Id" />
                            <asp:BoundColumn HeaderText="שם פרטי" DataField="FirstName" />
                            <asp:BoundColumn HeaderText="שם משפחה" DataField="LastName" />
                            <asp:EditCommandColumn HeaderText="ערוך" CancelText="בטל" EditText="ערוך" UpdateText="שמור" />
                            <asp:ButtonColumn HeaderText="מחק" CommandName="Delete" />
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>

           
        </table>

    </div>
</asp:Content>
