using BasisTheory.net.AspNetCore;

namespace ZeroCode_POC.Models
{
    public class CreatePersonDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [BasisTheorySsn]
        public string Ssn { get; set; }
    }
}