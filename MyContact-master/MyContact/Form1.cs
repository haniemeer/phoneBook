using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContact
{
    public partial class Form1 : Form
    {
        private IContactRepository contact;
        public Form1()
        {
            InitializeComponent();
            contact = new ContactRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void getData()
        {
            dgContact.AutoGenerateColumns = false;
            dgContact.DataSource = contact.SelectAll();
        }

        private void TsbRefresh_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void TsbAddUser_Click(object sender, EventArgs e)
        {
            AddEdit_form frm = new AddEdit_form();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                getData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string name = dgContact.CurrentRow.Cells[1].Value.ToString();
            string family = dgContact.CurrentRow.Cells[2].Value.ToString();
            String fullName = name + " " + family;
            if (dgContact.SelectedRows != null)
            {
                if (MessageBox.Show($"آیا از حذف {fullName} مطمئن هستید؟", "توجه", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int Contact_ID = Convert.ToInt32(dgContact.CurrentRow.Cells[0].Value);
                    contact.Delete(Contact_ID);
                    getData();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخص را انتخاب کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            int Contact_ID = Convert.ToInt32(dgContact.CurrentRow.Cells[0].Value.ToString());
            AddEdit_form frm = new AddEdit_form();
            frm.ContactID = Contact_ID;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                getData();
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgContact.DataSource = contact.Search(txtSearch.Text);
        }
    }
}
