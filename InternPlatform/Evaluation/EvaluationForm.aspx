<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EvaluationForm.aspx.cs" Inherits="InternPlatform.Evaluation.EvaluationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Personal information</div>
        <div class="panel-body">

            <form class="form-horizontal" role="form">
                <div class="form-group">
                    <label class="col-sm-2">First Name</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="Name" runat="server" placeholder="English"></asp:TextBox>

                        <asp:TextBox ID="Aname" runat="server" placeholder="Arabic"></asp:TextBox>
                    </div>
                    <label class="col-sm-2">Father Name</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="Father" runat="server" placeholder="English"></asp:TextBox>

                        <asp:TextBox ID="Afather" runat="server" placeholder="Arabic"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2">Grand Father Name</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="Grand" runat="server" placeholder="English"></asp:TextBox>

                        <asp:TextBox ID="Agrand" runat="server" placeholder="Arabic"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2">Last name</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="Last" runat="server" placeholder="English"></asp:TextBox>

                        <asp:TextBox ID="Alast" runat="server" placeholder="Arabic"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2">Nationality</label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="DdlNation" runat="server"></asp:DropDownList>
                    </div>

                    <label class="col-sm-2">Date of Birth</label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="Dob" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                
                    <label class="col-sm-2">Gender</label>

                    <asp:RadioButtonList ID="Gender" runat="server">
                        <asp:ListItem Value="0">Male</asp:ListItem>
                        <asp:ListItem Value="1">Female</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-group">
                    <label class="col-sm-2">ID Type </label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="Type" runat="server">
                            <asp:ListItem>National ID</asp:ListItem>
                            <asp:ListItem>Iqama ID</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <label class="col-sm-2">ID Number</label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="IDNo" runat="server"></asp:TextBox>
                  </div>
                
                    <label class="col-sm-2">ID Issue Date</label>
                    <div class="col-sm-3">
                    <asp:TextBox ID="IssueDate" runat="server" TextMode="Date"></asp:TextBox>
                </div>
            </form>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <div class="row" style="align-items: center">
                <asp:Button ID="ToTrainInfo" runat="server" Text="Next" OnClick="ToTrainInfo_Click" />
            </div>
        </div>
    </div>
    </label>
</asp:Content>