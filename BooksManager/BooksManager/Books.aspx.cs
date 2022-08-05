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
    public partial class Books : System.Web.UI.Page
    {
        public object GridView1 { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                bindData();
                bindDropdown();
            }

        }

        private void bindDropdown()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            String str = @"SELECT A.AName 
        ,A.AuthorID
         FROM [LIBRARY].[dbo].[Author] A ";
            SqlDataAdapter adptr = new SqlDataAdapter(str, conn);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            ddAuthor.DataSource = dt;
            //ddAuthor.DataTextField = "AName";
            //ddAuthor.DataValueField = "AuthorID";
            ddAuthor.DataBind();
            ddAuthor.SelectedIndex = 0;
        }

        private void bindData()
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            String str = @"SELECT DISTINCT B.Id
      ,B.Quantity
      ,B.Title
      ,A.AName Author,
B.AvailableQty,
      CASE WHEN B.AvailableQty = 0 THEN 'N' Else 'Y' END isAvailable
  FROM [LIBRARY].[dbo].[Books] B JOIN [LIBRARY].[dbo].[Author] A ON B.AuthorId = A.AuthorID";
            SqlDataAdapter adptr = new SqlDataAdapter(str, conn);

            DataSet ds = new DataSet();
            adptr.Fill(ds);

            Session["ds"] = ds.Tables[0]; GridView11.DataSource = (DataTable)Session["ds"];
            GridView11.DataBind();

        }

        protected void GridView11_SelectedIndexChanged(object sender, EventArgs e)
        {

            int pk = (int)GridView11.SelectedDataKey[0];


            GridView11.EditIndex = GridView11.SelectedIndex;

            Session["rIndex"] = GridView11.SelectedIndex; GridView11.DataSource = (DataTable)Session["ds"];
            GridView11.DataBind();

        }

        protected void GridView11_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView11.Columns[1].Visible = false; GridView11.DataSource = (DataTable)Session["ds"];
            GridView11.EditIndex = e.NewEditIndex;

            GridView11.DataBind();

        }

        protected void GridView11_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            GridView11.Columns[1].Visible = true;
            GridView11.EditIndex = -1;

            GridView11.DataSource = (DataTable)Session["ds"];
            GridView11.DataBind();

        }

        protected void GridView11_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridView11.Columns[1].Visible = true;
            int id = int.Parse(GridView11.DataKeys[e.RowIndex]["Id"].ToString());

            GridViewRow gvr = GridView11.Rows[e.RowIndex];
            //the following is how to get the values changed

            //the control's name made on the gridview template which will have the changed value is txtTitle

            String txtqty = ((TextBox)gvr.FindControl("txtqty")).Text;
            //after getting it just fire the update statement to update it.
            updateBook(id,txtqty);
            GridView11.EditIndex = -1;

            bindData();

        }

        private void updateBook(int id, string qty)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            String str = $"UPDATE  [LIBRARY].[dbo].[Books] SET QUANTITY = {qty} WHERE ID = {id}";
            SqlCommand cmd = new SqlCommand(str, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void GridView11_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(GridView11.DataKeys[e.RowIndex]["Id"].ToString());
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

            conn.Open();
            SqlCommand cmd = new SqlCommand($"delete FROM  [LIBRARY].[dbo].[Books] where id={id}", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            bindData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

            conn.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO   [LIBRARY].[dbo].[Books] VALUES ('{txtBook.Text}', {ddAuthor.SelectedValue}, {txtQty.Text}, {txtQty.Text})", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            bindData();

        }

        protected void GridView11_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView11.PageIndex = e.NewPageIndex;
            bindData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RentBook.aspx");
        }

        protected void GridView11_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable ds =(DataTable) GridView11.DataSource;
            ds.DefaultView.Sort = e.SortExpression;
            GridView11.DataSource = ds;
            GridView11.DataBind();
        }
    }
}