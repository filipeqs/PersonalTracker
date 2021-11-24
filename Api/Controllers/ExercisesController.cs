using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repositories.Contracts;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExercisesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> Index()
        {
            return Ok(await _unitOfWork.ExerciseRepository.GetAllAsync());
        }
    }
}
