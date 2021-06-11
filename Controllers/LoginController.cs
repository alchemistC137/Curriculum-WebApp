using Microsoft.AspNetCore.Mvc;
using Curriculum_WebApp.Models;
using Microsoft.AspNetCore.Http;
using Datakit;


namespace Curriculum_WebApp.Controllers
{
    public class LoginController : Controller
    {

        DataAccess dataAccess = new DataAccess();
     
        [HttpPost]
        public IActionResult checkCredentials(IFormCollection fc)
        {


            UserModel logedUser = new UserModel();
            logedUser.user = fc["mail"].ToString();
            logedUser.pass = fc["pass"].ToString();




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