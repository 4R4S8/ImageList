using ImageList.Data;
using ImageList.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageList.Controllers
{
    public class ImageViewController: Controller
    {
        private readonly ApplicationDbContext _db;

        public ImageViewController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ImageView> objImageList = _db.IamgeView.ToList();
            return View(objImageList);
        }
    }
}
