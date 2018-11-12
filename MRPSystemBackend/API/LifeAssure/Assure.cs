using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.LifeAssure
{
    public class Assure
    {
        [Required]
        public int SeqId { get; set; }
        public string AssureType { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
       
        [StringLength(15)]
        public string NIC { get; set; }
        public int NationalityId { get; set; }
        public string Occupation { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public double HeightCm { get; set; }
        public double HeightInch { get; set; }
        public double WeightKg { get; set; }
        public double WeightLbs { get; set; }
        public double BMI { get; set; }
        public double PreviousPolicyAmount { get; set; }
        public int IsAgeAdmitted { get; set; }
        public int IsSmoker { get; set; }
        public int IsFemaleRebate { get; set; }
        public int IsVIP { get; set; }
        public string RegisterDate { get; set; }
    }
}
