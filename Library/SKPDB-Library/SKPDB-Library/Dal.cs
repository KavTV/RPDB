using Npgsql;
using System;
using System.Collections.Generic;

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
                DateTime start;
                DateTime end;
                int statusid;
                DateTime.TryParse(reader["startdate"].ToString(), out start);
                DateTime.TryParse(reader["enddate"].ToString(), out end);
                int.TryParse(reader["status"].ToString(), out statusid);

                projectList.Add(new MiniProject(int.Parse(
                    reader["projectid"].ToString()),
                    statusid,
                    reader["projectmanager"].ToString(),
                    reader["headline"].ToString(),
                    reader["documentation"].ToString(),
                    reader["description"].ToString(),
                    start,
                    end));

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
                projectList.Add(CreateProject(reader));

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
        public bool CreateProject(int status, string projectmanager, string headline, string documentation, string description, DateTime startdate, DateTime enddate, string[] usernames)
        {
            if (string.IsNullOrWhiteSpace(headline))
            {
                return false;
            }
            foreach (var item in usernames)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    return false;
                }
            }
            //Make arraystring
            string usernameArray = "";
            for (int i = 0; i < usernames.Length; i++)
            {
                if (i != usernames.Length - 1)
                {
                    usernameArray += $"'{usernames[i]}',";
                }
                else
                {
                    usernameArray += $"'{usernames[i]}'";
                }
            }


            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("CALL sp_createproject(@status,@projectmanager,@headline, @documentation, @description,@startdate,@enddate, @username)", connection);

            command.Parameters.AddWithValue("status", status);
            command.Parameters.AddWithValue("projectmanager", projectmanager);
            command.Parameters.AddWithValue("headline", headline);
            command.Parameters.AddWithValue("documentation", documentation);
            command.Parameters.AddWithValue("description", description);
            command.Parameters.AddWithValue("startdate", NpgsqlTypes.NpgsqlDbType.Date, startdate);
            command.Parameters.AddWithValue("enddate", NpgsqlTypes.NpgsqlDbType.Date, enddate);
            command.Parameters.Add("username", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text).Value = usernames;

            return ExecuteNonQuery(command);

        }
        /// <summary>
        /// Deletes the project
        /// </summary>
        /// <param name="projectid">Id of project</param>
        public bool DeleteProject(int projectid)
        {

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("CALL sp_deleteproject(@projectid)", connection);

            command.Parameters.AddWithValue("projectid", projectid);

            return ExecuteNonQuery(command);

        }
        /// <summary>
        /// Edits the whole project
        /// </summary>
        public bool EditProject(int projectid, int status, string projectmanager, string headline, string documentation, string description, DateTime startdate, DateTime enddate, string[] usernames)
        {

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("CALL sp_editproject(@projectid, @status, @projectmanager, @headline, @documentation, @description, @startdate, @enddate, @username)", connection);

            command.Parameters.AddWithValue("projectid", projectid);
            command.Parameters.AddWithValue("status", status);
            command.Parameters.AddWithValue("projectmanager", projectmanager);
            command.Parameters.AddWithValue("headline", headline);
            command.Parameters.AddWithValue("documentation", documentation);
            command.Parameters.AddWithValue("description", description);
            command.Parameters.AddWithValue("startdate", NpgsqlTypes.NpgsqlDbType.Date, startdate);
            command.Parameters.AddWithValue("enddate", NpgsqlTypes.NpgsqlDbType.Date, enddate);
            command.Parameters.Add("username", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text).Value = usernames;

            return ExecuteNonQuery(command);

        }

        /// <summary>
        /// Returns a single Student object
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Student GetStudent(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            //Locals
            Student student = null;

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_getstudent(@username)", connection);

            command.Parameters.AddWithValue("username", username);

            // Opens connection
            connection.Open();
            try
            {

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
            }
            catch (Exception)
            {

            }
            connection.Close();

            return student;
        }

        /// <summary>
        /// Returns a single project object
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <returns></returns>
        public Project GetProject(int projectId)
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
                project = CreateProject(reader);
            }
            connection.Close();

            return project;
        }

        public bool AddToProject(int projectid, string username)
        {

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("CALL sp_addtoproject(@projectid, @username)", connection);

            command.Parameters.AddWithValue("projectid", projectid);
            command.Parameters.AddWithValue("username", username);

            return ExecuteNonQuery(command);

        }

        public bool RemoveFromProject(int projectid, string username)
        {

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("CALL sp_removefromproject(@projectid, @username)", connection);

            command.Parameters.AddWithValue("projectid", projectid);
            command.Parameters.AddWithValue("username", username);

            return ExecuteNonQuery(command);

        }

        public List<Project> SearchProjects(string search)
        {
            //Locals
            List<Project> projectList = new List<Project>();

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_searchprojects(@search)", connection);

            command.Parameters.AddWithValue("search", search);

            // Opens connection
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads all content from reservations table
            while (reader.Read())
            {

                projectList.Add(CreateProject(reader));

            }
            connection.Close();
            return projectList;
        }

        /// <summary>
        /// Returns a list with all students and their projects that the user searched for
        /// </summary>
        /// <returns></returns>
        public List<Student> SearchStudents(string search)
        {
            // Locals
            List<Student> studentList = new List<Student>();


            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_searchstudents(@search)", connection);

            command.Parameters.AddWithValue("search", search);

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


        private Project CreateProject(NpgsqlDataReader reader)
        {

            DateTime start;
            DateTime end;
            int statusid;
            DateTime.TryParse(reader["startdate"].ToString(), out start);
            DateTime.TryParse(reader["enddate"].ToString(), out end);
            int.TryParse(reader["status"].ToString(), out statusid);

            int projectId = Int32.Parse(reader["projectid"].ToString());
            Project project = new Project(
                projectId,
                statusid,
                reader["projectmanager"].ToString(),
                reader["headline"].ToString(),
                reader["documentation"].ToString(),
                reader["description"].ToString(),
                start,
                end,
                GetProjectStudents(projectId));

            return project;
        }

        private bool ExecuteNonQuery(NpgsqlCommand command)
        {
            //try
            //{
            // Creates connection
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            command.Connection = connection;

            // Opens connections and writes to table
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }

        public List<Comment> Getprojectcomments(int projectid)
        {
            try
            {
                List<Comment> comments = new List<Comment>();
                // Execute function
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_getprojectcomments(@projectid)", connection);

                command.Parameters.AddWithValue("projectid", projectid);

                // Opens connection
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();


                // Reads all content from reservations table
                while (reader.Read())
                {

                    DateTime timestamp;
                    int commentid;
                    DateTime.TryParse(reader["time_stamp"].ToString(), out timestamp);
                    int.TryParse(reader["commentid"].ToString(), out commentid);

                    comments.Add(new Comment(
                        commentid,
                        reader["username"].ToString(),
                        reader["msg"].ToString(),
                        timestamp
                        ));
                }

                connection.Close();

                return comments;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetUserPwd(string username)
        {
            try
            {
                // Execute function
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_getuserpwd(@username)", connection);

                command.Parameters.AddWithValue("username", username);

                // Opens connection
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();

                reader.Read();
                string pwd = reader["pwd"].ToString();
                connection.Close();

                return pwd;

            }
            catch (Exception)
            {

                return null;
            }
        }
        public bool SetToken(string username, string token)
        {
            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("CALL sp_settokn(@username, @tokn)", connection);

            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("tokn", NpgsqlTypes.NpgsqlDbType.Char, token);

            return ExecuteNonQuery(command);
        }

        public bool SetPwd(string username, string pwd)
        {
            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("CALL sp_setpwd(@username, @pwd)", connection);

            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("pwd", NpgsqlTypes.NpgsqlDbType.Char, pwd);

            return ExecuteNonQuery(command);
        }

        public bool CreateComment(int projectid, string username, string msg)
        {
            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("CALL sp_createcomment(@projectid, @username, @msg)", connection);

            command.Parameters.AddWithValue("projectid", projectid);
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("msg", msg);

            return ExecuteNonQuery(command);
        }

        public string GetAuthToken(string username)
        {
            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_getauthtoken(@username)", connection);

            command.Parameters.AddWithValue("username", username);

            // Opens connection
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            reader.Read();
            string authtoken = reader["authtoken"].ToString();
            connection.Close();

            return authtoken;
        }

        public string GetResetTokenUsername(string token)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_getresettokenusername(@tkn)", connection);

                command.Parameters.AddWithValue("tkn", token);

                // Opens connection
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();

                reader.Read();
                string authtoken = reader["username"].ToString();
                connection.Close();

                return authtoken;
            }
            catch (Exception)
            {

                return null;
            }
        }


        public int GetUserEducation(string username)
        {
            try
            {

                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_usereducationid(@username)", connection);

                command.Parameters.AddWithValue("username", username);

                // Opens connection
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();

                reader.Read();

                int educationid;
                if (!int.TryParse(reader["educationid"].ToString(), out educationid))
                {
                    educationid = 0;
                }
                connection.Close();

                return educationid;
            }
            catch (Exception)
            {


            }
            //Returns 0 if something was wrong, or nothing found
            return 0;
        }

        public bool SetProjectStatus(int projectid, int statusid)
        {
            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("CALL sp_setstatus(@projectid, @statusid)", connection);

            command.Parameters.AddWithValue("projectid", projectid);
            command.Parameters.AddWithValue("statusid", statusid);

            return ExecuteNonQuery(command);
        }

        public bool ProjectExist(int projectid)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fn_projectexist(@projectid)", connection);

            command.Parameters.AddWithValue("projectid", projectid);

            // Opens connection
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            reader.Read();
            bool exists = (bool)reader["fn_projectexist"];
            connection.Close();

            return exists;
        }

    }
}
