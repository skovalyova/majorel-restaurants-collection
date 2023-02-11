using Majorel.RestaurantsCollection.Application.Commands.CreateRestaurant;
using Majorel.RestaurantsCollection.Application.Commands.DeleteRestaurant;
using Majorel.RestaurantsCollection.Application.Commands.UpdateRestaurantRating;
using Majorel.RestaurantsCollection.Application.Dto;
using Majorel.RestaurantsCollection.Application.Queries.GetAllRestaurants;
using Majorel.RestaurantsCollection.Application.Queries.GetRestaurantById;
using Majorel.RestaurantsCollection.Application.Queries.GetRestaurantsByCity;
using Majorel.RestaurantsCollection.Application.Queries.GetRestaurantsSortedByRating;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Majorel.RestaurantsCollection.API.Controllers;

[ApiController]
[Route("restaurant")]
[Produces("application/json")]
[DisplayName("Restaurants")]
public class RestaurantController : ControllerBase
{
    private readonly IMediator _mediator;

    public RestaurantController(IMediator mediator)
    {
        ArgumentNullException.ThrowIfNull(mediator);

        _mediator = mediator;
    }

    /// <summary>
    /// Creates a restaurant.
    /// </summary>
    /// <param name="restaurant"></param>
    /// <returns>A newly created restaurant</returns>
    /// <response code="200">Request validation has failed</response>
    /// <response code="500">Internal server error</response>
    [HttpPost]
    [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody]CreateRestaurantCommand restaurant)
    {
        var createdRestaurant = await _mediator.Send(restaurant, HttpContext.RequestAborted);

        return CreatedAtAction(nameof(GetById), new { id = createdRestaurant.Id }, createdRestaurant);
    }

    /// <summary>
    /// Gets a collection of restaurants.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<RestaurantDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await _mediator.Send(new GetAllRestaurantsQuery(), HttpContext.RequestAborted);

        return Ok(restaurants);
    }

    [HttpGet("sort")]
    [ProducesResponseType(typeof(IReadOnlyCollection<RestaurantDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetSortedByRating()
    {
        var restaurants = await _mediator.Send(new GetRestaurantsSortedByRatingQuery(), HttpContext.RequestAborted);

        return Ok(restaurants);
    }

    [HttpGet("query")]
    [ProducesResponseType(typeof(IReadOnlyCollection<RestaurantDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByCity([FromQuery]string city)
    {
        var restaurants = await _mediator.Send(new GetRestaurantsByCityQuery(city), HttpContext.RequestAborted);

        return Ok(restaurants);
    }

    /// <summary>
    /// Gets a specific restaurant by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await _mediator.Send(new GetRestaurantByIdQuery(id), HttpContext.RequestAborted);

        return Ok(restaurant);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateRating([FromRoute]int id, [FromBody]UpdateRestaurantRatingCommand restaurantRating)
    {
        if (id != restaurantRating.Id)
        {
            return BadRequest("Restaurant Id must be the same");
        }

        var restaurant = await _mediator.Send(restaurantRating, HttpContext.RequestAborted);

        return Ok(restaurant);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        await _mediator.Send(new DeleteRestaurantCommand(id), HttpContext.RequestAborted);

        return Ok();
    }
}
