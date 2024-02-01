using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

namespace ActualylTask03.Controllers
{
    public class SaintsController : Controller
    {
        private readonly SaintModelContainer model = new SaintModelContainer();

        ~SaintsController() {
            model.Dispose();
        }

        // GET: Saints
        public ActionResult Index()
        {
            return View(model.Saints);
        }

        // GET: Saints/Details/5
        public ActionResult Details(int id)
        {
            return CommonAction(id);
        }

        private ActionResult CommonAction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var saint = model.Saints
                .Include(s => s.Images)
                .SingleOrDefault(s => s.Id == id);
            if (saint == null)
            {
                return HttpNotFound();
            }
            return View(saint);
        }

        // GET: Saints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Saints/Create
        [HttpPost]
        public ActionResult Create(Saint saint, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                saint.Images = new List<Image>();
                AddFiles(saint, files);
                model.Saints.Add(saint);
                model.SaveChanges();
                return RedirectToAction("Index");
            }

            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            allErrors.ForEach(error =>
            {
                System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                System.Diagnostics.Debug.WriteLine($"Property: {error.GetType()}");
            });

            return View(saint);
        }

        private void AddFiles(Saint saint, IEnumerable<HttpPostedFileBase> files)
        {
            System.Diagnostics.Debug.WriteLine("files: ");
            foreach (var file in files)
            {
                System.Diagnostics.Debug.WriteLine(file);

                if (file != null && file.ContentLength > 0)
                {
                    var picture = new Image()
                    {
                        ContentType = file.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(file.InputStream))
                    {
                        picture.Data = reader.ReadBytes(file.ContentLength);
                    }
                    saint.Images.Add(picture);
                }
            }
        }

        // GET: Saints/Edit/5
        public ActionResult Edit(int id)
        {
            return CommonAction(id);
        }

        // POST: Saints/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IEnumerable<HttpPostedFileBase> files)
        {
            var saint = model.Saints.Find(id);
            if (TryUpdateModel(
                saint,
                "",
                new string[]
                {
                    nameof(Saint.Name),
                    nameof(Saint.WhenHeBecame)
                }))
            {
                AddFiles(saint, files);

                model.Entry(saint).State = EntityState.Modified;
                model.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(saint);
        }

        // GET: Saints/Delete/5
        public ActionResult Delete(int? id)
        {
            return CommonAction(id);
        }

        // POST: Saints/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            model.Images.RemoveRange(model.Images.Where(f => f.SaintId == id));
            model.Saints.Remove(model.Saints.Find(id));
            model.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
