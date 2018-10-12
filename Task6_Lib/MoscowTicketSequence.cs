// <copyright file="MoscowTicketSequence.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task6_Lib
{
    using System;

    /// <summary>
    /// Class with Moscow ticket sequence, 
    /// which realize an opportunity to calculate lucky tickets count
    /// </summary>
    public class MoscowTicketSequence : TicketSequence
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoscowTicketSequence"/> class
        /// </summary>
        /// <param name="n">Ticket digits count</param>
        private MoscowTicketSequence(int n) : base(n)
        {
        }

        /// <summary>
        /// Class initializer
        /// </summary>
        /// <param name="n">Ticket digits count</param>
        /// <returns>Instance of class</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws when n is less than 1</exception>
        public static MoscowTicketSequence Initialize(int n)
        {
            if (n > 0)
            {
                return new MoscowTicketSequence(n);
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
            int leftPart = 0;
            int rightPart = 0;
            for (int i = 0; i < currentTicket.Size / 2; ++i)
            {
                rightPart += currentTicket[i];
            }

            for (int i = (currentTicket.Size / 2) + (currentTicket.Size % 2); i < currentTicket.Size; ++i)
            {
                leftPart += currentTicket[i];
            }

            return leftPart == rightPart;
        }
    }
}
