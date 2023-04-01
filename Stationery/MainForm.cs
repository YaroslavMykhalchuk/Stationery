using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Stationery
{
    public partial class MainForm : Form
    {
        string connStr;
        DataTable dt;
        private bool isConnected = false;
        public MainForm()
        {
            InitializeComponent();

            buttonDownload.Visible = false;
            tabControlMain.Visible = false;
            labelConnStatus.Text = "Статус: Відключено";
            button_SwitchOnOff.Text = "Під'єднатись до БД";
            comboBoxChooseQuery.SelectedIndex= 0;
        }


        private void button_SwitchOnOff_Click(object sender, EventArgs e)
        {
            if(!isConnected)
            {
                connStr = string.Empty;

                isConnected = true;
                buttonDownload.Visible = false;
                tabControlMain.Visible = false;
                labelConnStatus.Text = "Статус: Відключено";
                button_SwitchOnOff.Text = "Під'єднатись до БД";
            }
            else
            {
                connStr = ConfigurationManager.ConnectionStrings["defaultConn"].ConnectionString;

                isConnected = false;
                buttonDownload.Visible = true;
                tabControlMain.Visible = true;
                labelConnStatus.Text = "Статус: Підключено";
                button_SwitchOnOff.Text = "Від'єднатись від БД";
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControlMain.SelectedTab == Stationery)
            {
                buttonDownload.Text = "Завантажити Stationery";
                buttonDownload.Enabled = true;
            }
            else if(tabControlMain.SelectedTab == Type)
            {
                buttonDownload.Text = "Завантажити Type";
                buttonDownload.Enabled = true;
            }
            else if(tabControlMain.SelectedTab == Manager)
            {
                buttonDownload.Text = "Завантажити Manager";
                buttonDownload.Enabled = true;
            }
            else if(tabControlMain.SelectedTab == Others)
            {
                buttonDownload.Text = string.Empty;
                buttonDownload.Enabled= false;
            }
        }

        private async void buttonDownload_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == Stationery)
            {
                await DownloadDataFromDB("GetStationery", dataGridViewStationery);
            }
            else if (tabControlMain.SelectedTab == Type)
            {
                await DownloadDataFromDB("GetTypeFull", dataGridViewType);
            }
            else if (tabControlMain.SelectedTab == Manager)
            {
                await DownloadDataFromDB("GetManager", dataGridViewManager);
            }
        }

        async Task DownloadDataFromDB(string str, DataGridView dataGridView)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                dt = new DataTable();
                dataGridView.DataSource = null;

                SqlCommand command = new SqlCommand(str, conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = null;
                try
                {
                    await conn.OpenAsync();
                    reader = await command.ExecuteReaderAsync();
                    bool firstCheck = false;

                    while (reader.Read())
                    {
                        if (!firstCheck)
                        {
                            firstCheck = true;
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                dt.Columns.Add(reader.GetName(i));
                            }
                        }
                        DataRow row = dt.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }
                        dt.Rows.Add(row);
                    }
                    dataGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    reader?.Close();
                    conn?.Close();
                }
            }
        }

        async Task DownloadDataFromDB(string str, ComboBox comboBox)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                dt = new DataTable();
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

        async Task DownloadDataFromDB(string str, DataGridView dataGridView, ComboBox comboBox)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                dt = new DataTable();
                dataGridView.DataSource = null;
                SqlDataReader reader = null;
                SqlCommand command = new SqlCommand(str, conn);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    await conn.OpenAsync();
                    command.Parameters.AddWithValue("@variable", comboBox.Text.ToString());
                    reader = await command.ExecuteReaderAsync();
                    dt.Load(reader);
                    dataGridView.DataSource = dt;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally 
                { 
                    reader?.Close(); 
                }
            }
        }

        async private void buttonQueries_Click(object sender, EventArgs e)
        {
            switch (comboBoxChooseQuery.Text)
            {
                case "Показати канцтовари з максимальною кількістю одиниць.":
                    {
                        await DownloadDataFromDB("GetStationeryMaxCount", dataGridViewOther);
                        comboBoxChooseItem.Visible = false;
                    }
                    break;
                case "Показати канцтовари з мінімальною кількістю одиниць.":
                    {
                        await DownloadDataFromDB("GetStationeryMinCount", dataGridViewOther);
                        comboBoxChooseItem.Visible = false;
                    }
                    break;
                case "Показати канцтовари з мінімальною собівартістю одиниці.":
                    {
                        await DownloadDataFromDB("GetStationeryMinPrimeCost", dataGridViewOther);
                        comboBoxChooseItem.Visible = false;
                    }
                    break;
                case "Показати канцтовари з максимальною собівартістю одиниці.":
                    {
                        await DownloadDataFromDB("GetStationeryMaxPrimeCost", dataGridViewOther);
                        comboBoxChooseItem.Visible = false;
                    }
                    break;
                case "Показати канцтовари заданого типу.":
                    {
                        await DownloadDataFromDB("GetStationeryByType", dataGridViewOther, comboBoxChooseItem);
                    }
                    break;
                case "Показати канцтовари, які продав певний менеджер з продажу.":
                    {
                        await DownloadDataFromDB("GetStationerySoldByManager", dataGridViewOther, comboBoxChooseItem);
                    }
                    break;
                case "Показати канцтовари, які закупила певна фірма-покупець.":
                    {
                        await DownloadDataFromDB("GetStationeryPurchasedByBuyerCompany", dataGridViewOther, comboBoxChooseItem);
                    }
                    break;
                case "Показати інформацію про нещодавній продаж.":
                    {
                        await DownloadDataFromDB("GetRecentSalesInfo", dataGridViewOther);
                        comboBoxChooseItem.Visible = false;
                    }
                    break;
                case "Показати середню кількість товарів по кожному типу канцтоварів.":
                    {
                        await DownloadDataFromDB("GetAvgQuantityByType", dataGridViewOther);
                        comboBoxChooseItem.Visible = false;
                    }
                    break;
            }
        }

        async private void comboBoxChooseQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewOther.DataSource = null;
            if (comboBoxChooseQuery.Text == "Показати канцтовари заданого типу.")
            {
                comboBoxChooseItem.Visible = true;
                await DownloadDataFromDB("GetTypeName", comboBoxChooseItem);
            }
            else if (comboBoxChooseQuery.Text == "Показати канцтовари, які продав певний менеджер з продажу.")
            {
                comboBoxChooseItem.Visible = true;
                await DownloadDataFromDB("GetManagerFullname", comboBoxChooseItem);
            }
            else if (comboBoxChooseQuery.Text == "Показати канцтовари, які закупила певна фірма-покупець.")
            {
                comboBoxChooseItem.Visible = true;
                await DownloadDataFromDB("GetBuyerCompanyName", comboBoxChooseItem);
            }
            else
            {
                comboBoxChooseItem.Visible = false;
            }
        }

        private void comboBoxChooseItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewOther.DataSource = null;
        }
    }
}