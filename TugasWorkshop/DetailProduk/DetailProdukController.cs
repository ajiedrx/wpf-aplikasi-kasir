using System;
using System.Collections.Generic;
using TugasWorkshop.Database;
using TugasWorkshop.Database.Model;
using TugasWorkshop.Keranjang;

namespace TugasWorkshop.DetailProduk {
    public class DetailProdukController : IDetailProdukController{
        private DetailProdukView detailProdukView;
        private ProductDatabase productDatabase = ProductDatabase.getInstance();
        private KeranjangDatabase keranjangDatabase = KeranjangDatabase.getInstance();
        private List<Product> products;
        private int nomor = 0;

        public DetailProdukController() { }
        public DetailProdukController(DetailProdukView _detailProdukView) {
            detailProdukView = _detailProdukView;
            products = productDatabase.getProducts();
        }

        public void execute() {
            setComboBoxItems();
        }
        private void setComboBoxItems() {
            detailProdukView.setProducts(products);
        }


        public void setKeranjangView(KeranjangView _keranjangView) {
            detailProdukView.setKeranjangView(_keranjangView);        
        }

        public void addToKeranjang(Product _product, int _jumlah, int _subtotal) {
            nomor += 1;
            keranjangDatabase.addItem(new KeranjangM() {
                nomor = nomor,
                jumlah = _jumlah,
                namaProduk = _product.namaProduk,
                subtotal = _subtotal
            });
            for (int i = 0; i < keranjangDatabase.getKeranjang().Count; i++) {
                Console.WriteLine(keranjangDatabase.getKeranjang()[i].namaProduk);
            }
        }
    }
}
