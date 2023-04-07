namespace Stationery
{
    public partial class AddType : Form
    {
        private readonly Type type;
        public AddType(Type type)
        {
            InitializeComponent();
            this.type = type;

            if (type.Name != null)
            {
                Text = "Update type";
                textBoxName.Text = type.Name;
            }
            else
            {
                Text = "Add type";
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxName.Text))
            {
                type.Name = textBoxName.Text;
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
