//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicalInstitution.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblManager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblManager()
        {
            this.tblDoctors = new HashSet<tblDoctor>();
        }
    
        public int ManagerID { get; set; }
        public string NameSurname { get; set; }
        public string BLK { get; set; }
        public int Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Citizenship { get; set; }
        public string UsernameLogin { get; set; }
        public string PasswordLogin { get; set; }
        public int FloorInstitution { get; set; }
        public int MaxNumSupervising { get; set; }
        public int MinNumRoomSupervised { get; set; }
        public int NumOmissions { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDoctor> tblDoctors { get; set; }
        public virtual tblGender tblGender { get; set; }
    }
}
