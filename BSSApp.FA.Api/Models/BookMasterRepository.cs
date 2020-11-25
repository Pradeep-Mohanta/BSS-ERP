using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class BookMasterRepository : IBookMasterRepository
    {
        private readonly AppDbContext appDbContext;

        public BookMasterRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<BookMaster> AddBookMaster(BookMaster newBook)
        {
            var addBookResult= await appDbContext.BookMaster.AddAsync(newBook);
            await appDbContext.SaveChangesAsync();
            return addBookResult.Entity;
        }

        public async Task<IEnumerable<BookMaster>> GetBookMasters()
        {
            return await appDbContext.BookMaster.ToListAsync();
        }

        public async Task<BookMaster> GetBookMaster(int id)
        {
            return await appDbContext.BookMaster
                .Include(b=>b.CostCenter)
                .Include(c=>c.CategoryCode)
                .FirstOrDefaultAsync(a=>a.BookMasterID==id);
        }
    }
}
