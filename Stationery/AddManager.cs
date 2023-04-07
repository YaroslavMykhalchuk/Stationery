namespace Stationery
{
    public partial class AddManager : Form
    {
        private readonly Manager manager;
        public AddManager(Manager manager)
        {
            InitializeComponent();
            this.manager = manager;

            if(manager.Name != null )
            {
                Text = "Update manager";
                textBoxName.Text = manager.Name;
                textBoxSurname.Text = manager.Surname;
            }
            else
            {
                Text = "Add manager";
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrEmpty(textBoxSurname.Text))
            {
                manager.Name = textBoxName.Text;
                manager.Surname = textBoxSurname.Text;
            }
            else
            {
                MessageBox.Show("Fill in the empty textbox!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
