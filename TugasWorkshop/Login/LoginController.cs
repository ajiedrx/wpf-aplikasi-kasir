using System;
using System.Collections.Generic;
using System.Linq;
using TugasWorkshop.Database;
using TugasWorkshop.Database.Model;
using TugasWorkshop.Session;

namespace TugasWorkshop.Login {
    public class LoginController {
        private LoginView loginView;
        private UserDatabase userDatabase = UserDatabase.getInstance();
        private SessionManager sessionManager = SessionManager.getInstance();
        private User validatedUser;
        public LoginController(LoginView _loginView) {
            this.loginView = _loginView;
        }

        public bool validate(string username, string password) {
            List<User> registeredUser = userDatabase.getRegisteredUser();
            int usersCount = registeredUser.Count();
            bool result = false;
            for (int i = 0; i < usersCount; i++) {
                result = (username == registeredUser[i].username && password == registeredUser[i].password ? true : false);
                if (result) {
                    validatedUser = registeredUser[i];
                    sessionManager.setCurrentUser(validatedUser);
                    break;
                }
            }
            return result;
        }

        public User getValidatedUser() {
            return validatedUser;
        }
    }
}
