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

    // Draws a random card from the deck, removes it from the list, and returns it. 
    public static Cards DrawCard(List<Cards> deck)
    { 
       Random rng = new Random();

       // 1. Pick a random index between 0 and deck.Count - 1
       int randomIndex = rng.Next(deck.Count);

       // 2. Save the card at that index before removing it
       Cards drawnCard = deck[randomIndex];

       // 3. Remove the card from the deck so it can't be drawn again
       deck.RemoveAt(randomIndex); // The drawn card is removed from the deck.

       // 4. Return the saved card
       return drawnCard;
    }

    /*
    US-05: As a player, I want to see the cards in my hand, so that I know what I have drawn.
    US-13: As a player, I want Aces to count as either 1 or 11, so that hands are evaluated according to the rules of Blackjack.
    Developer Notes:
    - Update the existing method for calculating the value of a hand.
    - An Ace counts as 11 whenever possible without causing the hand to go bust.
    - If counting an Ace as 11 would cause the hand to exceed 21, it counts as 1 instead.
    */
    public static int CalculateHandValue(List<Cards> hand)
    {
        int score = 0;
        int aces = 0;

        foreach (Cards card in hand)
        {
            score += card.Value;
            if (card.Rank == "Ace")
            {
                aces++;
            }
        }

        // Reduce Ace values from 11 to 1 (-10 per Ace) as long as total score is > 21
        while (score > 21 && aces > 0)
        {
            score -= 10;
            aces--;
        }

        return score;
    }

    /*
    US-07: As a player, I want the game to tell me when I have gone bust, so that I know I have lost the round.
    Developer Notes:
    - Create a method that determines whether a hand has gone bust.
    - Reuse the existing method for calculating the value of a hand.
    */
    public static bool IsBust(List<Cards> hand)
    {
        return CalculateHandValue(hand) > 21;
    }
}