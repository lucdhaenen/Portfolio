using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace WebsiteLD.Models
{
    public class Contact
    {
        [Required(ErrorMessage="Voornaam is een verplicht veld")]        
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Familienaam is een verplicht veld")]
        public string Familienaam { get; set; }

        [Required(ErrorMessage = "Email is een verplicht veld")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Foutief email adres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Onderwerp is een verplicht veld")]
        public string Onderwerp { get; set; }

        [Required(ErrorMessage = "Bericht is een verplicht veld")]
        public string Bericht { get; set; }

        public string BuildMessage()
        {
            var msg = new StringBuilder();
            msg.AppendFormat("Van: {0}\n", Voornaam + " " + Familienaam);
            msg.AppendFormat("Email: {0}\n", Email);
            msg.AppendFormat("Onderwerp: {0}\n", Onderwerp);
            msg.AppendFormat("Bericht: {0}\n", Bericht);
            return msg.ToString();
        }
    }
}