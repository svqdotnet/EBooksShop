using Microsoft.AspNetCore.Authorization;
using SwaggerDemo.Api.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SwaggerDemo.Api
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="SwaggerDemo.Api.IController" />
    public partial class CrossController : IApiController
    {
        protected readonly IPetService _srvPet;
        protected readonly IUserService _srvUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="CrossController"/> class.
        /// </summary>
        /// <param name="srvPet">The SRV pet.</param>
        /// <param name="srvUser">The SRV user.</param>
        public CrossController(IPetService srvPet, IUserService srvUser)
        {
            _srvPet = srvPet;
            _srvUser = srvUser;
        }

        #region Pet

        /// <summary>
        /// Deletes a pet
        /// </summary>
        /// <param name="api_key"></param>
        /// <param name="petId">Pet id to delete</param>
        /// <returns></returns>
        [Authorize]
        public async Task PetDeleteAsync(string api_key, long petId)
        {
            await _srvPet?.DeletePetAsync(api_key, petId);
        }

        /// <summary>
        /// Find pet by ID
        /// </summary>
        /// <param name="petId">ID of pet to return</param>
        /// <returns>
        /// successful operation
        /// </returns>
        [Authorize]
        public async Task<Pet> PetGetAsync(long petId)
        {
            return await _srvPet?.GetPetByIdAsync(petId);
        }

        /// <summary>
        /// Add a new pet to the store
        /// </summary>
        /// <param name="body">Pet object that needs to be added to the store</param>
        /// <returns></returns>
        [Authorize]
        public async Task PetPostAsync(Pet body)
        {
            await _srvPet?.AddPetAsync(body);
        }

        /// <summary>
        /// Updates a pet in the store with form data
        /// </summary>
        /// <param name="petId">ID of pet that needs to be updated</param>
        /// <param name="name">Updated name of the pet</param>
        /// <param name="status">Updated status of the pet</param>
        /// <returns></returns>
        [Authorize]
        public async Task PetPostAsync(long petId, string name, string status)
        {
            if (Enum.TryParse(status, out PetStatus petStatus))
                await _srvPet?.UpdatePetWithFormAsync(petId, name, petStatus);

            // TODO: throw new Exception ("400");
        }

        /// <summary>
        /// Update an existing pet
        /// </summary>
        /// <param name="body">Pet object that needs to be added to the store</param>
        /// <returns></returns>
        [Authorize]
        public async Task PetPutAsync(Pet body)
        {
            await _srvPet?.UpdatePetAsync(body);
        }

        #endregion


        #region User

        public async Task UserDeleteAsync(string username)
        {
            await _srvUser?.DeleteUserAsync(username);            
        }

        public Task<User> UserGetAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task UserPostAsync(User body)
        {

            throw new NotImplementedException();
        }

        public Task UserPutAsync(string username, User body)
        {

            throw new NotImplementedException();
        }

        #endregion  
    }
}