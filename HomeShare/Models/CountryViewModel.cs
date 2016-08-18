using DAL;
using HomeShare.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeShare.Models
{
    public class CountryViewModel : Mappers.MapperBase<Country>, IViewModel<Country>
    {
        [ValueMember]
        public int ID { get; set; }
        public string CountryCode { get; set; }
        [DisplayMember]
        public string CountryName { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Residence> Residences { get; set; }

    }
}