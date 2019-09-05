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

namespace Sy.Forms
{
    public partial class OrderFrom : Form
    {
        private readonly IRepository<Product, Guid> _productRepo;
        private readonly IRepository<ProductStockAction, long> _productActionRepo;
        public OrderFrom()
        {
            InitializeComponent();
            _productRepo = new Repository<Product, Guid>();
            _productActionRepo = new Repository<ProductStockAction, long>();
            ListeyiDoldur();
        }

        private void ListeyiDoldur(string search = "")
        {
            var data = _productRepo.Query(x => x.ProductName.Contains(search))
                .Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    UnitPrice = x.UnitPrice,
                    CriticStock = x.CriticStock,
                    ProductName = x.ProductName,
                }).ToList();
            foreach (var item in data)
            {
                var actionList = _productActionRepo.Query(x => x.ProductId == item.Id).ToList();
                if (!actionList.Any()) continue;

                var girenAdet = actionList.Where(x => x.StockActionType == StockActionType.Incoming)
                    .Sum(x => x.Quantity);
                var cikanAdet = actionList.Where(x => x.StockActionType == StockActionType.Outgoing)
                    .Sum(x => x.Quantity);
                item.UnitsInStock = girenAdet - cikanAdet;
            }
            lstUrunler.DataSource = data;
            lstUrunler.DisplayMember = "Display";
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            ListeyiDoldur(txtAra.Text);
        }
        private ProductViewModel seciliurun;
        private void lstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedItem == null)
            {
                return;
            }
            seciliurun = lstUrunler.SelectedItem as ProductViewModel;
            lblUrunAdi.Text = seciliurun.ProductName;
            lblStokMiktari.Text = seciliurun.UnitsInStock.ToString();
        }
        
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                _productActionRepo.insert(new ProductStockAction()
                {
                    ProductId = seciliurun.Id,
                    Quantity = Convert.ToInt32(nudMiktar.Value),
                    UnitPrice = nudAlisFiyati.Value,
                    StockActionType = StockActionType.Incoming
                });
                MessageBox.Show("Stok Ekleme İşlemi Başarılı..");
            }
                
            catch (Exception)
            {

                throw;
            }
        }
    }
}
