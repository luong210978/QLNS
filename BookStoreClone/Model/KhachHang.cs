
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
    
public partial class KhachHang
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public KhachHang()
    {

        this.CTBaoCaoCongNoes = new HashSet<CTBaoCaoCongNo>();

        this.HoaDons = new HashSet<HoaDon>();

        this.PhieuThuTiens = new HashSet<PhieuThuTien>();

    }


    public int MaKH { get; set; }

    public string TenKH { get; set; }

    public string SDT { get; set; }

    public string DiaChi { get; set; }

    public string Email { get; set; }

    public int SoTienNo { get; set; }
    public int SoSachChuaTra { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CTBaoCaoCongNo> CTBaoCaoCongNoes { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<HoaDon> HoaDons { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<PhieuThuTien> PhieuThuTiens { get; set; }
		public int TongSoTien { get; internal set; }
		public bool IsEnable_BanSach { get; internal set; }
	}

}
