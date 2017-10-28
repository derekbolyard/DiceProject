
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
            player.RollDice();
            DiceLogic.PrintRolls(player.Rolls);
            Console.WriteLine(player.BestHand);



           
            
            Console.ReadLine();
        }
    }
}
