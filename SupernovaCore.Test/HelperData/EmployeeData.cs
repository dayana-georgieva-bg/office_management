using SupernovaCore.ViewModel;
using System;

namespace SupernovaCore.Test.HelperData
{
    public class EmployeeData
    {

        public static SupernovaModel GetEmployeeData()
        {
            return new SupernovaModel
            {
                FirstName = "Toni",
                SecondName = "Il.",
                LastName = "Dimitrov",
                Address = "Sofia, Steep mountain street",
                Birthday = new DateTime(1990, 08, 08),
                MobilePhone = "01234567890",
                CompanyMobileNumber = 0888777666,
                Email = "toni@toni",
                LaptopModel = "Dell",
            };
        }
    }
}
