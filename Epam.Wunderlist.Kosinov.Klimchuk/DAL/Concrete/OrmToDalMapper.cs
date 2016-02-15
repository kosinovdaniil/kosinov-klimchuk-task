using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public static class OrmToDalMapper
    {
        public static User ToOrmUser(this DalUser e)
        {
            return new User()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password
            };
        }
        public static DalUser ToDalUser(this User e)
        {            
            return new DalUser()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password
            };
        }

    }
}
