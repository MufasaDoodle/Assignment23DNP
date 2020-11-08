using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_WebService.Data;
using Assignment3_WebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3_WebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Retrieves a user with the given username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<User>> GetUser([FromQuery] string userName)
        {
            try
            {
                User user = await userService.ValidateUserAsync(userName);
                return Ok(user);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Add a user from the given User object
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="201">Returns the created user</response>
        /// <response code="400">The user is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                User added = await userService.AddUserAsync(user);
                return Created($"/{added.UserID}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Update a user from the given User object
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User user)
        {
            try
            {
                User updatedUser = await userService.UpdateUserAsync(user);
                return Ok(updatedUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
