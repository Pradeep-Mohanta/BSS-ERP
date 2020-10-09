using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class TypeMastRepository : ITypeMastRepository
    {
        private readonly AppDbContext appDbContext;

        public TypeMastRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<TypeMast> GetTypeMast(int id)
        {
            return await appDbContext.TypeMasts.FirstOrDefaultAsync(t => t.TypeMastID == id);
        }

        public async Task<IEnumerable<TypeMast>> GetTypeMasts()
        {
            return await appDbContext.TypeMasts
                        .OrderBy(t=>t.Description)
                        .ToListAsync();
        }
    }
}
