<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="KindergartenApp.Main" MasterPageFile="/Site.Master" %>
<%@ Import Namespace="Kindergarten.Domain.Entities" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2 id="GeneralTitle" runat="server">ברך הבא, נא התחבר למערכת</h2>
        <h2 id="LogedInTitle" runat="server"><%= ((Person) Session["CurrentUser"]).FullName %>, ברוך/ה הבאה למערכת</h2>
    </hgroup>
    <div>
    <marquee direction="down" scrollamount="2" >
        <ul>
            <li><a>יום הולדת לאורן. 10/10/2013</a></li>
            <li><a>הודעה על אסיפת הורים 1/10/2013</a></li>
        </ul>
    </marquee>
    </div>
    </asp:Content>