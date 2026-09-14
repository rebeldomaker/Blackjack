namespace Blackjack;

class Cards
{
    // TODO: Define properties (Suit, Rank, Value) inside the Card class
    /* import random as rand
        def card()
            foreach i in deck range(52):
                print(card-deck)*/

    public string Rank { get; set; }
    public string Suit { get; set; }
    public int Value { get; set; }

    public Cards(string rank, string suit, int value)
    {
        Rank = rank;
        Suit = suit;
        Value = value;
    }

    public static List<Cards> CreateDeck()
    {
        List<Cards> deck = new List<Cards>();

        string[] ranks = {
            "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"
        };

        string[] suits = {
            "♣", "♦", "♥", "♠"
        };

        foreach (string suit in suits)
        {
            for (int i = 0; i < ranks.Length; i++)
            {
                string rank = ranks[i];
                int value;

                if (rank == "Ace")
                {
                    value = 11;
                }
                else if (rank == "Jack" || rank == "Queen" || rank == "King")
                {
                    value = 10;
                }
                else
                {
                    value = int.Parse(rank);
                }

                deck.Add(new Cards(rank, suit, value));
            }
        }

        return deck;
    }

    public static void PrintDeck(List<Cards> cards)
    {
        foreach (Cards card in cards)
        {
            Console.WriteLine($"{card.Rank} of {card.Suit} (Value: {card.Value})");
        }
    }
}