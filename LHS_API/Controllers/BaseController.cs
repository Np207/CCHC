using LHS_API.Interfaces;
using LHS_API.Repositories;
using LHS_Client;
using LHS_WEBAPP_v1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LHS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TService> : ControllerBase,IController<TModel> 
    where TModel : class
    where TService : IService<TModel>
    {
        protected readonly TService _service;
        protected readonly JwtHelper _jwtHelper;

        public BaseController(TService service, JwtHelper jwtHelper)
        {
            _service = service;
            _jwtHelper = jwtHelper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.CallService_GetAll());
        }

        [HttpGet("GetOne/{id}")]
        public async Task<IActionResult> GetOne(string id)
        {
            return Ok(await _service.CallService_GetOneRow(id));
        }

        [HttpPost("AddOne")]
        public async Task<IActionResult> AddOne(TModel entity)
        {
            await _service.CallService_Create(entity);
            return Ok();
        }

        [HttpPut("EditOne")]
        public async Task<IActionResult> EditOne(TModel entity, string id)
        {
            await _service.CallService_Update(id, entity);
            return Ok();
        }

        [HttpDelete("RemoveOne/{id}")]
        public async Task<IActionResult> RemoveOne(string id)
        {
            await _service.CallService_Delete(id);
            return Ok();
        }
    }
}
