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
public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            connection.ConnectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
            Label label1 = MainContent.FindControl("expiredlabel") as Label;
            try
            {
                label1.Visible = true;
                connection.Open();
                SqlCommand command = new SqlCommand("Select Mcode,TradeName,GenericName from Medicine where ExpiryDate < getdate()", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds, "Medicine");
                GridView gridView = MainContent.FindControl("ExpiredMedicinesGridView") as GridView;
                gridView.DataSource = ds;
                gridView.DataBind();
                gridView.Visible = true;
                dt = ds.Tables["Medicine"];
                foreach (DataRow dr in dt.Rows)
                {
                    DataSet ds1 = new DataSet();
                    SqlCommand command1 = new SqlCommand("Select * from Vendor where Mcode=@mcode", connection);
                    command1.Parameters.AddWithValue("@mcode", dr["Mcode"]);
                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    adapter1.Fill(ds1, "Vendor");
                    GridView gridview1 = new GridView();
                    gridview1.DataSource = ds1;
                    gridview1.DataBind();
                    gridview1.AutoGenerateColumns = true;
                    Label label2 = new Label();
                    label2.Text = "Medicine Code :" + dr["Mcode"];
                    MainContent.Controls.Add(label2);
                    MainContent.Controls.Add(new LiteralControl("<br>"));
                    MainContent.Controls.Add(gridview1);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
        }
    }
}