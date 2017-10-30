using System;
using System.Collections.Generic;

namespace DiceProject
{
    public class Player
    {
        public Player()
        {

        }

        public Player(string playerName) : this()
        {
            _playerName = playerName;
        }

        public List<int> Rolls { get; set; }

        public string BestHand { get; set; }

        public string ValidationMessage { get; private set; }
        public bool IsNumbersAndLetters { get; set; }
        private string _playerName;

        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                IsNumbersAndLetters = true;
                for (int i = 0; i < value.Length; i++)
                {
                    if (!(char.IsLetter(value[i])) && (!(char.IsNumber(value[i]))))
                    {
                        IsNumbersAndLetters = false;
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
                else if (IsNumbersAndLetters == false)
                {
                    ValidationMessage = "Name can only contain letters and numbers.";
                }

                else
                {
                    _playerName = value;
                }

            }
        }

        public void RollDice()
        {
            var rolls = DiceLogic.RollDie(5);
            StoreRolls(rolls);
            BestHand = DiceLogic.CalculateBestHand(Rolls);
        }

        public void StoreRolls(List<int> rolls)
        {
            Rolls = rolls;
        }

        public void GetPlayerName()
        {
            

            while (PlayerName == null)
            {
                ValidationMessage = string.Empty;
                Console.WriteLine("What is your name, friend?");
                PlayerName = Console.ReadLine();
                Console.WriteLine(ValidationMessage);


            }
            
        }

        public void GreetPlayer()
        {
            Console.WriteLine($"Hello, { PlayerName }");
        }

        public void GetBestHand()
        {
            BestHand = DiceLogic.CalculateBestHand(Rolls);
        }
    }


}










