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

public partial class Default5 : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)

    {
        if (!IsPostBack)
        {
            ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
           RadioButtonList radioButtonList = MainContent.FindControl("VendorRadioList") as RadioButtonList;
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT VendorName from Vendor", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(ds, "Vendor");
                radioButtonList.DataSource = ds;
                radioButtonList.DataTextField = "VendorName";
                radioButtonList.DataValueField = "VendorName";
                this.DataBind();

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
    protected void btn_add_new_medicine(object sender,EventArgs e)
    {
        ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
       
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
        TextBox textBox1 = MainContent.FindControl("TNameTxtBox") as TextBox;
        TextBox textBox2 = MainContent.FindControl("GNameTxtBox") as TextBox;
        TextBox textBox3 = MainContent.FindControl("qtyTxtBox") as TextBox;
        TextBox textBox4 = MainContent.FindControl("batchtxtBox") as TextBox;
        TextBox textBox5 = MainContent.FindControl("expiryDateTxtBox") as TextBox;
        TextBox textBox6 = MainContent.FindControl("BatchDateTxtBox") as TextBox;
        TextBox textBox7 = MainContent.FindControl("SalesPriceTxtBox") as TextBox;
        TextBox textBox8 = MainContent.FindControl("PurchasePriceTxtBox") as TextBox;
        RadioButtonList radioButtonList = MainContent.FindControl("VendorRadioList") as RadioButtonList;
        Label label1 = MainContent.FindControl("ran") as Label;
        try
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO MEDICINE values (@mcode,@tradename,@genericname,@vendorname,@qty,@expirydate,@salesprice,@purchaseprice,@batchno,@batchdate)",connection);
            int medcode = new Random().Next(100, 999);
            command.Parameters.AddWithValue("@mcode", medcode);
            command.Parameters.AddWithValue("@tradename", textBox1.Text.ToString());
            command.Parameters.AddWithValue("@genericname", textBox2.Text.ToString());
          //  if (radioButtonList != null) { label1.Text = radioButtonList.SelectedIndex.ToString() + "  ata;ldj " ; } else { label1.Text = "13 "; }
            command.Parameters.AddWithValue("@vendorname", radioButtonList.SelectedValue.ToString());
            
            command.Parameters.AddWithValue("@qty",int.Parse(textBox3.Text));
            command.Parameters.AddWithValue("@expirydate",textBox5.Text.ToString());
            command.Parameters.AddWithValue("@salesprice", int.Parse(textBox7.Text.ToString()));
            command.Parameters.AddWithValue("@purchaseprice",int.Parse(textBox8.Text.ToString()));
            command.Parameters.AddWithValue("@batchno", int.Parse(textBox4.Text.ToString()));
            command.Parameters.AddWithValue("@batchdate", textBox6.Text.ToString());
             command.ExecuteNonQuery().ToString();
            
            //label1.Visible = true;
        }
        catch (Exception ex)
        {
            label1.Text += ex.ToString();
            label1.Visible = true;
        }
        finally
        {
            connection.Close();
        }
    }
}