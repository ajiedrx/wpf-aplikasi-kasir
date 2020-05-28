using System;
using System.Collections.Generic;
using TugasWorkshop.Database;
using TugasWorkshop.Database.Model;
using TugasWorkshop.Enum;
using TugasWorkshop.Session;

namespace TugasWorkshop.Keranjang {
    public class KeranjangController : IKeranjangController {
        private List<KeranjangM> keranjang = new List<KeranjangM>();
        private KeranjangDatabase keranjangDatabase = KeranjangDatabase.getInstance();
        private RekapTransaksiDatabase rekapTransaksiDatabase = RekapTransaksiDatabase.getInstance();
        private SessionManager sessionManager = SessionManager.getInstance();
        private KeranjangView keranjangView;
        private DateTime currentTime = DateTime.Now;
        int nomor = 0;

        public KeranjangController() { }
        public KeranjangController(KeranjangView _keranjangView) {
            keranjangView = _keranjangView;
            setPelanggan(sessionManager.getCurrentUser());
        }

        public void addItem(KeranjangM _item) {
            keranjang.Add(_item);
            setKeranjangTableData(keranjang);
        }


        public void execute() {
            keranjang = keranjangDatabase.getKeranjang();
            for (int i = 0; i < keranjangDatabase.getKeranjang().Count; i++) {
                Console.WriteLine(keranjangDatabase.getKeranjang()[i].namaProduk);
            }
            setKeranjangTableData(keranjang);
        }

        public void addRekapTransaksi() {
            nomor += 1;
            rekapTransaksiDatabase.addTransaksi(new RekapTransaksi() {
                nomor = nomor,
                pelanggan = (sessionManager.getCurrentUser().userType == EUserType.karyawan ? null : sessionManager.getCurrentUser()),
                tanggalTransaksi = currentTime,
                totalTransaksi = getTotalBelanja()
            });
        }

        public DateTime getCurrentTime() {
            return currentTime;
        }

        private void setPelanggan(User _user) {
            if (_user.userType != EUserType.karyawan) {
                keranjangView.setPelangganName(_user.username);
            }
            keranjangView.setUserType(_user.userType);
        }
        private void setKeranjangTableData(List<KeranjangM> _data) {
            keranjangView.setKeranjangs(_data);
        }

        public void deleteItem(KeranjangM _item) {
            keranjangDatabase.deleteItem(_item);
            execute();
        }

        public int getTotalBelanja() {
            int total = 0;
            for (int i = 0; i < keranjang.Count; i++) {
                total += keranjang[i].subtotal;
            }
            return total;
        }
    }
}
