using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SwaggerDemo.Api.Services
{
    public class PetService : IPetService
    {
        private static List<Pet> _PetDb;

        static PetService()
        {
            _PetDb = new List<Pet>()
            {
                new Pet() { Id = 1, Name = "doggie",
                    Status = PetStatus.Available,
                    PhotoUrls = new List<string>() { "https://www.pexels.com/photo/black-and-brown-short-haired-puppy-in-cup-39317/" },
                    Category = new Category() { Id = 1, Name = "dogs"},
                    Tags = new List<Tag>() { new Tag() { Id = 1, Name = "baby" } }                     
                },
                new Pet() { Id = 2, Name = "Super Cat",
                    Status = PetStatus.Available,
                    PhotoUrls = new List<string>() { "https://www.pexels.com/photo/grey-and-white-short-fur-cat-104827/" },
                    Category = new Category() { Id = 2, Name = "cats"},
                    Tags = new List<Tag>() { new Tag() { Id = 1, Name = "baby" } }
                },
                new Pet() { Id = 3, Name = "Super Lion",
                    Status = PetStatus.Available,
                    PhotoUrls = new List<string>() { "https://www.pexels.com/photo/animal-africa-zoo-lion-33045/" },
                    Category = new Category() { Id = 3, Name = "lion"},
                    Tags = new List<Tag>() { new Tag() { Id = 1, Name = "baby" } }
                },
                new Pet() { Id = 3, Name = "Big Smile",
                    Status = PetStatus.Available,
                    PhotoUrls = new List<string>() { " https://www.pexels.com/photo/black-chimpanzee-smiling-50582/" },
                    Category = new Category() { Id = 3, Name = "monkey"},
                    Tags = new List<Tag>() { new Tag() { Id = 1, Name = "smile" } }
                }         
            };
        }

        public async Task AddPetAsync(Pet body)
        {
            _PetDb.Add(body);
            await Task.CompletedTask;
        }

        public async Task UpdatePetAsync(Pet body)
        {
            var pet =_PetDb.Find(p => p.Id == body.Id);
            pet.Name = body.Name;
            pet.PhotoUrls = body.PhotoUrls;
            pet.Status = body.Status;
            pet.Tags = body.Tags;
            pet.Category = body.Category;

            await Task.CompletedTask;
        }

        public async Task<List<Pet>> FindPetsByStatusAsync(IEnumerable<Anonymous> status)
        {
            var pets = _PetDb.FindAll(p => p.Status.HasValue && (
                p.Status.Value == PetStatus.Available || p.Status.Value == PetStatus.Pending || p.Status.Value == PetStatus.Sold));

            await Task.CompletedTask;
            return pets;            
        }

        public async Task<Pet> GetPetByIdAsync(long petId)
        {
            var pet = _PetDb.Find(p => p.Id == petId);
            await Task.CompletedTask;
            return pet;
        }

        public async Task UpdatePetWithFormAsync(long petId, string name, PetStatus status)
        {            
            var pet = _PetDb.Find(p => p.Id == petId && p.Name == name && p.Status == status);
            await Task.CompletedTask;
        }

        public async Task DeletePetAsync(string api_key, long petId)
        {
            var petToRemove = _PetDb.Where(p => p.Id == petId).First();
            _PetDb.Remove(petToRemove);
            await Task.CompletedTask;
        }

        public async Task<ApiResponse> UploadFileAsync(long petId, string additionalMetadata, FileParameter file)
        {
            await Task.CompletedTask;
            return null;
        }

        public async Task<List<Pet>> FindPetsByTagsAsync(IEnumerable<string> tags)
        {
            await Task.CompletedTask;
            return null;
        }
    }
}
