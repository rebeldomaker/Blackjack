namespace Blackjack;

class Cards
{
    // auto-implements, to skip writing helper functions
    public string Rank { get; set; }
    public string Suit { get; set; }
    public int Value { get; set; }

    // the constructor's job is to initialize a new card object with specific values as soon as you create it.
    public Cards(string rank, string suit, int value) // constructor, no return type. Regular methods specify what they return (like void, int, or List<Cards>). A constructor has no return type at all—not even void.
    { // Cards name must match the class name.
      // It runs automatically when using the 'new' keyword. Its main job is to set up the initial values for a brand new object.
        Rank = rank;
        Suit = suit;
        Value = value;
    } // assignments (Rank = rank;, etc.): The code takes those input values and assigns them to the class properties (Rank, Suit, Value).
      // Storage: Once assigned, that specific instance of Cards holds its own rank, suit, and point value in memory for the rest of the game.

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
    } /*for suit in suits:
             for rank in ranks:
                 # Figure out the point value
                 if rank == "Ace":
                     value = 11
                 elif rank in ["Jack", "Queen", "King"]:
                     value = 10
                 else:
                     value = int(rank)  # Convert text like "7" into number 7
         
                 # Put the card into the deck list
                 deck.append(Cards(rank, suit, value))
         
         return deck*/

    // Iterates through and displays each card in the deck list
    public static void PrintDeck(List<Cards> cards)
    {
        foreach (Cards card in cards)
        {
            Console.WriteLine($"{card.Rank} of {card.Suit} (Value: {card.Value})");
        }
    }

    // Defined properties (Suit, Rank, Value) inside the Card class above
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