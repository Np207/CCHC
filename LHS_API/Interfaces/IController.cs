using Microsoft.AspNetCore.Mvc;

namespace LHS_WEBAPP_v1.Interfaces
{
    public interface IController<T> where T : class
    {
        [HttpGet("GetAll")]
        Task<IActionResult> GetAll();

        [HttpGet("GetOne/{id}")]
        Task<IActionResult> GetOne(string id);

        [HttpPost("AddOne")]
        Task<IActionResult> AddOne(T entity);

        [HttpPut("EditOne")]
        Task<IActionResult> EditOne(T entity, string id);

        [HttpDelete("RemoveOne/{id}")]
        Task<IActionResult> RemoveOne(string id);
    }
}
