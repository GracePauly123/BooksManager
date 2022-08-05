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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

            try
            {
                string uid = TextBox2.Text;
                string pass = TextBox1.Text;
                con.Open();
                string qry = "select * from dbo.[User] where Email='" + uid + "' and Password='" + pass + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    Label1.Text = "Login Sucess......!!";
                    Session["UserId"] = sdr[0];
                    Response.Redirect("RentBook.aspx");
                }
                else
                {
                    Label1.Text = "UserId & Password Is not correct Try again..!!";

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }
    }
    }
