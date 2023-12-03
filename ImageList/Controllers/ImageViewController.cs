using ImageList.Data;
using ImageList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.WindowsAzure.Storage.Auth;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ImageList.Controllers
{
    public class ImageViewController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ImageViewController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ImageView> image;
            image = _db.IamgeView;
            return View(image);
        }

        //GET
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Add(ImageView obj)
        { 
            FileInfo info = new FileInfo(obj.Path);
            obj.Extension = info.Extension;
            obj.Name = info.Name;
            obj.Size = 0;
            obj.CreationDate = info.CreationTime.ToString();
            _db.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
