using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemo.Api.Services
{
    public interface IPetService
    {
        Task AddPetAsync(Pet body);
        Task UpdatePetAsync(Pet body);
        Task<List<Pet>> FindPetsByStatusAsync(IEnumerable<Anonymous> status);
        Task<Pet> GetPetByIdAsync(long petId);
        Task UpdatePetWithFormAsync(long petId, string name, PetStatus status);
        Task DeletePetAsync(string api_key, long petId);
        Task<ApiResponse> UploadFileAsync(long petId, string additionalMetadata, FileParameter file);
        Task<List<Pet>> FindPetsByTagsAsync(IEnumerable<string> tags);
    }
}
