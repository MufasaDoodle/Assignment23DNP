using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment3_WebService.Models;
using Assignment3_WebService.Data;
using System.Data;

namespace Assignment3_WebService.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class AdultsController : ControllerBase
    {
        IPersonService personService;

        public AdultsController(IPersonService personService)
        {
            this.personService = personService;
        }

        /// <summary>
        /// Retrieves adults matching paramters
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults
            (
                [FromQuery] string firstName,
                [FromQuery] string lastName,
                [FromQuery] int? age,
                [FromQuery] int? id
            )
        {
            try
            {
                IList<Adult> adults = await personService.GetPeople(firstName, lastName, age, id);
                return Ok(adults);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Deletes an adult with a given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id)
        {
            try
            {
                await personService.RemovePerson(id);
                return Ok();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Adds an adult with the given Adult object
        /// </summary>
        /// <param name="adult"></param>
        /// <returns></returns>
        /// <response code="201">Returns the created adult</response>
        /// <response code="400">The adult is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Adult added = await personService.AddPerson(adult);
                return Created($"/{added.Id}", added);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Updates an adult from the given Adult object
        /// </summary>
        /// <param name="adult"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdult([FromBody] Adult adult)
        {
            try
            {
                Adult updatedAdult = await personService.UpdatePerson(adult);
                return Ok(updatedAdult);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
