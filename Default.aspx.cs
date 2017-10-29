using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void search_submit(object sender,EventArgs e)
    {
        ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
        DataSet ds = new DataSet();
        TextBox txt1 = MainContent.FindControl("TradeNameTxtBox") as TextBox;
        TextBox txt2 = MainContent.FindControl("GenericNameTxtBox") as TextBox;

        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
        SqlCommand command;
        try
        {
            connection.Open();
            if (!txt1.Text.Equals(""))
            {
               command = new SqlCommand("SELECT MCode,Quantity from Medicine where TradeName=@tradename", connection);
               command.Parameters.AddWithValue("@tradename", txt1.Text.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                 sth.Text = adapter.Fill(ds, "Medicine").ToString();
                GridView gridview = MainContent.FindControl("SearchGridView") as GridView;
                gridview.DataSource = ds.Tables["Medicine"].DefaultView;
                gridview.DataBind();
                gridview.Visible = true;

            }
            else if (!txt2.Equals(""))
            {
                command = new SqlCommand("SELECT MCode,Quantity from Medicine where GenericName=@tradename", connection);
                command.Parameters.AddWithValue("@tradename", txt2.Text.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                 sth.Text = adapter.Fill(ds, "Medicine").ToString();
                GridView gridview = MainContent.FindControl("SearchGridView") as GridView;
                gridview.DataSource = ds;
                gridview.DataBind();
                gridview.Visible = true;
            }
            
        }
        catch(Exception ex)
        {
          random.Text = ex.ToString();
        }
        finally
        {
            connection.Close();
        }
    }

}