using System.Windows;
using System.Windows.Media.Imaging;

namespace G24W12WPFCardDealer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void OnDeal(object sender, RoutedEventArgs e) {
            string[] suits = ["spades", "diamonds", "hearts", "clubs",];
            string[] values = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace",];

            Random random = new Random();
            int card = random.Next(suits.Length * values.Length);

            string suit = suits[card / values.Length];
            string value = values[card % values.Length];

            //--------------------------------------------
            // Jack, Queen, King일 때 suit 뒤에 2 붙이기
            //--------------------------------------------
            // 방법 1. Windows Forms 때처럼 if 문에서 suit에 "2" 추가
            //if (value == "jack" || value == "queen" || value == "king")
            //    suit += "2";

            // 방법 2. Contains 사용
            //if (new string[] { "jack", "queen", "king" }.Contains(value))
            //    suit += "2";

            // 방법 3. IndexOf() 함수 사용해도 됨
            //if (Array.IndexOf(new string[] { "jack", "queen", "king" }, value) != -1)
            //    suit += "2";

            // 방법 4. Lambda Expression을 사용하여 c % 13 값이 10, 11, 12와 일치하는지 검사
            if (Array.Exists(new string[] { "jack", "queen", "king" }, x => x == value))
                suit += "2";

                BitmapImage image = new BitmapImage(
                new Uri($"Images/{value}_of_{suit}.png", UriKind.Relative)
            );
            Card1.Source = image;
        }
    }
}