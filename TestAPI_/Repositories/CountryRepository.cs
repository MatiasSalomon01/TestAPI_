using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Respositories;
using TestAPI_.Models;

namespace TestAPI_.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Country>> GetAll()
        {
            return await _context.Country.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<Country> GetById(int id)
        {
            return await _context.Country.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Response> Create(Country country)
        {
            await _context.Country.AddAsync(country);
            await _context.SaveChangesAsync();
            return new Response(0, "Country Created Successfully", DateTime.Now);
        }

        public async Task<Response> Update(Country country)
        {
            _context.Country.Update(country);
            await _context.SaveChangesAsync();
            return new Response(0, "Country Updated Successfully", DateTime.Now);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _context.Country.FindAsync(id);
            if (result != null)
            {
                _context.Country.Remove(result);
                await _context.SaveChangesAsync();
                return new Response(0, "Country Deleted Successfully", DateTime.Now);
            }
            else
            {
                return new Response(1, "Unable to Delete Country", DateTime.Now);
            }
        }
    }
}
