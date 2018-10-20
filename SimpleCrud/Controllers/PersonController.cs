using SimpleCrud.Repositories;
using System.Web.Mvc;
using SimpleCrud.Entities;
using SimpleCrud.Models;

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
            return View();
        }

        public ActionResult Add()
        {
            var model = new AddUserModel();
            return View(model);
        }
    }
}