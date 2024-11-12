using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TreeService.Models.Requests.FolderModels;
using TreeService.Models.Responses.FolderModels;
using TreeService.Services.Interfaces;

namespace TreeService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoldersController : ControllerBase
    {
        private readonly IFolderManager _folderManager;

        public FoldersController(IFolderManager folderManager)
        {
            _folderManager = folderManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetFolderResponse), 200)]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var client = await _folderManager.GetAsync(id);

            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> Create([FromBody, Required] CreateFolderRequest request)
        {
            var clientId = await _folderManager.CreateAsync(request);

            return Ok(clientId);
        }
    }
}
