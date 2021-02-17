using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DAL;

namespace Interview_task
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
               binduser();
                //Binddata();
            }
            else
            {

            }

            if (GridView1.EmptyDataText == null)
            {
                binduser();
                Response.Write("<script>alert('" + TextBox1.Text + " Not Found')</script>");

            }
        }


        

        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;

        protected IEnumerable<ProductList> Binddata()
        {
            using (Interview_TextEntities entities = new Interview_TextEntities())
            {
                return entities.ProductLists.ToList();
            }
        }


        protected void binduser()
        {
           // string cs = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;


            SqlConnection con = new SqlConnection(cs);

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from ProductList", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ID = dt.Rows[i]["ID"].ToString();
                string product_name = dt.Rows[i]["Name"].ToString();
                string Product_Descriprion = dt.Rows[i]["Descripton"].ToString();
                string Product_Price = dt.Rows[i]["Price"].ToString();
                string subname = product_name.Substring(0, 3).ToUpper();
                String Code = subname + "_0" + ID;
                SqlCommand cmd11 = new SqlCommand("update ProductList set Code='" + Code + "' where ID='" + ID + "'", con);
                cmd11.ExecuteNonQuery();               
            }
            con.Close();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from ProductList", con);
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
            sda1.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            con.Close();
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add Products.aspx");
        }

        protected void Imagebutton_Click(object sender, EventArgs e)
        {
            ImageButton Imgbtn = sender as ImageButton;
            GridViewRow row = Imgbtn.NamingContainer as GridViewRow;
            string pk = GridView1.DataKeys[row.RowIndex].Values[0].ToString();


            // GridViewRow gr = (GridViewRow)GridView1.Rows[e.new]
            Response.Redirect("Add Products.aspx?id="+pk);//.Cells[0].Text+" Code="+gr.Cells[1].Text+" & name = "+gr.Cells[2].Text+" & Price = "+gr.Cells[3].Text+" & Descripton = "+gr.Cells[4].Text);
        }


       /* protected void searchuser_click(object sender, EventArgs e  )
        {

            string txtsearc = TextBox1.Text.Trim();
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from ProductList where Name='"+txtsearc+"'", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GridView1.DataSource = dt;

        }*/

        protected void myButton_Click(object sender, EventArgs e)
        {
          //  string cs = System.Configuration.ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

            //string txtsearc = TextBox1.Text.Trim();
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from ProductList where Name='" + TextBox1.Text.Trim() + "'", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            TextBox1.Text = string.Empty;
        }

    protected void getUserByID_Click(object sender, EventArgs e)
        {
           

            GridViewRow gr = GridView1.SelectedRow;
            Response.Redirect("Add Products.aspx?Code="+gr.Cells[0].Text+"&Name"+gr.Cells[1].Text+ "&Descripton"+gr.Cells[2].Text+"&Ptice"+gr.Cells[3].Text);

            //string pk = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
        }
      /*  protected void gvDetails_RowDeleting(object sender, GridViewCommandEventArgs e)

        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            string id = GridView1.DataKeys[row.RowIndex].Values[1].ToString();
            
        }*/

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lbleditid = (Label)row.FindControl("lblID");
            //int id = Convert.ToInt32(e.RowIndex);
            //int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values.ToString());
           // id = +1;
            using (SqlConnection con = new SqlConnection(cs))
            { 
                con.Open();
                SqlCommand cmd = new SqlCommand("   delete from ProductList where id="+ lbleditid.Text+"", con);
                int t = cmd.ExecuteNonQuery();
                if(t>0)
                {
                    Response.Write("<script>alert('Product Deleted')</script>");
                    GridView1.EditIndex = -1;

                    binduser();
                }
            }

            
        }


    }


}