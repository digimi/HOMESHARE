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
    
    public partial class Review
    {
        public int ID { get; set; }
        public int Note { get; set; }
        public string Comment { get; set; }
        public int TransactionID { get; set; }
    
        public virtual Transaction Transaction { get; set; }
    }
}