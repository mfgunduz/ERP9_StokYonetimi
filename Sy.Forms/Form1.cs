using Sy.Business.Repository;
using Sy.Forms.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sy.Core.Entities;

namespace Sy.Forms
{
    public partial class Form1 : Form
    {
        private Repository<Product, Guid> _productrepo;

        public Form1()
        {
            InitializeComponent();
            _productrepo = new Repository<Product, Guid>();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            frm.ShowDialog();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            RegisterForm rgstr = new RegisterForm();
            rgstr.ShowDialog();
        }
    }
}
