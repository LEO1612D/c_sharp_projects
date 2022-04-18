using System;
namespace Game
{

    // Concrete Round Factory
    class ConcreteRoundFactory : RoundFactory
    {
        public override Round GetRound(string Round)
        {
            switch (Round)
            {
                case "Easy":
                    return new Easy();
                case "Medium":
                    return new Medium();
                case "Hard":
                    return new Hard();
                default:
                    throw new ApplicationException(string.Format("Round '{0}' cannot be created", Round));
            }
        }



    }
}
