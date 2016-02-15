using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}