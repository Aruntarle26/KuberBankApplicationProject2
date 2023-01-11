using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KuberBankApplicationProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------Welcome to Kuber Bank---------------------");
            
            OurMultithreading o = new OurMultithreading();
            
            Thread t = new Thread(new ThreadStart(o.process));
            Thread t2 = new Thread(new ThreadStart(o.process));
            t.Start();
            t.Join();


           
            int op = 6;
            int userid;
            char cha;
            CrudApplication userCRUD = new CrudApplication();
            do
            {
                Console.Clear();
                Console.WriteLine("\t....Login...");
                

                User user = new User();
                Console.WriteLine("Enter UserName");
                user.UserName = Console.ReadLine();
                Console.WriteLine("Enter Password");
                user.Password = Console.ReadLine();


                int result = userCRUD.ValidateUser(user, out userid);
               
                if (result == 1)
                {
                    char admenu;
                    do
                    {
                        Console.Clear();
                      // Console.WriteLine("Adminid is:----------" + userid);
                       
                        Console.WriteLine("1. Add User");
                        Console.WriteLine("2. Show All User");
                        Console.WriteLine("3. Modify User");
                        Console.WriteLine("4. Delete User");
                        Console.WriteLine("5. Activate User");
                        Console.WriteLine("6. Deactive User");
                        Console.WriteLine("7. ShowActiveUser");
                        Console.WriteLine("8. ShowDeactiveUser");
                        Console.WriteLine("9. Exit");
                        Console.WriteLine("Enter your option");
                        op = Convert.ToInt32(Console.ReadLine());
                        switch (op)
                        {
                            case 1:
                                char c5;
                                do
                                {
                                    User u = new User();
                                    Console.WriteLine("Enter [userid,Username,Minbalance,password]");
                                    u.UserId = Convert.ToInt32(Console.ReadLine());
                                    u.UserName = Console.ReadLine();
                                    u.Role = Roles.Customer;
                                    u.MinBalance = Convert.ToDouble(Console.ReadLine());
                                    u.Password = Console.ReadLine();
                                    userCRUD.AddUser(u);
                                    //t2.Start();
                                    //t2.Join();
                                    Console.WriteLine("------------User Created Successfully...");
                                    
                                    Console.WriteLine("if you want to add another user then press y else press n");
                                    c5 = Convert.ToChar(Console.ReadLine());
                                } while (c5 == 'y' || c5 == 'Y');
                                break; 
                            case 2:
                                List<User> alluser = new List<User>();
                                alluser=userCRUD.ShowAll();
                                foreach (var item in alluser)
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                            case 3:
                                User u6 = new User();
                                Console.WriteLine("please enter the userid which you want to modify ");
                                u6.UserId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter new values [username,password,minBalance]");
                                u6.UserName = Console.ReadLine();
                                u6.Password = Console.ReadLine();
                                u6.Role = Roles.Customer;
                                u6.MinBalance = Convert.ToDouble(Console.ReadLine());
                               
                                userCRUD.ModifyUser(u6);
                                break;
                            case 4:
                                User u7 = new User();
                                Console.WriteLine("please enter the userid which you want to Delet ");
                                u7.UserId = Convert.ToInt32(Console.ReadLine());

                                userCRUD.DeletUser(u7);
                                Console.WriteLine("account deleted successfully.......");
                                break;
                            case 5:
                                User u8 = new User();
                                Console.WriteLine("please enter the userid which you want to active ");
                                u8.UserId = Convert.ToInt32(Console.ReadLine());
                                userCRUD.ActivateUser(u8);
                                Console.WriteLine("account activated successfully.......");
                                break;
                            case 6:
                                User u9 = new User();
                                Console.WriteLine("please enter the userid which you want to Deactive ");
                                u9.UserId = Convert.ToInt32(Console.ReadLine());
                                userCRUD.DeactivateUser(u9);
                                Console.WriteLine("account Deactivated successfully.......");
                                break;
                            case 7:
                                userCRUD.ShowActiveUser();

                                break;
                            case 8:
                                userCRUD.ShowDeActiveUser();

                                break;
                            case 9:
                                break;
                            default:
                                Console.WriteLine("Wrong");
                                break;
                        }
                        Console.WriteLine("Do you want to see admin menu again..? then press y else press n");
                        admenu = Convert.ToChar(Console.ReadLine());
                    } while (admenu == 'y' || admenu == 'Y');
                }



                else if (result == 0)
                {
                    char ch1;
                    do
                    {
                        Console.Clear();
                       //Console.WriteLine("userid is:----------" + userid);
                        Console.WriteLine("1. Deposit Balance");
                        Console.WriteLine("2. Check Balance");
                        Console.WriteLine("3. Add Payee");
                        Console.WriteLine("4. ShowAllPayee");
                        Console.WriteLine("5. RemovePayee");
                        Console.WriteLine("6. Transfer Amount to payee");
                        Console.WriteLine("7. Exit");
                        Console.WriteLine("Enter your option");
                        op = Convert.ToInt32(Console.ReadLine());
                        CrudApplication c1 = new CrudApplication();
                        switch (op)
                        {
                            case 1:
                                char ch;
                                do
                                {
                                   
                                    User u4 = new User();
                                    Console.WriteLine("Enter amount  ");
                                    u4.UserId = userid;
                                    u4.Balance = Convert.ToDouble(Console.ReadLine());
                                   
                                    userCRUD.DepositBalance(u4);
                                   
                                    Console.WriteLine("Do you want to deposit money again.?");
                                    ch = Convert.ToChar(Console.ReadLine());
                                } while (ch == 'y' || ch == 'Y');
                                break;
                            case 2:
                               
                                User u3 = new User();
                                u3.UserId = userid;
                                double value= userCRUD.CheckBalance(u3);
                                Console.WriteLine("Available balance is: "+value);

                                break;
                            case 3:
                                char chp;
                                do
                                {
                                    Payee p1 = new Payee();
                                    p1.UserId = userid;
                                    Console.WriteLine("Enter Payee [id , Name]");

                                    p1.PayeeId = Convert.ToInt32(Console.ReadLine());
                                    p1.PayeeName = Console.ReadLine();

                                    userCRUD.AddPayee(p1);
                                    Console.WriteLine(" Do you want to Add another payee? then press y else press n");
                                    chp = Convert.ToChar(Console.ReadLine());
                                } while (chp=='y'||chp=='Y');

                                break;
                            case 4:
                                userCRUD.ShowPayeeList(userid);
                                break;
                            case 5:
                                Payee p = new Payee();
                                Console.WriteLine("Enter the payeeId which you want to delet");
                                p.PayeeId = Convert.ToInt32(Console.ReadLine());
                                userCRUD.DeletPayee(p,userid);
                                break;
                            case 6:
                                try
                                {
                                    User u10 = new User();
                                    Console.WriteLine("Enter amount you want to transfer");
                                    u10.UserId = userid;
                                    u10.Balance = Convert.ToDouble(Console.ReadLine());
                                    Payee p2 = new Payee();
                                    Console.WriteLine("Please enter Payee id");
                                    p2.PayeeId = Convert.ToInt32(Console.ReadLine());
                                    userCRUD.TransferMoney(p2, u10);
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.GetType());
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case 7 :
                                break;
                            default:
                                Console.WriteLine("Wrong");
                                break;
                        }
                        Console.WriteLine("Do you want see user menu menu again?if yes then press y");
                        ch1 = Convert.ToChar(Console.ReadLine());
                    } while (ch1 == 'y' || ch1 == 'Y');

                }
                else if (result == 2)
                {
                    op = 6;
                    Console.WriteLine("User name or password is wrong");
                }
                Console.WriteLine("if you want*** Login ***again press y else press n to exit");
                cha = Convert.ToChar(Console.ReadLine());
            }
            while (cha=='y'||cha=='Y');
        }

    }
}

