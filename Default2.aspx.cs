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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Generate_Bill(object sender, EventArgs e)
    {
      
            ContentPlaceHolder MainContent = Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            //DataSet ds = new DataSet();
            //  TextBox txt1 = MainContent.FindControl("D2MedicineTextBox") as TextBox;
            DropDownList dropDownList = MainContent.FindControl("MedicineDropDownList") as DropDownList;
            TextBox txt2 = MainContent.FindControl("D2QuantityTextBox") as TextBox;
            Label Billlabel = MainContent.FindControl("billLabel") as Label;
            Label label = MainContent.FindControl("verify") as Label;
            int total = 0;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = WebConfigurationManager.ConnectionStrings["Pubs"].ConnectionString;
            try
            {
                connection.Open();

                SqlDataReader reader;


                SqlCommand command2 = new SqlCommand("SELECT QUANTITY FROM Medicine where Mcode=@mcode", connection);
                command2.Parameters.AddWithValue("@mcode", dropDownList.SelectedItem.Value);
                reader = command2.ExecuteReader();
                int leftQuantity = 0;
                while (reader.Read())
                {
                    string qty = reader["Quantity"].ToString();
                    leftQuantity += int.Parse(qty);
                }
                reader.Close();
                int diff = leftQuantity - int.Parse(txt2.Text);
                if (diff < 0)
                {
                    label.Text = "SORRY NOT ENOUGH QUANTITY";
                    label.Visible = true;
                }
                else
                {
                    SqlCommand command = new SqlCommand("SELECT PurchasePrice from Medicine where Mcode=@mcode", connection);
                    command.Parameters.AddWithValue("@mcode", dropDownList.SelectedItem.Value);
                    //   SqlDataReader reader;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string price = reader["PurchasePrice"].ToString();
                        total += int.Parse(price) * int.Parse(txt2.Text.ToString());
                        Billlabel.Text = "Your Total Amount : " + total.ToString();
                    }
                    reader.Close();
                    int sales_id = new Random().Next(1000, 9999);
                    SqlCommand command1 = new SqlCommand("INSERT INTO SALES(salesid,Mcode,Quantity,SalesDate,TotalPrice) values (@sales_id,@mcode,@quantity,getdate(),@tprice)", connection);
                    command1.Parameters.AddWithValue("@sales_id", sales_id);
                    command1.Parameters.AddWithValue("@mcode", dropDownList.SelectedItem.Value);
                    command1.Parameters.AddWithValue("@quantity", int.Parse(txt2.Text));
                    command1.Parameters.AddWithValue("@tprice", total);
                    command1.ExecuteNonQuery();
                    SqlCommand command3 = new SqlCommand("UPDATE MEDICINE SET QUANTITY=@quantity where Mcode=@mcode", connection);
                    command3.Parameters.AddWithValue("@quantity", diff);
                    command3.Parameters.AddWithValue("mcode", dropDownList.SelectedItem.Value);
                    command3.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                label.Text = ex.ToString();
            }
            finally
            {
                connection.Close();
            }
        label.Visible = false;
        }
    
}