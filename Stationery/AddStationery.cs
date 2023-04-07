using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Stationery
{
    public partial class AddStationery : Form
    {
        private readonly Stationery stationery;
        string connStr = ConfigurationManager.ConnectionStrings["defaultConn"].ConnectionString;

        public AddStationery(Stationery stationery)
        {
            InitializeComponent();
            this.stationery = stationery;

            if (stationery.Name != null)
            {
                Text = "Update Stationery";
                textBoxNameStationery.Text = stationery.Name;
                textBoxQuantity.Text = stationery.Quantity.ToString();
                textBoxQuantitySold.Text = stationery.QuantitySold.ToString();
                textBoxPrimeCost.Text = stationery.Prime_cost.ToString();
                textBoxPrice.Text = stationery.Price.ToString();
                if (stationery.Date_sold == default(DateTime))
                {
                    dateTimePicker.Value = DateTime.Now;
                }
                else
                {
                    dateTimePicker.Value = stationery.Date_sold;
                }
                DownloadDataFromDB("GetManagerFullName", comboBoxManager);
                DownloadDataFromDB("GetBuyerCompanyName", comboBoxBuyerCompany);
                DownloadDataFromDB("GetTypeName", comboBoxType);

                DownloadDataFromDB(stationery.Manager_ID, "GetManagerFullnameById", comboBoxManager);
                DownloadDataFromDB(stationery.Buyer_company_ID, "GetBuyerCompanyNameById",  comboBoxBuyerCompany);
                DownloadDataFromDB(stationery.Type_ID, "GetTypeNameById", comboBoxType);
            }
            else
            {
                Text = "Add Stationery";
                DownloadDataFromDB("GetManagerFullName", comboBoxManager);
                DownloadDataFromDB("GetBuyerCompanyName", comboBoxBuyerCompany);
                DownloadDataFromDB("GetTypeName", comboBoxType);
                dateTimePicker.Value = DateTime.Now;
                Task.Delay(1000);
            }
        }

        async Task DownloadDataFromDB(string str, ComboBox comboBox)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(str, conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = null;
                comboBox.Items.Clear();
                try
                {
                    await conn.OpenAsync();
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        comboBox.Items.Add(reader.GetString(0));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    reader?.Close();
                }
            }
        }

        private async Task DownloadDataFromDB(int? id, string str, ComboBox comboBox)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    await conn.OpenAsync();

                    SqlCommand command = new SqlCommand(str, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    object result = await command.ExecuteScalarAsync();
                    if (result != null)
                    {
                        comboBox.SelectedItem = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    await conn.CloseAsync();
                }
            }
        }

        private async Task<int?> AddIdFromDB(string procedureName, ComboBox combobox)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    await conn.OpenAsync();

                    SqlCommand command = new SqlCommand(procedureName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", combobox.SelectedItem.ToString());
                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { await conn.CloseAsync(); }
            }
            return null;
        }

        private async void buttonOK_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxNameStationery.Text) && !string.IsNullOrEmpty(textBoxQuantity.Text) && 
                !string.IsNullOrEmpty(textBoxQuantitySold.Text) && !string.IsNullOrEmpty(textBoxPrimeCost.Text) && 
                !string.IsNullOrEmpty(textBoxPrice.Text))
            {
                stationery.Name = textBoxNameStationery.Text;
                int tmpint; //variable to help check int variable
                double tmpdouble; //variable to help check double variable
                if (int.TryParse(textBoxQuantity.Text, out tmpint))
                    stationery.Quantity = tmpint;
                else
                    MessageBox.Show("You entered an incorrect quantity of the product!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (int.TryParse(textBoxQuantitySold.Text, out tmpint))
                    stationery.QuantitySold = tmpint;
                else
                    MessageBox.Show("You have entered an incorrect quantity of the product sold!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (double.TryParse(textBoxPrimeCost.Text, out tmpdouble))
                    stationery.Prime_cost = tmpdouble;
                else
                    MessageBox.Show("You have entered an incorrect prime cost of the product!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (double.TryParse(textBoxPrice.Text, out tmpdouble))
                    stationery.Price = tmpdouble;
                else
                    MessageBox.Show("You have entered an incorrect price of the product!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stationery.Date_sold = dateTimePicker.Value.Date;
                if (comboBoxManager.SelectedIndex != -1)
                {
                    stationery.Manager_ID = await AddIdFromDB("GetManagerId2", comboBoxManager);
                }
                else
                {
                    MessageBox.Show("Choose manager in combobox!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (comboBoxBuyerCompany.SelectedIndex != -1)
                {
                    stationery.Buyer_company_ID = await AddIdFromDB("GetBuyerCompanyId2", comboBoxBuyerCompany);
                }
                else
                    MessageBox.Show("Choose manager in combobox!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (comboBoxType.SelectedIndex != -1)
                {
                    stationery.Type_ID = await AddIdFromDB("GetTypeId2", comboBoxType);
                }
                else
                    MessageBox.Show("Choose manager in combobox!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //else if ()
            //{

            //}

            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
