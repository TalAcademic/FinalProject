﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="KindergartenApp.Main" MasterPageFile="/Site.Master" %>

<%@ Import Namespace="Kindergarten.Domain.Entities" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2 id="GeneralTitle" runat="server">ברך הבא, נא התחבר למערכת</h2>
        <h2 id="LogedInTitle" runat="server"><%= ((Person) Session["CurrentUser"]).FullName %>, ברוך/ה הבאה למערכת</h2>
    </hgroup>

    <div id="MessagesDiv" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="ההודעות האחרונות שלך במערכת(לחץ לצפיה)" />
        </div>
        <br />
        <marquee direction="down" scrollamount="2">
        <asp:DataGrid runat="server" ID="Messages" AutoGenerateColumns="False">
          <Columns>
              <asp:TemplateColumn>
                  <ItemTemplate >
                <a  class="label" href='./Messaging/ViewMessage.aspx?messageId=<%#Eval("Id") %>'> <%#((DateTime)Eval("SendTime")).ToShortDateString()  + " \"" + Eval("Title") + "\""%> </a>
            </ItemTemplate>
              </asp:TemplateColumn>
          </Columns>
            </asp:DataGrid>
    </marquee>
    </div>
</asp:Content>
