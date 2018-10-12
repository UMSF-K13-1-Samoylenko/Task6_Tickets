// <copyright file="PiterTicketSequence.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task6_Lib
{
    using System;

    /// <summary>
    /// Class with piter ticket sequence, 
    /// which realize an opportunity to calculate lucky tickets count
    /// </summary>
    public class PiterTicketSequence : TicketSequence
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PiterTicketSequence" /> class
        /// </summary>
        /// <param name="n">Ticket digits count</param>
        private PiterTicketSequence(int n) : base(n)
        {
        }

        /// <summary>
        /// Class initializer
        /// </summary>
        /// <param name="n">Ticket digits count</param>
        /// <returns>Instance of class</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws when n is less than 1</exception>
        public static PiterTicketSequence Initialize(int n)
        {
            if (n > 0)
            {
                return new PiterTicketSequence(n);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Please use correct value of n, that are equal count of digits in ticket!");
            }
        }

        /// <summary>
        /// Method to separate lucky tickets from unlucky
        /// </summary>
        /// <param name="currentTicket">Current ticket to analize</param>
        /// <returns>Ticket fits conditions status</returns>
        protected override bool TicketCondition(Ticket currentTicket)
        {
            int oddSum = 0;
            int evenSum = 0;
            for (int i = 0; i < currentTicket.Size; i++)
            {
                if (i % 2 == 0)
                {
                    oddSum += currentTicket[i];
                }
                else
                {
                    evenSum += currentTicket[i];
                }
            }

            return oddSum == evenSum;
        }
    }
}
