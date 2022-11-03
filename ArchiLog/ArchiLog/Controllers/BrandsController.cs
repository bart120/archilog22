using ArchiLibrary.controllers;
using ArchiLog.Data;
using ArchiLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArchiLog.Controllers
{
    
    [Route("api/[controller]")]
    public class BrandsController : BaseController<ArchiLogDbContext, Brand>
    {
        public BrandsController(ArchiLogDbContext context):base(context)
        {
        }

       







    }
}
