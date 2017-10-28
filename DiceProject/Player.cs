using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceProject
{
    public class Player
    {
        public Player()
        {

        }

        public Player(string playerName) : this()
        {
            this.playerName = playerName;
        }

        public List<int> Rolls { get; set; }

        public string BestHand { get; set; }

        public string ValidationMessage { get; private set; }
        public bool isNumbersAndLetters { get; set; }
        private string playerName;

        public string PlayerName
        {
            get { return playerName; }
            set
            {
                isNumbersAndLetters = true;
                for (int i = 0; i < value.Length; i++)
                {
                    if (!(char.IsLetter(value[i])) && (!(char.IsNumber(value[i]))))
                    {
                        isNumbersAndLetters = false;
                    }

                }
                if (string.IsNullOrEmpty(value))
                {
                    ValidationMessage = "Name cannot be null or empty.";
                }
                else if (value.Length < 3)
                {
                    ValidationMessage = "Name cannot be less than 3 characters.";
                }
                else if (value.Length > 12)
                {
                    ValidationMessage = "Name cannot be longer than 12 characters.";
                }
                else if (isNumbersAndLetters == false)
                {
                    ValidationMessage = "Name can only contain letters and numbers.";
                }

                else
                {
                    playerName = value;
                }

            }
        }

        public void RollDice()
        {
            var rolls = DiceLogic.RollDie(5);
            StoreRolls(rolls);
            this.BestHand = DiceLogic.CalculateBestHand(this.Rolls);
        }

        public void StoreRolls(List<int> rolls)
        {
            this.Rolls = rolls;
        }

        public void GetPlayerName()
        {
            

            while (this.PlayerName == null)
            {
                ValidationMessage = string.Empty;
                Console.WriteLine("What is your name, friend?");
                PlayerName = Console.ReadLine();
                Console.WriteLine(this.ValidationMessage);


            }
            
        }

        public void GreetPlayer()
        {
            Console.WriteLine($"Hello, { this.PlayerName }");
        }

        public void GetBestHand()
        {
            this.BestHand = DiceLogic.CalculateBestHand(this.Rolls);
        }
    }


}










