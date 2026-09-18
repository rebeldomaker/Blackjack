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
            List<Cards> deck = Cards.CreateDeck();

            // Create a List<Cards> playerHand collection to represent the player's hand (initially empty)
            List<Cards> playerHand = new List<Cards>();

            // Call Cards.DrawCard(deck) twice and add both drawn cards to playerHand
            for (int i = 0; i < 2; i++) 
            {
                Cards drawnCard = Cards.DrawCard(deck);
                playerHand.Add(drawnCard);
            }
               
            // Display both cards in playerHand to the console using a loop or individual WriteLine statements
            foreach (Cards card in playerHand)
            {
                Console.WriteLine($"You drew {card.Rank} of {card.Suit}");
            }

            // Verify playerHand.Count equals 2 to confirm the initial deal is complete
            if (playerHand.Count == 2)
            {
                Console.WriteLine("Initial deal complete!");
            }

            // Calculate initial score
            int initialScore = 0;
            int initialAces = 0;
            foreach (Cards card in playerHand)
            {
                initialScore += card.Value;
                if (card.Rank == "Ace")
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

            if (choice == 'h', 'hit').Trim().ToLower()
            {
                drawnCard = Cards.drawCard(deck) // Draw exactly one card using the existing Cards.DrawCard method
                playerHand.Add(drawnCard); // Add the card to the player's hand
                Console.WriteLine($"You drew: {drawnCard.rank} of {drawnCard.suit}"); // Display the newly drawn card
                // Recalculate and display the updated hand total (handling Ace logic)
                int score = 0;
                int aces = 0;
                for card in playerHand
                {
                    score += card.value;
                    if card.rank == "Ace"
                    {
                        aces += 1
                    }
                } while score > 21 && aces > 0
                {
                    score -= 10;
                    aces -= 1
                    {
                        Console.WriteLine($"Your current score is: {score}");
                    }
                    // Check if the player busted (score > 21)
                    if score > 21
                    {
                        Console.WriteLine("Bust! You went over 21");
                        yield break;
                    } 
                    // TODO: If the player chooses to hold (stand), break out of the prompt loop
                else (choice == ("score", "stand"))
                {
                    Console.WriteLine("You chose to stand. Turn ends.");
                    yield break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter 'H' or 'S'.");
                }
                
                }

            }
            /*  
            */
        }
    }
}