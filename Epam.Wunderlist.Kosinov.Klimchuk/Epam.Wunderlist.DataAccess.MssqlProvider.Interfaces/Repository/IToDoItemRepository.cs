﻿using Epam.Wunderlist.DomainModel;
using System.Collections.Generic;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.Interfaces.Repository
{
    public interface IToDoItemRepository : IRepository<ToDoItem>
    {
        IEnumerable<ToDoItem> GetByList(int id);
    }
}