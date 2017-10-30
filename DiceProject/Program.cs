
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiceProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Player player = new Player();
            player.PlayerName = "Derek";
            
            player.RollDice();
            DiceLogic.PrintRolls(player.Rolls);
            Console.WriteLine(player.BestHand);

            Player opponent = new Player();
            opponent.PlayerName = "Susie";
            opponent.RollDice();
            DiceLogic.PrintRolls(opponent.Rolls);
            Console.WriteLine(opponent.BestHand);

            var winner = DiceLogic.FindWinner(player, opponent);

            if (winner == "draw")
                Console.WriteLine("It's a draw");
            else
                Console.WriteLine($"{ winner } has won!!!");


           
            
            Console.ReadLine();
        }
    }
}
