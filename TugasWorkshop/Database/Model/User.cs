using TugasWorkshop.Enum;

namespace TugasWorkshop.Database.Model {
    public class User {
        public int id { get; set; }
        public EUserType userType { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
