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
        [ProducesResponseType(typeof(List<GetFolderResponse>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var folders = await _folderManager.GetAllAsync();

            return Ok(folders);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetFolderResponse), 200)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var folder = await _folderManager.GetAsync(id);

            return Ok(folder);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(GetFolderTreeResponse), 200)]
        public async Task<IActionResult> Tree([FromQuery] Guid id)
        {
            var folderTree = await _folderManager.GetTreeAsync(id);

            return Ok(folderTree);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        public async Task<IActionResult> Create([FromBody, Required] CreateFolderRequest request)
        {
            var folderId = await _folderManager.CreateAsync(request);

            return Ok(folderId);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update([FromBody, Required] UpdateFolderRequest request)
        {
            await _folderManager.UpdateAsync(request);

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete([FromBody, Required] DeleteFolderRequest request)
        {
            await _folderManager.DeleteAsync(request);

            return Ok();
        }
    }
}
