namespace Blackjack;

// TODO: Write a loop to populate the deck with all 52 unique Suit & Rank combinations
// TODO: Call the deck creation code when the application starts in Main()
// TODO: Finish the PrintDeck method to iterate through and display each card in the deck

class Card
{
    // TODO: Define properties (Suit, Rank, Value) inside the Card class

    static void PrintDeck(List<Card> cards)
    {
        string[] Rank = {
            "Ace",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "Jack",
            "Queen",
            "King"
        };

        string[] Suit = {
            "♣",
            "♦",
            "♥",
            "♠"
        };
    }
}