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
            List<Cards> deck = Cards.CreateDeck(); // deck = Cards.create_deck()

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
        }
    }
}