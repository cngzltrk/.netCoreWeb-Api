using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appMvc.Models
{
    public class user
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Adınızı giriniz")]
        [StringLength(50,ErrorMessage ="Adınızı düzgün giriniz",MinimumLength =3)]
        public string userName { get; set; }
        [Required(ErrorMessage = "Soyadınızı giriniz")]
        [StringLength(50, ErrorMessage = "Soyadınızı düzgün giriniz", MinimumLength = 3)]
        public string userLastName { get; set; }
        [Required(ErrorMessage = "Lütfen geçerli Email giriniz")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli Email giriniz")]
        public string email { get; set; }
        public string pass { get; set; }
        public int accountId { get; set; }
        public accountType account { get; set; }
    }
    public class userLogin
    {
        [Required(ErrorMessage = "Lütfen geçerli Email giriniz")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli Email giriniz")]
        public string email { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string pass { get; set; }
    }
    public class accountType
    {
        public int ID { get; set; }
        public string accountName { get; set; }
    }
    public class creditType
    {
        public int ID { get; set; }
        public string creditName { get; set; }
    }
    public class interest
    {
        public int ID { get; set; }
        public virtual accountType account { get; set; }
        public virtual creditType credit { get; set; }
        public double value { get; set; }
    }
    public class Veri
    {
        public string tür { get; set; }
        public string krediAylık { get; set; }
        public int tutar { get; set; }
        public int ay { get; set; }

    }
    public static class Faiz
    {
        public static double faiz;
    }

}
