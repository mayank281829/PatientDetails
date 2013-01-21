using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using PatientDetails.Models;
using System.Web.Mvc;

namespace PatientDetails.Models
{
    public class NewPatient
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Your Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Your Contactno.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Numbers Only")]
        [StringLength(10,ErrorMessage = "Not more than 10")]
        public string Contactno { get; set; }
        //[RegularExpression(@"^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$", ErrorMessage = "Date Should be in MM/DD/YYYY")]
        [Required(ErrorMessage ="Enter Your DOB")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        //[DataType(DataType.Date)]
        //[DateRange("1900/01/01")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Enter Your City")]
        public string City { get; set; }
       
    }
}