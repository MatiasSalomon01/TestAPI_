using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Respositories;
using TestAPI_.Models;
using TestAPI_.Models.Country;

namespace TestAPI_.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<CountryViewModel>> GetAll()
        {
            return await _context.Country
                .OrderBy(c => c.Id)
                .Include(c => c.Cities)
                .ProjectTo<CountryViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<CountryViewModel> GetById(int id)
        {
            return await _context.Country
                .Where(c => c.Id == id)
                .ProjectTo<CountryViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
        public async Task<Response> Create(Country country)
        {
            await _context.Country.AddAsync(country);
            await _context.SaveChangesAsync();
            return new Response(0, "Country Created Successfully", DateTime.Now);
        }

        public async Task<Response> Update(int id, Country country)
        {
            var c = await _context.Country.FindAsync(id);
            if (c != null)
            {
                c.Name = country.Name;
                _context.Country.Update(c);
                await _context.SaveChangesAsync();
                return new Response(0, "Country Updated Successfully", DateTime.Now);
            }
            else
            {
                return new Response(1, "Unable to Update Country", DateTime.Now);
            }
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
