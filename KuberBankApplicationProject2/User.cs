using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuberBankApplicationProject2
{
    public enum Roles
    {
        Customer,Admin
    }
    public class User
    {
        
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public bool IsActive { get; set; }
        public double Balance { get; set; }
        public double  MinBalance { get; set; }
        public AccountTypes AccountType { get; set; }
        public override string ToString()
        {
            return $"user Id:{UserId} User Name:{UserName}  Role:{Role} Balance:{MinBalance+Balance}"; 
        }






    }
}
