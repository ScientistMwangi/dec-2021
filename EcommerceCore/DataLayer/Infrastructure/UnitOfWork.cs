using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCore.DataLayer
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();
    }
    public class UnitOfWork : IUnitOfWork
    {
        public EcommerceDbContext _context;

        public UnitOfWork(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
