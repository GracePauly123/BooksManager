using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksManager
{
    public partial class RentBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label3.Text = "";
                bindData();
                bindAvailableData();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label3.Text = "";
            int pk = (int)GridView1.SelectedDataKey[0];
            int bookid = (int)GridView1.SelectedDataKey[1];
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

            conn.Open();
            SqlCommand cmd = new SqlCommand($"DELETE FROM   [LIBRARY].[dbo].[BorrowedBooks] where  Id= {pk} ", conn);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand($"Update  [LIBRARY].[dbo].[Books] SET AvailableQty = AvailableQty +1 where id={bookid}", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            bindData();
            bindAvailableData();
        }

        private void bindAvailableData()
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            String str = @" SELECT B.Id BookId, B.Title,A.AName,
  CASE WHEN B.AvailableQty = 0 THEN 'N' Else 'Y' END isAvailable
  FROM [dbo].[Author] AS A
  INNER JOIN [dbo].[Books] AS B
  ON B.AuthorId =A.AuthorID";
            SqlDataAdapter adptr = new SqlDataAdapter(str, conn);

            DataSet ds = new DataSet();
            adptr.Fill(ds);


            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();

        }
        private void bindData()
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            String str = @"SELECT BB.Id,B.Id BookId, B.[Title],BB.TakenDate
  FROM [BorrowedBooks] As BB
  INNER JOIN [Books] AS B
  ON B.Id=BB.BookId
WHERE BB.BorrowedId="+ Session["UserId"];
            SqlDataAdapter adptr = new SqlDataAdapter(str, conn);

            DataSet ds = new DataSet();
            adptr.Fill(ds);

       
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Books.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label3.Text = "";
            int pk = (int)GridView2.SelectedDataKey[0];
            int userid = (int)Session["UserId"];
            string isavailable =GridView2.SelectedDataKey[1].ToString();

            if(isavailable == "N")
            {
                 Label3.Text = "Out of stock";
                return;
            }
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

            conn.Open();


            string qry = "select * from dbo.[BorrowedBooks] where [BorrowedId]='" + userid + "' and bookid=" + pk;
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {

                Label3.Text = "Book already rented out......!!";
                conn.Close();
                sdr.Close();
            }
            else
            {
                sdr.Close();



                 cmd = new SqlCommand($"INSERT INTO   [LIBRARY].[dbo].[BorrowedBooks] VALUES ({userid}, {pk}, getdate())", conn);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand($"Update  [LIBRARY].[dbo].[Books] SET AvailableQty = AvailableQty -1 where id={pk}", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                bindData();
                bindAvailableData();
            }
        }
    }
}