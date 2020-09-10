using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SKPDB_Library;

namespace APITEST2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAll")]
    public class ProjectsController : ControllerBase
    {

        Manager manager = new Manager("Server = 127.0.0.1; Port=5432; User Id = postgres; Password=123; Database=SKPDB;");


        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(ILogger<ProjectsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string get() {
            var json = JsonSerializer.Serialize<List<Project>>(manager.GetProjects());
            return json;
        }
    }
}