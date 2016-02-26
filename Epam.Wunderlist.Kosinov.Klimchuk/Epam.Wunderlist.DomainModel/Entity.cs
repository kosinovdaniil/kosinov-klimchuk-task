using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.DomainModel
{
    public abstract class Entity
    {
        public virtual int Id { get; protected set; }
    }
}
