//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Residence_Option
    {
        public int OptionID { get; set; }
        public int ResidenceID { get; set; }
        public string Value { get; set; }
    
        public virtual Option Option { get; set; }
        public virtual Residence Residence { get; set; }
    }
}
