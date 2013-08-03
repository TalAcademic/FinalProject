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
                   <asp:TextBox ID="Name" runat="server"/>
                  <asp:RequiredFieldValidator  runat="server" ControlToValidate="Name" ErrorMessage="*" ToolTip="שדה חובה" SetFocusOnError="True" CssClass="field-validation-error" />
              </td>
          </tr>
          <tr>
               <td>
                  <asp:Label runat="server" Text="גן"/>
                 
              </td>
              <td>
                   <asp:DropDownList runat="server" ID="Gardens" DataTextField="Name" DataValueField="Id"/>
              </td>
          </tr>
          <tr>
             <td>
                  <asp:Label  runat="server" Text="סוג"/>
             </td> 
              <td>
                    <asp:DropDownList ID="Types" runat="server" DataTextField="Value" />
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label runat="server" Text="תאריך"/>
              </td>
              <td>
                  <asp:Calendar runat="server" ID="Date"/>
              </td>
              <td>
                  <asp:CustomValidator runat="server" ID="CalendarValidator" ErrorMessage="*" ToolTip="שדה חובה" SetFocusOnError="True" CssClass="field-validation-error" />
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label  runat="server" Text="מידע נוסף"/>
              </td>
              <td>
                  <asp:TextBox runat="server" TextMode="MultiLine" ID="Info"/>
              </td>
          </tr>
      </table> 
           <asp:Button ID="Save" runat="server" Text="שמור" OnClick="SaveClick"/>
    </div>
    </asp:Content>
