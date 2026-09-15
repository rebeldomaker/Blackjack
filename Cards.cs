namespace Blackjack;

class Cards
{
    public string Rank { get; set; }
    public string Suit { get; set; }
    public int Value { get; set; }

    public Cards(string rank, string suit, int value) // constructor, no return type. Regular methods specify what they return (like void, int, or List<Cards>). A constructor has no return type at all—not even void.
    { // Cards name must match the class name.
      // It runs automatically when using the 'new' keyword. Its main job is to set up the initial values for a brand new object.
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

    // TODO: Define properties (Suit, Rank, Value) inside the Card class
    /* import random as rand
        def card()
            foreach i in deck range(52):
                print(card-deck)*/

    /* @staticmethod
        def shuffle_deck(deck):
        # random.shuffle modifies the list directly in place
        random.shuffle(deck)*/

    public static void ShuffleDeck(List<Cards> deck)
    {
        Random rng = new Random();
        int n = deck.Count;

        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);

            // Swap deck[i] with deck[j]
            Cards temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }
    }
}