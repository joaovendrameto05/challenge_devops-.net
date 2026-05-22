using celticsTech.Data;
using celticsTech.Enums;
using celticsTech.Models;
using Microsoft.EntityFrameworkCore;

namespace celticsTech.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly AppDbContext _context;

        public PetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pet>> FindAllAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet?> FindByIdAsync(long id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task<List<Pet>> SearchAsync(string? species, PetSizeEnum? petSize)
        {
            var query = _context.Pets.AsQueryable();

            if (!string.IsNullOrWhiteSpace(species))
                query = query.Where(p => p.Species.ToLower().Contains(species.ToLower()));

            if (petSize.HasValue)
                query = query.Where(p => p.PetSize == petSize.Value);

            return await query.ToListAsync();
        }

        public async Task<Pet> CreateAsync(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task UpdateAsync(Pet pet)
        {
            _context.Pets.Update(pet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pet pet)
        {
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }
    }
}