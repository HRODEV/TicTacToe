using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Logic
{
    public static class IntExtensions
    {
        /// <summary>
        /// including itself
        /// </summary>
        /// <param name="number"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static bool IsBetween(this int number, int from, int to)
        {
            return number >= from && number <= to;
        }
    }
}
