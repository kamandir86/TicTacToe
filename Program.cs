using System;

namespace TicTacToe
{
    class Program
    {
        static string[,] playField =
            {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"}
            };

        static int turns = 0;

        static void Main(string[] args)
        {
            
            int player = 1; // Player 1 starts
            int fieldChoice = 0;
            bool correctFieldChoice = true;            
            
            do
            {
                SetField();

                CheckEnd(); // method checking if any player won

                do
                {
                    Console.WriteLine("\n Player {0}: Please choose your field", player);
                    try
                    {
                        fieldChoice = Convert.ToInt32(Console.ReadLine());
                        correctFieldChoice = CheckFieldChoice(fieldChoice); // test if field is already taken
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number from 1 to 9");
                    }
                    
                    
                } while (!correctFieldChoice);

                if (player == 1)
                {
                    ChangeField(player, fieldChoice);
                    player = 2;
                }

                else if (player == 2)
                {
                    ChangeField(player, fieldChoice);
                    player = 1;
                }
                                               
            } while (true); 

            
        }

        private static void ResetField()
        {
            string[,] playFieldInitial =
            {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"}
            };

            playField = playFieldInitial;
            SetField();
            turns = 0;
        }

        private static void CheckEnd()
        {
            string[] playerSigns = { "X", "O" };

            foreach (string playerSign in playerSigns)
            {
                if (((playField[0, 0] == playerSign) && (playField[0, 1] == playerSign) && (playField[0, 2] == playerSign)) // 1, 2, 3
                    || ((playField[1, 0] == playerSign) && (playField[1, 1] == playerSign) && (playField[1, 2] == playerSign)) // 4, 5, 6
                    || ((playField[2, 0] == playerSign) && (playField[2, 1] == playerSign) && (playField[2, 2] == playerSign)) // 7, 8, 9
                    || ((playField[0, 0] == playerSign) && (playField[1, 0] == playerSign) && (playField[2, 0] == playerSign)) // 1, 4, 7
                    || ((playField[0, 1] == playerSign) && (playField[1, 1] == playerSign) && (playField[2, 1] == playerSign)) // 2, 5, 8
                    || ((playField[0, 2] == playerSign) && (playField[1, 2] == playerSign) && (playField[2, 2] == playerSign)) // 3, 6, 9
                    || ((playField[0, 0] == playerSign) && (playField[1, 1] == playerSign) && (playField[2, 2] == playerSign)) // 1, 5, 9
                    || ((playField[2, 0] == playerSign) && (playField[1, 1] == playerSign) && (playField[0, 2] == playerSign)) // 7, 5, 3
                    )
                {
                    if (playerSign == "X")
                        Console.WriteLine("\nPlayer 1 has won!");
                    else
                        Console.WriteLine("\nPlayer 2 has won!");

                    Console.WriteLine("\nPress any key to rest the game!");
                    Console.ReadKey();
                    ResetField();
                }
                else if (turns == 10)
                {
                    // draw situation
                    Console.WriteLine("\nWe have a draw!");
                    Console.WriteLine("\nPress any key to rest the game!");
                    Console.ReadKey();
                    ResetField();
                    
                }

            }
                                   
                
        }

        private static bool CheckFieldChoice(int fieldChoice)
        {
            if ((fieldChoice == 1) && (playField[0, 0] == "1"))
                return true;
            else if ((fieldChoice == 2) && (playField[0, 1] == "2"))
                return true;
            else if ((fieldChoice == 3) && (playField[0, 2] == "3"))
                return true;
            else if ((fieldChoice == 4) && (playField[1, 0] == "4"))
                return true;
            else if ((fieldChoice == 5) && (playField[1, 1] == "5"))
                return true;
            else if ((fieldChoice == 6) && (playField[1, 2] == "6"))
                return true;
            else if ((fieldChoice == 7) && (playField[2, 0] == "7"))
                return true;
            else if ((fieldChoice == 8) && (playField[2, 1] == "8"))
                return true;
            else if ((fieldChoice == 9) && (playField[2, 2] == "9"))
                return true;
            else
                return false;
        }

        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[0,0], playField[0,1], playField[0,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("     |     |     ");
            turns++;
        }

        public static void ChangeField(int player, int fieldChoice)
        {
            string playerSign = "";

            if (player == 1)
                playerSign = "X";
            else if (player == 2)
                playerSign = "O";

            switch (fieldChoice)
            {
                case 1: playField[0, 0] = playerSign; break;
                case 2: playField[0, 1] = playerSign; break;
                case 3: playField[0, 2] = playerSign; break;
                case 4: playField[1, 0] = playerSign; break;
                case 5: playField[1, 1] = playerSign; break;
                case 6: playField[1, 2] = playerSign; break;
                case 7: playField[2, 0] = playerSign; break;
                case 8: playField[2, 1] = playerSign; break;
                case 9: playField[2, 2] = playerSign; break;
            }

        }
    }
}
