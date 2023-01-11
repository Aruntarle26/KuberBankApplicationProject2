using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuberBankApplicationProject2
{
    class OnlyException
    {
    }
    public class MinimunBalanceException:Exception
    {
        public MinimunBalanceException(string msg):base(msg)
        {

        }
    }
}
