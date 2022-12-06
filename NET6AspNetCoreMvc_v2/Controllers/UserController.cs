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
        public UserController(DatabaseContext databaseContext,IMapper mapper)
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
    }
}
