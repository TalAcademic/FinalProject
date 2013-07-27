<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="KindergartenApp.User.AddUser" MasterPageFile="../Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>הוספת משתמש חדש למערכת</h2>
    </hgroup>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="תעודת זהות:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Id" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Id" ErrorMessage="*" ToolTip="שדה חובה" SetFocusOnError="True" CssClass="message-error"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="שם פרטי:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="FirstName" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="שם משפחה:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="LastName" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="טלפון:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Phone" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="תאריך לידה:" />
                </td>
                <td>

                    <asp:TextBox runat="server" ID="BirthDate" />
                    <cc1:TextBoxWatermarkExtender ID="txtBirthDate_TextBoxWatermarkExtender" runat="server"
                        TargetControlID="BirthDate" WatermarkCssClass="watermark" WatermarkText="DD/MM/YYYY" />
                    <cc1:CalendarExtender ID="txtBirthDate_CalendarExtender" runat="server" TargetControlID="BirthDate"
                        FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
                    <asp:RequiredFieldValidator ID="txtBirthDate_RequiredFieldValidator" runat="server"
                        ErrorMessage="חובה להזין תאריך" ControlToValidate="BirthDate"
                        Display="Dynamic" EnableClientScript="true" ValidationGroup="YourValGroup"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="txtBirthDate_RegularExpressionValidator" runat="server"
                        ErrorMessage="יש להזין תאריך בפורמט DD/MM/YYYY" ControlToValidate="BirthDate"
                        Display="Dynamic" EnableClientScript="true" ValidationGroup="YourValGroup"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="סוג משתמש:" />

                </td>
                <td>
                    <asp:DropDownList runat="server" ID="PersonTypes" 
                        OnSelectedIndexChanged="PersonTypesChanged" AutoPostBack="True">
                        <Items>
                             <asp:ListItem Text="אנא בחר ערך..." Value="0" Selected="True" />
                            <asp:ListItem Text="גננת" Value="2" />
                            <asp:ListItem Text="ילד" Value="1" />
                            <asp:ListItem Text="מפקחת" Value="3" />
                        </Items>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <div id="ChildData" runat="server" Visible="False">
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="רגישויות" />
                    </td>
                    <td>
                        <asp:CheckBoxList runat="server" ID="Sensetivities" RepeatDirection="Horizontal" 
                             DataTextField="Description" DataValueField="Id"/>
                        
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="Other" Width="80px" />
                        <cc1:TextBoxWatermarkExtender ID="OtherWatermarkExtender" runat="server"
                            TargetControlID="Other" WatermarkCssClass="watermark" WatermarkText="הזן ערך אחר" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="TeacherData"  runat="server" Visible="False">
        <table >
            <tr>
                <td>
                    <asp:Label runat="server" Text="ותק:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Sen" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="גננת מחליפה:" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="Teachers" /></td>
            </tr>
        </table>
            </div>
        <div>
            
             <div id="SupervisorData"  runat="server" Visible="False">
        <table >
            <tr>
                <td>
                    <asp:Label runat="server" Text="עיר:" />
                </td>
                <td>
                   <asp:DropDownList runat="server" ID="Cities"  DataTextField="Value" />
                </td>
            </tr>
        </table>
            </div>
        <div>
            
            <asp:Button ID="Save" runat="server" Text="שמור" Font-Size="15px" OnClick="SaveClick"  />

        </div>

    </div>
</asp:Content>
