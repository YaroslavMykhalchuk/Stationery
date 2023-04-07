namespace Stationery
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDownload = new System.Windows.Forms.Button();
            this.button_SwitchOnOff = new System.Windows.Forms.Button();
            this.labelConnStatus = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.Stationery = new System.Windows.Forms.TabPage();
            this.buttonUpdateStationery = new System.Windows.Forms.Button();
            this.buttonDeleteStationery = new System.Windows.Forms.Button();
            this.buttonAddStationery = new System.Windows.Forms.Button();
            this.dataGridViewStationery = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.TabPage();
            this.buttonUpdateType = new System.Windows.Forms.Button();
            this.buttonDeleteType = new System.Windows.Forms.Button();
            this.dataGridViewType = new System.Windows.Forms.DataGridView();
            this.buttonAddType = new System.Windows.Forms.Button();
            this.Manager = new System.Windows.Forms.TabPage();
            this.buttonUpdateManager = new System.Windows.Forms.Button();
            this.buttonDeleteManager = new System.Windows.Forms.Button();
            this.dataGridViewManager = new System.Windows.Forms.DataGridView();
            this.buttonAddManager = new System.Windows.Forms.Button();
            this.BuyerCompany = new System.Windows.Forms.TabPage();
            this.buttonUpdateBuyerCompany = new System.Windows.Forms.Button();
            this.buttonDeleteBuyerCompany = new System.Windows.Forms.Button();
            this.dataGridViewBuyerCompany = new System.Windows.Forms.DataGridView();
            this.buttonAddBuyerCompany = new System.Windows.Forms.Button();
            this.Others = new System.Windows.Forms.TabPage();
            this.buttonQueries = new System.Windows.Forms.Button();
            this.dataGridViewOther = new System.Windows.Forms.DataGridView();
            this.comboBoxChooseItem = new System.Windows.Forms.ComboBox();
            this.comboBoxChooseQuery = new System.Windows.Forms.ComboBox();
            this.tabControlMain.SuspendLayout();
            this.Stationery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStationery)).BeginInit();
            this.Type.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewType)).BeginInit();
            this.Manager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManager)).BeginInit();
            this.BuyerCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuyerCompany)).BeginInit();
            this.Others.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOther)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(12, 12);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(196, 37);
            this.buttonDownload.TabIndex = 0;
            this.buttonDownload.Text = "Завантажити Stationery";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // button_SwitchOnOff
            // 
            this.button_SwitchOnOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SwitchOnOff.Location = new System.Drawing.Point(636, 12);
            this.button_SwitchOnOff.Name = "button_SwitchOnOff";
            this.button_SwitchOnOff.Size = new System.Drawing.Size(152, 37);
            this.button_SwitchOnOff.TabIndex = 1;
            this.button_SwitchOnOff.Text = "Під\'єднатися до БД";
            this.button_SwitchOnOff.UseVisualStyleBackColor = true;
            this.button_SwitchOnOff.Click += new System.EventHandler(this.button_SwitchOnOff_Click);
            // 
            // labelConnStatus
            // 
            this.labelConnStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelConnStatus.AutoSize = true;
            this.labelConnStatus.Location = new System.Drawing.Point(487, 23);
            this.labelConnStatus.Name = "labelConnStatus";
            this.labelConnStatus.Size = new System.Drawing.Size(115, 15);
            this.labelConnStatus.TabIndex = 2;
            this.labelConnStatus.Text = "Статус: Відключено";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.Stationery);
            this.tabControlMain.Controls.Add(this.Type);
            this.tabControlMain.Controls.Add(this.Manager);
            this.tabControlMain.Controls.Add(this.BuyerCompany);
            this.tabControlMain.Controls.Add(this.Others);
            this.tabControlMain.Location = new System.Drawing.Point(12, 55);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(776, 383);
            this.tabControlMain.TabIndex = 3;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // Stationery
            // 
            this.Stationery.Controls.Add(this.buttonUpdateStationery);
            this.Stationery.Controls.Add(this.buttonDeleteStationery);
            this.Stationery.Controls.Add(this.buttonAddStationery);
            this.Stationery.Controls.Add(this.dataGridViewStationery);
            this.Stationery.Location = new System.Drawing.Point(4, 24);
            this.Stationery.Name = "Stationery";
            this.Stationery.Padding = new System.Windows.Forms.Padding(3);
            this.Stationery.Size = new System.Drawing.Size(768, 355);
            this.Stationery.TabIndex = 0;
            this.Stationery.Text = "Stationery";
            this.Stationery.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateStationery
            // 
            this.buttonUpdateStationery.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonUpdateStationery.Location = new System.Drawing.Point(290, 329);
            this.buttonUpdateStationery.Name = "buttonUpdateStationery";
            this.buttonUpdateStationery.Size = new System.Drawing.Size(186, 23);
            this.buttonUpdateStationery.TabIndex = 3;
            this.buttonUpdateStationery.Text = "Update Stationery";
            this.buttonUpdateStationery.UseVisualStyleBackColor = true;
            this.buttonUpdateStationery.Click += new System.EventHandler(this.buttonUpdateStationery_Click);
            // 
            // buttonDeleteStationery
            // 
            this.buttonDeleteStationery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteStationery.Location = new System.Drawing.Point(576, 329);
            this.buttonDeleteStationery.Name = "buttonDeleteStationery";
            this.buttonDeleteStationery.Size = new System.Drawing.Size(186, 23);
            this.buttonDeleteStationery.TabIndex = 2;
            this.buttonDeleteStationery.Text = "Delete Stationery";
            this.buttonDeleteStationery.UseVisualStyleBackColor = true;
            this.buttonDeleteStationery.Click += new System.EventHandler(this.buttonDeleteStationery_Click);
            // 
            // buttonAddStationery
            // 
            this.buttonAddStationery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddStationery.Location = new System.Drawing.Point(6, 329);
            this.buttonAddStationery.Name = "buttonAddStationery";
            this.buttonAddStationery.Size = new System.Drawing.Size(186, 23);
            this.buttonAddStationery.TabIndex = 1;
            this.buttonAddStationery.Text = "Add Stationery";
            this.buttonAddStationery.UseVisualStyleBackColor = true;
            this.buttonAddStationery.Click += new System.EventHandler(this.buttonAddStationery_Click);
            // 
            // dataGridViewStationery
            // 
            this.dataGridViewStationery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStationery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStationery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStationery.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewStationery.Name = "dataGridViewStationery";
            this.dataGridViewStationery.RowTemplate.Height = 25;
            this.dataGridViewStationery.Size = new System.Drawing.Size(756, 312);
            this.dataGridViewStationery.TabIndex = 0;
            // 
            // Type
            // 
            this.Type.Controls.Add(this.buttonUpdateType);
            this.Type.Controls.Add(this.buttonDeleteType);
            this.Type.Controls.Add(this.dataGridViewType);
            this.Type.Controls.Add(this.buttonAddType);
            this.Type.Location = new System.Drawing.Point(4, 24);
            this.Type.Name = "Type";
            this.Type.Padding = new System.Windows.Forms.Padding(3);
            this.Type.Size = new System.Drawing.Size(768, 355);
            this.Type.TabIndex = 1;
            this.Type.Text = "Type";
            this.Type.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateType
            // 
            this.buttonUpdateType.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonUpdateType.Location = new System.Drawing.Point(290, 326);
            this.buttonUpdateType.Name = "buttonUpdateType";
            this.buttonUpdateType.Size = new System.Drawing.Size(186, 23);
            this.buttonUpdateType.TabIndex = 6;
            this.buttonUpdateType.Text = "Update Type";
            this.buttonUpdateType.UseVisualStyleBackColor = true;
            this.buttonUpdateType.Click += new System.EventHandler(this.buttonUpdateType_Click);
            // 
            // buttonDeleteType
            // 
            this.buttonDeleteType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteType.Location = new System.Drawing.Point(576, 326);
            this.buttonDeleteType.Name = "buttonDeleteType";
            this.buttonDeleteType.Size = new System.Drawing.Size(186, 23);
            this.buttonDeleteType.TabIndex = 5;
            this.buttonDeleteType.Text = "Delete Type";
            this.buttonDeleteType.UseVisualStyleBackColor = true;
            this.buttonDeleteType.Click += new System.EventHandler(this.buttonDeleteType_Click);
            // 
            // dataGridViewType
            // 
            this.dataGridViewType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewType.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewType.Name = "dataGridViewType";
            this.dataGridViewType.RowTemplate.Height = 25;
            this.dataGridViewType.Size = new System.Drawing.Size(756, 312);
            this.dataGridViewType.TabIndex = 0;
            // 
            // buttonAddType
            // 
            this.buttonAddType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddType.Location = new System.Drawing.Point(6, 326);
            this.buttonAddType.Name = "buttonAddType";
            this.buttonAddType.Size = new System.Drawing.Size(186, 23);
            this.buttonAddType.TabIndex = 4;
            this.buttonAddType.Text = "Add Type";
            this.buttonAddType.UseVisualStyleBackColor = true;
            this.buttonAddType.Click += new System.EventHandler(this.buttonAddType_Click);
            // 
            // Manager
            // 
            this.Manager.Controls.Add(this.buttonUpdateManager);
            this.Manager.Controls.Add(this.buttonDeleteManager);
            this.Manager.Controls.Add(this.dataGridViewManager);
            this.Manager.Controls.Add(this.buttonAddManager);
            this.Manager.Location = new System.Drawing.Point(4, 24);
            this.Manager.Name = "Manager";
            this.Manager.Size = new System.Drawing.Size(768, 355);
            this.Manager.TabIndex = 2;
            this.Manager.Text = "Manager";
            this.Manager.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateManager
            // 
            this.buttonUpdateManager.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonUpdateManager.Location = new System.Drawing.Point(290, 329);
            this.buttonUpdateManager.Name = "buttonUpdateManager";
            this.buttonUpdateManager.Size = new System.Drawing.Size(186, 23);
            this.buttonUpdateManager.TabIndex = 6;
            this.buttonUpdateManager.Text = "Update Manager";
            this.buttonUpdateManager.UseVisualStyleBackColor = true;
            this.buttonUpdateManager.Click += new System.EventHandler(this.buttonUpdateManager_Click);
            // 
            // buttonDeleteManager
            // 
            this.buttonDeleteManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteManager.Location = new System.Drawing.Point(576, 329);
            this.buttonDeleteManager.Name = "buttonDeleteManager";
            this.buttonDeleteManager.Size = new System.Drawing.Size(186, 23);
            this.buttonDeleteManager.TabIndex = 5;
            this.buttonDeleteManager.Text = "Delete Manager";
            this.buttonDeleteManager.UseVisualStyleBackColor = true;
            this.buttonDeleteManager.Click += new System.EventHandler(this.buttonDeleteManager_Click);
            // 
            // dataGridViewManager
            // 
            this.dataGridViewManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewManager.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManager.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewManager.Name = "dataGridViewManager";
            this.dataGridViewManager.RowTemplate.Height = 25;
            this.dataGridViewManager.Size = new System.Drawing.Size(756, 312);
            this.dataGridViewManager.TabIndex = 0;
            // 
            // buttonAddManager
            // 
            this.buttonAddManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddManager.Location = new System.Drawing.Point(6, 329);
            this.buttonAddManager.Name = "buttonAddManager";
            this.buttonAddManager.Size = new System.Drawing.Size(186, 23);
            this.buttonAddManager.TabIndex = 4;
            this.buttonAddManager.Text = "Add Manager";
            this.buttonAddManager.UseVisualStyleBackColor = true;
            this.buttonAddManager.Click += new System.EventHandler(this.buttonAddManager_Click);
            // 
            // BuyerCompany
            // 
            this.BuyerCompany.Controls.Add(this.buttonUpdateBuyerCompany);
            this.BuyerCompany.Controls.Add(this.buttonDeleteBuyerCompany);
            this.BuyerCompany.Controls.Add(this.dataGridViewBuyerCompany);
            this.BuyerCompany.Controls.Add(this.buttonAddBuyerCompany);
            this.BuyerCompany.Location = new System.Drawing.Point(4, 24);
            this.BuyerCompany.Name = "BuyerCompany";
            this.BuyerCompany.Size = new System.Drawing.Size(768, 355);
            this.BuyerCompany.TabIndex = 4;
            this.BuyerCompany.Text = "Buyer Company";
            this.BuyerCompany.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateBuyerCompany
            // 
            this.buttonUpdateBuyerCompany.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonUpdateBuyerCompany.Location = new System.Drawing.Point(291, 329);
            this.buttonUpdateBuyerCompany.Name = "buttonUpdateBuyerCompany";
            this.buttonUpdateBuyerCompany.Size = new System.Drawing.Size(186, 23);
            this.buttonUpdateBuyerCompany.TabIndex = 6;
            this.buttonUpdateBuyerCompany.Text = "Update Buyer Company";
            this.buttonUpdateBuyerCompany.UseVisualStyleBackColor = true;
            this.buttonUpdateBuyerCompany.Click += new System.EventHandler(this.buttonUpdateBuyerCompany_Click);
            // 
            // buttonDeleteBuyerCompany
            // 
            this.buttonDeleteBuyerCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteBuyerCompany.Location = new System.Drawing.Point(577, 329);
            this.buttonDeleteBuyerCompany.Name = "buttonDeleteBuyerCompany";
            this.buttonDeleteBuyerCompany.Size = new System.Drawing.Size(186, 23);
            this.buttonDeleteBuyerCompany.TabIndex = 5;
            this.buttonDeleteBuyerCompany.Text = "Delete Buyer Company";
            this.buttonDeleteBuyerCompany.UseVisualStyleBackColor = true;
            this.buttonDeleteBuyerCompany.Click += new System.EventHandler(this.buttonDeleteBuyerCompany_Click);
            // 
            // dataGridViewBuyerCompany
            // 
            this.dataGridViewBuyerCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBuyerCompany.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBuyerCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBuyerCompany.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewBuyerCompany.Name = "dataGridViewBuyerCompany";
            this.dataGridViewBuyerCompany.RowTemplate.Height = 25;
            this.dataGridViewBuyerCompany.Size = new System.Drawing.Size(756, 312);
            this.dataGridViewBuyerCompany.TabIndex = 0;
            // 
            // buttonAddBuyerCompany
            // 
            this.buttonAddBuyerCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddBuyerCompany.Location = new System.Drawing.Point(7, 329);
            this.buttonAddBuyerCompany.Name = "buttonAddBuyerCompany";
            this.buttonAddBuyerCompany.Size = new System.Drawing.Size(186, 23);
            this.buttonAddBuyerCompany.TabIndex = 4;
            this.buttonAddBuyerCompany.Text = "Add Buyer Company";
            this.buttonAddBuyerCompany.UseVisualStyleBackColor = true;
            this.buttonAddBuyerCompany.Click += new System.EventHandler(this.buttonAddBuyerCompany_Click);
            // 
            // Others
            // 
            this.Others.Controls.Add(this.buttonQueries);
            this.Others.Controls.Add(this.dataGridViewOther);
            this.Others.Controls.Add(this.comboBoxChooseItem);
            this.Others.Controls.Add(this.comboBoxChooseQuery);
            this.Others.Location = new System.Drawing.Point(4, 24);
            this.Others.Name = "Others";
            this.Others.Size = new System.Drawing.Size(768, 355);
            this.Others.TabIndex = 3;
            this.Others.Text = "Other";
            this.Others.UseVisualStyleBackColor = true;
            // 
            // buttonQueries
            // 
            this.buttonQueries.Location = new System.Drawing.Point(640, 12);
            this.buttonQueries.Name = "buttonQueries";
            this.buttonQueries.Size = new System.Drawing.Size(121, 23);
            this.buttonQueries.TabIndex = 3;
            this.buttonQueries.Text = "Виконати";
            this.buttonQueries.UseVisualStyleBackColor = true;
            this.buttonQueries.Click += new System.EventHandler(this.buttonQueries_Click);
            // 
            // dataGridViewOther
            // 
            this.dataGridViewOther.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOther.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOther.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOther.Location = new System.Drawing.Point(3, 42);
            this.dataGridViewOther.Name = "dataGridViewOther";
            this.dataGridViewOther.RowTemplate.Height = 25;
            this.dataGridViewOther.Size = new System.Drawing.Size(762, 310);
            this.dataGridViewOther.TabIndex = 2;
            // 
            // comboBoxChooseItem
            // 
            this.comboBoxChooseItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxChooseItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseItem.FormattingEnabled = true;
            this.comboBoxChooseItem.Location = new System.Drawing.Point(401, 12);
            this.comboBoxChooseItem.Name = "comboBoxChooseItem";
            this.comboBoxChooseItem.Size = new System.Drawing.Size(233, 23);
            this.comboBoxChooseItem.TabIndex = 1;
            this.comboBoxChooseItem.Visible = false;
            this.comboBoxChooseItem.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseItem_SelectedIndexChanged);
            // 
            // comboBoxChooseQuery
            // 
            this.comboBoxChooseQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseQuery.FormattingEnabled = true;
            this.comboBoxChooseQuery.Items.AddRange(new object[] {
            "Показати канцтовари з максимальною кількістю одиниць.",
            "Показати канцтовари з мінімальною кількістю одиниць.",
            "Показати канцтовари з мінімальною собівартістю одиниці.",
            "Показати канцтовари з максимальною собівартістю одиниці.",
            "Показати канцтовари заданого типу.",
            "Показати канцтовари, які продав певний менеджер з продажу.",
            "Показати канцтовари, які закупила певна фірма-покупець.",
            "Показати інформацію про нещодавній продаж.",
            "Показати середню кількість товарів по кожному типу канцтоварів."});
            this.comboBoxChooseQuery.Location = new System.Drawing.Point(3, 13);
            this.comboBoxChooseQuery.Name = "comboBoxChooseQuery";
            this.comboBoxChooseQuery.Size = new System.Drawing.Size(392, 23);
            this.comboBoxChooseQuery.TabIndex = 0;
            this.comboBoxChooseQuery.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseQuery_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.labelConnStatus);
            this.Controls.Add(this.button_SwitchOnOff);
            this.Controls.Add(this.buttonDownload);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tabControlMain.ResumeLayout(false);
            this.Stationery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStationery)).EndInit();
            this.Type.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewType)).EndInit();
            this.Manager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManager)).EndInit();
            this.BuyerCompany.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuyerCompany)).EndInit();
            this.Others.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOther)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonDownload;
        private Button button_SwitchOnOff;
        private Label labelConnStatus;
        private TabControl tabControlMain;
        private TabPage Stationery;
        private TabPage Type;
        private TabPage Manager;
        private TabPage Others;
        private DataGridView dataGridViewStationery;
        private DataGridView dataGridViewType;
        private DataGridView dataGridViewManager;
        private DataGridView dataGridViewOther;
        private ComboBox comboBoxChooseItem;
        private ComboBox comboBoxChooseQuery;
        private Button buttonQueries;
        private TabPage BuyerCompany;
        private DataGridView dataGridViewBuyerCompany;
        private Button buttonUpdateStationery;
        private Button buttonDeleteStationery;
        private Button buttonAddStationery;
        private Button buttonUpdateType;
        private Button buttonDeleteType;
        private Button buttonAddType;
        private Button buttonUpdateManager;
        private Button buttonDeleteManager;
        private Button buttonAddManager;
        private Button buttonUpdateBuyerCompany;
        private Button buttonDeleteBuyerCompany;
        private Button buttonAddBuyerCompany;
    }
}