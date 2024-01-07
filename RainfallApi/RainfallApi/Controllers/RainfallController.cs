using DotNetEnv;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RainfallApi.Application.Interfaces;
using RainfallApi.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace RainfallApi.Controllers
{
    /// <summary>
    /// Operations relating to rainfall
    /// </summary>
    [Route("rainfall")] 
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class RainfallController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Initializes a new instance of the <see cref="RainfallController"/> controller.
        /// </summary>
        public RainfallController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        /// <summary>
        /// Get rainfall readings by station Id
        /// </summary>
        /// <param name="stationId">The id of the reading station</param>
        /// <param name="count">The number of readings to return</param>
        /// <returns>Retrieve the latest readings for the specified stationId.</returns>
        /// <exception cref="Exception">Invalid email address</exception>
        [HttpGet("id/{stationId}/readings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<GetRainfallReadingResponse> Get([Range(1, 100, ErrorMessage = "Value for {stationId} must be between {1} and {100}.")] [Required(ErrorMessage = "stationId is required")] int stationId, int count = 10)
        {
            return await _unitOfWork.Rainfall.Get(stationId, count);
        }
    }
}
