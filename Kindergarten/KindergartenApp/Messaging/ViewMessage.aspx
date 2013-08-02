<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMessage.aspx.cs" Inherits="KindergartenApp.Messaging.ViewMessage" MasterPageFile="../Site.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>צפייה הודעה</h2>
    </hgroup>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="תאריך:" />
                </td>
                <td>
                    <asp:Label ID="Date" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="שולח:" />
                </td>
                <td>
                    <asp:Label runat="server" ID="From"  />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="כותרת:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Title" Enabled="False" ReadOnly="True"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="הודעה:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Message" Height="162px" TextMode="MultiLine" Width="500px" Enabled="False" ReadOnly="True"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
