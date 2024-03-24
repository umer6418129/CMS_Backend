using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CMS_Backend.Helpers
{
    public static class EnumHelper
    {
        public enum Gender
        {
            Male,
            Female,
            Other
        }
        public enum Status
        {
            Pending,
            Approved,
            Rejected
        }

        public static string getGender(int gender)
        {
            if (gender == 0)
            {
                string genderResult = "Male";
                return genderResult;
            }else if (gender == 1)
            {
                string genderResult = "Female";
                return genderResult;
            }
            else
            {
                string genderResult = "Other";
                return genderResult;
            }
        }
        public static string getStatus(int gender)
        {
            if (gender == 0)
            {
                string genderResult = "Pending";
                return genderResult;
            }else if (gender == 1)
            {
                string genderResult = "Approved";
                return genderResult;
            }
            else
            {
                string genderResult = "Rejected";
                return genderResult;
            }
        }

    }
}
