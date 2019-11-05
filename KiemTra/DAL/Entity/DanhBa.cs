using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.DAL.Entity
{
    class DanhBa
    {
        public string TenNhom { get; set; }
        public string Tengoi { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public static List<DanhBa> GetListFromFile(string pathData,string tenNhom)
        {
            var arrayLines = File.ReadAllLines(pathData);
            List<DanhBa> ketQua = new List<DanhBa>();
            foreach (var line in arrayLines)
            {
                var lsValue = line.Split(new char[] { '#' });

                var danhba = new DanhBa
                {
                    Tengoi = lsValue[1],
                    Diachi = lsValue[2],
                    Email = lsValue[3],
                    SoDienThoai = lsValue[4],
                    TenNhom = lsValue[5],
                };
                if (danhba.TenNhom == tenNhom )
                    ketQua.Add(danhba);
            }
            return ketQua;
        }
    }
}
