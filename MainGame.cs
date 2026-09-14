namespace Blackjack
{
    class MainGame
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("Welcome! Press enter to begin.");
            Console.ReadLine(); // press enter to then print new text aka the line of code below this comment
            Console.Clear();
            Console.WriteLine("- Blackjack 2026 project, for ZBC -");
            
            // Creates the 52-card deck
            List<Cards> deck = Cards.CreateDeck(); // deck = Cards.create_deck()

            // Prints all 52 cards to the console
            Cards.PrintDeck(deck);
        }
        
        // TODO: Create a List<Card> deck collection in MainGame.cs

        // TODO: Call the deck creation code when the application starts in Main()

        // TODO: Finish the PrintDeck method to iterate through and display each card in the deck
        
        // TODO: Write a loop to populate the deck with all 52 unique Suit & Rank combinations

    }
}