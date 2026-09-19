namespace Blackjack
{
    // Handles entry point and main game flow
    class MainGame
    {
        static void Main(string[] args)
        {           
            /*
            US-01: As a player, I want to start the game, so that I know it is running.
            Acceptance Criteria:
            - The application builds successfully.
            - The application starts without errors.
            - A welcome message is displayed in the console.
            - The application exits normally after displaying the welcome message.
            */
            Console.WriteLine("Welcome! Press enter to begin.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("- Blackjack 2026 project, for ZBC -");
            
            /*
            US-02: As a player, I want the game to use a deck of cards, so that I can draw cards from it.
            US-12: As a player, I want the game to reshuffle when too few cards remain, so that I can continue playing without running out of cards.
            Developer Notes:
            - Reuse the existing method for creating a deck.
            - Before starting a new round, check how many cards remain in the deck.
            - If fewer than 15 cards remain in the deck, replace the current deck with a newly created deck.
            */
            // Creates the 52-card deck
            List<Cards> deck = Cards.CreateDeck();
            bool keepPlaying = true;

            /*
            US-11: As a player, I want to play another round without restarting the application, so that I can keep playing.
            Acceptance Criteria:
            - After a round has ended, the player is asked whether they wish to play another round.
            - If the player chooses to play another round: A new round begins, hands are emptied, player & dealer receive new hands.
            - If the player chooses to exit, the application terminates normally.
            */
            while (keepPlaying)
            {
                // US-12 Check remaining cards before round starts
                if (deck.Count < 15)
                {
                    Console.WriteLine("\n[Deck Check] Fewer than 15 cards left in deck. Creating and shuffling a new deck...");
                    deck = Cards.CreateDeck();
                }

                // Create a List<Cards> playerHand collection to represent the player's hand (initially empty)
                List<Cards> playerHand = new List<Cards>();

                /*
                US-08: As a player, I want the dealer to play automatically, so that I have an opponent.
                Developer Notes:
                - Create a collection to represent the dealer's hand.
                */
                List<Cards> dealerHand = new List<Cards>();

                Console.WriteLine("\n---------------------------------");
                Console.WriteLine($"Starting new round... Cards remaining in deck: {deck.Count}");

                /*
                US-04: As a player, I want to start each round with two cards, so that the game follows the rules of Blackjack.
                US-03: As a player, I want to draw a card, so that I can begin building my hand.
                */
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

                // Calculate initial score using US-05 / US-13 Ace rules
                int score = Cards.CalculateHandValue(playerHand);
                Console.WriteLine($"Your starting score is: {score}\n");
                
                /*
                US-06: As a player, I want to choose whether to draw another card or hold, so that I can decide how to play my hand.
                Developer Notes:
                - Prompt the player for input after each draw.
                - Continue prompting the player until they choose to hold.
                - Reuse existing methods for drawing cards and calculating hand value.
                */
                bool playerBust = false;

                while (true)
                {
                    Console.WriteLine("Do you wish to Hit or Hold? (Type 'H'/'Hit' to draw, 'S'/'Hold'/'Stand' to stay):");
                    string choice = Console.ReadLine().Trim().ToLower();

                    // If the player chooses to draw (hit):
                    if (choice == "h" || choice == "hit")
                    {
                        Cards drawnCard = Cards.DrawCard(deck); // Draw exactly one card using the existing Cards.DrawCard method
                        playerHand.Add(drawnCard); // Add the card to the player's hand
                        Console.WriteLine($"You drew: {drawnCard.Rank} of {drawnCard.Suit}"); // Display the newly drawn card
                        
                        // Recalculate and display updated score
                        score = Cards.CalculateHandValue(playerHand);
                        Console.WriteLine($"Your current score is: {score}");

                        /*
                        US-07: As a player, I want the game to tell me when I have gone bust, so that I know I have lost the round.
                        Acceptance Criteria:
                        - The game checks whether the player's hand exceeds 21 after each card is drawn.
                        - If hand value exceeds 21, the player is declared bust.
                        - A message is displayed informing the player they have gone bust.
                        - The player cannot draw any more cards after going bust. Current round ends.
                        */
                        if (Cards.IsBust(playerHand))
                        {
                            Console.WriteLine("--> BUST! You went over 21!");
                            playerBust = true;
                            break;
                        }
                    }
                    // If the player chooses to hold (stand), break out of the prompt loop
                    else if (choice == "s" || choice == "stand" || choice == "hold")
                    {
                        Console.WriteLine($"You chose to stand at {score}. Turn ends.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please enter 'H' to Hit or 'S' to Stand.");
                    }
                }

                /*
                US-08: As a player, I want the dealer to play automatically, so that I have an opponent.
                US-09: As a player, I want the dealer to follow the rules of Blackjack, so that the game is fair.
                Acceptance Criteria:
                - The dealer begins their turn after the player chooses to hold.
                - The dealer is dealt an initial hand of two cards.
                - The dealer continues drawing cards until hand value is at least 17 or goes bust.
                - Dealer turn is played automatically without requiring player input.
                */
                if (!playerBust)
                {
                    Console.WriteLine("\n--- Dealer's Turn ---");
                    dealerHand.AddCard = deck; // Reusing card drawing
                    dealerHand.Add(Cards.DrawCard(deck));
                    dealerHand.Add(Cards.DrawCard(deck));

                    Console.WriteLine("Dealer's opening hand:");
                    foreach (Cards card in dealerHand)
                    {
                        Console.WriteLine($"  {card.Rank} of {card.Suit}");
                    }

                    int dealerScore = Cards.CalculateHandValue(dealerHand);
                    Console.WriteLine($"Dealer's starting score: {dealerScore}");

                    while (dealerScore < 17)
                    {
                        Console.WriteLine("Dealer draws a card...");
                        Cards drawn = Cards.DrawCard(deck);
                        dealerHand.Add(drawn);
                        Console.WriteLine($"Dealer drew: {drawn.Rank} of {drawn.Suit}");

                        dealerScore = Cards.CalculateHandValue(dealerHand);
                        Console.WriteLine($"Dealer's current score: {dealerScore}");
                    }

                    if (Cards.IsBust(dealerHand))
                    {
                        Console.WriteLine("--> Dealer BUSTS!");
                    }
                }

                /*
                US-10: As a player, I want the game to determine the winner of the round, so that I know whether I have won or lost.
                Acceptance Criteria:
                - The winner is determined after the dealer's turn has ended.
                - If the player has gone bust, the dealer wins.
                - If the dealer has gone bust, the player wins.
                - If neither went bust, hand values are compared (higher score wins; if equal, dealer wins).
                */
                Console.WriteLine("\n=================================");
                Console.WriteLine("          ROUND RESULT           ");
                Console.WriteLine("=================================");

                int finalPlayerScore = Cards.CalculateHandValue(playerHand);
                int finalDealerScore = Cards.CalculateHandValue(dealerHand);

                if (playerBust)
                {
                    Console.WriteLine("Dealer Wins! (Player went bust)");
                }
                else if (Cards.IsBust(dealerHand))
                {
                    Console.WriteLine("Player Wins! (Dealer went bust)");
                }
                else if (finalPlayerScore > finalDealerScore)
                {
                    Console.WriteLine($"Player Wins! ({finalPlayerScore} vs Dealer's {finalDealerScore})");
                }
                else if (finalDealerScore > finalPlayerScore)
                {
                    Console.WriteLine($"Dealer Wins! ({finalDealerScore} vs Player's {finalPlayerScore})");
                }
                else
                {
                    Console.WriteLine($"Dealer Wins! (Tie game at {finalPlayerScore} - Dealer wins ties per US-10)");
                }
                Console.WriteLine("=================================");

                /*
                US-11: Play another round prompt logic
                */
                while (true)
                {
                    Console.Write("\nDo you want to play another round? (Y/N): ");
                    string reply = Console.ReadLine().Trim().ToLower();

                    if (reply == "y" || reply == "yes")
                    {
                        keepPlaying = true;
                        break;
                    }
                    else if (reply == "n" || reply == "no")
                    {
                        keepPlaying = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Enter 'Y' or 'N'.");
                    }
                }
            }

            Console.WriteLine("\nThanks for playing Blackjack! Application exiting normally.");
        }
    }
}