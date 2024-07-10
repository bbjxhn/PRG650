using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_Test
{
    public class Software : Product
    {
        private int Version;

        public sealed override string GetInfo()
        {
            return base.Code + Version;
        }
    }
}
