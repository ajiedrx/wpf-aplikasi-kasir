using System.Collections.Generic;
using TugasWorkshop.Database;
using TugasWorkshop.Database.Model;

namespace TugasWorkshop.RecordTransaksi {
    public class RekapTransaksiController {
        private RekapTransaksiView rekapTransaksiView;
        private List<RekapTransaksi> rekapTransaksiData = new List<RekapTransaksi>();
        private RekapTransaksiDatabase rekapTransaksiDatabase = RekapTransaksiDatabase.getInstance();
        private KeranjangDatabase keranjangDatabase = KeranjangDatabase.getInstance();
        public RekapTransaksiController(RekapTransaksiView _rekapTransaksiView) {
            rekapTransaksiView = _rekapTransaksiView;
        }

        public void execute() {
            rekapTransaksiData = rekapTransaksiDatabase.getRekapTransaksi();
            rekapTransaksiView.setTableData(rekapTransaksiData);
        }

        public void resetKeranjang() {
            keranjangDatabase.resetKeranjang();
        }
    }
}
