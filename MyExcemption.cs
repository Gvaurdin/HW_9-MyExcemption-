using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9_My_Excemption
{
    public class MyException : ApplicationException
    {
        public DateTime TimeException { get; private set; }
        public MyException() : base("My exception")
        {
            TimeException = DateTime.Now;
        }
        public MyException(string message) : base(message)
        {
            TimeException = DateTime.Now;
        }
    }
}
