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
using System.Web.UI.DataVisualization.Charting;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
        SqlConnection connection = new SqlConnection();
        DataSet dataSet = new DataSet();
        connection.ConnectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
        Label label3 = MainContent.FindControl("randommm") as Label;
        Label label2 = MainContent.FindControl("TotalPriceLabel") as Label;
        try
        {
            Label dlabel = MainContent.FindControl("DLabel") as Label;
            DateTime dateTime = DateTime.UtcNow.Date;
            dlabel.Text = dateTime.ToString("dd/MM/yyyy");
            dlabel.Visible = true;
            SqlCommand command = new SqlCommand("SELECT * FROM SALES WHERE SALESDATE = CAST(CURRENT_TIMESTAMP as DATE)", connection);
           // command.Parameters.AddWithValue("@getdate", dateTime.ToString("dd/MM/yyyy"));
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dataSet, "Sales");
            GridView gridView = MainContent.FindControl("GridView1") as GridView;
            gridView.DataSource = dataSet;
            gridView.DataBind();
            gridView.Visible = true;
            DataTable dt1 = dataSet.Tables["Sales"];
            int total = 0;
            foreach(DataRow dr in dt1.Rows)
            {
                total += int.Parse(dr["TotalPrice"].ToString());
            }
            label2.Text = "Total Revenue for the day : " + total.ToString();
            label2.Visible = true;
        }
        catch(Exception ex)
        {
            label3.Text = ex.ToString();
        }
        finally
        {
            connection.Close();
        }
      
        
    }
}