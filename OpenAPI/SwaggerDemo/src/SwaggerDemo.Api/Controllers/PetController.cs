using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Api.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemo.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="SwaggerDemo.Api.IPetApiController" />
    /// <seealso cref="SwaggerDemo.Api.IPetApiController" />
    [Authorize]
    public partial class PetController : CrossController, IPetApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PetController"/> class.
        /// </summary>
        /// <param name="srvPet">The SRV pet.</param>
        public PetController(IPetService srvPet) : base(srvPet, null)
        {
        }

        /// <summary>
        /// Finds Pets by status
        /// </summary>
        /// <param name="status">Status values that need to be considered for filter</param>
        /// <returns>
        /// successful operation
        /// </returns>
        public async Task<List<Pet>> FindByStatusAsync(IEnumerable<Anonymous> status)
        {

            //var x = new JsonResult(from c in User.Claims select new { c.Type, c.Value });

            return await _srvPet.FindPetsByStatusAsync(status);
        }

        /// <summary>
        /// Finds Pets by tags
        /// </summary>
        /// <param name="tags">Tags to filter by</param>
        /// <returns>
        /// successful operation
        /// </returns>
        public async Task<List<Pet>> FindByTagsAsync(IEnumerable<string> tags)
        {
            return await _srvPet.FindPetsByTagsAsync(tags);
        }

        /// <summary>
        /// uploads an image
        /// </summary>
        /// <param name="petId">ID of pet to update</param>
        /// <param name="additionalMetadata">Additional data to pass to server</param>
        /// <param name="file">file to upload</param>
        /// <returns>
        /// successful operation
        /// </returns>
        public async Task<ApiResponse> UploadImageAsync(long petId, string additionalMetadata, FileParameter file)
        {
            return await _srvPet.UploadFileAsync(petId, additionalMetadata, file);
        }
    }
}
