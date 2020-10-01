﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SKPDB_Library;
using System.Collections.Generic;
using System.Text.Json;

namespace APITEST2.Controllers
{
    [Route("")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ManagerController : ControllerBase
    {
        private Manager manager = new Manager("Server = 10.108.48.80; Port=5432; User Id = postgres; Password=Kode123; Database=SKPpDB;");

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

        [Route("createproject")]
        [HttpPost]
        public IActionResult CreateProject(
            [FromQuery] string headline,
            [FromQuery] string documentation,
            [FromQuery] string description,
            [FromQuery] string username)
        {
            if (string.IsNullOrWhiteSpace(headline) || string.IsNullOrWhiteSpace(documentation) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(username))
            {
                return BadRequest();
            }

            string[] usernameSplit = username.Split(",");

            if (manager.CreateProject(headline, documentation, description, usernameSplit))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("editproject")]
        [HttpPost]
        public IActionResult EditProject(
            [FromQuery] int projectid,
            [FromQuery] string headline,
            [FromQuery] string documentation,
            [FromQuery] string description,
            [FromQuery] string usernames)
        {
            if (string.IsNullOrWhiteSpace(headline) || string.IsNullOrWhiteSpace(documentation) || string.IsNullOrWhiteSpace(description))
            {
                return BadRequest();
            }
            string[] usernameSplit = usernames.Split(",");
            //EditProject returns true if everything goes alright
            if (manager.EditProject(projectid, headline, documentation, description, usernameSplit))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("addtoproject")]
        [HttpPost]
        public IActionResult AddToProject(
            [FromQuery] int projectid,
            [FromQuery] string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest();
            }
            if (manager.AddToProject(projectid, username))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("removefromproject")]
        [HttpPost]
        public IActionResult RemoveFromProject(
            [FromQuery] int projectid,
            [FromQuery] string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest();
            }
            if (manager.RemoveFromProject(projectid, username))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("searchprojects")]
        [HttpGet]
        public string SearchProjects(
            [FromQuery] string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return null;
            }
            var json = JsonSerializer.Serialize<List<Project>>(manager.SearchProjects(search));
            return json;
        }

        [Route("searchstudents")]
        [HttpGet]
        public string SearchStudents(
            [FromQuery] string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return null;
            }
            var json = JsonSerializer.Serialize<List<Student>>(manager.SearchStudents(search));
            return json;
        }
    }
}