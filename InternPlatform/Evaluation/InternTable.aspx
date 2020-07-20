<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InternTable.aspx.cs" Inherits="InternPlatform.Evaluation.InternTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Admin Crud Ops</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-sm-10">

                    
                    <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" ShowFooter="true" AllowPaging="True" OnPageIndexChanging="OnPaging" DataKeyNames="InternID"
                        OnRowCommand="GV_RowCommand" OnRowEditing="GV_RowEditing" OnRowCancelingEdit="GV_RowCancelingEdit"
                        OnRowUpdating="GV_RowUpdating" OnRowDeleting="GV_RowDeleting"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">


                        <%-- Theme Properties --%>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />

                        <Columns>
                            <asp:TemplateField HeaderText="First Name">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Fname") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFirstName" Text='<%# Eval("Fname") %>' runat="server" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFirstNameFooter" runat="server" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Lname") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLastName" Text='<%# Eval("Lname") %>' runat="server" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtLastNameFooter" runat="server" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Email") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmail" Text='<%# Eval("Email") %>' runat="server" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtEmailFooter" runat="server" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                                    <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                    <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ImageUrl="~/Images/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="col-sm-2">
                    <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
                    <br />
                    <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>