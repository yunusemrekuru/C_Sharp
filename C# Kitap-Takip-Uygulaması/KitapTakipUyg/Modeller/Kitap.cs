﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapTakipUyg.Modeller
{
    public class Kitap
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string? RafNo { get; set; }
        public int KategoriId { get; set; }//FK
        public Kategori Kategori { get; set; }
    }
}
