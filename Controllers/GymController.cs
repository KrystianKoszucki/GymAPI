using GymAPI.Models;
using GymAPI.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using GymAPI.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GymAPI.Controllers
{
    [Route("api/gym")]
    [ApiController]
    [Authorize(Roles ="Admin,Manager")]

    public class GymController : ControllerBase
    {
        private readonly IGymService _gymService;

        public GymController(IGymService gymService)
        {
            _gymService = gymService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateTrainingDto training, [FromRoute] int id)
        {
            _gymService.Update(id, training);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<TrainingDto>> GetAll()
        {
            var trainingsDto= _gymService.GetAll();

            return Ok(trainingsDto);

        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<TrainingDto> GetById([FromRoute] int id)
        {
            var training = _gymService.GetById(id);

            return Ok(training);
        }

        [HttpPost]
        public ActionResult CreateTraining([FromBody] CreateTrainingDto model)
        {
            var id = _gymService.Create(model);
            
            return Created($"/api/gym/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult<TrainingDto> DeleteTraining([FromRoute] int id)
        {
            _gymService.DeleteById(id);

            return NoContent();
        }
    }
}
