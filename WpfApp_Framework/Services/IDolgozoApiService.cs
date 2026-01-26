using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp_Framework.Models;

namespace WpfApp_Framework.Services
{
    public interface IDolgozoApiService
    {
        Task<List<Dolgozo>> GetAllAsync();
        Task<bool> InsertAsync(Dolgozo dolgozo);
        Task<bool> UpdateAsync(Dolgozo dolgozo);
        Task<bool> DeleteAsync(long id);
    }
}
