using celticsTech.DTOs.Request;
using celticsTech.DTOs.Response;
using celticsTech.Enums;
using celticsTech.Exceptions;
using celticsTech.Models;
using celticsTech.Repositories;

namespace celticsTech.Services
{
    public class PetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<PetResponseDTO> CreateAsync(PetRequestDTO dto)
        {
            var pet = new Pet
            {
                Name = dto.Name,
                Species = dto.Species,
                Breed = dto.Breed,
                AgeType = dto.AgeType,
                Age = dto.Age,
                Weight = dto.Weight,
                PetSize = dto.PetSize
            };

            var savedPet = await _petRepository.CreateAsync(pet);
            return ToResponse(savedPet);
        }

        public async Task<List<PetResponseDTO>> FindAllAsync()
        {
            var pets = await _petRepository.FindAllAsync();
            return pets.Select(ToResponse).ToList();
        }

        public async Task<PetResponseDTO> FindByIdAsync(long id)
        {
            var pet = await _petRepository.FindByIdAsync(id)
                ?? throw new ApiException("Pet não encontrado", 404);

            return ToResponse(pet);
        }

        public async Task<List<PetResponseDTO>> SearchAsync(string? species, PetSizeEnum? petSize)
        {
            var pets = await _petRepository.SearchAsync(species, petSize);
            return pets.Select(ToResponse).ToList();
        }

        public async Task<PetResponseDTO> UpdateAsync(long id, PetRequestDTO dto)
        {
            var pet = await _petRepository.FindByIdAsync(id)
                ?? throw new ApiException("Pet não encontrado", 404);

            pet.Name = dto.Name;
            pet.Species = dto.Species;
            pet.Breed = dto.Breed;
            pet.AgeType = dto.AgeType;
            pet.Age = dto.Age;
            pet.Weight = dto.Weight;
            pet.PetSize = dto.PetSize;

            await _petRepository.UpdateAsync(pet);
            return ToResponse(pet);
        }

        public async Task DeleteAsync(long id)
        {
            var pet = await _petRepository.FindByIdAsync(id)
                ?? throw new ApiException("Pet não encontrado", 404);

            await _petRepository.DeleteAsync(pet);
        }

        private static PetResponseDTO ToResponse(Pet pet)
        {
            return new PetResponseDTO
            {
                Id = pet.Id,
                Name = pet.Name,
                Species = pet.Species,
                Breed = pet.Breed,
                AgeType = pet.AgeType,
                Age = pet.Age,
                Weight = pet.Weight,
                PetSize = pet.PetSize
            };
        }
    }
}