<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="KindergartenApp.User.ChangePassword" MasterPageFile="../Site.Master" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>החלפת סיסמא</h2>
    </hgroup>
    <div>
        <asp:Label runat="server" Text="הזן את הסיסמא החדשה"/>
        <asp:TextBox runat="server"/>
    </div>
    <div>
        <asp:Button runat="server" Text="שמור"/>
    </div>
    </asp:Content>