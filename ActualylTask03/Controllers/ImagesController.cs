using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace ActualylTask03.Controllers
{
    public class ImagesController : Controller
    {
        private readonly SaintModelContainer db = new SaintModelContainer();
        ~ImagesController()
        {
            db.Dispose();
        }

        public ActionResult Index(int id)
        {
            var file = db.Images.Find(id);
            return File(file.Data, file.ContentType);
        }
        public ActionResult Delete(int id)
        {
            var file = db.Images.Find(id);
            db.Images.Remove(file);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsolutePath); // refresh caller
        }
    }
}