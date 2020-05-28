using System.Windows;
using TugasWorkshop.Database;
using TugasWorkshop.Database.Model;
using TugasWorkshop.Enum;
using TugasWorkshop.Login;
using TugasWorkshop.Register;

namespace TugasWorkshop {
    public partial class MainWindow : Window {
        private ProductDatabase productDatabase = ProductDatabase.getInstance();
        private UserDatabase userDatabase = UserDatabase.getInstance();
        public MainWindow() {
            InitializeComponent();
            initProducts();
            initUsers();
            LoginView login = new LoginView();
            login.Show();
            this.Close();
        }

        private void initProducts() {
            productDatabase.addProduct(
                new Product() { namaProduk = "Beras 1Kg", hargaProduk = 20000});
            productDatabase.addProduct(
                new Product() { namaProduk = "Indomie 1 Karton", hargaProduk = 50000 });
            productDatabase.addProduct(
                new Product() { namaProduk = "Minyak Goreng 1L", hargaProduk = 20000 });
            productDatabase.addProduct(
                new Product() { namaProduk = "Telur 1Kg", hargaProduk = 10000 });
        }

        int id = 0;
        private void initUsers() {
            userDatabase.addUser(new User() {
                id = id++,
                username = "dibyo",
                password = "dibyo",
                userType = EUserType.karyawan
            });
        }
    }
}
