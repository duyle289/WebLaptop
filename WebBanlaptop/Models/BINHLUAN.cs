//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanlaptop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BINHLUAN
    {
        public int MABL { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<int> MAKH { get; set; }
        public Nullable<int> MASP { get; set; }
        public Nullable<System.DateTime> NGAYGUI { get; set; }
        public string TENKH { get; set; }
    
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
    }
}
