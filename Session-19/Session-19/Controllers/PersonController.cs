using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Session_19.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase {

        [HttpGet(Name = "GetPerson")]
        public Person Get() {


            Person person = new Person();
            person.Name = "fotis";

            return person;

        }
    }
}
