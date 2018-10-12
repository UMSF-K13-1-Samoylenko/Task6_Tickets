// <copyright file="Ticket.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task6_Lib
{
    using System;

    /// <summary>
    /// Ticket class
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Array with digits of ticket number
        /// </summary>
        private readonly int[] array;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticket"/> class
        /// </summary>
        /// <param name="ticketNumber">Int ticket number</param>
        /// <param name="n">Digits in ticket(max)</param>
        public Ticket(int ticketNumber, int n)
        {
            this.Size = n;
            this.array = this.TicketNumberDigitParser(ticketNumber);
        }

        /// <summary>
        /// Gets size of array and count of digits(max) in ticket
        /// </summary>
        public int Size
        {
            get;
            private set;
        }

        /// <summary>
        /// Indexator for getting digit value of ticket number
        /// </summary>
        /// <param name="i">Index of digit</param>
        /// <returns>Value of ticket`s digit</returns>
        /// <exception cref="IndexOutOfRangeException">Throws when index less than 0 or bigger than Size-1</exception>
        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Size)
                {
                    return this.array[i];
                }
                else
                {
                    throw new IndexOutOfRangeException($"Use indexer for [0,{this.Size - 1}] values");
                }
            }
        }

        /// <summary>
        /// Method, which parse ticket number into digits array
        /// </summary>
        /// <param name="ticketNumber">Int ticket number</param>
        /// <returns>Digits array</returns>
        private int[] TicketNumberDigitParser(int ticketNumber)
        {
            int[] result = new int[this.Size];
            for (int i = 0; ticketNumber != 0; ++i)
            {
                result[i] = ticketNumber % 10;
                ticketNumber /= 10;
            }

            return result;
        }
    }
}
