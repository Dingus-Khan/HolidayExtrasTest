using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace UserAPI
{
    public class Users
    {
        private List<Models.User> UserList { get; } = new List<Models.User>();
        private string JsonFileName { get; set; }
        private int LastIndex { get; set; } = 1;

        // Opens a "connection" (in this case, a JSON file containing the data, which could be easily swapped out for a database connection)
        public Users(string jsonFile = "users.json") {
            JsonFileName = jsonFile;

            if (!System.IO.File.Exists(jsonFile)) {
                System.IO.File.Create(jsonFile).Close();
            }

            System.IO.StreamReader stream = new System.IO.StreamReader(JsonFileName);
            var jsonString = "";

            while (!stream.EndOfStream) {
                jsonString += stream.ReadLine();
            }

            stream.Close();
            stream.Dispose();

            if (!String.IsNullOrEmpty(jsonString)) {
                UserList = JsonConvert.DeserializeObject<List<Models.User>>(jsonString);
                if (UserList.Any()) {
                    LastIndex = UserList.OrderByDescending(m => m.Id).FirstOrDefault().Id + 1;
                }
            }
        }

        // Retrieves the user with the matching ID
        public Models.User GetUser(int id) {
            return UserList.Where(m => m.Id == id).FirstOrDefault();
        }

        public List<Models.User> GetUsers() {
            return UserList;
        }

        // Create a new user. Returns the new ID if successful, and null if not
        public int? CreateUser(Models.User user) {
            user.Id = LastIndex++; // Increments the index to stop duplication (normally handled by an identity column in the DB)
            user.DateCreated = DateTime.Now; // Sets the datetime to now, ensuring accuracy of the date created field
            UserList.Add(user);
            SaveChanges();
            return user.Id;
        }

        // Overload for passing Json
        public int? CreateUser(string userJson) {
            return CreateUser(JsonToUser(userJson));
        }

        // Updates the specified user to match the model passed in. Returns the ID if successful, and null if not
        public int? UpdateUser(Models.User user) {
            if (UserList.Where(m => m.Id == user.Id).Any()) {
                UserList.Find(m => m.Id == user.Id).Email = user.Email;
                UserList.Find(m => m.Id == user.Id).GivenName = user.GivenName;
                UserList.Find(m => m.Id == user.Id).FamilyName = user.FamilyName;
            }
            SaveChanges();
            return UserList.Where(m => m.Id == user.Id).FirstOrDefault().Id;
        }

        // Overload for passing Json
        public int? UpdateUser(string userJson) {
            return UpdateUser(JsonToUser(userJson));
        }

        // Deletes the specified user from the records
        public bool DeleteUser(int id) {
            UserList.RemoveAll(m => m.Id == id);
            SaveChanges();
            return true;
        }

        // Batch updates the "DB", to be called before closing the "connection"
        public void SaveChanges() {
            var stream = new System.IO.StreamWriter(JsonFileName, false);
            stream.Write(JsonConvert.SerializeObject(UserList));
            stream.Close();
            stream.Dispose();
        }

        // Converts user json to a user model and returns if successful, throws an exception if not
        private Models.User JsonToUser(string json) {
            return JsonConvert.DeserializeObject<Models.User>(json);
        }
    }
}
