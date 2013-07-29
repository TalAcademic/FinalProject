<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="KindergartenApp.User.ChangePassword" MasterPageFile="../Site.Master" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>החלפת סיסמא</h2>
    </hgroup>
    <div>
        <asp:Label runat="server" Text="הזן את הסיסמא החדשה"/>
        <asp:TextBox runat="server" id="NewPassword"/>
        <asp:RequiredFieldValidator  runat="server" ControlToValidate="NewPassword" ErrorMessage="*" ToolTip="שדה חובה" SetFocusOnError="True" CssClass="message-error" />
    </div>
    <div>
        <asp:Button runat="server" Text="שמור" OnClick="SaveClick"/>
    </div>
    </asp:Content>