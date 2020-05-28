using System.Collections.Generic;
using TugasWorkshop.Database.Model;

namespace TugasWorkshop.Database {
    public class KeranjangDatabase {
        private static KeranjangDatabase instance;
        private List<KeranjangM> keranjang = new List<KeranjangM>();
        private KeranjangDatabase() {

        }

        public static KeranjangDatabase getInstance() {
            if (instance == null) {
                instance = new KeranjangDatabase();
            }
            return instance;
        }

        public List<KeranjangM> getKeranjang() {
            return keranjang;
        }

        public void addItem(KeranjangM _item) {
            keranjang.Add(_item);
        }

        public void deleteItem(KeranjangM _item) {
            keranjang.Remove(_item);
        }

        public void resetKeranjang() {
            keranjang = new List<KeranjangM>();
        }
    }
}
