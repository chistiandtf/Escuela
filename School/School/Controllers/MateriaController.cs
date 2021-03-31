using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Route("lopes")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        [HttpGet]

        public IEnumerable<Models.Materium> get()
        {

            using (var db = new Models.EscolarContext())
            {
                IEnumerable<Models.Materium> l = db.Materia.ToList();
                return l;
            }



        }
    }
}
