using System.Collections.Generic;
using System.Threading.Tasks;
using framework_WpfApp.Models;

namespace framework_WpfApp.Services
{
    public interface IDolgozoApiService
    {
        Task<List<Dolgozo>> GetAllAsync();
        Task<bool> InsertAsync(Dolgozo dolgozo);
        Task<bool> UpdateAsync(Dolgozo dolgozo);
        Task<bool> DeleteAsync(long id);
    }
}
