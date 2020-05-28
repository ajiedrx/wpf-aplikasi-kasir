using System.Windows;


namespace TugasWorkshop {
    public partial class ConfirmationPopUp : Window {
        public ConfirmationPopUp() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
