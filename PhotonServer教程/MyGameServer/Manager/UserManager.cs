using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using MyGameServer.Model;
using NHibernate.Criterion;

namespace MyGameServer.Manager
{
    class UserManager:IUserManager
    {
        public void Add(Model.User user)
        {
            //ISession session = NHibernateHelper.OpenSession();
            //session.Save(user);
            //session.Close();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                }
            }

        }

        public void Update(Model.User user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
        }

        public void Remove(Model.User user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(user);
                    transaction.Commit();
                }
            }
        }

        public Model.User GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    User user = session.Get<User>(id);
                    transaction.Commit();
                    return user;
                }
            }
        }

        public Model.User GetByUsername(string username)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //ICriteria criteria = session.CreateCriteria(typeof(User));
                //criteria.Add(Restrictions.Eq("Username", username));
                //User user = criteria.UniqueResult<User>();
                User user = session.CreateCriteria(typeof(User)).Add(Restrictions.Eq("Username", username)).UniqueResult<User>();
                return user;
            }
        }

        

        public ICollection<Model.User> GetAllUsers()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //ICriteria criteria = session.CreateCriteria(typeof(User));
                //criteria.Add(Restrictions.Eq("Username", username));
                //User user = criteria.UniqueResult<User>();
                IList<User> users = session.CreateCriteria(typeof(User)).List<User>();
                return users;
            }
        }


        public bool VerifyUser(string username, string password)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //ICriteria criteria = session.CreateCriteria(typeof(User));
                //criteria.Add(Restrictions.Eq("Username", username));
                //User user = criteria.UniqueResult<User>();
                User user = session
                    .CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("Username", username))
                    .Add(Restrictions.Eq("Password", password))
                    .UniqueResult<User>();
                if (user == null) return false;
                return true;
            }
        }
    }
}
