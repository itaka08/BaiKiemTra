using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.DAL.Entity
{
    class Nhom
    { public string TenNhom { get; set; }
        public static List<Nhom> GetListFromFile(string pathData)
        {
            var arrayLines = File.ReadAllLines(pathData);
            List<Nhom> ketQua = new List<Nhom>();
            foreach (var line in arrayLines)
            {
                var lsValue = line.Split(new char[] { '#' });
                var nhom = new Nhom
                {
                    TenNhom=lsValue[1],
                };
                
                    ketQua.Add(nhom);
            }
            return ketQua;
        }
    }
}
