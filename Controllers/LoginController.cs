using Microsoft.AspNetCore.Mvc;
using Curriculum_WebApp.Models;
using Microsoft.AspNetCore.Http;
using Datakit;

namespace Curriculum_WebApp.Controllers
{
    public class LoginController : Controller
    {

        // PoolConnection pc = new PoolConnection();

        [HttpPost]
        public void checkCredentials(IFormCollection fc)
        {


            UserModel logedUser = new UserModel();
            logedUser.user = fc["mail"].ToString();
            logedUser.pass = fc["pass"].ToString();

            // pc.saludo();

        }
    }

}