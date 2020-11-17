 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testTypeForm.aspx.cs" Inherits="DiagnosticCenterBillManagementSystemApp.testTypeForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h5>Test Type Form</h5>
       <div class="col-md-3"></div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="control-label">Type Name</label>
                <asp:TextBox ID="typeNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:HiddenField ID="idHiddenField1" runat="server" />
                <div class="col-md-2 btn-group">
                     <asp:Button ID="saveButton" CssClass="btn btn-primary btn-lg" runat="server" Text="Save" OnClick="saveButton_Click" />
                </div>
                 <div class="col-md-2 btn-group">
                      <asp:Button ID="findButton" CssClass="btn btn-primary btn-lg" runat="server" Text="Find" OnClick="findButton_Click" />
                 </div>
                <div class="col-md-2 btn-group">
                      <asp:Button ID="updateButton" CssClass="btn btn-default btn-lg" runat="server" Text="Update" OnClick="updateButton_Click" />
                 </div>
                <div class="col-md-2 btn-group">
                      <asp:Button ID="deleteButton" CssClass="btn btn-danger btn-lg" runat="server" Text="Delete" OnClick="deleteButton_Click" />
                 </div>
            </div>
              
            <div class="form-group">
                <asp:Label ID="massageLabel" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="col-md-3"></div>
    </div>
    
   <div class="row">
       <div class="col-md-12"></div>
   </div>

    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <asp:GridView ID="tetTypeGridView" CssClass="table table-bordered table-hover"  runat="server" OnSelectedIndexChanged="tetTypeGridView_SelectedIndexChanged" AutoGenerateColumns="False">
                <Columns>
                    
                    <asp:TemplateField HeaderText="Serial">
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="gdvSerialLabel" runat="server" Text='<%#Eval("Serial")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Type Name">
                         <ItemStyle HorizontalAlign="Left" Width="90%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="gdvTypeNameLabel" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-2"></div>
    </div>
</asp:Content> 
