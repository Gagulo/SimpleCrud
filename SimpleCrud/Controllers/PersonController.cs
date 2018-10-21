using SimpleCrud.Repositories;
using System.Web.Mvc;
using SimpleCrud.Models;
using System;
using SimpleCrud.Validators;

namespace SimpleCrud.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

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
            Validate(model);
            

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