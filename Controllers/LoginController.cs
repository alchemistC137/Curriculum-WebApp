using Microsoft.AspNetCore.Mvc;
using Curriculum_WebApp.Models;
using Microsoft.AspNetCore.Http;
using Datakit;
using Microsoft.Extensions.Configuration;

namespace Curriculum_WebApp.Controllers
{
    public class LoginController : Controller
    {
      

        DataAccess dataAccess = new DataAccess();


        public LoginController(IConfiguration configuration)
        {
        
          
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult checkCredentials(IFormCollection fc)
        {


            UserModel logedUser = new UserModel();
            //logedUser.IdUsuario = fc["mail"].ToString();
            logedUser.userName = fc["mail"].ToString();




            if (dataAccess.checkCredentials(Helper.TypeConverter.UserModel_To_User(logedUser)))
            {
                return View("../Home/Access");
            }
            else
            {
                return View("../Home/Index");
            }




        }
    }

}