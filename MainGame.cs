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

            // Prints all 52 cards to the console
            Cards.PrintDeck(deck);

            // Call Cards.DrawCard(deck) and store the returned card in a variable
            Cards drawnCard = Cards.DrawCard(deck);

            // Print the drawn card's Rank and Suit to the console so the player can see what they drew
            Console.WriteLine($"You drew the {drawnCard.Rank} of {drawnCard.Suit}!");        }
    }
}