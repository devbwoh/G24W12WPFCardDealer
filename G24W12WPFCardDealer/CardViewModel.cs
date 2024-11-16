using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace G24W12WPFCardDealer;

class CardViewModel : INotifyPropertyChanged {
    private CardModel cardModel;

    private ObservableCollection<string> _cardResource;

    public ObservableCollection<string> CardResource {
        get { return _cardResource; }
    }

    public CardViewModel(CardModel cardModel) {
        this.cardModel = cardModel;

        _cardResource = new ObservableCollection<string>();

        GetResourceName(cardModel.Cards);
    }

    public void DealCards() {
        var newCards = cardModel.DealCards();

        GetResourceName(newCards);
    }

    private void GetResourceName(List<Card> cards) {
        _cardResource.Clear();

        foreach (var card in cards) {
            _cardResource.Add(GetCardImageName(card));
        }

        OnPropertyChanged(nameof(CardResource));
    }

    private string GetCardImageName(Card card) {
        string[] suits = ["spades", "diamonds", "hearts", "clubs",];
        string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king",];

        if (card.Suit < 0 || card.Value < 0)
            return "Images/black_joker.png";

        string suit = suits[card.Suit];
        string value = values[card.Value];

        return (value == "jack" || value == "queen" || value == "king")
            ? $"Images/{value}_of_{suit}2.png"
            : $"Images/{value}_of_{suit}.png";
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propName = "") {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
