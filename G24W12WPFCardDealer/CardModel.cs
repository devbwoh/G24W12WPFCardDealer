namespace G24W12WPFCardDealer;

class Card {
    public static readonly int NUMBER_OF_SUITS = 4;
    public static readonly int NUMBER_OF_VALUES = 13;

    public Card(int suit, int value) {
        Suit = suit;
        Value = value;
    }

    public Card(int number) {
        Suit = number / NUMBER_OF_VALUES;
        Value = number % NUMBER_OF_VALUES;
    }

    public int Suit { get; set; }
    public int Value { get; set; }

}

class CardModel {
    public static readonly int NUMBER_OF_CARDS = 5;

    private List<Card> _cards = new List<Card>();

    public List<Card> Cards { get { return _cards; } }

    public CardModel() {
        // -1, -1이면 Jocker 출력
        for (int i = 0; i < NUMBER_OF_CARDS; i++)
            _cards.Add(new Card(-1, -1));
    }

    public List<Card> DealCards() {
        Random random = new Random();

        // C#에서 Set 없고 대신 HashSet 사용
        // Set은 중복 안되는 성질 이용
        HashSet<int> cardSet = new HashSet<int>();
        while (cardSet.Count < NUMBER_OF_CARDS) {
            cardSet.Add(random.Next(Card.NUMBER_OF_SUITS * Card.NUMBER_OF_VALUES));
        }

        // List로 바꾸고 정렬 (Set은 순서 없음)
        List<int> cardList = cardSet.ToList();
        cardList.Sort();

        _cards.Clear();
        foreach (var cardNumber in cardList) {
            _cards.Add(new Card(cardNumber));
        }

        return Cards;
    }
}
