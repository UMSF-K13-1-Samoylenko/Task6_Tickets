// <copyright file="Tickets.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task6_Lib
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for work with tickets
    /// </summary>
    public class Tickets
    {
        /// <summary>
        /// Count of digits in tickets
        /// </summary>
        private readonly int n;

        /// <summary>
        /// Minimum value of ticket number
        /// </summary>
        private int startValue;

        /// <summary>
        /// Maximum number of ticket number
        /// </summary>
        private int endValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tickets"/> class
        /// </summary>
        /// <param name="n">Count of digits in tickets</param>
        public Tickets(int n)
        {
            this.n = n;
            this.CalcMaxValue();
        }

        /// <summary>
        /// Calculating count of happy tickets by Moscow method
        /// </summary>
        /// <returns>Count of happy tickets</returns>
        public int MoscowTicketsCount()
        {
            int ticketsCount = 0;
            this.startValue = (int)Math.Pow(10, this.n - 1);
            IEnumerator<int> ticketSequence = this.TicketSequence();
            while (ticketSequence.MoveNext())
            {
                int leftTicketPart = 0;
                int rightTicketPart = 0;
                int currentTicket = ticketSequence.Current;
                for (int i = 0; i < this.n / 2; ++i)
                {
                    rightTicketPart += currentTicket % 10;
                    currentTicket /= 10;
                }

                for (int i = 0; i < (this.n / 2) + (this.n % 2); ++i)
                {
                    leftTicketPart += currentTicket % 10;
                    currentTicket /= 10;
                }

                if (leftTicketPart == rightTicketPart)
                {
                    ++ticketsCount;
                }
            }

            return ticketsCount;
        }

        /// <summary>
        /// Calculating count of happy tickets by P I T E R method
        /// </summary>
        /// <returns>Count of happy tickets</returns>
        public int PiterTicketsCount()
        {
            int ticketsCount = 0;
            this.startValue = (int)Math.Pow(10, this.n - 2);
            IEnumerator<int> ticketSequence = this.TicketSequence();
            while (ticketSequence.MoveNext())
            {
                int oddPart = 0;
                int evenPart = 0;
                int currentTicket = ticketSequence.Current;
                for (int i = 0; currentTicket != 0; ++i)
                {
                    if (i % 2 == 0)
                    {
                        oddPart += currentTicket % 10;
                    }
                    else
                    {
                        evenPart += currentTicket % 10;
                    }

                    currentTicket /= 10;
                }

                if (oddPart == evenPart)
                {
                    ++ticketsCount;
                }
            }

            return ticketsCount;
        }

        /// <summary>
        /// Calculating max number of tickets
        /// </summary>
        private void CalcMaxValue()
        {
            this.endValue = 0;
            for (int i = 0; i < this.n; i++)
            {
                int currentR = 9;
                for (int j = 0; j < i; j++)
                {
                    currentR *= 10;
                }

                this.endValue += currentR;
            }
        }

        /// <summary>
        /// Method to get all tickets
        /// </summary>
        /// <returns>Current ticket</returns>
        private IEnumerator<int> TicketSequence()
        {
            for (int i = this.startValue; i <= this.endValue; ++i)
            {
                yield return i;
            }
        }
    }
}
