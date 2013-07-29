<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="KindergartenApp.User.AddUser" MasterPageFile="../Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <script src="../Scripts/jquery-1.8.2.min.js"></script>
    <script>
        function showMessage() {

            alert("המשתמש התווסף בהצלחה");
        }
    </script>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Id" ErrorMessage="*" ToolTip="שדה חובה" SetFocusOnError="True" CssClass="message-error" />
                    <asp:CustomValidator  ID="IdValidator" runat="server" ControlToValidate="Id"  CssClass="message-error" ToolTip="משתמש קיים" ErrorMessage="*"  />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="שם פרטי:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="FirstName" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FirstName" ErrorMessage="*" ToolTip="שדה חובה" SetFocusOnError="True" CssClass="message-error" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="שם משפחה:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="LastName" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LastName" ErrorMessage="*" ToolTip="שדה חובה" SetFocusOnError="True" CssClass="message-error" />
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
                    <asp:Label ID="Label2" runat="server" Text="תאריך לידה:" />
                </td>
                <td>

                    <asp:TextBox runat="server" ID="BirthDate" />
                    <cc1:TextBoxWatermarkExtender ID="txtBirthDate_TextBoxWatermarkExtender" runat="server" ValidateRequestMode="Enabled"
                        TargetControlID="BirthDate" WatermarkCssClass="watermark" WatermarkText="DD/MM/YYYY" />
                    <cc1:CalendarExtender ID="txtBirthDate_CalendarExtender" runat="server" TargetControlID="BirthDate"
                        FirstDayOfWeek="Monday" Format="dd/MM/yyyy" />
                    <asp:RequiredFieldValidator ID="txtBirthDate_RequiredFieldValidator" runat="server" ErrorMessage="*"
                        ToolTip="חובה להזין תאריך" ControlToValidate="BirthDate" CssClass="message-error" />
                    <asp:RegularExpressionValidator ID="txtBirthDate_RegularExpressionValidator" runat="server"
                        ToolTip="יש להזין תאריך בפורמט DD/MM/YYYY" ControlToValidate="BirthDate" ErrorMessage="*"
                        CssClass="message-error"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" />
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
                    <asp:CompareValidator runat="server" ToolTip="חובה לבחור ערך"
                        ErrorMessage="*" Operator="GreaterThan" ControlToValidate="PersonTypes" CssClass="message-error"
                        ValueToCompare="0" />
                </td>
            </tr>
        </table>
        <div id="ChildData" runat="server" visible="False">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="רגישויות" />
                    </td>
                    <td>
                        <asp:CheckBoxList runat="server" ID="Sensetivities" RepeatDirection="Horizontal"
                            DataTextField="Description" DataValueField="Id" />

                    </td>
                </tr>
            </table>
        </div>
        <div id="TeacherData" runat="server" visible="False">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="ותק:" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="Sen" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Sen" ErrorMessage="*" ToolTip="שדה חובה" SetFocusOnError="True" CssClass="message-error" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="גננת מחליפה:" />
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="Teachers" DataValueField="Id" DataTextField="FullName" /></td>
                </tr>
            </table>
        </div>

        <div id="SupervisorData" runat="server" visible="False">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="עיר:" />
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="Cities" DataTextField="Value"  />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Button ID="Save" runat="server" Text="שמור" Font-Size="15px" OnClick="SaveClick" />
        </div>
    </div>
</asp:Content>

