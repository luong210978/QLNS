
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace BookStoreClone.Model
{

using System;
    using System.Collections.Generic;
    
public partial class CTHD
{

    public int MaHD { get; set; }
    public int MaSach { get; set; }
    public Nullable<int> SoLuong { get; set; }
    public Nullable<int> DonGiaBan { get; set; }
    public string PhuongThuc { get; set; }
    public Nullable <long> ThanhTien { get; set; }
    public virtual HoaDon HoaDon { get; set; }
    public virtual Sach Sach { get; set; }

}

}
