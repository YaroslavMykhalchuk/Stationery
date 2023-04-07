using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
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
            comboBoxChooseQuery.SelectedIndex = 0;
        }


        private void button_SwitchOnOff_Click(object sender, EventArgs e)
        {
            if (!isConnected)
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
            if (tabControlMain.SelectedTab == Stationery)
            {
                buttonDownload.Text = "Завантажити Stationery";
                buttonDownload.Enabled = true;
            }
            else if (tabControlMain.SelectedTab == Type)
            {
                buttonDownload.Text = "Завантажити Type";
                buttonDownload.Enabled = true;
            }
            else if (tabControlMain.SelectedTab == Manager)
            {
                buttonDownload.Text = "Завантажити Manager";
                buttonDownload.Enabled = true;
            }
            else if (tabControlMain.SelectedTab == Others)
            {
                buttonDownload.Text = string.Empty;
                buttonDownload.Enabled = false;
            }
            else if (tabControlMain.SelectedTab == BuyerCompany)
            {
                buttonDownload.Text = "Завантажити Buyer Company";
                buttonDownload.Enabled = true;
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
            else if (tabControlMain.SelectedTab == BuyerCompany)
            {
                await DownloadDataFromDB("GetBuyerCompanyFull", dataGridViewBuyerCompany);
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

        private async void buttonAddStationery_Click(object sender, EventArgs e)
        {
            Stationery stationery = new Stationery();
            AddStationery addStationery = new AddStationery(stationery);

            if (addStationery.ShowDialog() == DialogResult.OK)
            {
                await InsertDataToDb(stationery);
                MessageBox.Show("Data is successfully added!");
                await DownloadDataFromDB("GetStationery", dataGridViewStationery);
            }
        }

        async Task InsertDataToDb(object obj)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn?.OpenAsync();

                    if (obj is Stationery)
                    {
                        Stationery stationery = (Stationery)obj;
                        SqlCommand command = new SqlCommand("InsertStationery", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", stationery.Name);
                        command.Parameters.AddWithValue("@Quantity", stationery.Quantity);
                        command.Parameters.AddWithValue("@QuantitySold", stationery.QuantitySold);
                        command.Parameters.AddWithValue("@PrimeCost", stationery.Prime_cost);
                        command.Parameters.AddWithValue("@Price", stationery.Price);
                        command.Parameters.AddWithValue("@DateSold", stationery.Date_sold.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@manager_id", stationery.Manager_ID);
                        command.Parameters.AddWithValue("@buyerCompanyId", stationery.Buyer_company_ID);
                        command.Parameters.AddWithValue("@typeId", stationery.Type_ID);

                        await command.ExecuteNonQueryAsync();
                    }
                    else if (obj is Type)
                    {
                        Type type = (Type)obj;

                        SqlCommand command = new SqlCommand("InsertType", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", type.Name);

                        await command.ExecuteNonQueryAsync();
                    }
                    else if (obj is Manager)
                    {
                        Manager manager = (Manager)obj;

                        SqlCommand command = new SqlCommand("InsertManager", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", manager.Name);
                        command.Parameters.AddWithValue("@Surname", manager.Surname);

                        await command.ExecuteNonQueryAsync();
                    }
                    else if (obj is BuyerCompany)
                    {
                        BuyerCompany buyerCompany = (BuyerCompany)obj;

                        SqlCommand command = new SqlCommand("InsertBuyerCompany", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", buyerCompany.Name);

                        await command.ExecuteNonQueryAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn?.CloseAsync();
                }
            }
        }

        async Task UpdateDataToDb(object obj, DataGridViewRow row)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn?.OpenAsync();

                    if (obj is Stationery)
                    {
                        Stationery stationery = (Stationery)obj;
                        SqlCommand command = new SqlCommand("UpdateStationery", conn);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Id", row.Cells["Id"].Value);
                        command.Parameters.AddWithValue("@Name", stationery.Name);
                        command.Parameters.AddWithValue("@Quantity", stationery.Quantity);
                        command.Parameters.AddWithValue("@QuantitySold", stationery.QuantitySold);
                        command.Parameters.AddWithValue("@PrimeCost", stationery.Prime_cost);
                        command.Parameters.AddWithValue("@Price", stationery.Price);
                        command.Parameters.AddWithValue("@DateSold", stationery.Date_sold.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@manager_id", stationery.Manager_ID);
                        command.Parameters.AddWithValue("@buyerCompanyId", stationery.Buyer_company_ID);
                        command.Parameters.AddWithValue("@typeId", stationery.Type_ID);

                        await command.ExecuteNonQueryAsync();
                    }
                    else if (obj is Type)
                    {
                        Type type = (Type)obj;
                        SqlCommand command = new SqlCommand("UpdateType", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", row.Cells["Id"].Value);
                        command.Parameters.AddWithValue("@Name", type.Name);

                        await command.ExecuteNonQueryAsync();
                    }
                    else if (obj is Manager)
                    {
                        Manager manager = (Manager)obj;
                        SqlCommand command = new SqlCommand("UpdateManager", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", row.Cells["Id"].Value);
                        command.Parameters.AddWithValue("@Name", manager.Name);
                        command.Parameters.AddWithValue("@Surname", manager.Surname);

                        await command.ExecuteNonQueryAsync();
                    }
                    else if (obj is BuyerCompany)
                    {
                        BuyerCompany buyerCompany = (BuyerCompany)obj;
                        SqlCommand command = new SqlCommand("UpdateBuyerCompany", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", row.Cells["Id"].Value);
                        command.Parameters.AddWithValue("@Name", buyerCompany.Name);

                        await command.ExecuteNonQueryAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn?.CloseAsync();
                }
            }
        }

        private async void buttonUpdateStationery_Click(object sender, EventArgs e)
        {
            if (dataGridViewStationery.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть рядок з даними, які хочете змінити!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewStationery.SelectedRows.Count > 1)
            {
                MessageBox.Show("Оберіть 1 рядок з даними, які хочете змінити!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewStationery.SelectedRows.Count == 1 && dataGridViewStationery.CurrentRow == null)
            {
                MessageBox.Show("Ви обрали порожній рядок", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewStationery.SelectedRows.Count == 1 && dataGridViewStationery.CurrentRow != null)
            {
                Stationery stationery = new Stationery();
                DataGridViewRow row = dataGridViewStationery.CurrentRow;

                stationery.Name = Convert.ToString(row.Cells["Name"].Value);
                stationery.Quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                stationery.QuantitySold = Convert.ToInt32(row.Cells["Quantity Sold"].Value);
                stationery.Prime_cost = Convert.ToDouble(row.Cells["Prime cost"].Value);
                stationery.Price = Convert.ToDouble(row.Cells["Price"].Value);
                stationery.Date_sold = Convert.ToDateTime(row.Cells["Date sold"].Value);
                string name = row.Cells["Name"].Value.ToString();
                stationery.Manager_ID = await GetIdFromDb("GetManagerId", name);
                stationery.Buyer_company_ID = await GetIdFromDb("GetBuyerCompanyId", name);
                stationery.Type_ID = await GetIdFromDb("GetTypeId", name);

                AddStationery addStationery = new AddStationery(stationery);

                if (addStationery.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Data is successfully updated!");
                    await UpdateDataToDb(stationery, row);
                    await DownloadDataFromDB("GetStationery", dataGridViewStationery);
                }
            }
        }

        async Task<int> GetIdFromDb(string str, string name)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand command = new SqlCommand(str, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);
                    object result = await command.ExecuteScalarAsync();
                    if (result != null)
                    {
                        id = Convert.ToInt32(result);
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
                return id;
            }
        }

        private async void buttonDeleteStationery_Click(object sender, EventArgs e)
        {
            if (dataGridViewStationery.SelectedRows.Count == 0 || dataGridViewStationery.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select the data row you want to delete!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewStationery.SelectedRows.Count == 1 && dataGridViewStationery.CurrentRow == null)
            {
                MessageBox.Show("You have selected an empty row!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewStationery.SelectedRows.Count == 1 && dataGridViewStationery.CurrentRow != null)
            {
                DataGridViewRow row = dataGridViewStationery.CurrentRow;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this entry?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await DeleteDataFromDb("Stationery", row);

                    MessageBox.Show("Data successfully deleted from database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await DownloadDataFromDB("GetStationery", dataGridViewStationery);
                }
            }
        }

        async Task DeleteDataFromDb(string str, DataGridViewRow row)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    await conn.OpenAsync();

                    if (str == "Stationery")
                    {
                        await DeleteData("DeleteStationery", row.Cells["Id"].Value, conn);
                    }
                    else if (str == "Type")
                    {
                        await DeleteData("DeleteType", row.Cells["Id"].Value, conn);
                    }
                    else if (str == "Manager")
                    {
                        await DeleteData("DeleteManager", row.Cells["Id"].Value, conn);
                    }
                    else if (str == "Buyer Company")
                    {
                        await DeleteData("DeleteBuyerCompany", row.Cells["Id"].Value, conn);
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

        private async Task DeleteData(string storedProcedureName, object parameterValue, SqlConnection conn)
        {
            SqlCommand command = new SqlCommand(storedProcedureName, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", parameterValue);
            await command.ExecuteNonQueryAsync();
        }

        private async void buttonAddType_Click(object sender, EventArgs e)
        {
            Type type = new Type();
            AddType addType = new AddType(type);

            if (addType.ShowDialog() == DialogResult.OK)
            {
                await InsertDataToDb(type);
                MessageBox.Show("Data is successfully added!");
                await DownloadDataFromDB("GetTypeFull", dataGridViewType);
            }
        }

        private async void buttonUpdateType_Click(object sender, EventArgs e)
        {
            if (dataGridViewType.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть рядок з даними, які хочете змінити!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewType.SelectedRows.Count > 1)
            {
                MessageBox.Show("Оберіть 1 рядок з даними, які хочете змінити!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewType.SelectedRows.Count == 1 && dataGridViewType.CurrentRow == null)
            {
                MessageBox.Show("Ви обрали порожній рядок", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewType.SelectedRows.Count == 1 && dataGridViewType.CurrentRow != null)
            {
                Type type = new Type();
                DataGridViewRow row = dataGridViewType.CurrentRow;

                type.Name = Convert.ToString(row.Cells["Name"].Value);
                AddType addType = new AddType(type);

                if (addType.ShowDialog() == DialogResult.OK)
                {
                    await UpdateDataToDb(type, row);
                    await DownloadDataFromDB("GetTypeFull", dataGridViewType);
                    MessageBox.Show("Data is successfully updated!");
                }
            }
        }

        private async void buttonDeleteType_Click(object sender, EventArgs e)
        {
            if (dataGridViewType.SelectedRows.Count == 0 || dataGridViewType.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select the data row you want to delete!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewType.SelectedRows.Count == 1 && dataGridViewType.CurrentRow == null)
            {
                MessageBox.Show("You have selected an empty row!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewType.SelectedRows.Count == 1 && dataGridViewType.CurrentRow != null)
            {
                DataGridViewRow row = dataGridViewType.CurrentRow;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this entry?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await DeleteDataFromDb("Type", row);

                    MessageBox.Show("Data successfully deleted from database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await DownloadDataFromDB("GetTypeFull", dataGridViewStationery);
                }
            }
        }

        private async void buttonAddManager_Click(object sender, EventArgs e)
        {
            Manager manager = new Manager();
            AddManager addManager = new AddManager(manager);

            if (addManager.ShowDialog() == DialogResult.OK)
            {
                await InsertDataToDb(manager);
                MessageBox.Show("Data is successfully added!");
                await DownloadDataFromDB("GetManager", dataGridViewManager);
            }
        }

        private async void buttonUpdateManager_Click(object sender, EventArgs e)
        {
            if (dataGridViewManager.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть рядок з даними, які хочете змінити!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewManager.SelectedRows.Count > 1)
            {
                MessageBox.Show("Оберіть 1 рядок з даними, які хочете змінити!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewManager.SelectedRows.Count == 1 && dataGridViewManager.CurrentRow == null)
            {
                MessageBox.Show("Ви обрали порожній рядок", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewManager.SelectedRows.Count == 1 && dataGridViewManager.CurrentRow != null)
            {
                Manager manager = new Manager();
                DataGridViewRow row = dataGridViewManager.CurrentRow;

                SplitNameSurname(row, manager);
                AddManager addManager = new AddManager(manager);

                if (addManager.ShowDialog() == DialogResult.OK)
                {
                    await UpdateDataToDb(manager, row);
                    MessageBox.Show("Data is successfully updated!");
                    await DownloadDataFromDB("GetManager", dataGridViewManager);
                }
            }
        }

        private void SplitNameSurname(DataGridViewRow row, Manager manager)
        {
            string fullName = row.Cells["Column1"].Value.ToString();
            string[] nameParts = fullName.Split(' ');
            manager.Surname = nameParts[0];
            manager.Name = nameParts[1];
        }

        private async void buttonDeleteManager_Click(object sender, EventArgs e)
        {
            if (dataGridViewManager.SelectedRows.Count == 0 || dataGridViewManager.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select the data row you want to delete!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewManager.SelectedRows.Count == 1 && dataGridViewManager.CurrentRow == null)
            {
                MessageBox.Show("You have selected an empty row!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewManager.SelectedRows.Count == 1 && dataGridViewManager.CurrentRow != null)
            {
                DataGridViewRow row = dataGridViewManager.CurrentRow;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this entry?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await DeleteDataFromDb("Manager", row);

                    MessageBox.Show("Data successfully deleted from database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await DownloadDataFromDB("GetManager", dataGridViewManager);
                }
            }
        }

        private async void buttonAddBuyerCompany_Click(object sender, EventArgs e)
        {
            BuyerCompany buyerCompany = new BuyerCompany();
            AddBuyerCompany addBuyerCompany = new AddBuyerCompany(buyerCompany);
            if (addBuyerCompany.ShowDialog() == DialogResult.OK)
            {
                await InsertDataToDb(buyerCompany);
                MessageBox.Show("Data is successfully added!");
                await DownloadDataFromDB("GetBuyerCompanyFull", dataGridViewBuyerCompany);
            }
        }

        private async void buttonUpdateBuyerCompany_Click(object sender, EventArgs e)
        {
            if (dataGridViewBuyerCompany.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть рядок з даними, які хочете змінити!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewBuyerCompany.SelectedRows.Count > 1)
            {
                MessageBox.Show("Оберіть 1 рядок з даними, які хочете змінити!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewBuyerCompany.SelectedRows.Count == 1 && dataGridViewBuyerCompany.CurrentRow == null)
            {
                MessageBox.Show("Ви обрали порожній рядок", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewBuyerCompany.SelectedRows.Count == 1 && dataGridViewBuyerCompany.CurrentRow != null)
            {
                BuyerCompany buyerCompany = new BuyerCompany();
                DataGridViewRow row = dataGridViewBuyerCompany.CurrentRow;

                buyerCompany.Name = Convert.ToString(row.Cells["Buyer Company"].Value);
                AddBuyerCompany addBuyerCompany = new AddBuyerCompany(buyerCompany);

                if (addBuyerCompany.ShowDialog() == DialogResult.OK)
                {
                    await UpdateDataToDb(buyerCompany, row);
                    MessageBox.Show("Data is successfully updated!");
                    await DownloadDataFromDB("GetBuyerCompanyFull", dataGridViewBuyerCompany);
                }
            }
        }

        private async void buttonDeleteBuyerCompany_Click(object sender, EventArgs e)
        {
            if (dataGridViewBuyerCompany.SelectedRows.Count == 0 || dataGridViewBuyerCompany.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select the data row you want to delete!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewBuyerCompany.SelectedRows.Count == 1 && dataGridViewBuyerCompany.CurrentRow == null)
            {
                MessageBox.Show("You have selected an empty row!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridViewBuyerCompany.SelectedRows.Count == 1 && dataGridViewBuyerCompany.CurrentRow != null)
            {
                DataGridViewRow row = dataGridViewBuyerCompany.CurrentRow;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this entry?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await DeleteDataFromDb("Buyer Company", row);

                    MessageBox.Show("Data successfully deleted from database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await DownloadDataFromDB("GetBuyerCompanyFull", dataGridViewBuyerCompany);
                }
            }
        }
    }
}