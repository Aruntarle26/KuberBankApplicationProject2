using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuberBankApplicationProject2
{
    public class Payee
    {
        public int PayeeId { get; set; }
        public int UserId { get; set; }
        public string PayeeName { get; set; }
        public int PayeeAccNo { get; set; }
        public double PayeeBalance { get; set; }
        public override string ToString()
        {
            return $"Payee id:{PayeeId} Payee name:{PayeeName} Balance:{PayeeBalance}";
        }


    }
}
