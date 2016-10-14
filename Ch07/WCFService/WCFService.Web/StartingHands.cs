using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCFService.Web
{
    public class StartingHands
    {
        public string Nickname;
        public string Notes;
        public string Card1;
        public string Card2;

        public static List<StartingHands> GetHands()
        {
            List<StartingHands> hands = new List<StartingHands>();

            hands.Add(
                new StartingHands()
                {
                    Nickname = "Big Slick",
                    Notes = "Also referred to as Anna Kournikova.",
                    Card1 = "As",
                    Card2 = "Ks"
                });

            hands.Add(
            new StartingHands()
            {
                Nickname = "Pocket Rockets",
                Notes = "Also referred to as Bullets.",
                Card1 = "As",
                Card2 = "Ad"
            });

            hands.Add(
                new StartingHands()
                {
                    Nickname = "Blackjack",
                    Notes = "The casino game blackjack.",
                    Card1 = "As",
                    Card2 = "Js"
                });

            hands.Add(
                new StartingHands()
                {
                    Nickname = "Cowboys",
                    Notes = "Also referred to as King Kong",
                    Card1 = "Ks",
                    Card2 = "Kd"
                });

            hands.Add(
                new StartingHands()
                {
                    Nickname = "Doyle Brunson",
                    Notes = "Named after poker great Doyle Brunson",
                    Card1 = "Ts",
                    Card2 = "2s"
                });


            return hands;
        }
    }
}
