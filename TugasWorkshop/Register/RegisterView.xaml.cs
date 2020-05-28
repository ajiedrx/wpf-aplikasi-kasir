using System.Collections.Generic;
using System.Windows;
using TugasWorkshop.Keranjang;
using TugasWorkshop.Login;
using TugasWorkshop.RecordTransaksi;

namespace TugasWorkshop.Register {
    public partial class RegisterView : Window {
        private RegisterController registerController;
        public RegisterView() {
            InitializeComponent();
            initComboBoxItems();
            registerController = new RegisterController(this);
        }

        private void initComboBoxItems() {
            List<string> comboBoxItems = new List<string>();
            comboBoxItems.Add("Pelanggan");
            comboBoxItems.Add("Karyawan");
            jenisAkun_cbx.ItemsSource = comboBoxItems;
        }

        private void onClickRegisterBtn(object sender, RoutedEventArgs e) {
            string userType = jenisAkun_cbx.SelectedItem.ToString();
            string username  = userName_tb.Text;
            string password  = password_tb.Text;
            string cPassword = cPassword_tb.Text;

            if (password.Equals(cPassword)) {
                registerController.register(userType, username, password);
            } else {
                RegisterPopUp registerPopUp = new RegisterPopUp();
                registerPopUp.Show();
            }
        }

        public void movePage(bool _type) {
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

        private void login_btn_Click(object sender, RoutedEventArgs e) {
            LoginView login = new LoginView();
            login.Show();
            this.Close();
        }
    }
}
