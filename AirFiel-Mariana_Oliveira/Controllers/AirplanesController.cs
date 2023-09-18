using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirFiel_Mariana_Oliveira.Data;
using AirFiel_Mariana_Oliveira.Data.Entities;
using AirFiel_Mariana_Oliveira.Helpers;
using Microsoft.AspNetCore.Authorization;
using AirFiel_Mariana_Oliveira.Models;

namespace AirFiel_Mariana_Oliveira.Controllers
{
    public class AirplanesController : Controller
    {
        private readonly IAirplanesRepository _repository;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public AirplanesController(IImageHelper imageHelper, IConverterHelper converterHelper, IUserHelper userHelper, IAirplanesRepository airplanesRepository)
        {
           _converterHelper = converterHelper;
            _imageHelper = imageHelper;
            _userHelper = userHelper;
            _repository = airplanesRepository;
        }

        // GET: Airplanes
        public IActionResult Index()
        {
            return View(_repository.GetAllWithUser().OrderBy(e => e.Name));
        }


        [Authorize(Roles = "Admin")]
        // GET: Airplanes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("AirplaneNotFound");
            }

            var airplanes = await _repository.GetByIdAsync(id.Value);
             
            if (airplanes == null)
            {
                return new NotFoundViewResult("AirplaneNotFound");
            }

            return View(airplanes);
        }

        [Authorize(Roles = "Admin")]
        // GET: Airplanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airplanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlanesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var imageId = string.Empty;

                if(model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    imageId = await _imageHelper.UploadImageAsync(model.ImageFile, "planes");
                }

                var airplanes = _converterHelper.ToPlanes(model, imageId, true);

               airplanes.users = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);

                await _repository.CreateAsync(airplanes);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        // GET: Airplanes/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("AirplaneNotFound");
            }

            var airplanes = await _repository.GetByIdAsync(id.Value);

            if (airplanes == null)
            {
                return new NotFoundViewResult("AirplaneNotFound");
            }

            var model = _converterHelper.ToPlanesViewModel(airplanes);
            return View(model);
        }

        // POST: Airplanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlanesViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = model.ImagePlane;

                    if(model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        path = await _imageHelper.UploadImageAsync(model.ImageFile, "planes");
                    }

                    var plane = _converterHelper.ToPlanes(model, path, false);

                    plane.users = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await _repository.UpdateAsync(plane);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await _repository.ExistAsync(model.Id))
                    {
                        return new NotFoundViewResult("AirplaneNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Airplanes/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("AirplaneNotFound");
            }

            var airplanes = await _repository.GetByIdAsync(id.Value);

            if (airplanes == null)
            {
                return new NotFoundViewResult("AirplaneNotFound");
            }

            return View(airplanes);
        }

        // POST: Airplanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_repository == null)
            {
                return Problem("Entity set 'DataContext.airplanes' is null");
            }

            var planes = await _repository.GetByIdAsync(id);

            if(planes != null)
            {
                await _repository.DeleteAsync(planes);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult PlaneNotFound()
        {
            return View();
        }
    }
}
