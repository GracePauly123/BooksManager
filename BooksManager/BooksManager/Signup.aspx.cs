using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace BooksManager
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

             SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
           
            con.Open();
                string emailId = TextBox2.Text;
                
                string qry = "select * from dbo.[User] where Email='" + emailId + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                   
                    Label1.Text = "EmailId already existed......!!";

                }
                else
                {
                sdr.Close();
                SqlCommand cmd1 = new SqlCommand("insert into dbo.[User] values(@Name, @Email, @Password)", con);

                    cmd1.Parameters.AddWithValue("Name", TextBox1.Text);
                    cmd1.Parameters.AddWithValue("Email", TextBox2.Text);
                    cmd1.Parameters.AddWithValue("Password", TextBox3.Text);
                    cmd1.ExecuteNonQuery();

                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox1.Focus();
                    Label1.Text = "Register Sucess......!!";
                }

                con.Close();
            }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
    }
