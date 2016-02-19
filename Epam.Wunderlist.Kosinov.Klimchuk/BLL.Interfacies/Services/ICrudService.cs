using System.Collections.Generic;

namespace BLL.Interface.Services
{
    public interface ICrudService<IEntity>
    {
        IEntity Get(int id);

        IEnumerable<IEntity> GetAll();

        IEntity Create(IEntity entity);

        void Update(IEntity entity);

        void Delete(IEntity entity);
    }
}
