using Fruit_Store.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.Interfaces.Services
{
    public interface INewServices
    {
        Task<IEnumerable<NewDTO>> GetLastAsync();
        Task<NewDTO?> GetByIDAsync(int id);
        Task<bool> AddAsync(NewDTO NewDTO);
        Task<bool> UpdateAsync(NewDTO NewDTO);
        Task<bool> DeleteAsync(int id);

        // Add PaginatedResult for divide the news into pages
        // and u can use it in the controller to get the news by page
        // Feature if u need 


    }
}