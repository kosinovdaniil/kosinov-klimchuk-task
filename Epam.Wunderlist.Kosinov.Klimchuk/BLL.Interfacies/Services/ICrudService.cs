using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface ICrudService<IEntity>
    {
        IEntity Get(int id);
        IEntity Create(IEntity entity);
        void Update(IEntity entity);
        void Delete(IEntity entity);
    }
}
