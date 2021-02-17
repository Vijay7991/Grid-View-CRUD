<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Add Products.aspx.cs" Inherits="Interview_task.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleSheet.css" rel="stylesheet" />
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style>
        .div3{
            padding:10px;
            margin-left:50px;
        }
        .col-1 {width: 8.33%;}
.col-2 {width: 16.66%;}
.col-3 {width: 25%;}
.col-4 {width: 33.33%;}
.col-5 {width: 41.66%;}
.col-6 {width: 50%;}
.col-7 {width: 58.33%;}
.col-8 {width: 66.66%;}
.col-9 {width: 75%;}
.col-10 {width: 83.33%;}
.col-11 {width: 91.66%;}
.col-12 {width: 100%;}

@media only screen and (max-width: 768px) {
  /* For mobile phones: */
  [class*="col-"] {
    width: 100%;
  }

  </style>
    <script type="text/javascript">
    function ValidatorUpdateDisplay(val) {
        if (typeof (val.display) == "string") {
            if (val.display == "None") {
                return;
            }
            if (val.display == "Dynamic") {
                val.style.display = val.isvalid ? "none" : "inline";
                return;
            }

        }
        val.style.visibility = val.isvalid ? "hidden" : "visible";
        if (val.isvalid) {
            document.getElementById(val.controltovalidate).style.border = '1px solid #333';
        }
        else {
            document.getElementById(val.controltovalidate).style.border = '1px solid red';
        }          
    }
    </script>

    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3><asp:Label ID="Label1" runat="server" Text="Add Product"></asp:Label><br />
</h3>
      
    </div>  
                    <asp:Label ID="lblCode" runat="server" Text="" BackColor="Yellow" Font-Size="Larger" ForeColor="Red"></asp:Label><br />

    
    <div class="Txtbox " >
        <ul> <li> 
            <div>
                <asp:Label runat="server" Text="Name"></asp:Label><br />
               <asp:TextBox ID="TxtName" runat="server" placeholder="Product Name" BorderColor="Black" ValidateRequestMode="Enabled" Height="26px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtName" ErrorMessage="Enter Product Name." ForeColor="Red" ></asp:RequiredFieldValidator>
            </div></li>
            <li>
                <div>
                <asp:Label runat="server" Text="Price"></asp:Label><br />
                 <asp:TextBox ID="TxtPrice" runat="server" placeholder="Product Price" BorderColor="Black" Height="25px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtPrice" ErrorMessage="Enter Product Price/" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Price In Number" ControlToValidate="TxtPrice" ForeColor="Red" ValidationExpression="\d.*"></asp:RegularExpressionValidator>
                </div>
            </li>
        </ul>
    </div>
       
   
    <div class="col-1">
            <asp:TextBox ID="TextBox1" runat="server"  placeholder="Product Description" TextMode="MultiLine" 
                style=" border: solid 2px black;
 margin-left:55px;
 margin-top:20px;
    padding-left:30px;
    padding-top:10px;
    width:360px;
    height:120px;"></asp:TextBox>     
    </div>
    <div class="col-1">
        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Save_Click" style="height:35px;  margin-left:55px;
 margin-top:20px; border:solid 1px black; width:60px;   background-color:blue" ForeColor="White"/> <br />
    </div>

</asp:Content>
