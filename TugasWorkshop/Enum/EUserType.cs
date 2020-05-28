
namespace TugasWorkshop.Enum {
    public class EUserType {
        public static EUserType pelanggan = new EUserType("Pelanggan");
        public static EUserType karyawan = new EUserType("Karyawan");

        private string type;
        private EUserType(string _type) {
            type = _type;
        }
        public string getUserType() {
            return type;
        }
        public static EUserType getMatchType(string _type) {
            if (_type.Equals(pelanggan.getUserType())) {
                return pelanggan;
            } else { return karyawan; }
        }
    }
}
