using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using Sikiedu.Model;
using Sikiedu.Manager;

namespace Sikiedu
{
    class Program
    {
        static void Main(string[] args)
        {
            //var configuration = new Configuration();
            //configuration.Configure();//解析nhibernate.cfg.xml 
            //configuration.AddAssembly("Sikiedu");//解析 映射文件  User.hbm.xml ....

            //ISessionFactory sessionFactory = null;
            //ISession session = null;
            //ITransaction transaction = null;
            //try
            //{
            //    sessionFactory= configuration.BuildSessionFactory();

            //    session = sessionFactory.OpenSession();//打开一个跟数据库的会话


            //    //User user = new User() { Username = "dslfkjer", Password = "234234" };

            //    //session.Save(user);

            //    //事务
            //    transaction= session.BeginTransaction();
            //    //进行操作
            //    User user1 = new User() { Username = "cxvxcv34", Password = "234234" };
            //    User user2 = new User() { Username = "cxvxcv34", Password = "234234" };

            //    session.Save(user1);
            //    session.Save(user2);
            //    transaction.Commit();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}finally{
            //    if (transaction != null)
            //    {
            //        transaction.Dispose();
            //    }
            //    if (session != null)
            //    {
            //        session.Close();
            //    }
            //    if (sessionFactory != null)
            //    {
            //        sessionFactory.Close();
            //    }
            //}

            //User user = new User() { Id=10 };
            IUserManager userManager = new UserManager();
            //userManager.Add(user);

            //userManager.Update(user);
            //userManager.Remove(user);
            //User user = userManager.GetById(18);

            //User user = userManager.GetByUsername("wer");
            //Console.WriteLine(user.Username);
            //Console.WriteLine(user.Password);

            //ICollection<User> users = userManager.GetAllUsers();
            //foreach (User u in users)
            //{
            //    Console.WriteLine(u.Username + " " + u.Password);
            //}
            Console.WriteLine(userManager.VerifyUser("wer", "wer"));
            Console.WriteLine(userManager.VerifyUser("wer2", "wer"));
           
            Console.ReadKey();
        }
    }
}
