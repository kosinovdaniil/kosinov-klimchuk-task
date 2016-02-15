using System.Collections.Generic;

namespace BLL.Interface.Services
{
    public interface ITaskSearchService
    {
        IEnumerable<int> Search(string input);
    }
}