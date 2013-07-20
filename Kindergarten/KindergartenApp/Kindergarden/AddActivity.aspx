<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddActivity.aspx.cs" Inherits="KindergartenApp.Kindergarden.AddActivity" MasterPageFile="../Site.Master" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>הוספת פעילות</h2>
    </hgroup>
    
    <div>
      <table>
          <tr>
              <td>
                  <asp:Label runat="server" Text="שם הפעילות"/>
        
              </td>
              <td>
                   <asp:TextBox ID="TextBox1" runat="server"/>
              </td>
          </tr>
          <tr>
               <td>
                  <asp:Label runat="server" Text="גן"/>
                 
              </td>
              <td>
                   <asp:DropDownList runat="server" ID="Gardens"/>
              </td>
          </tr>
          <tr>
             <td>
                  <asp:Label  runat="server" Text="סוג"/>
             </td> 
              <td>
                    <asp:DropDownList ID="Types" runat="server" DataTextField="Value"/>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label runat="server" Text="תאריך"/>
              </td>
              <td>
                  <asp:Calendar runat="server"/>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label  runat="server" Text="מידע נוסף"/>
              </td>
              <td>
                  <asp:TextBox runat="server" TextMode="MultiLine"/>
              </td>
          </tr>
      </table> 
           <asp:Button ID="Button1" runat="server" Text="שמור"/>
    </div>
    </asp:Content>
