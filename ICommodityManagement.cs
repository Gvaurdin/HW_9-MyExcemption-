using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9_My_Excemption
{
    public interface ICommodityManagement
    {
        void Add(int count);
        void Sell(int count);
        void Dispose(int count);
        void Transfer (int count, string export );
    }

    public interface IGeTCode
    {
        string ProductCode { get; }
    }
}
