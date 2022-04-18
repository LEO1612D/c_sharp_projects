using System;
using System.Collections.Generic;

namespace Game
{
    class Program {
    
        static void Main(string[] args)
        {

            
            Console.WriteLine("Hello World!");

            bool endGame = false;
            while(!endGame)
        {
            
                Player p1 = new Player();
                p1.setPlayerDetails();
                Console.WriteLine(p1);
                
                RoundFactory Round = new ConcreteRoundFactory();
                Round SelectedRound = null;

                switch (p1.gameMode)
                {
                    case Player.mode.Easy:
                        SelectedRound = Round.GetRound("Easy");
                        break;
                    case Player.mode.Medium:
                        SelectedRound = Round.GetRound("Medium");
                        break;
                    case Player.mode.Hard:
                        SelectedRound = Round.GetRound("Hard");
                        break;
                    default:
                        break;
                }
                bool quitRound = false;
                while (!quitRound && !SelectedRound.roundEnd)
                {
                    Console.WriteLine("----------------------------------------");
                    SelectedRound.roundPrompt();
                    string input = Console.ReadLine();

                    switch (input.ToUpper())
                    {
                        case "Q":
                            quitRound = true;
                            break;
                        case "E":
                            endGame = true;
                            quitRound = true;
                            break;
                        case "H":
                            SelectedRound.useHint();
                            break;
                        default:
                            bool ans = SelectedRound.checkAnswer(input);
                            if (ans)
                            {
                                Console.WriteLine($"Congratulations you won {SelectedRound.roundPoint} Points");
                            }
                            Console.WriteLine("Given Answer is not valid");
                            break;

                    }
                    Console.WriteLine("----------------------------------------");

                }
                Console.WriteLine($"Congratulations you scored {SelectedRound.getTotalScore()} Points");
            }
            
           
  
        }
    }

}
