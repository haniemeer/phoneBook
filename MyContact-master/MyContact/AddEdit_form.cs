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
    public partial class AddEdit_form : Form
    {
        private IContactRepository repository;
        public int ContactID = 0;
        public AddEdit_form()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        public bool isValid()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if (txtFamily.Text == "")
            {
                if (MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) ;
                txtFamily.Focus();
                return false;
            }
            if (txtMobile.Text == "")
            {
                if (MessageBox.Show("لطفا موبایل را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) ;
                txtMobile.Focus();
                return false;
            }
            if (txtAge.Value == 0)
            {
                if (MessageBox.Show("لطفا سن را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) ;
                txtAge.Focus();
                return false;
            }
            if (txtEmail.Text == "")
            {
                if (MessageBox.Show("لطفا ایمیل را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) ;
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                bool isSucsess;
                if (ContactID == 0)
                {
                    isSucsess = repository.Insert(txtName.Text, txtFamily.Text, txtEmail.Text, txtMobile.Text, (int)txtAge.Value, txtAddress.Text);
                }
                else
                {
                    isSucsess = repository.Update(ContactID, txtName.Text, txtFamily.Text, txtEmail.Text,
                        txtMobile.Text, (int) txtAge.Value, txtAddress.Text);
                }
                if (isSucsess)
                {
                    MessageBox.Show("عملیات با موفقیت ثبت گردید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(" عملیات با شکست مواجه شد دوباره امتحان کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddEdit_form_Load(object sender, EventArgs e)
        {
            if (ContactID == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش شخص";
                DataTable data = repository.SelectRow(ContactID);
                txtName.Text = data.Rows[0][1].ToString();
                txtFamily.Text = data.Rows[0][2].ToString();
                txtAge.Text = data.Rows[0][3].ToString();
                txtMobile.Text = data.Rows[0][4].ToString();
                txtEmail.Text = data.Rows[0][5].ToString();
                txtAddress.Text = data.Rows[0][6].ToString();
                btnSubmit.Text = "ویرایش";
            }

        }
    }
}
