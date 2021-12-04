using Api.Errors;
using Application.Commands.Exercises.CreateExercise;
using Application.Commands.Exercises.UpdateExercise;
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

            if (exercises == null)
                return NotFound(new ApiErrorResponse(404));

            return Ok(exercises);
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseDetailsDto>> Create(CreateExerciseDto createExerciseDto)
        {
            var command = new CreateExerciseCommand(createExerciseDto);
            await _mediator.Send(command);

            if (command.Success == false)
                return BadRequest(new ApiValidationErrorResponse(command.Errors));

            return Ok(command.Exercise);
        }

        [HttpPut]
        public async Task<ActionResult<ExerciseDetailsDto>> Update(UpdateExerciseDto updateExerciseDto)
        {
            var command = new UpdateExerciseCommand(updateExerciseDto);
            await _mediator.Send(command);

            if (command?.Success == false)
                return BadRequest(new ApiValidationErrorResponse(command.Errors));

            return Ok(command.Exercise);
        }
    }
}
