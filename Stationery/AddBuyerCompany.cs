using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stationery
{
    public partial class AddBuyerCompany : Form
    {
        private readonly BuyerCompany buyerCompany;
        public AddBuyerCompany(BuyerCompany buyerCompany)
        {
            InitializeComponent();
            this.buyerCompany = buyerCompany;

            if(buyerCompany.Name != null )
            {
                textBoxName.Text = buyerCompany.Name;
                Text = "Update Buyer Company";
            }
            else
            {
                Text = "Add Buyer Company";
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxName.Text))
            {
                buyerCompany.Name = textBoxName.Text;
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
