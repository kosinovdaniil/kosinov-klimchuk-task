using DAL.Interface.DTO;
using ORM;
using System;
using System.Linq;

namespace DAL.Mappers
{
    public static class DalUserMapper
    {
        public static User ToOrmUser(this DalUser e)
        {
            return new User()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password,
                Email = e.Email,
                PhotoPath = e.PhotoPath //TODO add lists if needed
            };
        }

        public static DalUser ToDalUser(this User e)
        {
            return new DalUser()
            {
                Id = e.Id,
                Name = e.Name,
                Password = e.Password,
                Email = e.Email,
                ListsId = e.Lists?.Select(x => x.Id).ToList(),
                PhotoPath = e.PhotoPath
            };
        }

        public static void CopyFieldsTo(this DalUser source, User target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            target.Name = source.Name;
            target.Password = source.Password;
        }
    }
}
