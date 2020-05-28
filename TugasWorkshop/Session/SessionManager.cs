using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasWorkshop.Database.Model;

namespace TugasWorkshop.Session {
    public class SessionManager {
        private static SessionManager instance;
        private User currentUser;
        private SessionManager() {

        }

        public static SessionManager getInstance() {
            if (instance == null) {
                instance = new SessionManager();
            }
            return instance;
        }

        public void setCurrentUser(User _currentUser) {
            currentUser = _currentUser;
        }

        public User getCurrentUser() {
            return currentUser;
        }

    }
}
