using System.Collections.Generic;
using TugasWorkshop.Database.Model;

namespace TugasWorkshop.Database {
    public class RekapTransaksiDatabase {
        private static RekapTransaksiDatabase instance;
        private List<RekapTransaksi> rekapTransaksi = new List<RekapTransaksi>();
        private RekapTransaksiDatabase() {

        }

        public static RekapTransaksiDatabase getInstance() {
            if (instance == null) {
                instance = new RekapTransaksiDatabase();
            }
            return instance;
        }

        public List<RekapTransaksi> getRekapTransaksi() {
            return rekapTransaksi;
        }

        public void addTransaksi(RekapTransaksi _transaksi) {
            rekapTransaksi.Add(_transaksi);
        }
    }
}
