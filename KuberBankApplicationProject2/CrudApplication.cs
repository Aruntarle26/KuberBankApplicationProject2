using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuberBankApplicationProject2
{
   public class CrudApplication
    {
       
        public List<User> userList = new List<User> ();
        public List<Payee> payeeList = new List<Payee>();
        public static int count;

        public List<User> ShowAll()
        {
            return userList;
        }
        public List<User> ShowCustomers()
        {
            List<User> list = new List<User>();
            foreach (User item in userList)
            {
                if (item.Role == Roles.Customer)
                {
                    userList.Add(item);
                }
            }
            return list;
        }
        public List<User> ShowActiveUsers()
        {
            List<User> list = new List<User>();
            foreach (User item in userList)
            {
                if (item.IsActive == true)
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public List<User> ShowDeactivedUsers()
        {
            List<User> list = new List<User>();
            foreach (User item in userList)
            {
                if (item.IsActive == false)
                {
                    list.Add(item);
                }
            }
            return list;
        }
       

        public void AddUser(User user)
        {
            user.Role = Roles.Customer;
            user.IsActive = true;
            user.UserId = user.UserId;
            userList.Add(user);
            count++;
        }
        public void DeactivateUser(User user)
        {
            foreach (var item in userList)
            {
                if (item.UserId == user.UserId)
                {
                    item.IsActive = false;
                    break;
                }
            }
        }
        public void ActivateUser(User user)
        {
            foreach (var item in userList)
            {
                if (item.UserId == user.UserId)
                {
                    item.IsActive = true;
                    break;
                }
            }
        }
        public CrudApplication()
        {
           
            userList.Add(new User { UserName = "arun", UserId = 100, Password = "arun#123", Role = Roles.Admin });
            userList.Add(new User { UserName = "tarle", UserId = 101, Password = "tarle#123", Role = Roles.Admin });
        }
        public int ValidateUser(User user, out int userid)
        {
            userid=0;
            foreach (User u in userList)
            {
                if (u.UserName == user.UserName && u.Password == user.Password )
                {
                    if (u.Role == Roles.Admin)
                    {
                        userid = u.UserId;
                        return 1;

                    }
                    else
                    {
                        userid = u.UserId;
                        return 0;
                    }
                }

            }
            return 2;
        }
        User u = new User();
        public double  CheckBalance(User u1)
        {
            double b = 0;

            foreach (User u in userList)
            {
                if(u.UserId==u1.UserId)
                {
                    b = u.Balance+u.MinBalance;
                }
            }
            return b;

        }
        public void DepositBalance(User u4)
        {
           
            foreach (User u in userList)
            {
                if (u.UserId==u4.UserId)
                {
                    u.Balance = u.Balance + u4.Balance;
                  

                }
            }
        }
        public void ModifyUser(User um)
        {
            //List<User> apdateList = new List<User>();
            foreach (User u in userList)
            {
                if(u.UserId==um.UserId)
                {
                    u.UserName = um.UserName;
                    u.Password = um.Password;
                    u.Role = um.Role;
                    u.MinBalance = um.MinBalance;
                }
            }

        }
        public void DeletUser(User um)
        {
            //List<User> apdateList = new List<User>();
            foreach (User u in userList)
            {
                if (u.UserId == um.UserId)
                {
                    userList.Remove(u);
                    break;
                }
            }

        }
        public void ShowActiveUser()
        {
            foreach (var item in userList)
            {
                if (item.IsActive== true)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void ShowDeActiveUser()
        {
            foreach (var item in userList)
            {
                if (item.IsActive == false)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void AddPayee(Payee p)
        {
            foreach (User item in userList)
            {
                if(item.UserId==p.UserId)
                {
                    if(item.IsActive==true)
                    {
                        payeeList.Add(p);
                    }
                    else
                    {
                        Console.WriteLine("Sorry you are InActive so yo can't Add Payee");
                    }
                }

            }
           
        }
        public void ShowPayeeList(int userid)
        {
            foreach (Payee p in payeeList)
            {
                if (p.UserId == userid)
                {
                    Console.WriteLine(p);
                }
            }
        }
        public void TransferMoney(Payee p,User u)
        {
            foreach  (User ur in userList)
            {
                 if (ur.UserId == u.UserId)
                {
                    if(ur.Balance<u.Balance)
                    {
                        throw new MinimunBalanceException("Your Balance is Less than Transfer Amount..");
                    }
                    else
                    {
                        foreach (Payee item in payeeList)
                        {
                            if (item.PayeeId == p.PayeeId)
                            {
                                item.PayeeBalance = item.PayeeBalance + u.Balance;
                            }

                        }
                        foreach (User item in userList)
                        {
                            if (item.UserId == u.UserId)
                            {
                                item.Balance = item.Balance - u.Balance;
                            }

                        }

                    }
                }

            }
            
        }
        public void DeletPayee(Payee p1,int userid)
        {
           
            foreach (Payee p in payeeList)
            {
                if (p.UserId==userid)
                {
                    payeeList.Remove(p);
                    break;
                }
            }

        }
    }
}

    

