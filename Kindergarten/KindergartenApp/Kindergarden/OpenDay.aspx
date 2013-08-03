<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenDay.aspx.cs" Inherits="KindergartenApp.Kindergarden.OpenDay" MasterPageFile="../Site.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>פתיחת יום</h2>
    </hgroup>
    <div>
        <asp:Label runat="server" Text="בחר גן:" />
        <asp:DropDownList runat="server" ID="Gardens"  DataTextField="Name" DataValueField="Id"/>
    </div>
    <div>
        <asp:Label runat="server" Text="בחר תאריך:"></asp:Label>
        <asp:Calendar runat="server" id="DatePicker" />
    </div>
    <div>
        <asp:Button runat="server" ID="ShowAttendande" OnClick="ShowAttendanceClick" Text="הצג" />
    </div>
    <div>
        <asp:DataGrid runat="server" ID="ChildrenGrid" AutoGenerateColumns="False" OnEditCommand="EditChild">
            <Columns>
                  <asp:TemplateColumn HeaderText="מזהה" Visible="False">
                    <ItemTemplate>
                        <asp:Label  ID="Id" runat="server" Text='<%#Bind("Child.Id")%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="ת.ז">
                    <ItemTemplate>
                        <asp:Label  ID="IdNum" runat="server" Text='<%#Bind("Child.IdNum")%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="שם פרטי">
                    <ItemTemplate>
                        <asp:Label  ID="FirstName" runat="server" Text='<%#Bind("Child.FirstName")%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="שם משפחה">
                    <ItemTemplate>
                        <asp:Label ID="LastName" runat="server" Text='<%#Bind("Child.LastName")%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="הגיע?">
                    <ItemTemplate>
                           <asp:CheckBox runat="server"  ID="Arrived" Checked='<%# Bind("Arrived")%>'/>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:EditCommandColumn HeaderText="ערוך" CancelText="בטל" EditText="ערוך" UpdateText="שמור" />
            </Columns>
        </asp:DataGrid>
    </div>
    <div>
        <asp:Button runat="server" ID="Save" OnClick="SaveClick" Text="שמור"/>
    </div>
</asp:Content>
