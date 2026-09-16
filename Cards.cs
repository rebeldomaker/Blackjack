namespace Blackjack;

class Cards
{
    // auto-implements, to skip writing helper functions
    public string Rank { get; set; }
    public string Suit { get; set; }
    public int Value { get; set; }

    // the constructor's job is to initialize a new card object with specific values as soon as you create it.
    public Cards(string rank, string suit, int value)
    {
        Rank = rank;
        Suit = suit;
        Value = value;
    }

    public static List<Cards> CreateDeck()
    {
        // Initializes the List<Cards> deck collection
        List<Cards> deck = new List<Cards>();

        string[] ranks = {
            "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"
        };

        string[] suits = {
            "♣", "♦", "♥", "♠"
        };

        // Loops to populate the deck with all 52 unique Suit & Rank combinations
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

    // Iterates through and displays each card in the deck list
    public static void PrintDeck(List<Cards> cards)
    {
        foreach (Cards card in cards)
        {
            Console.WriteLine($"{card.Rank} of {card.Suit} (Value: {card.Value})");
        }
    }

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

    // Draws a random card from the deck, removes it from the list, and returns it
    public static Cards DrawCard(List<Cards> deck)
    { 
       Random rng = new Random();

       // 1. Pick a random index between 0 and deck.Count - 1
       int randomIndex = rng.Next(deck.Count);

       // 2. Save the card at that index before removing it
       Cards drawnCard = deck[randomIndex];

       // 3. Remove the card from the deck so it can't be drawn again
       deck.RemoveAt(randomIndex);

       // 4. Return the saved card
       return drawnCard;
    }
}