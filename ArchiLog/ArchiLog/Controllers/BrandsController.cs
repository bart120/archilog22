using ArchiLog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArchiLog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController
    {
        [HttpGet]
        public IEnumerable<Brand>? GetAll()
        {
            return null;
        }

    }
}
