// <copyright file="TicketsMenu.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task6_UI
{
    using System;
    using System.IO;
    using Task6_Lib;

    /// <summary>
    /// Class with methods for calculating the count of lucky tickets
    /// </summary>
    public class TicketsMenu
    {
        /// <summary>
        /// Digits in ticket number
        /// </summary>
        private readonly int n;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketsMenu"/> class
        /// </summary>
        /// <param name="n">Digits in ticket number</param>
        public TicketsMenu(int n)
        {
            this.n = n;
        }

        /// <summary>
        /// Type of calculation of the number of lucky tickets
        /// </summary>
        private enum TicketsType
        {
            /// <summary>
            /// Moscow method
            /// </summary>
            Moscow,

            /// <summary>
            /// P i t e r method
            /// </summary>
            Piter
        }

        /// <summary>
        /// Console menu for tickets
        /// </summary>
        public void ConsoleMenu()
        {
            string[] args = Environment.GetCommandLineArgs(); // +1 - start filepath
            switch (args.Length)
            {
                case 2:
                    {
                        try
                        {
                            TicketsType ticketsType = this.GetTicketsType(args[1]);

                            TicketSequence tickets;
                            switch (ticketsType)
                            {
                                case TicketsType.Moscow:
                                {
                                    tickets = MoscowTicketSequence.Initialize(this.n);
                                    break;
                                }

                                case TicketsType.Piter:
                                {
                                    tickets = PiterTicketSequence.Initialize(this.n);
                                    break;
                                }

                                default:
                                    tickets = null;
                                    break;
                            }

                            Console.WriteLine(tickets.GetLuckyTicketsCount());
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (FileNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    }

                default:
                {
                    this.Instruction();
                    break;
                }
            }
        }

        /// <summary>
        /// Getting tickets type of calculation
        /// </summary>
        /// <param name="filepath">Path to file with type of calculation (only 1 word in file)</param>
        /// <returns>Tickets Type</returns>
        private TicketsType GetTicketsType(string filepath)
        {
            if (File.Exists(filepath))
            {
                TicketsType result = TicketsType.Moscow;
                string command = string.Empty;
                using (StreamReader streamReader = new StreamReader(filepath))
                {
                    command = streamReader.ReadLine();
                }

                switch (command)
                {
                    case "Moscow":
                    {
                        result = TicketsType.Moscow;
                        break;
                    }

                    case "Piter":
                    {
                        result = TicketsType.Piter;
                        break;
                    }

                    default:
                    {
                        throw new ArgumentException("Incorrect file input");
                    }
                }

                return result;
            }
            else
            {
                throw new FileNotFoundException("Source file wasn`t found");
            }
        }

        /// <summary>
        /// Instruction to the program (sending to the console)
        /// </summary>
        private void Instruction()
        {
            Console.WriteLine("Program assignment" + Environment.NewLine +
               "Calculate count of happy numbers in tickets by Moskow or Piter method" + Environment.NewLine +
               "Enter filepath to file with Moscow or Piter word" + Environment.NewLine +
               "Launch example: <filepath>");
        }
    }
}
