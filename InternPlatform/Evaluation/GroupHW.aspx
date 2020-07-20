<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupHW.aspx.cs" Inherits="InternPlatform.Evaluation.GroupHW" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>

        <br />
    </p>
    <table class="nav-justified">
        <br />
        <br />
        <tr>
            <td colspan="2">
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 160px; height: 22px;">Intern Id</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtInternId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 160px">First Name English</td>
            <td>
                <asp:TextBox ID="txtFnameEn" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 160px">First Name Arabic </td>
            <td>
                <asp:TextBox ID="txtFnameAr" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 160px">Country</td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 160px; height: 24px;">Salary</td>
            <td style="height: 24px">
                <asp:TextBox ID="textSalary" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 160px">Gender</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem Value="1">Female</asp:ListItem>
                    <asp:ListItem Value="0">Male</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="width: 160px" id="Hobbies">Hobbies</td>
            <td id="Ho">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Swimming" />
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Traviling" />
                <asp:CheckBox ID="CheckBox3" runat="server" Text="Blogging" />

                <br>
            </td>
            <tr>
                <td style="width: 60px; height: 100px;"></td>
                <td style="height: 100px">
                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" BackColor="#FFFFE1" ForeColor="Black" Height="25px" Width="149px" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" BackColor="#FFFFE1" Height="25px" Width="150px" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" BackColor="#FFFFE1" Height="25px" Width="150px" />
                    <p></p>
                    <asp:Button ID="btnShowData" runat="server" Text="Show Data" OnClick="btnShowData_Click" BackColor="#FFFFE1" Height="25px" Width="150px" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" BackColor="#FFFFE1" Height="25px" Width="150px" />
                    <asp:Button ID="btnShowIntern" runat="server" OnClick="btnShowIntern_Click" Text="Show Intern" BackColor="#FFFFE1" Height="25px" Width="150px" />
                    <br />
                    <br />
                    <asp:GridView ID="gvIntern" runat="server" BorderColor="Black" BorderStyle="Double" ForeColor="Black">
                    </asp:GridView>
                </td>
            </tr>
    </table>
</asp:Content>