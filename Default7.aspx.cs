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
public partial class Default7 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
        RadioButtonList radioButtonList = MainContent.FindControl("RadioButtonList1") as RadioButtonList;
        DropDownList dropDownList = MainContent.FindControl("DropDownList1") as DropDownList;
                
          SqlConnection connection = new SqlConnection();
            connection.ConnectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select VendorName from Vendor where Mcode=@mcode", connection);
                command.Parameters.AddWithValue("@mcode", int.Parse(dropDownList.SelectedItem.Value));
                SqlDataReader reader;
                reader = command.ExecuteReader();
            radioButtonList.Items.Clear();
                while (reader.Read())
                {
                    radioButtonList.Items.Add(reader["VendorName"].ToString());
                }
                reader.Close();
                radioButtonList.Visible = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
        
    }
    protected void btn_add_supply(object sender,EventArgs e)
    { 
        ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
        RadioButtonList radioButtonList = MainContent.FindControl("RadioButtonList1") as RadioButtonList;
        DropDownList dropDownList = MainContent.FindControl("DropDownList1") as DropDownList;
        TextBox textBox1 = MainContent.FindControl("SupplyBatchTxtBox") as TextBox;
        TextBox textBox2 = MainContent.FindControl("SupplyExpiryDateTxtBox") as TextBox;
        TextBox textBox3 = MainContent.FindControl("SupplyQtyTxtBox") as TextBox;
        Label label1 = MainContent.FindControl("rrr") as Label;
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
        try
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE MEDICINE SET BatchNumber=@batchno,Expirydate=@expirydate,Quantity=@quantity where Mcode=@mcode", connection);
            command.Parameters.AddWithValue("@batchno", int.Parse(textBox1.Text));
            command.Parameters.AddWithValue("@expirydate", textBox2.Text.ToString());
            command.Parameters.AddWithValue("@quantity", int.Parse(textBox3.Text));  
            command.Parameters.AddWithValue("@mcode", int.Parse(dropDownList.SelectedItem.Value));
            command.ExecuteNonQuery();
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