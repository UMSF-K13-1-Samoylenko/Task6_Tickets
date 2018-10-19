// <copyright file="Tickets_Tests.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task6_UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task6_Lib;

    /// <summary>
    /// Class with tests for tickets calculation methods
    /// </summary>
    [TestClass]
    public class Tickets_Tests
    {
        /// <summary>
        /// Moscow method Tickets Tests
        /// </summary>
        /// <param name="n">Digits count</param>
        /// <param name="expected">Expected count of lucky tickets</param>
        [DataTestMethod]
        [DataRow(2, 9)]// 11,22,33,44..
        [DataRow(6, 55251)]
        public void MocowTicketsTests(int n, int expected)
        {
            // Arrange
            TicketSequence ticketSequence = MoscowTicketSequence.Initialize(n);

            // Actual
            int actual = ticketSequence.GetLuckyTicketsCount();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// P i t e r method Tickets Tests
        /// </summary>
        /// <param name="n">Digits count</param>
        /// <param name="expected">Expected count of lucky tickets</param>
        [DataTestMethod]
        [DataRow(2, 9)]
        [DataRow(6, 55251)]
        public void PiterTicketsTests(int n, int expected)
        {
            // Arrange
            TicketSequence ticketSequence = PiterTicketSequence.Initialize(n);

            // Actual
            int actual = ticketSequence.GetLuckyTicketsCount();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
