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
public partial class Default9 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
        Label label1 = MainContent.FindControl("r1") as Label;
        try
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT Mcode from medicine", connection);
            GridView gridView = MainContent.FindControl("thresholdgridview") as GridView;
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            label1.Text += adapter.Fill(ds, "Medicine").ToString();
            DataTable table = ds.Tables["Medicine"];
            foreach (DataRow dr in table.Rows)
            {
                DataSet ds1 = new DataSet();
                SqlCommand command1 = new SqlCommand("Select Quantity from Sales where Mcode=@mcode AND SalesDate >= DATEADD(day,-7, GETDATE())", connection);
                command1.Parameters.AddWithValue("mcode", dr["MCode"]);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command1);
                int totalPrice = 0;
                label1.Text += dataAdapter.Fill(ds1, "Sales");
                DataTable dt = ds1.Tables["Sales"];
                foreach (DataRow dr1 in dt.Rows)
                {
                    totalPrice += int.Parse(dr1["Quantity"].ToString());
                }
                SqlCommand command2 = new SqlCommand("UPDATE ThresholdMedicine set Threshold=@threshold,ThresholdDate=getdate() where Mcode=@mcode", connection);
                command2.Parameters.AddWithValue("@mcode", dr["MCode"]);
                float ths = totalPrice / 7;
                command2.Parameters.AddWithValue("@threshold", ths);
                label1.Text+="   "+command2.ExecuteNonQuery();
              //  label1.Visible = true; 
            }
            SqlCommand command3 = new SqlCommand("SELECT * FROM tHRESHOLDMEDICINE", connection);
            DataSet dss = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command3);
            da.Fill(dss, "ThresholdMedicine");
            gridView.DataSource = dss;
            gridView.DataBind();
            gridView.Visible = true;

            SqlCommand command4 = new SqlCommand("Select M.Mcode from Medicine M,ThresholdMedicine T where M.Quantity < T.Threshold and M.MCode=T.MCode", connection);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command4);
            DataSet ds2 = new DataSet();
            adapter1.Fill(ds2, "Medicine");
            GridView gridView1 = MainContent.FindControl("vendorthresholdmedicine") as GridView;
            gridView1.DataSource = ds2;
            gridView1.DataBind();   

            DataTable dt2 = ds2.Tables["Medicine"];
            foreach (DataRow dr in dt2.Rows)
            {
                DataSet ds1 = new DataSet();
                SqlCommand command1 = new SqlCommand("Select * from Vendor where Mcode=@mcode", connection);
                command1.Parameters.AddWithValue("@mcode", dr["Mcode"]);
                SqlDataAdapter adapter2 = new SqlDataAdapter(command1);
                adapter2.Fill(ds1, "Vendor");
                GridView gridview2 = new GridView();
                gridview2.DataSource = ds1;
                gridview2.DataBind();
                gridview2.AutoGenerateColumns = true;
                Label label2 = new Label();
                label2.Text = "Medicine Code with Vendor Details :" + dr["Mcode"];
                MainContent.Controls.Add(label2);
                MainContent.Controls.Add(new LiteralControl("<br><br>"));
                MainContent.Controls.Add(gridview2);
                MainContent.Controls.Add(new LiteralControl("<br>"));
            }
        }
        catch(Exception ex)
        {
            label1.Text = ex.ToString();
            label1.Visible = true;
        }
        finally
        {
            connection.Close();
        }

    }
}