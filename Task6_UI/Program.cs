// <copyright file="Program.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task6_UI
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args">Command line args</param>
        private static void Main(string[] args)
        {
            TicketsMenu ticketsMenu = new TicketsMenu(6);
            ticketsMenu.ConsoleMenu();
        }
    }
}
