using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceProject
{
    public class DiceLogic
    {
        public static bool HasThreeOfAKind { get; set; }


        static readonly Random NumberGen = new Random();
 

        public static List<int> RollDie()
        {
            List<int> rolls = new List<int>();
            rolls.Add(NumberGen.Next(1, 7));
            return rolls;
        }

        public static List<int> RollDie(int number)
        {
            List<int> rolls = new List<int>();
            for (var i = 0; i < number; i++)
            {
                rolls.Add(NumberGen.Next(1, 7));
            }
            rolls.Sort();
            return rolls;
        }


        public static void PrintRolls(List<int> rolls)
        {
            int i = 1;
            foreach (var roll in rolls)
            {
                Console.WriteLine($"Roll #{ i }: { roll }");
                i++;
            }
        }

        public static List<IGrouping<int, int>> GroupRolls(List<int> rolls)
        {
            var groupedRolls = rolls.GroupBy(x => x)
            .Select(g => g)
            .ToList();
            return groupedRolls;

        }


        public static bool FiveOfAKind(List<int> rolls)
        {
            var groupedRolls = GroupRolls(rolls);
            var isFiveOfAKind = groupedRolls.Where(x => x.Count() == 5)
                .ToList();

            if (isFiveOfAKind.Count == 1)
            {
                return true;
            }
            return false;
        }

        public static bool FourOfAKind(List<int> rolls)
        {
            var groupedRolls = GroupRolls(rolls);
            var isFourOfAKind = groupedRolls.Where(x => x.Count() == 4)
                .ToList();

            if (isFourOfAKind.Count() == 1)
            {
                return true;
            }
            return false;
        }

        public static bool ThreeOfAKind(List<int> rolls)
        {
            var groupedRolls = GroupRolls(rolls);
            var isThreeOfAKind = groupedRolls.Where(x => x.Count() == 3)
                .ToList();

            var isPair = groupedRolls.Where(x => x.Count() == 2)
                .ToList();

            if (isThreeOfAKind.Count() == 1 && isPair.Count() == 0)
            {
                return true;
            }
            return false;
        }

        public static bool Pair(List<int> rolls)
        {
            var groupedRolls = GroupRolls(rolls);

            var isPair = groupedRolls.Where(x => x.Count() == 2)
                .ToList();

            var isThreeOfAKind = groupedRolls.Where(x => x.Count() == 3)
                .ToList();

            if (isPair.Count == 1 && isThreeOfAKind.Count == 0)
            {
                return true;
            }
            return false;
        }

        public static bool TwoPair(List<int> rolls)
        {
            var groupedRolls = GroupRolls(rolls);

            var isPair = groupedRolls.Where(x => x.Count() == 2)
                .ToList();

            if (isPair.Count == 2)
            {
                return true;
            }
            return false;
        }

        public static bool FullHouse(List<int> rolls)
        {
            var groupedRolls = GroupRolls(rolls);

            var isPair = groupedRolls.Where(x => x.Count() == 2)
                .ToList();

            var isThreeOfAKind = groupedRolls.Where(x => x.Count() == 3)
                .ToList();

            if (isPair.Count == 1 && isThreeOfAKind.Count == 1)
            {
                return true;
            }
            return false;
        }

        public static bool FiveHighStraight(List<int> rolls)
        {
            bool isStraight = false;
            var groupedRolls = GroupRolls(rolls);

            if (groupedRolls.Count() == 5)
            {
                isStraight = true;
            }

            if (isStraight && ContainsASix(rolls) == false)
            {
                return true;
            }
            return false;
        }

        public static bool SixHighStraight(List<int> rolls)
        {
            bool isStraight = false;
            var groupedRolls = GroupRolls(rolls);

            if (groupedRolls.Count() == 5)
            {
                isStraight = true;
            }

            if (isStraight && ContainsAOne(rolls) == false)
            {
                return true;
            }
            return false;
        }

        private static bool ContainsASix(List<int> rolls)
        {
            foreach (var number in rolls)
            {
                if (number == 6)
                    return true;
            }
            return false;
        }

        private static bool ContainsAOne(List<int> rolls)
        {
            foreach (var number in rolls)
            {
                if (number == 1)
                    return true;
            }
            return false;
        }

        public static string PrintBestHand(List<int> rolls)
        {
            if (Pair(rolls))
            {
                return "You have a Pair.";
            }

            if (TwoPair(rolls))
            {
                return "You have Two pair.";
            }

            if (ThreeOfAKind(rolls))
            {
                return "You have Three of a Kind.";
            }

            if (FiveHighStraight(rolls))
            {
                return "You have a Five High Straight";
            }

            if (SixHighStraight(rolls))
            {
                return "You have a Six High Straight";
            }

            if (FullHouse(rolls))
            {
                return "You have a Full House!";
            }

            if (FourOfAKind(rolls))
            {
                return "You have Four of a Kind!!";
            }

            if (FiveOfAKind(rolls))
            {
                return "You have Five of a Kind!!!";
            }
            return "You have nothing";
        }

        public static string CalculateBestHand(List<int> rolls)
        {
            if (Pair(rolls))
                return "Pair";
            if (TwoPair(rolls))
                return "Two Pair";
            if (ThreeOfAKind(rolls))
                return "Three of a Kind";
            if (FiveHighStraight(rolls))
                return "Five High Straight";
            if (SixHighStraight(rolls))
                return "Six High Straight";
            if (FullHouse(rolls))
                return "Full House";
            if (FourOfAKind(rolls))
                return "Four of a Kind";
            if (FiveOfAKind(rolls))
                return "Five of a Kind";
            return "nothing";
        }

        public static string FindWinner(Player firstPlayer, Player secondPlayer)
        {
            if (HandValue(firstPlayer.BestHand) > HandValue(secondPlayer.BestHand))
                return firstPlayer.PlayerName;
            if (HandValue(firstPlayer.BestHand) < HandValue(secondPlayer.BestHand))
                return secondPlayer.PlayerName;
            return "draw";
        }

        public static int HandValue(string hand)
        {
            if (hand == "nothing")
                return 1;
            if (hand == "Pair")
                return 2;
            if (hand == "Two Pair")
                return 3;
            if (hand == "Three of a Kind")
                return 4;
            if (hand == "Five High Straight")
                return 5;
            if (hand == "Six High Straight")
                return 6;
            if (hand == "Full House")
                return 7;
            if (hand == "Four of a Kind")
                return 8;
            if (hand == "Five of a kind")
                return 9;
            Console.WriteLine("Couldn't calculate hand");
            return 0;
        }




    }
}
