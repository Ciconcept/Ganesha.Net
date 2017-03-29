using AutoMapper;
using Ganesha.Common.Tools;
using Ganesha.Core.Entities;
using Ganesha.Core.Interfaces;
using Ganesha.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ganesha.Web.Controllers {

    //[AuthorizeRoles(RoleName.RoleAdministrator, RoleName.RoleSuperAdministrator)]
    public class FormationsController : Controller {
        private readonly IFormationRepository _repository;

        public FormationsController(IFormationRepository repository) {
            if (repository == null) {
                throw new ArgumentException("repository");
            }
            _repository = repository;
        }


        // GET: Formations
        public ActionResult Index() {

            return View(Mapper.Map<IEnumerable<FormationViewModel>>(_repository.GetAll()));
        }

        // GET: Formations/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var formation = Mapper.Map<FormationViewModel>(_repository.GetSingle((int)id));
            if (formation == null) {
                return HttpNotFound();
            }

            return View(formation);
        }

        // GET: Formations/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Formations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormationViewModel frmViewModel, HttpPostedFileBase fileUpload) {


            try {
                if (!ModelState.IsValid) {
                    return View();
                }
                if (fileUpload != null && fileUpload.ContentLength > 0) {
                    frmViewModel.FrmImage = ImageConverter.ConvertToBytes(fileUpload);
                }

                _repository.Add(Mapper.Map<Formation>(frmViewModel));

                return RedirectToAction("Index");
            } catch (RetryLimitExceededException) {

                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(frmViewModel);

        }

        // GET: Formations/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var formation = Mapper.Map<FormationViewModel>(_repository.GetSingle((int)id));
            if (formation == null) {
                return HttpNotFound();
            }
            return View(formation);
        }

        // POST: Formations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormationViewModel frmViewModel) {
            if (!ModelState.IsValid) {
                return View();
            }
            _repository.Update(Mapper.Map<Formation>(frmViewModel));
            return RedirectToAction("Index");
        }

        // GET: Formations/Delete/5
        public ActionResult Delete(int? id) {

            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var formation = Mapper.Map<FormationViewModel>(_repository.GetSingle((int)id));
            if (formation == null) {
                return HttpNotFound();
            }
            return View(formation);
        }

        // POST: Formations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            var formation = _repository.GetSingle(id);
            _repository.Delete(formation);
            return RedirectToAction("Index");


        }

        public FileContentResult FormationPhotos(int? id) {

            if (id == null) {
                var fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");
                byte[] imageData = null;
                var fileInfo = new FileInfo(fileName);
                var imageFileLength = fileInfo.Length;
                var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                return File(imageData, "image/png");
            }
            var formation = Mapper.Map<FormationViewModel>(_repository.GetSingle((int)id));
            return File(formation.FrmImage, "image/jpeg");
        }
    }
}
