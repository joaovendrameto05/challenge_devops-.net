using celticsTech.Enums;
using celticsTech.Models;

namespace celticsTech.Repositories
{
    public interface IVeterinarianRepository
    {
        Task<List<Veterinarian>> FindAllAsync();
        Task<Veterinarian?> FindByIdAsync(long id);
        Task<List<Veterinarian>> SearchByNameAsync(string name);
        Task<List<Veterinarian>> SearchBySpecialtyAsync(SpecialtyEnum specialty);
        Task<bool> ExistsByEmailAsync(string email);
        Task<bool> ExistsByCrmvAsync(string crmv);
        Task<Veterinarian> CreateAsync(Veterinarian veterinarian);
        Task UpdateAsync(Veterinarian veterinarian);
        Task DeleteAsync(Veterinarian veterinarian);
    }
}