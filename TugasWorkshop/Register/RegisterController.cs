using TugasWorkshop.Database;
using TugasWorkshop.Database.Model;
using TugasWorkshop.Enum;
using TugasWorkshop.Session;

namespace TugasWorkshop.Register {
    public class RegisterController {
        private UserDatabase userDatabase = UserDatabase.getInstance();
        private SessionManager sessionManager = SessionManager.getInstance();
        private RegisterView registerView;
        int id = 0;
        public RegisterController(RegisterView _registerView) {
            registerView = _registerView;
        }

        public void register(string _userType, string _username, string _password) {
            id += 1;
            User user = new User() {
                id = id,
                userType = EUserType.getMatchType(_userType),
                username = _username,
                password = _password
            };
            userDatabase.addUser(user);
            bool type = (_userType == EUserType.karyawan.getUserType() ? true : false);
            sessionManager.setCurrentUser(user);
            registerView.movePage(type);
        }
    }
}
