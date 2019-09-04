using Sy.Business.Repository;
using Sy.Core.Abstracts;
using Sy.Core.Entities;
using Sy.Core.Enums;
using Sy.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sy.Forms.Auth
{
    public partial class RegisterForm : Form
    {
        private readonly IRepository<Client, int> _clientRepository; // irepository ile polymorphsim yapıldı..
        public RegisterForm()
        {
            InitializeComponent();
            _clientRepository = new Repository<Client, int>();
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            var model = new RegisterViewModel()
            {
                Name = txtAd.Text,
                Email = txtEmail.Text,
                SurName = txtSoyad.Text,
                Password = txtSifre.Text

            };

            var kontrol = _clientRepository.Query(predicate: x => x.Email == model.Email).Any();

            if (kontrol)
            {
                MessageBox.Show("Bu mail adresi kullanılmaktadır..");
                return;
            }

            var MusteriMi = _clientRepository.Query().Any(); // any var mı yok mu diye kontrol ediyor..

            _clientRepository.insert(new Client()
            {
                Email = model.Email,
                SurName = model.SurName,
                Name = model.Name,
                Password = model.Password,
                ApplicationRole = MusteriMi ? ApplicationRole.Customer : ApplicationRole.Admin
            });
            MessageBox.Show("Kayıt Başarılıdır..");
            this.Close();
        }
    }
}
