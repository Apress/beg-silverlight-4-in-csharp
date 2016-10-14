using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ListBoxCustom
{
    public class StartingHands
    {
        public string Nickname { get; set; }
        public string Notes { get; set; }
        public string Card1 { get; set; }
        public string Card2 { get; set; }

        public static ObservableCollection<StartingHands> GetHands()
        {
            ObservableCollection<StartingHands> hands =
            new ObservableCollection<StartingHands>();

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
