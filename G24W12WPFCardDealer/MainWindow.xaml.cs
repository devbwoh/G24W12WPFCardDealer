using System.Windows;

namespace G24W12WPFCardDealer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private CardModel cardModel = new CardModel();
        private CardViewModel viewModel;

        public MainWindow() {
            InitializeComponent();

            viewModel = new CardViewModel(cardModel);

            DataContext = viewModel;
        }

        private void OnDeal(object sender, RoutedEventArgs e) {
            viewModel.DealCards();
        }
    }
}