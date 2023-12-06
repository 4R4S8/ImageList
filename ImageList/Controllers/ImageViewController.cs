using ImageList.Data;
using ImageList.Models;
using ImageList.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Collections.Generic;
using System.Drawing.Text;
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
        //GET
        [HttpGet]
        public IActionResult Index(string id)
        {
            ViewModel vmm = new ViewModel();
            vmm.ImageListCollection = _db.IamgeView.ToList();
            if (id != null)
            {
                Guid guid = new Guid(id);

                var result = _db.IamgeView
                    .Where(e => e.GUID == guid)
                    .Select(e => e.Path)
                    .FirstOrDefault();

                if (result != null)
                {
                    byte[] imageByte = System.IO.File.ReadAllBytes(result);
                    vmm.ImageViewCollection = imageByte;
                    
                }
            }
            return View(vmm);
            
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
            if (obj.Path!=null)
            {
                FileInfo info = new FileInfo(obj.Path);
                if (info.Exists)
                {
                    obj.Extension = info.Extension;
                    obj.Name = info.Name;
                    obj.Size = (int)info.Length;
                    obj.CreationDate = info.CreationTime.ToString();
                    _db.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
         
        }

        
    }
}
