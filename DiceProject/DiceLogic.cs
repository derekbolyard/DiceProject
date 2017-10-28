using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceProject
{
    public class DiceLogic
    {
        private static bool hasPair { get; set; }
        public static bool hasThreeOfAKind { get; set; }

        static bool pair { get; set; } = false;
        static bool twoPair { get; set; } = false;
        static bool threeOfAKind { get; set; } = false;
        static bool fiveHighStraight { get; set; } = false;
        static bool sixHighStraight { get; set; } = false;
        static bool fullHouse { get; set; } = false;
        static bool fourOfAKind { get; set; } = false;
        static bool fiveOfAKind { get; set; } = false;


        static Random numberGen = new Random();
        public static List<int> Rolls = new List<int>();

        public static List<int> RollDie()
        {
            Rolls.Add(numberGen.Next(1, 7));
            return Rolls;
        }

        public static List<int> RollDie(int number)
        {

            for (var i = 0; i < number; i++)
            {
                Rolls.Add(numberGen.Next(1, 7));
            }
            Rolls.Sort();
            return Rolls;
        }

        public static void PrintRolls()
        {
            int i = 1;
            foreach (var roll in Rolls)
            {
                Console.WriteLine($"Roll #{ i }: { roll }");
                i++;
            }
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

            if (isFiveOfAKind.Count() == 1)
            {
                fiveOfAKind = true;
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
                fourOfAKind = true;
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
                threeOfAKind = true;
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
                pair = true;
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
                twoPair = true;
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
                fullHouse = true;
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

            if (isStraight == true && containsASix(rolls) == false)
            {
                fiveHighStraight = true;
                return true;
            }
            else
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

            if (isStraight == true && containsAOne(rolls) == false)
            {
                sixHighStraight = true;
                return true;
            }
            else
                return false;
        }

        private static bool containsAFive(List<int> rolls)
        {
            foreach (var number in rolls)
            {
                if (number == 5)
                    return true;
            }
            return false;
        }

        private static bool containsASix(List<int> rolls)
        {
            foreach (var number in rolls)
            {
                if (number == 6)
                    return true;
            }
            return false;
        }

        private static bool containsAOne(List<int> rolls)
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
            if (Pair(rolls) == true)
                return "You have a Pair.";
            if (TwoPair(rolls) == true)
                return "You have Two pair.";
            if (ThreeOfAKind(rolls) == true)
                return "You have Three of a Kind.";
            if (FiveHighStraight(rolls) == true)
                return "You have a Five High Straight";
            if (SixHighStraight(rolls) == true)
                return "You have a Six High Straight";
            if (FullHouse(rolls) == true)
                return "You have a Full House!";
            if (FourOfAKind(rolls) == true)
                return "You have Four of a Kind!!";
            if (FiveOfAKind(rolls) == true)
                return "You have Five of a Kind!!!";
            else
                return "You have nothing";
        }

        public static string CalculateBestHand(List<int> rolls)
        {
            if (Pair(rolls) == true)
                return "Pair";
            if (TwoPair(rolls) == true)
                return "Two pair.";
            if (ThreeOfAKind(rolls) == true)
                return "Three of a Kind.";
            if (FiveHighStraight(rolls) == true)
                return "Five High Straight";
            if (SixHighStraight(rolls) == true)
                return "Six High Straight";
            if (FullHouse(rolls) == true)
                return "Full House!";
            if (FourOfAKind(rolls) == true)
                return "Four of a Kind!!";
            if (FiveOfAKind(rolls) == true)
                return "Five of a Kind!!!";
            else
                return "nothing";
        }

        public static Player FindWinner (Player firstPlayer, Player secondPlayer)
        {
            if (HandValue(firstPlayer.BestHand) > HandValue(secondPlayer.BestHand))
                return firstPlayer;
            else if (HandValue(firstPlayer.BestHand) < HandValue(secondPlayer.BestHand))
                return secondPlayer;
            else
            {
                Player draw = new Player();
                draw.BestHand = "Draw";
                return draw;
            }
        }

        public static int HandValue (string hand)
        {
            if (hand == "nothing")
                return 1;
            else if (hand == "Pair")
                return 2;
            else if (hand == "Two Pair")
                return 3;
            else if (hand == "Three of a Kind")
                return 4;
            else if (hand == "Five High Straight")
                return 5;
            else if (hand == "Six High Straight")
                return 6;
            else if (hand == "Full House")
                return 7;
            else if (hand == "Four of a Kind")
                return 8;
            else if (hand == "Five of a kind")
                return 9;
            else
            {
                Console.WriteLine("Couldn't calculate hand");
                return 0;
            }
            
        }


    }
}
