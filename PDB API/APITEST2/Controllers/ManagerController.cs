﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using SKPDB_Library;

namespace APITEST2.Controllers
{
    [Route("api")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        Manager manager = new Manager("Server = 127.0.0.1; Port=5432; User Id = postgres; Password=123; Database=SKPDB;");


        [Route("students")]
        [HttpGet]
        public string GetStudents()
        {
            var json = JsonSerializer.Serialize<List<Student>>(manager.GetStudents());
            return json;
        }

        [Route("projects")]
        [HttpGet]
        public string GetProjects()
        {
            var json = JsonSerializer.Serialize<List<Project>>(manager.GetProjects());
            return json;
        }

        [Route("project")]
        [HttpGet]
        public string GetProject(
            [FromQuery] int projectId)
        {
            var json = JsonSerializer.Serialize<Project>(manager.GetProject(projectId));
            return json;
        }

        [Route("student")]
        [HttpGet]
        public string GetStudent(
            [FromQuery] string username)
        {
            var json = JsonSerializer.Serialize<Student>(manager.GetStudent(username));
            return json;
        }

    }
}
