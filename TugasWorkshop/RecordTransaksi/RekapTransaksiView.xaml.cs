using System.Collections.Generic;
using System.Windows;
using TugasWorkshop.Database.Model;
using TugasWorkshop.Keranjang;
using TugasWorkshop.Login;

namespace TugasWorkshop.RecordTransaksi {
    public partial class RekapTransaksiView : Window {
        public List<RekapTransaksi> tableData;
        public RekapTransaksiController rekapTransaksiController;
        public RekapTransaksiView() {
            InitializeComponent();
            rekapTransaksiController = new RekapTransaksiController(this);
            rekapTransaksiController.execute();
            this.DataContext = tableData;
        }

        public void setTableData(List<RekapTransaksi> _rekapTransaksi) {
            this.tableData = _rekapTransaksi;
            refreshTableData();
        }

        private void refreshTableData() {
            this.DataContext = tableData;
        }

        private void transaksiBaru_btn_Click(object sender, RoutedEventArgs e) {
            rekapTransaksiController.resetKeranjang();
            KeranjangView keranjangView = new KeranjangView();
            keranjangView.Show();
            this.Hide();
        }

        private void keluar_btn_Click(object sender, RoutedEventArgs e) {
            LoginView login = new LoginView();
            login.Show();
            this.Close();
        }
    }
}
