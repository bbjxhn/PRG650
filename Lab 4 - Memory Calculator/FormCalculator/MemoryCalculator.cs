using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibCalculator;

namespace FormCalculator
{
    internal class MemoryCalculator : Calculator
    {
        private decimal memoryValue { get; set; } = 0m;

        public void MemoryStore(decimal value)
        {
            memoryValue = value;
        }   

        public decimal MemoryRecall()
        {
            return memoryValue;
        }

        public decimal MemoryAdd(decimal value)
        {
            return memoryValue += value;
        }

        public void MemoryClear()
        {
            memoryValue = 0;
        }
    }
}
