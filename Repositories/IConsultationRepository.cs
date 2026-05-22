using celticsTech.Models;

namespace celticsTech.Repositories
{
    public interface IConsultationRepository
    {
        Task<List<Consultation>> FindAllAsync();
        Task<Consultation?> FindByIdAsync(long id);
        Task<Consultation> CreateAsync(Consultation consultation);
        Task UpdateAsync(Consultation consultation);
        Task DeleteAsync(Consultation consultation);
    }
}