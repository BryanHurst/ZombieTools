// Custom Includes
using MemoryLib;

// Standard Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AionMemory
{
    /// <summary>
    /// Read various values from AION's memory.
    /// </summary>
    public class Read
    {
        /// <summary>
        /// Reads macro text from AION's memory for the current player.  *NOT FINISHED*
        /// </summary>
        /// <param name="e">Current player structure.</param>
        /// <param name="slot">Macro slot.</param>
        public static void Macro(ref Player e, int slot)
        {
            e.Macro1 = Memory.ReadString(Process.handle, Process.macro1, 255, true);
        }
    }
}
