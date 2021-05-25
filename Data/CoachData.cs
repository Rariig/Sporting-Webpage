using SportEU.Data.Common;

namespace SportEU.Data
{
    public sealed class CoachData : PersonData
    {

        public decimal Salary { get; set; }
        public string Speciality { get; set; }
        public string PhoneNumber { get; set; }

    }
}
