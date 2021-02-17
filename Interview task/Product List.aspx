<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Product List.aspx.cs" Inherits="Interview_task.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="StyleSheet.css" rel="stylesheet" />
    <style>
        .TextBox2 {
    height: 25px;
    width: 170px;
    border: 2px solid black;
    border-radius:3px;
    padding:5px;
    margin:10px;
}

     
    </style>
    <script>

   function runScript(e) {
        if (e.keyCode == 13) {
            $("#searchbtn").click(); //jquery
            document.getElementById("searchbtn").click(); //javascript
        }
    }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body" >
        <div  class="Phead"><h3>Product List</h3></div>
        <div class="main"> 
            <div class="div2">
                <asp:Button runat="server" class="btnadd" Text="Add Product" onclick="btnadd_Click" />
<%--                <input type="button" class="btnadd" value="Add Product" onclick="btnadd"/>--%>

                <asp:TextBox ID="TextBox1" CssClass="TextBox2" runat="server" placeholder="Search" BorderColor="Black"></asp:TextBox>
               
                <asp:Button ID="searchbtn" runat="server" class="btnadd" Text="Search" OnClick="myButton_Click" />
            </div>
            <div class="grid" style="overflow-y; overflow-x">
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Found!!" Width="524px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    OnSelectedIndexChanged="getUserByID_Click" OnRowDeleting="GridView1_RowDeleting" >
                     <Columns>
                         <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                         <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                         <asp:BoundField DataField="Descripton" HeaderText="Descripton" SortExpression="Descripton" />
                         <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                         <asp:CommandField HeaderText="Edit" SelectText="Edit" ShowSelectButton="True"  ButtonType="Button" />
                         <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("id")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                         <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" />


                     </Columns>
                     <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                     <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                     <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                     <RowStyle BackColor="White" ForeColor="#003399" />
                     <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                     <SortedAscendingCellStyle BackColor="#EDF6F6" />
                     <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                     <SortedDescendingCellStyle BackColor="#D6DFDF" />
                     <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:myconn %>" SelectCommand="SELECT [Code], [Name], [Descripton], [Price] FROM [ProductList]"></asp:SqlDataSource>
            </div>
        </div>

    </div>
   

</asp:Content>
