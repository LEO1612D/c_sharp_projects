using System;
namespace Game
{
    // Round Factory
    abstract class RoundFactory
    {
        public abstract Round GetRound(string Round);
    }
}
