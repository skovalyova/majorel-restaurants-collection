using AutoMapper;
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
    private readonly IMapper _mapper;

    public RestaurantController(IMediator mediator, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        ArgumentNullException.ThrowIfNull(mapper);

        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a restaurant.
    /// </summary>
    /// <returns>A newly created restaurant</returns>
    /// <response code="201">Success</response>
    /// <response code="400">Request validation has failed</response>
    /// <response code="500">Internal server error</response>
    [HttpPost]
    [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateRestaurantDto restaurant)
    {
        var command = _mapper.Map<CreateRestaurantCommand>(restaurant);
        var createdRestaurant = await _mediator.Send(command, HttpContext.RequestAborted);

        return CreatedAtAction(nameof(GetById), new { id = createdRestaurant.Id }, createdRestaurant);
    }

    /// <summary>
    /// Gets a collection of all restaurants.
    /// </summary>
    /// <returns>All restaurants ordered by ID</returns>
    /// <response code="200">Success</response>
    /// <response code="400">Request validation has failed</response>
    /// <response code="500">Internal server error</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<RestaurantDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await _mediator.Send(new GetAllRestaurantsQuery(), HttpContext.RequestAborted);

        return Ok(restaurants);
    }

    /// <summary>
    /// Gets a collection of all restaurants sorted by average rating.
    /// </summary>
    /// <returns>All restaurants ordered by average rating</returns>
    /// <response code="200">Success</response>
    /// <response code="400">Request validation has failed</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("sort")]
    [ProducesResponseType(typeof(IReadOnlyCollection<RestaurantDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetSortedByRating()
    {
        var restaurants = await _mediator.Send(new GetRestaurantsSortedByRatingQuery(), HttpContext.RequestAborted);

        return Ok(restaurants);
    }

    /// <summary>
    /// Gets a collection of restaurants in a particular city.
    /// </summary>
    /// <returns>All restaurants in a particular city</returns>
    /// <param name="city" example="Miamy">City in which the restaurants are located. Required, max length = 200 chars</param>
    /// <response code="200">Success</response>
    /// <response code="400">Request validation has failed</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("query")]
    [ProducesResponseType(typeof(IReadOnlyCollection<RestaurantDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByCity([FromQuery] string city)
    {
        var restaurants = await _mediator.Send(new GetRestaurantsByCityQuery(city), HttpContext.RequestAborted);

        return Ok(restaurants);
    }

    /// <summary>
    /// Gets a specific restaurant.
    /// </summary>
    /// <returns>A restaurant</returns>
    /// <param name="id" example="1">Unique ID of the restaurant generated by the system. Required, positive non-zero number</param>
    /// <response code="200">Success</response>
    /// <response code="400">Request validation has failed</response>
    /// <response code="404">Resource is not found</response>
    /// <response code="500">Internal server error</response>
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

    /// <summary>
    /// Updates average rating and votes for a specific restaurant.
    /// </summary>
    /// <returns>An updated restaurant</returns>
    /// <param name="id" example="1">Unique ID of the restaurant generated by the system. Required, positive non-zero number</param>
    /// <param name="restaurantRating">Updated rating details. Required</param>
    /// <response code="200">Success</response>
    /// <response code="400">Request validation has failed</response>
    /// <response code="404">Resource is not found</response>
    /// <response code="500">Internal server error</response>
    [HttpPatch("{id:int}")]
    [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateRating([FromRoute] int id, [FromBody] UpdateRestaurantRatingDto restaurantRating)
    {
        var command = _mapper.Map<UpdateRestaurantRatingCommand>(restaurantRating) with { Id = id };
        var restaurant = await _mediator.Send(command, HttpContext.RequestAborted);

        return Ok(restaurant);
    }

    /// <summary>
    /// Deletes a specific restaurant.
    /// </summary>
    /// <param name="id" example="1">Unique ID of the restaurant generated by the system. Required, positive non-zero number</param>
    /// <response code="200">Success</response>
    /// <response code="400">Request validation has failed</response>
    /// <response code="404">Resource is not found</response>
    /// <response code="500">Internal server error</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new DeleteRestaurantCommand(id), HttpContext.RequestAborted);

        return Ok();
    }
}
