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
    
    public partial class tblInstitution
    {
        public int InstitutionID { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionOwner { get; set; }
        public string InstitutionAddress { get; set; }
        public int NumberOfFloors { get; set; }
        public int NumberOfRoomsPerFloor { get; set; }
        public int Terrace { get; set; }
        public int Yard { get; set; }
        public int NumberAPAmbulances { get; set; }
        public Nullable<int> NumberAPDisabled { get; set; }
    }
}
