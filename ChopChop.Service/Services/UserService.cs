using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.Entity.Repository;
using ChopChop.Entity.EntityFramework;

namespace ChopChop.Service
{
    public class UserService: GenericRepository<User>, IUserService
    {
        IGenericRepository<User> repoUser = new GenericRepository<User>();
        /// <summary>
        /// Function to Insert data into Admin table in database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertUser(User entity)
        {
            bool isInserted = false;
            try
            {
                repoUser.Add(entity);
                isInserted = true;
            }
            catch (Exception ex)
            {
                isInserted = false;
            }

            return isInserted;
        }

        public User Login(User entity)
        {
            return repoUser.GetAll().Where(x => x.UserName == entity.UserName && x.Password == entity.Password).FirstOrDefault();
        }

        /// <summary>
        /// Get List of all User
        /// </summary>
        /// <returns></returns>
        public User GetUser(int userId)
        {
            return repoUser.GetAll().FirstOrDefault(x=>x.UserID==userId);
        }

        public User GetUserByUserNamePassword(string userName,string password)
        {
            return repoUser.GetAll().Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            //return repoUser.GetAll().FirstOrDefault(x => x.UserName == userName && x.Password == password && x.IsActive == true);
        }
    }
}
