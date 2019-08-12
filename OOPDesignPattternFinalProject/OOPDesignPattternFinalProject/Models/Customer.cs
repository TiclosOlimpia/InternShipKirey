
namespace OOPDesignPatternFinalProject.Models
{
    public class Customer
    {
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }

        public Customer(string stateCode, string zipCode, string county)
        {
            StateCode = stateCode;
            ZipCode = zipCode;
            County = county;
        }
    }
}
