namespace Blackjack
{
    // Handles entry point and main game flow
    class MainGame
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("Welcome! Press enter to begin.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("- Blackjack 2026 project, for ZBC -");
            
            // Creates the 52-card deck
            List<Cards> deck = Cards.CreateDeck();[cite: 1]

            // Create a List<Cards> playerHand collection to represent the player's hand (initially empty)
            List<Cards> playerHand = new List<Cards>();[cite: 2]

            // Call Cards.DrawCard(deck) twice and add both drawn cards to playerHand
            for (int i = 0; i < 2; i++) 
            {
                Cards drawnCard = Cards.DrawCard(deck);[cite: 1, 2]
                playerHand.Add(drawnCard);[cite: 2]
            }
               
            // Display both cards in playerHand to the console using a loop or individual WriteLine statements
            foreach (Cards card in playerHand)
            {
                Console.WriteLine($"You drew {card.Rank} of {card.Suit}");[cite: 1, 2]
            }

            // Verify playerHand.Count equals 2 to confirm the initial deal is complete
            if (playerHand.Count == 2)[cite: 2]
            {
                Console.WriteLine("Initial deal complete!");[cite: 2]
            }

            // Calculate initial score
            int initialScore = 0;
            int initialAces = 0;
            foreach (Cards card in playerHand)
            {
                initialScore += card.Value;[cite: 1]
                if (card.Rank == "Ace")[cite: 1]
                {
                    initialAces++;
                }
            }
            while (initialScore > 21 && initialAces > 0)
            {
                initialScore -= 10;
                initialAces--;
            }
            Console.WriteLine($"Your starting score is: {initialScore}\n");
            
            // Prompt the player to hit or stand after the initial deal
            Console.WriteLine("Do you wish to hold? (Type HOLD if you want to stand)");
            string choice = Console.ReadLine().Trim().ToLower();

            // TODO: Create a loop that continues prompting until the player chooses to hold (stand)
            while (choice != "hold" && deck.Count > 0) 
            {
                Console.WriteLine("Press Enter to draw or type HOLD to stand:"); 
                choice = Console.ReadLine().Trim().ToLower();
            } // TODO: If the player chooses to draw (hit):

            if (choice = )
            /*
            if choice in ['h', 'hit']:
# - Draw exactly one card using the existing Cards.DrawCard method
            drawn_card = Cards.draw_card(deck)
        
# - Add the card to the player's hand
            player_hand.append(drawn_card)

# - Display the newly drawn card
            print(f"You drew: {drawn_card.rank} of {drawn_card.suit}")

# - Recalculate and display the updated hand total (handling Ace logic)
            score = 0
            aces = 0

            for card in player_hand:
            score += card.value
            if card.rank == "Ace":
            aces += 1

            while score > 21 and aces > 0:
            score -= 10
            aces -= 1

            print(f"Your current score is: {score}")

# - Check if the player busted (score > 21)
            if score > 21:
            print("Bust! You went over 21.")
            break

# TODO: If the player chooses to hold (stand), break out of the prompt loop
            elif choice in ['s', 'stand']:
            print("You chose to stand. Turn ends.")
            break

            else:
            print("Invalid option. Please enter 'H' or 'S'.")*/
        }
    }
}