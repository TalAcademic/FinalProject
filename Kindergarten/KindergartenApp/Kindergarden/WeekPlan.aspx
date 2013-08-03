<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeekPlan.aspx.cs" Inherits="KindergartenApp.Kindergarden.WeekPlan" MasterPageFile="../Site.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>תכנון שבועי</h2>
    </hgroup>
    <div>

        <div>
            <asp:Label ID="Label1" runat="server" Text="בחר תאריך:"></asp:Label>
            <asp:Calendar ID="Calendar" runat="server" SelectionMode="DayWeek"></asp:Calendar>
        </div>
        <div>
            
            <asp:Button runat="server" ID="Plan" Text="תכנן" OnClick="Planclick"/>
            
            <div  >
                <asp:Label ID="ListLabel" runat="server" Text="רשימת אירועים" Visible="False"></asp:Label>
                <br/>
                <asp:ListView ID="ListView1" runat="server" DataMember="Title"> 
                    <LayoutTemplate>
                      <div >
                         <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                      </div>
                   </LayoutTemplate>
                   <ItemTemplate>
                      <div style="width: 500px">
                         <%# Eval("Title")%>
                      </div>
                   </ItemTemplate>
                   <AlternatingItemTemplate>
                      <div style=" background-color: #dadada;width: 500px">
                         <%# Eval("Title")%>
                      </div>
                   </AlternatingItemTemplate>
                   <EmptyDataTemplate>
                      No records found
                   </EmptyDataTemplate>
                </asp:ListView>
            </div>
            <br/>
            <br/>

            <div>
                <asp:Label ID="ProductsLabel" runat="server" Text="רשימת קניות" Visible="False"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="פריט" />
                        <asp:BoundField DataField="Quantity" HeaderText="כמות" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
    </div>
</asp:Content>
