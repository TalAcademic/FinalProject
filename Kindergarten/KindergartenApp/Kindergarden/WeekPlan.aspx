﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeekPlan.aspx.cs" Inherits="KindergartenApp.Kindergarden.WeekPlan" MasterPageFile="../Site.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>תכנון שבועי</h2>
    </hgroup>
    <div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="בחר גן" />
            <asp:DropDownList runat="server" ID="Gardens" DataTextField="Name" DataValueField="Id" />
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="בחר תאריך:"></asp:Label>
            <asp:Calendar ID="Calendar" runat="server" SelectionMode="DayWeek"></asp:Calendar>
        </div>
        <div>
            <asp:Button runat="server" ID="Plan" Text="תכנן" OnClick="Planclick"/>
        </div>
        <div>
            אירועי השבוע:
        יום הולדת לשני לוי
   
        </div>
        <div>
            רשימת קניות:
       
            <br />
            3 חלב
          
            <br />
            4 כיכרות לחם
          
            <br />
            2 ממרחי שוקולד
          
            <br />
            5 חבילות במבה
          
            <br />
            6 חבילות ביסלי
          
            <br />
            1 חבילת בלונים
          
            <br />
            30 תפוחים
          
            <br />
            30 אפרסקים
          
            <br />
            4 חבילות וופלה
          
            <br />
        </div>
    </div>
</asp:Content>
