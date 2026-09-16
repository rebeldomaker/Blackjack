namespace Blackjack
{
    // Handles entry point and main game flow
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
        
    // As a player, I want to draw a card, so that I can begin building my hand.
    // 	todo The player can draw a single card from the deck.
    // 	todo The game displays the suit and rank of the drawn card.
    // 	todo The drawn card is removed from the deck.
    // 	todo The same card cannot be drawn again during the current deck.
    // Developer Notes
    // 	todo Create a method for drawing a card from the deck. The method should return the drawn card.
    // 	todo Choose a card at random from the remaining cards in the deck.
    // 	todo Remove the card from the deck before returning it.
    }
}