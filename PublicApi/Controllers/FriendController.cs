using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicApi.Entities;
using PublicApi.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PublicApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class FriendController : ControllerBase
    {
       
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        /// <summary>
        /// Get a friend.
        /// </summary>
        /// <param name="id">Id of friend.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/friends/{id}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute][Required] int id)
        {
            var friend = await _friendService.GetByIdAsync(id);

            if (friend == null)
                return NotFound();

            return Ok(await _friendService.GetByIdAsync(id));
        }

        /// <summary>
        /// Get the list of all friends.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/friends")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _friendService.ListAllAsync());
        }

        /// <summary>
        /// Add a friend.
        /// </summary>
        /// <remarks></remarks>
        /// <param name="friend">New friend.</param>
        /// <returns>A newly created Friend.</returns>
        [HttpPost]
        [Route("/api/friends")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] Friend friend)
        {
            await _friendService.AddAsync(friend);

            return CreatedAtRoute("GetById", new { id = friend.Id }, friend);
        }

        /// <summary>
        /// Update a friend.
        /// </summary>
        /// <param name="id">Id of friend.</param>
        /// <param name="friend">Updated friend.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("/api/friends/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute][Required] int id, [FromBody] Friend friend)
        {
            var friendToUpdate = await _friendService.GetByIdAsync(id);

            if (friendToUpdate == null)
                return NotFound();

            friendToUpdate.UpdateDetails(friend.FirstName, friend.LastName);

            await _friendService.UpdateAsync(friendToUpdate);

            return Ok(friendToUpdate);
        }

        /// <summary>
        /// Delete a friend.
        /// </summary>
        /// <param name="id">Id of friend.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/api/friends/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute][Required] int id)
        {
            var friend = await _friendService.GetByIdAsync(id);

            if (friend == null)
                return NotFound();

            await _friendService.DeleteAsync(friend);

            return NoContent();
        }
    }
}
