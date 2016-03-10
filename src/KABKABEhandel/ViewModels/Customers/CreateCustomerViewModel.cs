using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KABKABEhandel.ViewModels.Customers
{
    public class CreateCustomerViewModel
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Du måste ange förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Du måste anve efternamn")]
        public string LastName { get; set; }

        [Display(Name = "Telefonnummer")]
        [Required(ErrorMessage = "Du måste ange telefonnummer")]
        public string Phone { get; set; }

        [Display(Name = "Gatuadress")]
        [Required(ErrorMessage = "Du måste ange gata och gatunummer")]
        public string Street { get; set; }

        [Display(Name = "Postnummer")]
        [Required(ErrorMessage = "Du måste ange postnummer")]
        public string Zip { get; set; }

        [Display(Name = "Postort")]
        [Required(ErrorMessage = "Du måste ange Postort")]
        public string City { get; set; }

        [Display(Name = "Land")]
        [Required(ErrorMessage = "Du måste ange land")]
        public string Country { get; set; }

        [Display(Name = "Godkänn våra köpvillkor")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Du måste godkänna våra köpvillkor!")]
        public bool AcceptTerms { get; set; }

    }
}
