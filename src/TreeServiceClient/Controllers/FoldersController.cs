using Microsoft.AspNetCore.Mvc;
using TreeServiceClient.HttpClients.Interfaces;
using TreeServiceClient.Models.Requests.FolderModels;

namespace TreeServiceClient.Controllers
{
    public class FoldersController : Controller
    {
        private readonly IFoldersApiHttpClient _foldersHttpClient;

        public FoldersController(IFoldersApiHttpClient foldersHttpClient)
        {
            _foldersHttpClient = foldersHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            var folders = await _foldersHttpClient.GetAllAsync();

            return View(folders);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var folder = await _foldersHttpClient.GetAsync(id);

            return View(folder);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFolderRequest request)
        {
            var response = await _foldersHttpClient.CreateAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var folder = await _foldersHttpClient.GetAsync(id);

            return View(folder);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateFolderRequest request)
        {
            var response = await _foldersHttpClient.EditAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

        public IActionResult Delete(Guid id) 
        {
            return View(new DeleteFolderRequest { Id = id }); 
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteConfirmed(DeleteFolderRequest request)
        {
            var response = await _foldersHttpClient.DeleteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

        public async Task<IActionResult> Tree(Guid id)
        {
            var folderTree = await _foldersHttpClient.GetTreeAsync(id);

            return View(folderTree);
        }
    }
}
