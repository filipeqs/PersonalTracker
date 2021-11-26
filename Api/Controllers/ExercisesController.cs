using Application.Dtos.Exercise;
using Application.Queries.Exercises.GetExerciseDetailsById;
using Application.Queries.Exercises.GetExerciseList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExercisesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseListDto>>> GetAll()
        {
            var query = new GetExerciseListQuery();
            var exercises = await _mediator.Send(query);
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseDetailsDto>> GetById(int id)
        {
            var query = new GetExerciseDetailsByIdQuery(id);
            var exercises = await _mediator.Send(query);
            return (exercises);
        }
    }
}
