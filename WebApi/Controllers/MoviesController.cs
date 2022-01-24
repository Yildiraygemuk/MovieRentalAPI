using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        /// <summary>
        /// Gets the movie list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            var result = _movieService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        /// <summary>
        /// Returns the movie with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _movieService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        /// <summary>
        /// Returns the movies of the given category with the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetListByCategory/{id}")]
        public IActionResult GetListByCategory(Guid id)
        {
            var result = _movieService.GetListByCategory(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        /// <summary>
        /// Performs category addition
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(MovieDto movie)
        {
            var result = _movieService.Add(movie);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        /// <summary>
        /// Performs movie rentals
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost("RentTheMovie")]
        public IActionResult RentTheMovie(Guid id)
        {
            var result = _movieService.RentTheMovie(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        /// <summary>
        /// Cancels movie rental
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost("CancelRentTheMovie")]
        public IActionResult CancelRentTheMovie(Guid id)
        {
            var result = _movieService.CancelRentTheMovie(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        /// <summary>
        /// Performs movie update
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(MoviePutDto movie)
        {
            var result = _movieService.Update(movie);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        /// <summary>
        /// Deletes the movie with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var result = _movieService.Delete(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
