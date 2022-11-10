<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ProductOverview.aspx.cs" Inherits="Shop.ProductOverview" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  

    <div class="container ">
        
            <asp:Label ID="lblMessage" runat="server" CssClass="row p-2 alert alert-danger " role="alert" Visible="false"></asp:Label>
        
        <div class="form-row py-4">
            <div class="form-inline    float-lg-left ">
                <asp:TextBox class="form-control  " ID="txtSearch" runat="server" placeholder="Product Name" aria-label="Product Name"></asp:TextBox>
                <asp:Button class="btn btn-outline-success " ID="btnSearch" runat="server" Text="Search" type="submit" OnClick="btnSearch_Click" />
            </div>

        </div>
        <div class="row">
            <div class="col-lg-6">
                <h1>Products</h1>
                <p>
                    <asp:GridView ID="GridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="5" Width="437px">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#2461BF" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </p>

            </div>
            <div class="col-lg-6">
                <h1>CRUD operations</h1>
                <table style="width: 95%; float: left">
                    <tr id="trowId" runat="server" visible="false">
                        <td style="width: 95px; height: 40px;">ID</td>
                        <td style="height: 40px" aria-hidden="False">
                            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trowName" runat="server">
                        <td id="lblId" style="width: 95px; height: 40px;">Name</td>
                        <td style="height: 38px">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trowPrice" runat="server">
                        <td id="lblPrice" style="width: 95px; height: 38px;">Price</td>
                        <td style="height: 38px">
                            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 95px">&nbsp;</td>
                        <td>
                            <asp:Button class="btn btn-primary" ID="btnAdd" runat="server" Text="Add" type="submit" OnClick="btnAdd_Click" />

                            <asp:Button class="btn btn-primary" ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                            <asp:Button class="btn btn-primary" ID="btnDelete" runat="server" Text="Delete" type="submit" OnClick="btnDelete_Click" />
                            <asp:Button class="btn btn-primary" ID="btnCancel" runat="server" Text="Cancel" type="submit" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
     
</asp:Content>
