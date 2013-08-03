<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenDay.aspx.cs" Inherits="KindergartenApp.Kindergarden.OpenDay" MasterPageFile="../Site.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>פתיחת יום</h2>
    </hgroup>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="בחר גן:" /></td>
            <td>
                <asp:DropDownList runat="server" ID="Gardens" DataTextField="Name" DataValueField="Id" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="בחר תאריך:"></asp:Label></td>
            <td>
                <asp:Calendar runat="server" ID="DatePicker" />
            </td>
            <td>
                <asp:CustomValidator runat="server" ID="CalendarValidator"
                    ErrorMessage="*" ToolTip="שדה חובה" SetFocusOnError="True" CssClass="field-validation-error" /></td>
        </tr>
    </table>
    <div>
        <asp:Button runat="server" ID="ShowAttendande" OnClick="ShowAttendanceClick" Text="הצג" />
    </div>
    <div>
        <asp:Label ID="ListLabel" runat="server" Text="רשימת אירועים" Visible="False"></asp:Label>
        <br />
        <asp:ListView ID="ListView1" runat="server" DataMember="Title">
            <LayoutTemplate>
                <div>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div style="width: 500px">
                    <%# Eval("Title")%>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div style="background-color: #dadada; width: 500px">
                    <%# Eval("Title")%>
                </div>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                אין אירועים
           
            </EmptyDataTemplate>
        </asp:ListView>
    </div>

    <br />
    <br />
    <div>
        <asp:DataGrid runat="server" ID="ChildrenGrid" AutoGenerateColumns="False" OnEditCommand="EditChild"  CssClass="Grid">
            <Columns>
                <asp:TemplateColumn HeaderText="מזהה" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="Id" runat="server" Text='<%#Bind("Child.Id")%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="ת.ז">
                    <ItemTemplate>
                        <asp:Label ID="IdNum" runat="server" Text='<%#Bind("Child.IdNum")%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="שם פרטי">
                    <ItemTemplate>
                        <asp:Label ID="FirstName" runat="server" Text='<%#Bind("Child.FirstName")%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="שם משפחה">
                    <ItemTemplate>
                        <asp:Label ID="LastName" runat="server" Text='<%#Bind("Child.LastName")%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="הגיע?">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="Arrived" Checked='<%# Bind("Arrived")%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:EditCommandColumn HeaderText="ערוך" CancelText="בטל" EditText="ערוך" UpdateText="שמור" />
            </Columns>
        </asp:DataGrid>
    </div>
    <div>
        <asp:Button runat="server" ID="Save" OnClick="SaveClick" Text="שמור" />
    </div>
</asp:Content>
