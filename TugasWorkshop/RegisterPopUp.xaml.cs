using System.Windows;

namespace TugasWorkshop {
    public partial class RegisterPopUp : Window {
        public RegisterPopUp() {
            InitializeComponent();
        }

        private void okButton_btn_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
