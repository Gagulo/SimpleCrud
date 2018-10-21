using SimpleCrud.Repositories;
using System.Web.Mvc;
using SimpleCrud.Entities;
using SimpleCrud.Models;
using System;

namespace SimpleCrud.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _repository = new PersonRepository();

        public ActionResult Index()
        {
            var userList = _repository.GetAllUsers();
            return View(userList);
        }

        public ActionResult Edit(long id)
        {
            var model = _repository.GetUser(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserModel model)
        {
            _repository.Update(model);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            var model = new AddUserModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(AddUserModel model)
        {

            var dateOfBirth = model.DateOfBirth;
            var now = DateTime.UtcNow;

            var yearsDifference = now.Year - dateOfBirth.Year;

            if(yearsDifference <= 10)
            {
                ModelState.AddModelError(nameof(model.DateOfBirth), "U must be older then 10yo.");
            }

            if(ModelState.IsValid)
            {
                _repository.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(long id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult Delete(long id, object dummy)
        {
            _repository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}