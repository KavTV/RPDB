﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace SKPDB_Library
{
    internal class Dal
    {
        private string connectionString;


        public Dal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list with all students and their projects
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudents()
        {
            // Locals
            List<Student> studentList = new List<Student>();


            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_getstudents()", connection);

            // Opens connection
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads all content from reservations table
            while (reader.Read())
            {
                studentList.Add(new Student(
                    reader["username"].ToString(),
                    reader["education"].ToString(),
                    reader["fullname"].ToString(),
                    GetStudentProjects(reader["username"].ToString())));

            }
            connection.Close();

            return studentList;
        }
        /// <summary>
        /// Returns all projects that the student has
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<MiniProject> GetStudentProjects(string username)
        {
            //Locals
            List<MiniProject> projectList = new List<MiniProject>();

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM fn_getstudentprojects(@username)", connection);

            command.Parameters.AddWithValue("username", username);
            // Opens connection
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads all content from reservations table
            while (reader.Read())
            {

                projectList.Add(new MiniProject(int.Parse(
                    reader["projectid"].ToString()),
                    reader["headline"].ToString(),
                    reader["documentation"].ToString(),
                    reader["description"].ToString()));

            }
            connection.Close();
            return projectList;
        }
        /// <summary>
        /// Returns a list with all projects, and all students in the project
        /// </summary>
        /// <returns></returns>
        public List<Project> GetProjects()
        {
            //Locals
            List<Project> projectList = new List<Project>();

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_getprojects()", connection);

            // Opens connection
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads all content from reservations table
            while (reader.Read())
            {
                int projectId = Int32.Parse(reader["projectid"].ToString());
                projectList.Add(new Project(
                    projectId,
                    reader["headline"].ToString(),
                    reader["documentation"].ToString(),
                    reader["description"].ToString(),
                    GetProjectStudents(projectId)));

            }
            connection.Close();
            return projectList;
        }
        /// <summary>
        /// Returns a list with all students in the project
        /// </summary>
        /// <param name="projectId">Id of project</param>
        /// <returns></returns>
        public List<MiniStudent> GetProjectStudents(int projectId)
        {
            //Locals
            List<MiniStudent> studentList = new List<MiniStudent>();

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_getprojectstudents(@projectid)", connection);

            command.Parameters.AddWithValue("projectid", projectId);

            // Opens connection
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads all content from reservations table
            while (reader.Read())
            {
                studentList.Add(new MiniStudent(
                    reader["username"].ToString(),
                    reader["educationid"].ToString(),
                    reader["fullname"].ToString()));

            }
            connection.Close();
            return studentList;
        }
        /// <summary>
        /// Creates a project
        /// </summary>
        public void CreateProject(string headline, string documentation, string description, string username)
        {
            if (string.IsNullOrWhiteSpace(headline) || string.IsNullOrWhiteSpace(username))
            {
                return;
            }

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("CALL sp_createproject(@headline, @documentation, @description, @username)", connection);

            command.Parameters.AddWithValue("headline", headline);
            command.Parameters.AddWithValue("documentation", documentation);
            command.Parameters.AddWithValue("description", description);
            command.Parameters.AddWithValue("username", username);

            ExecuteNonQuery(command);

        }
        /// <summary>
        /// Deletes the project
        /// </summary>
        /// <param name="projectid">Id of project</param>
        public void DeleteProject(int projectid)
        {

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("CALL sp_deleteproject(@projectid)", connection);

            command.Parameters.AddWithValue("projectid", projectid);

            ExecuteNonQuery(command);

        }
        /// <summary>
        /// Edits the whole project
        /// </summary>
        public void EditProject(int projectid, string headline, string documentation, string description)
        {

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("CALL sp_editproject(@projectid, @headline, @documentation, @description)", connection);

            command.Parameters.AddWithValue("projectid", projectid);
            command.Parameters.AddWithValue("headline", headline);
            command.Parameters.AddWithValue("documentation", documentation);
            command.Parameters.AddWithValue("description", description);

            ExecuteNonQuery(command);

        }

        /// <summary>
        /// Returns a single Student object
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Student GetStudent(string username)
        {
            //Locals
            Student student = null;

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_getstudent(@username)", connection);

            command.Parameters.AddWithValue("username", username);

            // Opens connection
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads all content from reservations table
            while (reader.Read())
            {
                string user = reader["username"].ToString();
                student = new Student(
                    user,
                    reader["education"].ToString(),
                    reader["fullname"].ToString(),
                    GetStudentProjects(user));
            }
            connection.Close();

            return student;
        }

        /// <summary>
        /// Returns a single project object
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <returns></returns>
        public Project GetProject(string projectId)
        {
            //Locals
            Project project = null;

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_getproject(@projectid)", connection);

            command.Parameters.AddWithValue("projectid", projectId);

            // Opens connection
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads all content from reservations table
            while (reader.Read())
            {
                int id = int.Parse(reader["username"].ToString());
                project = new Project(
                    id,
                    reader["headline"].ToString(),
                    reader["documentation"].ToString(),
                    reader["description"].ToString(),
                    GetProjectStudents(id));
            }
            connection.Close();

            return project;
        }


        private void ExecuteNonQuery(NpgsqlCommand command)
        {
            try
            {

                // Creates connection
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                command.Connection = connection;

                // Opens connections and writes to table
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
