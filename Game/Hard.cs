using System;
namespace Game
{
    class Hard : Round
    {
        private readonly string[] _words = new string[5] { "costochondritis", "orange", "grapes", "wood", "bat" };
        private readonly int _hintPoint = 5;
        private readonly int _roundPoint = 20;
        private int _usedHints;
        private static int wordCount = 0;
        private string _currentWord;
        private bool _roundEnd;


        public Hard()
        {
            _usedHints = 0;
            if (wordCount >= _words.Length)
            {
                _roundEnd = true;
            }
            else
            {
                _currentWord = _words[wordCount++];
            }

        }

        public override void nextRound()
        {
            _usedHints = 0;
            if (wordCount >= _words.Length)
            {
                _roundEnd = true;
            }
            else
            {
                _currentWord = _words[wordCount++];
            }

        }

        public override void useHint()
        {
            throw new NotImplementedException();
        }

        public override void roundPrompt()
        {
            throw new NotImplementedException();
        }

        public override bool checkAnswer(string playerAnswer)
        {
            throw new NotImplementedException();
        }

        public override int getTotalScore()
        {
            throw new NotImplementedException();
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
