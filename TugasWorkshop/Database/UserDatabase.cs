using System.Collections.Generic;
using TugasWorkshop.Database.Model;

namespace TugasWorkshop.Database {
    public class UserDatabase {
        private static UserDatabase instance;
        private List<User> registeredUser = new List<User>();
        private UserDatabase() {
            
        }

        public static UserDatabase getInstance() {
            if (instance == null) {
                instance = new UserDatabase();
            }
            return instance;
        }

        public List<User> getRegisteredUser() {
            return registeredUser;
        }

        public User getUserByID(int _id) {
            User user = null;
            for (int i = 0; i < registeredUser.Count; i++) {
                if (_id == registeredUser[i].id) {
                    user = registeredUser[i];
                }
            }
            return user;
        }

        public void addUser(User _user) {
            registeredUser.Add(_user);
        }
    }
}
