﻿using DAL.Interface.DTO;
using DAL.Interface.Repository;
using System.Collections.Generic;

namespace DAL.Interfacies.Repository
{
    public interface IToDoListRepository : IRepository<DalToDoList>
    {
        IEnumerable<DalToDoItem> GetByList(int id);
    }
}
