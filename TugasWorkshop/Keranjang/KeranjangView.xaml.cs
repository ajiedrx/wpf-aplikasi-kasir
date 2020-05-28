using System;
using System.Collections.Generic;
using System.Windows;
using TugasWorkshop.Database.Model;
using TugasWorkshop.DetailProduk;
using TugasWorkshop.Enum;
using TugasWorkshop.Login;
using TugasWorkshop.RecordTransaksi;

namespace TugasWorkshop.Keranjang {
    public partial class KeranjangView : Window {
        private List<KeranjangM> keranjangs = new List<KeranjangM>();
        private KeranjangController keranjangController;
        private EUserType userType;

        public KeranjangView() {
            InitializeComponent();
            keranjangController = new KeranjangController(this);
            setDateTime(keranjangController.getCurrentTime());
            keranjangController.execute();
            this.DataContext = keranjangs;
            total_tb.Text = "Rp. " + keranjangController.getTotalBelanja().ToString();
        }

        public KeranjangView(List<KeranjangM> _data) {
            keranjangs = _data;
        }

        public void setPelangganName(string _text) {
            namaPelanggan_tb.Text = _text;
        }

        private void setDateTime(DateTime _dateTime) {
            dateTime_tb.Text = _dateTime.ToString();
        }

        public void setUserType(EUserType eUserType) {
            userType = eUserType;
        }

        private void onClickTambahBtn(object sender, RoutedEventArgs e) {
            DetailProdukView detailProdukView = new DetailProdukView();
            this.Hide();
            detailProdukView.Show();
        }

        public void setKeranjangs(List<KeranjangM> _keranjangs) {
            keranjangs = _keranjangs;
            this.DataContext = keranjangs;
        }

        private void batal_btn_Click(object sender, RoutedEventArgs e) {
            if (userType == EUserType.karyawan) {
                RekapTransaksiView rekapTransaksiView = new RekapTransaksiView();
                rekapTransaksiView.Show();
                this.Hide();
            } else {
                LoginView loginView = new LoginView();
                loginView.Show();
                this.Hide();
            }
        }

        private void bayar_btn_Click(object sender, RoutedEventArgs e) {
            ConfirmationPopUp confirmationPopUp = new ConfirmationPopUp();
            keranjangController.addRekapTransaksi();
            confirmationPopUp.Show();
        }

        private void hapus_btn_Click(object sender, RoutedEventArgs e) {
            keranjangController.deleteItem((KeranjangM)keranjang_dg.SelectedItem);
            this.DataContext = keranjangs;
            KeranjangView keranjangView = new KeranjangView();
            keranjangView.Show();
            this.Close();
        }
    }
}
