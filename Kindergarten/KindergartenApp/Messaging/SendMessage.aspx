<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="KindergartenApp.Messaging.SendMessage" MasterPageFile="../Site.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>שליחת הודעה</h2>
    </hgroup>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="סוג הודעה:" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="Who" RepeatDirection="Horizontal" OnSelectedIndexChanged="SelectedWho"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="WhereLabel" runat="server" Text="שלח אל:" Visible="False" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="Where" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="כותרת:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Title" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="יש למלא את כותרת ההודעה" ControlToValidate="Title"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    
                    <asp:Label ID="Label2" runat="server" Text="הודעה:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Message" Height="162px" TextMode="MultiLine" Width="500px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Message" ErrorMessage="יש להזין את תוכן ההודעה"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Send" runat="server" Text="שלח" OnClick="SendClick"/>
                </td>
            </tr>
        </table>
    </div>
&nbsp;&nbsp;&nbsp; 
</asp:Content>
