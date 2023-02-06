using Microsoft.EntityFrameworkCore;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Respositories;
using TestAPI_.Models;

namespace TestAPI_.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<City>> GetAll()
        {
            return await _context.City.OrderBy(c => c.Id).ToListAsync();
        }


        public async Task<City> GetById(int id)
        {
            return await _context.City.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Response> Create(City city)
        {
            var countryId = await _context.Country.FindAsync(city.CountryId);
            if (countryId == null)
            {
                return new Response(1, "Unable to Create City", DateTime.Now);
            }
            else
            {
                await _context.City.AddAsync(city);
                await _context.SaveChangesAsync();
                return new Response(0, "City Created Successfully", DateTime.Now);
            }
        }

        public async Task<Response> Update(City city)
        {
            if (_context.City.Any(c => c.Id == city.Id && c.CountryId == city.CountryId))
            {
                _context.City.Update(city);
                await _context.SaveChangesAsync();
                return new Response(0, "City Updated Successfully", DateTime.Now);
            }
            else
            {
                return new Response(1, "Unable to Update City", DateTime.Now);
            }
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _context.City.FindAsync(id);
            if (result != null)
            {
                _context.City.Remove(result);
                await _context.SaveChangesAsync();
                return new Response(0, "City Deleted Successfully", DateTime.Now);
            }
            else
            {
                return new Response(1, "Unable to Delete City", DateTime.Now);
            }
        }
    }
}
