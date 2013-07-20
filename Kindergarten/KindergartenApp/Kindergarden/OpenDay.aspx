<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenDay.aspx.cs" Inherits="KindergartenApp.Kindergarden.OpenDay" MasterPageFile="../Site.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>פתיחת יום</h2>
    </hgroup>
    <div>
        <asp:Label runat="server" Text="בחר גן:" />
        <asp:DropDownList runat="server" ID="Gardens" />
    </div>
    <div>
        <asp:Label runat="server" Text="בחר תאריך:"></asp:Label>
        <asp:Calendar runat="server" ></asp:Calendar>
    </div>
    <div>
        <asp:DataGrid runat="server" ID="ChildrenGrid" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundColumn HeaderText="ת.ז" DataField="Id" />
                <asp:BoundColumn HeaderText="שם פרטי" DataField="FirstName" />
                <asp:BoundColumn HeaderText="שם משפחה" DataField="LastName" />
                <asp:TemplateColumn HeaderText="הגיע?">
                    <ItemTemplate>
                           <asp:CheckBox runat="server"/>
                    </ItemTemplate>
                </asp:TemplateColumn>
       <%--         <asp:BoundColumn HeaderText="הגיע?"/>--%>
                <asp:EditCommandColumn HeaderText="ערוך" CancelText="בטל" EditText="ערוך" UpdateText="שמור" />
            </Columns>
        </asp:DataGrid>
    </div>
</asp:Content>
