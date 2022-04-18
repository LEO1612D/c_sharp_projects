using System;
namespace Game
{
    public class Player
    {

        public enum mode
        {
            Easy,
            Medium,
            Hard
        }

        public string name;
        private int score;
        private int hintUsed;
        private string badge;
        public mode gameMode;


        public Player()
        {
            score = 0;
            hintUsed = 0;
            badge = "Newbie";
        }

        public void setPlayerDetails()
        {
            Console.WriteLine("Please Enter your Name");
            name = Console.ReadLine();

            Console.WriteLine($"{name} please choose your game mode \n Available modes are \n 1. Easy \n 2. Medium \n 3. Hard \n Choose 1,2 or 3");
            int selectedMode = Convert.ToInt32(Console.ReadLine());
            setGameMode(selectedMode);

        }

        private void setGameMode(int num)
        {

            switch (num)
            {
                case 1:
                    gameMode = mode.Easy;
                    break;
                case 2:
                    gameMode = mode.Medium;
                    break;
                case 3:
                    gameMode = mode.Hard;
                    break;
                default:
                    gameMode = mode.Easy;
                    break;
            }


        }


        public override string ToString()
        {
            return $" - Player {name} scored {score} \n - Hints used : {hintUsed} \n - Congratulation you have earned {badge} badge \n - In Mode {gameMode} ";
        }
    }
}
