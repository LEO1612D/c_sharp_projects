using System;
namespace Game
{
    // Round Interface
    abstract class Round
    {

        public abstract string[] words { get; }
        public abstract int roundPoint { get; }
        public abstract bool roundEnd { get; set; }
        public abstract void nextRound();
        public abstract void useHint();
        public abstract bool checkAnswer(string playerAnswer);
        public abstract void roundPrompt();

        public abstract int getTotalScore();

    }
}
