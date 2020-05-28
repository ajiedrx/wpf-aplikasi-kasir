using System;
using System.Windows;
using TugasWorkshop.Enum;
using TugasWorkshop.Keranjang;
using TugasWorkshop.RecordTransaksi;
using TugasWorkshop.Register;

namespace TugasWorkshop.Login {
    public partial class LoginView : Window {
        private LoginController loginController;
        public LoginView() {
            InitializeComponent();
            loginController = new LoginController(this);
        }

        private void onClickLogin_btn(object sender, RoutedEventArgs e) {
            string username = username_tb.Text;
            string password = password_tb.Text;

            if (loginController.validate(username, password)) {
                bool type = (loginController.getValidatedUser().userType == EUserType.karyawan ? true : false);
                movePage(type);
            }
        }

        private void movePage(bool _type) {
            if (_type) {
                RekapTransaksiView rekapTransaksi = new RekapTransaksiView();
                rekapTransaksi.Show();
                this.Close();
            } else {
                KeranjangView keranjangView = new KeranjangView();
                keranjangView.Show();
                this.Close();
            }
        }

        private void register_btn_Click(object sender, RoutedEventArgs e) {
            RegisterView registerView = new RegisterView();
            registerView.Show();
            this.Close();
        }
    }
}
