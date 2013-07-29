<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KindergartenApp.User.Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>התחבר למערכת</h1>
    </hgroup>
    <div >
        <div>
            <asp:Label ID="Label1" runat="server" Text="תעודת זהות" />
            <asp:TextBox runat="server" ID="UserName" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="message-error" ToolTip="שדה חובה" ErrorMessage="*" />
            <asp:CustomValidator  ID="UserValidator" runat="server" ControlToValidate="UserName"  CssClass="message-error" ToolTip="משתמש לא קיים" ErrorMessage="*"  />
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="סיסמא" />
            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="message-error" ToolTip="שדה חובה" ErrorMessage="*" />
            <asp:CustomValidator  ID="PasswordValidator" runat="server" ControlToValidate="Password"  CssClass="message-error" ToolTip="סיסמא לא תקינה" ErrorMessage="*"  />
        </div>
          <asp:Button ID="DoLogin" runat="server" Text="התחבר" OnClick="DoLoginClick" />
    </div>
</asp:Content>
