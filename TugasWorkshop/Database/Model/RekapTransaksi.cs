using System;

namespace TugasWorkshop.Database.Model {
    public class RekapTransaksi {
        public int nomor { get; set; }
        public DateTime tanggalTransaksi { get; set; }
        public User pelanggan { get; set; }
        public int totalTransaksi { get; set; }

    }
}
