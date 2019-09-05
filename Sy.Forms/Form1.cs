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
using Sy.Core.ComplexTypes;
using Sy.Core.Enums;

namespace Sy.Forms
{
    public partial class Form1 : Form
    {
        private Repository<Product, Guid> _productrepo;

        public Form1()
        {
            InitializeComponent();
            _productrepo = new Repository<Product, Guid>();
            groupBox1.Visible = true;
            lblGirisBilgi.Visible = false;
            menuStrip1.Visible = false;
            
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            frm.ShowDialog();

            if (StockSettings.UserInfo == null)
            {
                groupBox1.Visible = true;
                lblGirisBilgi.Visible = false;
            }
            else
            {
                groupBox1.Visible = false;
                lblGirisBilgi.Visible = true;
                lblGirisBilgi.Text = StockSettings.UserInfo.Display;
                menuStrip1.Visible = true;
                if (StockSettings.UserInfo.ApplicationRole == ApplicationRole.Customer)
                {
                    ürünlerToolStripMenuItem.Visible = false;
                    müşterilerToolStripMenuItem.Visible = false;
                }
            }
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            RegisterForm rgstr = new RegisterForm();
            rgstr.ShowDialog();
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.Show();
        }

        private void siparişlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderFrom frm = new OrderFrom();
            frm.Show();
        }
    }
}
