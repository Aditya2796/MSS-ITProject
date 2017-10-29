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

public partial class Default8 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
                      
    }
    protected void btn_add_vendor(object sender,EventArgs e)
    {
        ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
        TextBox textBox1 = MainContent.FindControl("VendorNameTxtBox") as TextBox;
        TextBox textBox2 = MainContent.FindControl("VendorAddressTxtBox") as TextBox;
        TextBox textbox3 = MainContent.FindControl("VendorNUmberTxtBox") as TextBox;
        DropDownList dropDownList = MainContent.FindControl("DropDownList1") as DropDownList;
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
        try
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Insert into Vendor values (@vendorname,@vendoraddress,@vendornumber,@mcode)", connection);
            command.Parameters.AddWithValue("@vendorname", textBox1.Text);
            command.Parameters.AddWithValue("@vendoraddress", textBox2.Text);
            command.Parameters.AddWithValue("@vendornumber", textbox3.Text);
            command.Parameters.AddWithValue("mcode", dropDownList.SelectedItem.Text);
            command.ExecuteNonQuery();
        }
        catch(Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }
    }
}