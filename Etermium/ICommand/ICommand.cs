using Etermium.Entits;
using System;
using System.Threading;

namespace Etermium.ICommand
{
    /// <summary>
    /// Interface for defining command objects.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="player">The player object.</param>
        /// <param name="enemy">The enemy object.</param>
        void Execute(Player player, Enemy enemy);
    }
}