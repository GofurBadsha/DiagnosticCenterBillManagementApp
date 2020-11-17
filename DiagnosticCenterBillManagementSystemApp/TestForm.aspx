<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestForm.aspx.cs" Inherits="DiagnosticCenterBillManagementSystemApp.TestForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <d iv class="row">
        <div class="col-md-12">Test Form</div>
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="control-label">Test Name</label>
                <asp:TextBox ID="testNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            
             <div class="form-group">
                <label class="control-label">Fee (BDT)</label>
                <asp:TextBox ID="feeTextBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            
              <div class="form-group">
                <label class="control-label">Test Name</label>
                  <asp:DropDownList ID="testTypeDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            
            <asp:HiddenField ID="idHiddenField" runat="server" />
            <div class="form-group">
                <div class="col-md-2 btn-group">
                    <asp:Button ID="saveButton" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="saveButton_Click" />
                </div>
                
                
                <div class="col-md-2 btn-group">
                    <asp:Button ID="findButton" runat="server" CssClass="btn btn-primary" Text="Find" OnClick="findButton_Click" />
                </div>
                
                
                <div class="col-md-2 btn-group">
                    <asp:Button ID="updatButton" runat="server" CssClass="btn btn-default" Text="Update" OnClick="updatButton_Click" />
                </div>
                
                
                <div class="col-md-2 btn-group">
                    <asp:Button ID="deleteButton" runat="server" CssClass="btn btn-danger" Text="Delete" OnClick="deleteButton_Click" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="massageLabel" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="col-md-3"></div>
    </d>
    
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <asp:GridView ID="testGridView" CssClass="table table-bordered table-hover" runat="server"></asp:GridView>
            <columns>
                    <asp:TemplateField HeaderText="Serial">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="gdvSerialLabel" runat="server" Text='<%#Eval("Serial")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Test Name">
                         <ItemStyle HorizontalAlign="Left" Width="400%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="gdvTestNameLabel" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Fee (BDT)">
                         <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="gdvFeeLabel" runat="server" Text='<%#Eval("Fee")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Test Name">
                         <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="gdvTypenameLabel" runat="server" Text='<%#Eval("TestTypeName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </columns>
        </div>
        <div class="col-md-2"></div>
    </div>

</asp:Content>
