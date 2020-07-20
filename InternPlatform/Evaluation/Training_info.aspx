<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Training_info.aspx.cs" Inherits="InternPlatform.Evaluation.Training_info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Training information</div>
        <div class="panel-body">

                <form class="form-horizontal" role="form">
            <div class="form-group">
                <label class="col-sm-2 control-label">Institution</label>
                <div class="col-sm-4">
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </div>
                <label class="col-sm-2 control-label">Training hours</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </div>
            </div>

                <div class="form-group">
                <label class="col-sm-2 control-label">Training start date</label>
                <div class="col-xs-4">
                    <asp:TextBox ID="TextBox1" runat="server" Text="date"></asp:TextBox>
                </div>
                  <label class="col-sm-2 control-label" ">Training end date</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBox2" runat="server" Text="date"></asp:TextBox>
                </div>
            </div>

                <div class="form-group">
                <label class="col-sm-2 control-label">Major</label>
                <div class="col-sm-4">
                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                </div>
                     <label class="col-sm-2 control-label">GPA</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </div>
            </div>

                <div class="form-group">
                    <label class="col-sm-2 control-label">Academic Id</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </div>
                <label class="col-sm-2 control-label">Supervisor's name</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </div>
              </div>

                <div class="form-group">
                    <label class="col-sm-2 control-label">Supervisor's phone number</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </div>
                <label class="col-sm-2 control-label">Supervisor's email</label>
                <div class="col-sm-4 ">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </div>
            </div>
        </form>

        <div class="col-sm-offset-4 col-sm-8">
            <asp:Button ID="Previous" runat="server" Text="Previous" OnClick="Previous_Click" />
                        <asp:Button ID="Next" runat="server" Text="Next" />
                </div>
        </div>
    </div>
</asp:Content>