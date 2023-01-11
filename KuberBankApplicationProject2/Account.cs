using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuberBankApplicationProject2
{
    public enum AccountTypes
    {
        Saving,Current
    }
    public class Account
    {
        public int UserId { get; set; }
        public int AccNo { get; set; }

        public double Balance { get; set; }
        public AccountTypes AccountType { get; set; }

    }
}
