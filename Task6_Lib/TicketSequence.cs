// <copyright file="TicketSequence.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task6_Lib
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for work with tickets
    /// </summary>
    public abstract class TicketSequence
    {
        /// <summary>
        /// Count of digits in tickets
        /// </summary>
        private readonly int n;

        /// <summary>
        /// Initializes a new instance of the <see cref="Task6_Lib.TicketSequence"/> class
        /// </summary>
        /// <param name="n">Count of digits in tickets</param>
        public TicketSequence(int n)
        {
            this.n = n;
        }

        /// <summary>
        /// Getting lucky tickets count
        /// </summary>
        /// <returns>Lucky tickets count</returns>
        public int GetLuckyTicketsCount()
        {
            int ticketCounts = 0;
            foreach (Ticket ticket in this.Sequence())
            {
                if (this.TicketCondition(ticket))
                {
                    ++ticketCounts;
                }
            }

            return ticketCounts;
        }

        /// <summary>
        /// Method to separate lucky tickets from unlucky
        /// </summary>
        /// <param name="currentTicket">Current ticket to analize</param>
        /// <returns>Ticket fits conditions status</returns>
        protected abstract bool TicketCondition(Ticket currentTicket);

        /// <summary>
        /// Get value of max number ticket
        /// </summary>
        /// <returns>Max ticket number</returns>
        private int GetMaxTicketNumber()
        {
            int endValue = 0;
            for (int i = 0; i < this.n; ++i)
            {
                int currentR = 9;
                for (int j = 0; j < i; ++j)
                {
                    currentR *= 10;
                }

                endValue += currentR;
            }

            return endValue;
        }

        /// <summary>
        /// Method to get all tickets
        /// </summary>
        /// <returns>Current ticket</returns>
        private IEnumerable<Ticket> Sequence()
        {
            int maxTicketNumber = this.GetMaxTicketNumber();
            for (int i = 1; i <= maxTicketNumber; ++i)
            {
                yield return new Ticket(i, this.n);
            }
        }
    }
}
