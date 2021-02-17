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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string code = Request.QueryString["Code"];
                if (!Page.IsPostBack)
                {

                    if (code == null)
                    {
                        
                    }
                    else
                    {
                        Binddata(code);
                        Button1.Text = "Update";
                        Label1.Text = "Edit Product";
                    }
                    /* TxtName.Text = Request.QueryString["Name"].ToString();
                     TxtPrice.Text = Request.QueryString["Price"].ToString();
                     TextBox1.Text = Request.QueryString["Descripton"].ToString();*/
                }
            }
            catch
            {

            }
            

        }



        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;

        protected void Save_Click(object sender, EventArgs e)
        {
            string Pro_Name = TxtName.Text.Trim();
            string Pro_Descr = TextBox1.Text.Trim();
            float Pro_Price = float.Parse(TxtPrice.Text.Trim()); ;
            string code = lblCode.Text;
            if (Button1.Text == "Save")
            {
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name FROM ProductList WHERE Name=@Name", con);
                cmd.Parameters.AddWithValue("@Name", Pro_Name);
                SqlDataReader srd = cmd.ExecuteReader();
                if (srd.HasRows)
                {
                    Response.Write("<script>alert('Data Alredy Exist')</script>");
                }
                else
                {
                    srd.Close();
                    SqlCommand cmd1 = new SqlCommand("insert into ProductList (Name,Descripton,Price) Values ('" + Pro_Name + "','" + Pro_Descr + "'," + Pro_Price + ") ", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Data inserted successfully')</script>");

                }
            }
            else if(Button1.Text == "Update")
            {
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd2 = new SqlCommand("update ProductList Set Name='" + Pro_Name + "',Descripton='" + Pro_Descr + "', Price=" + Pro_Price + " where Code='" + code + "'", con);
                    //"Update ProductList Set Name= '" + Pro_Name + "', Descripton='" + Pro_Descr + "',Price=" + Pro_Price + " Where Code = '"+code+"'", con);
                cmd2.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Data Updates successfully')</script>");
            }



            
            TxtName.Text = string.Empty;
            TextBox1.Text = string.Empty;
            TxtPrice.Text = string.Empty;
        }
        protected void Binddata(string Code1)
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from ProductList where Code='" + Code1 + "'", con);

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            lblCode.Text = dt.Rows[0]["code"].ToString();
            TxtName.Text = dt.Rows[0]["Name"].ToString();
            TxtPrice.Text = dt.Rows[0]["Price"].ToString();
            TextBox1.Text = dt.Rows[0]["Descripton"].ToString();
            cmd.ExecuteNonQuery();


            con.Close();
        }
    }
}