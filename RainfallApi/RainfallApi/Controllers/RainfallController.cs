using Microsoft.AspNetCore.Mvc;

namespace RainfallApi.Controllers
{
    /// <summary>
    /// Controller responsible for handling the validations of created storefront tokens in BigCommerce frontend
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class RainfallController : Controller
    {

        /// <summary>
        /// Generate JWT
        /// </summary>
        /// <exception cref="Exception">Invalid email address</exception>
        [HttpGet("id/{stationId}/readings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Consumes("application/json")]
        public string Get()
        {
            return "success";
        }

    }
}
