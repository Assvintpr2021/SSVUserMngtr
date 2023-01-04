using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using UserManagement.Attributes;

namespace UserManagement.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Countries = getCountryList();
            GenderList = getGenderList();
        }

        #region "Cascading methods"
        public List<SelectListItem> getCountryList()
        {
            List<SelectListItem> countryList = new List<SelectListItem>() {
                new SelectListItem{ Text = "India", Value = "1"},
                new SelectListItem { Text = "USA", Value="2"},
                new SelectListItem{ Text = "Canada", Value="3"},
                new SelectListItem{ Text = "Australia", Value ="4"}
            };
            return countryList;
        }
        public List<SelectListItem> getGenderList()
        {
            List<SelectListItem> GenderList = new List<SelectListItem> {
                new SelectListItem{ Text ="Male",Value = "1"},
                new SelectListItem{Text ="Female",Value="2"}
            };
            return GenderList;
        }
        public List<SelectListItem> getCitybyCountryId(int countryId)
        {
            List<SelectListItem> cityList = new List<SelectListItem>();
            if (countryId == 1)
            {
                cityList = new List<SelectListItem>()
                {
                    new SelectListItem{Text="New Delhi",Value="1"},
                    new SelectListItem{Text="Gurgaon",Value ="2"},
                    new SelectListItem{Text="Mumbai",Value="3"},
                    new SelectListItem{Text="Pune",Value="4"}
                };
            }
            else if (countryId == 2)
            {
                cityList = new List<SelectListItem>()
                {
                    new SelectListItem{Text="NJ",Value="1"},
                    new SelectListItem{Text="NY",Value ="2"}
                };
            }
            else if (countryId == 3)
            {
                cityList = new List<SelectListItem>()
                {
                    new SelectListItem{Text="Toronto",Value="1"},
                    new SelectListItem{Text="Ottawa",Value ="2"}
                };
            }
            else if (countryId == 4)
            {
                cityList = new List<SelectListItem>()
                {
                    new SelectListItem{Text="Melbourne",Value="1"},
                    new SelectListItem{Text="Sydney",Value ="2"}
                };
            }
            else
            {
                cityList = new List<SelectListItem>()
                {
                    new SelectListItem{ Text ="Other",Value="1"}
                };
            }
            return cityList;
        }
        #endregion

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Password doesn't match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [RegularExpression("^[6789]\\d{9}", ErrorMessage = "Please Enter Correct Contact No")]
        public string? Contact { get; set; }
        public List<SelectListItem> Countries { get; set; }
        [Required(ErrorMessage = "Please Select Country")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public List<SelectListItem>? Cities { get; set; }
        [Required(ErrorMessage = "Please Select City")]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public List<SelectListItem> GenderList { get; set; }
        [Required(ErrorMessage = "Gender Required")]
        public string Gender { get; set; }

        [ValidateCheckBox(ErrorMessage = "Please Accept Terms")]
        [Display(Name = "I Accept Terms and Conditions")]
        public bool Terms { get; set; }
    }
}
