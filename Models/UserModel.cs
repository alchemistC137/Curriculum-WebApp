using System;

namespace Curriculum_WebApp.Models
{

    public class UserModel
    {
        public Guid? IdUsuario { get; set; }
        public string userName { get; set; }
        protected Guid? IdPass { get; set; }
        public string password { get; set; }



    }
}


