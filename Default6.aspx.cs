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
public partial class Default6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
        if (!IsPostBack)
        {
            
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
            SqlCommand command = new SqlCommand("Select SalesDate,SUM(TotalPrice) as SumTotalPrice from Sales group by SalesDate", connection);
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            string[] Xpoint = new string[dt.Rows.Count];
            int[] YPoint = new int[dt.Rows.Count];

            for(int count = 0; count < dt.Rows.Count; count++)
            {
                Xpoint[count] = dt.Rows[count]["SalesDate"].ToString();
                YPoint[count] = Convert.ToInt32(dt.Rows[count]["SumTotalPrice"]);
            }
            Chart1.Series[0].Points.DataBindXY(Xpoint, YPoint);

            //Setting width of line  
            Chart1.Series[0].BorderWidth = 1;
            //setting Chart type   
            Chart1.Series[0].ChartType = SeriesChartType.Line;
            connection.Close();
        }
    }
}