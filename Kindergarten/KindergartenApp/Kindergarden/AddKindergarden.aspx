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
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Name" ErrorMessage="*" ToolTip="שדה חובה" SetFocusOnError="True" CssClass="field-validation-error" />
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
                    <asp:Label runat="server" Text="כמות ילדים מקסימלית:" /></td>
                <td>
                    <asp:TextBox runat="server" ID="ChildrenNum" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ChildrenNum" ErrorMessage="*" ToolTip="שדה חובה" SetFocusOnError="True" CssClass="field-validation-error" />
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="גננת:" /></td>
                <td>
                    <asp:DropDownList runat="server" ID="Teachers" DataTextField="FullName" DataValueField="Id" /></td>

            </tr>
            <tr>
                <td>
                    <asp:Button ID="SaveGarden" runat="server" Text="שמור" OnClick="SaveClick" Font-Size="15px" />
                </td>
            </tr>
            </table>
        <table runat="server" id="ChildrenData">
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
                    <asp:DataGrid ID="ChildrenGrid" runat="server" AutoGenerateColumns="False" DataKeyField="Id"
                        ShowHeader="True" OnDeleteCommand="DeleteChild"  OnEditCommand="EditChild">
                        <Columns>
                            <asp:BoundColumn HeaderText="ת.ז" DataField="IdNUm" />
                            <asp:BoundColumn HeaderText="שם פרטי" DataField="FirstName" />
                            <asp:BoundColumn HeaderText="שם משפחה" DataField="LastName" />
                            <asp:EditCommandColumn HeaderText="ערוך" CancelText="בטל" EditText="ערוך" UpdateText="שמור" />
                            <asp:ButtonColumn HeaderText="מחק" CommandName="Delete" Text="מחק" />
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>

           
        </table>

    </div>
</asp:Content>
