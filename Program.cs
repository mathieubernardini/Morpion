using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    class Program
    {
        
        static void Main(string[] args)
        {

            /*
             * VARIABLES
             * 
            */

            //players declaration
            int player1 = 1;
            int player2 = 2;
            int player = 1; // determine which player is currently active


            // check if a winner has been found
            int win = 1;

            int roundNum = 1; // round number

            // gather player's action datas
            char[,] actionHandler = new char[3, 3];

            // actionHandler's initialization
            for (int i = 0; i < 3; i ++) {
                for (int j = 0; j < 3; j++) {
                    actionHandler[i, j] = ' ';
                }
            }

            // gather datas from the current round
            string[] values = new string[3];

            // values initialization

            for (int i = 0; i < 3; i++)
            {
                values[i] = "";
            }

            /*
             * FUNCTIONS
             * 
            */

            //drawing game board
            void drawGameboard(string[] position)
            {
                //Cursor drawing position
                int x = 10;
                int y = 5;
                

                // check if drawGameboard needs to draw a player's move
                if (position[0] == "") /*no player has begin */ {

                    // drawing loop
                    while (y <= 11)
                    {
                        //switch between two different lines drawing
                        if (x % 2 == 1)
                        {
                            x--;
                            Console.SetCursorPosition(x, y);
                            Console.Write("|   |   |   |");
                        }
                        else
                        {
                            x++;
                            Console.SetCursorPosition(x, y);
                            Console.Write("-----------");
                        }
                        y++;
                    }
                } else {
                    x = 8 + 4*int.Parse(position[1]);
                    y = 4 + 2 * int.Parse(position[2]);
                    Console.SetCursorPosition(x, y);
                    if (position[0] == "1") {
                        Console.Write("O");
                    } else {
                        Console.Write("X");
                    }
                }

            }

            // player round handler

            string[] round(int actualPlayer) {

                Console.SetCursorPosition(2, 15);
                Console.Write("C'est au tour du joueur " + actualPlayer + " :");

                // switch between player 1 and player 2
                if (actualPlayer == 1) {
                    actualPlayer++;
                } else {
                    actualPlayer--;
                }

                // allow possibility to get player's move

                Console.SetCursorPosition(10, 16);
                Console.Write("ligne   : ");
                Console.SetCursorPosition(10, 17);
                Console.Write("colonne : ");
                Console.SetCursorPosition(20, 16);
                string line = Console.ReadKey().KeyChar.ToString();
                Console.SetCursorPosition(20, 17);
                string column = Console.ReadKey().KeyChar.ToString();

                string[] output = new string[3];
                output[0] = actualPlayer.ToString();
                output[1] = line;
                output[2] = column;

                return output;
            }

            // action display / player 1 = O, player 2 = X
            /*
            void display (string[] values) {
                char[,] actionHandler = new char[3,3];
                if (values[0] == "1") {
                    actionHandler[int.Parse(values[1]) - 1, int.Parse(values[2]) - 1] = 'O';
                } else {
                    actionHandler[int.Parse(values[1]) - 1, int.Parse(values[2]) - 1] = 'X';
                }

                for (int i = 0; i < 3; i++) {
                    for (int j = 0; j < 3; j++) {
                        Console.SetCursorPosition(16, 16);
                        Console.Write(actionHandler[i, j]);
                    }

                }
            }
            */


            /*
             * MAIN CODE
             * 
            */

            drawGameboard(values);

            while (win == 1 && roundNum < 10) {
                //display(round());
                
                values = round(player);
                player = int.Parse(values[0]);
                drawGameboard(values);
                roundNum++;
            }

            Console.ReadLine();
        }
    }
}
