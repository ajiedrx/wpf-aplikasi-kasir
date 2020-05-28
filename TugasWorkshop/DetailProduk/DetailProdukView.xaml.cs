using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TugasWorkshop.Database.Model;
using TugasWorkshop.Keranjang;

namespace TugasWorkshop.DetailProduk {
    public partial class DetailProdukView : Window {
        private DetailProdukController detailProdukController;
        private Product selectedProduct;
        private KeranjangView keranjangView;
        private int pieces;
        private int subtotal;

        public DetailProdukView() {
            InitializeComponent();
            detailProdukController = new DetailProdukController(this);
            detailProdukController.execute();
        }

        public void setProducts(List<Product> _products) {
            produk_cbx.ItemsSource = _products;
        }

        private void produk_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectedProduct = ((Product)produk_cbx.SelectedItem);
            hargaSatuan_txt.Text = "Rp. " + selectedProduct.hargaProduk.ToString();
            subTotal_txt.Text = "";
            jumlah_tb.Clear();
        }

        public void setKeranjangView(KeranjangView _keranjangView) {
            this.keranjangView = _keranjangView;
        }

        private void jumlah_tb_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void jumlah_tb_TextChanged(object sender, TextChangedEventArgs e) {
            if (int.TryParse(jumlah_tb.Text, out pieces)) {
                subtotal = selectedProduct.hargaProduk * pieces;
                if (produk_cbx.SelectedItem != null) {
                    subTotal_txt.Text = "Rp. " + (subtotal).ToString();
                }
            } else {
                pieces = 0;
                subTotal_txt.Text = "";
            }
        }

        private void tambah_btn_Click(object sender, RoutedEventArgs e) {
            if (produk_cbx.SelectedItem != null && jumlah_tb.Text != null) {
                detailProdukController.addToKeranjang(selectedProduct, pieces, subtotal);
                Console.WriteLine(selectedProduct.namaProduk + pieces + subtotal);
                keranjangView = new KeranjangView();
                keranjangView.Show();
                this.Hide();
            }
        }
    }
}
