using System.Collections.Generic;

namespace BLL.Interface.Services
{
    public interface IToDoListSearchService
    {
        IEnumerable<int> Search(string input);
    }
}