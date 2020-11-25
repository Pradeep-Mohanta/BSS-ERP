using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public interface IBookMasterRepository
    {
        Task<IEnumerable<BookMaster>> GetBookMasters();
        Task<BookMaster> GetBookMaster(int id);
        Task<BookMaster> AddBookMaster(BookMaster newBook);
    }
}
