using GymAPI.ModelsDTO;
using GymAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [Route("api/gym/{trainingId}/exercise")]
    [ApiController]
    [Authorize(Roles ="Admin.Manager")]
    public class ExerciseController: ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int trainingId)
        {
            _exerciseService.RemoveAll(trainingId);
            return NoContent();
        }


        [HttpDelete("{exerciseId}")]
        public ActionResult DeleteById([FromRoute] int trainingId, [FromRoute] int exerciseId)
        {
            _exerciseService.Remove(trainingId, exerciseId);
            return NoContent();
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int trainingId, [FromBody] CreateExerciseDto exercise)
        {
            var newExerciseId= _exerciseService.Create(trainingId, exercise);

            return Created($"api/gym/{trainingId}/exercise/{newExerciseId}", null);
        }

        [AllowAnonymous]
        [HttpGet("{exerciseId}")]
        public ActionResult<ExerciseDto> Get([FromRoute] int trainingId, [FromRoute] int exerciseId)
        {
            var exercise= _exerciseService.GetById(trainingId, exerciseId);
            return Ok(exercise);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<ExerciseDto>> Get([FromRoute] int trainingId)
        {
            var exercises = _exerciseService.GetAll(trainingId);
            return Ok(exercises);
        }


    }
}
