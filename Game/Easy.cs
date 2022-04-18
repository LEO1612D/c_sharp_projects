using System;
using System.Collections.Generic;

namespace Game
{
    class Easy : Round
    {

        private readonly string[] _words = new string[5] { "costochondritis", "orange", "grapes", "wood", "bat" };
        private readonly int _roundPoint = 10;
        private static int _usedHints = 0;
        private static int wordCount = 0;
        private string _currentWord;
        private bool _roundEnd;

        private string currentRoundAnswer;
        private static int score = 0;

        private IDictionary<int, char> hiddenWords = new Dictionary<int, char>();

        Random rnd = new Random();


        public Easy()
        {
            initializeRound();
        }

        public override void nextRound()
        {

            initializeRound();

            Console.WriteLine(getFirstHint(hiddenWords));
            Console.WriteLine(getSecondHint(hiddenWords));
            // Logic

        }

        private void initializeRound()
        {

            _usedHints = 0;
            hiddenWords.Clear();
            if (wordCount >= _words.Length)
            {
                _roundEnd = true;
                wordCount = 0;
            }
            else
            {
                currentRoundAnswer = _words[wordCount++];
                _currentWord = new String(getHiddenWord(currentRoundAnswer));
            }

        }

        private char[] getHiddenWord(string originalWord)
        {

            string currentWord = originalWord;
            char[] ch = currentWord.ToCharArray();
            int wordLength = currentWord.Length;
            int hiddenCharCount = wordLength / 2;


            // TO Hide word
            for (int j = 0; j < hiddenCharCount; j++)
            {
                int numberToHide = rnd.Next(0, wordLength);

                if (!hiddenWords.ContainsKey(numberToHide))
                {
                    hiddenWords.Add(numberToHide, ch[numberToHide]);
                }

                ch[numberToHide] = '*';

            }
            return ch;
        }

        private string getFirstHint(IDictionary<int, char> hiddenWords)
        {
            string missingWords = "";
            foreach (KeyValuePair<int, char> kvp in hiddenWords)
            {
                missingWords = missingWords + " " + kvp.Value;
            }

            return missingWords;

        }

        private string getSecondHint(IDictionary<int, char> hiddenWords)
        {

            string missingWordPos = "";
            foreach (KeyValuePair<int, char> kvp in hiddenWords)
            {
                missingWordPos = missingWordPos + " " + (kvp.Key + 1);
            }

            return missingWordPos;


        }

        public override void useHint()
        {
            switch (_usedHints)
            {
                case 0:
                    Console.WriteLine(getFirstHint(hiddenWords));
                    _usedHints++;
                    break;
                case 1:
                    Console.WriteLine(getSecondHint(hiddenWords));
                    _usedHints++;
                    break;
                default:
                    Console.WriteLine("Sorry you haved used all available hints");
                    break;
            }
            Console.WriteLine("----------------------------------------");

        }

        public override void roundPrompt()
        {

            Console.WriteLine($"Please give correct spelling by replacing * with correct alphabets \n Word is : {_currentWord}");
            Console.WriteLine($"- To Use Hint Press h \n - To Give answer just type it");
            Console.WriteLine("- To End This Round Press E");
            Console.WriteLine($"- To Quit Game Press Q");

        }

        public override bool checkAnswer(string playerAnswer)
        {
            if (playerAnswer == currentRoundAnswer)
            {
                score = score + 10;
                nextRound();
                return true;
            }
            return false;
        }

        public override int getTotalScore()
        {
            return score;
        }

        public override string[] words
        {
            get { return _words; }
        }



        public override int roundPoint
        {
            get { return _roundPoint; }
        }


        public override bool roundEnd
        {
            get { return _roundEnd; }
            set { _roundEnd = value; }
        }

    }
}
