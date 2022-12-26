using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NET6AspNetCoreMvc_v2.Entities;
using NET6AspNetCoreMvc_v2.Models;

namespace NET6AspNetCoreMvc_v2.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        //Bağımlılıkları enjekte ediyoruz.
        public UserController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //ViewModel' çevirmek için kullanılabilecek yöntemler:
            //1.Linq
            //2.Select
            //3.AutoMapper

            List<User> users = _databaseContext.Users.ToList();
            List<UserViewModel> usersViewModel = users.Select(x => _mapper.Map<UserViewModel>(x)).ToList();

            return View(usersViewModel);
        }
        public IActionResult Create()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Create(CreateUserViewModel createUserViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(createUserViewModel);
                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(createUserViewModel);


        }


        public IActionResult Edit(Guid id)
        {
            var returnUser = _databaseContext.Users.Find(id);
            var updateUser = _mapper.Map<UpdateUserViewModel>(returnUser);
            return View(updateUser);

        }


        [HttpPost]
        public IActionResult Edit(Guid id, UpdateUserViewModel updateUserViewModel)
        {
            if (ModelState.IsValid)
            {
               
                if (_databaseContext.Users.Any(x=>x.UserName.ToLower() == updateUserViewModel.UserName.ToLower() && x.Id != id))
                {
                    ModelState.AddModelError(nameof(updateUserViewModel.UserName), "Kullanıcı kayıtlı");
                    return View(updateUserViewModel);

                }


                User user = _databaseContext.Users.Find(id);
                _mapper.Map(updateUserViewModel, user);
                //_databaseContext.Users.Update(user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(updateUserViewModel);


        }
    }
}
