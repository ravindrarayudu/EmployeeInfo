using EmployeeInfo.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeInfo.Data.DataContext
{
    public static class EmployeeInfoInitializer
    {
        public static void Initialize(EmployeeInfoContext context)
        {
            if (StaticConfigs.GetConfig("UseInMemoryDatabase") != "true")
            {
                context.Database.EnsureCreated();
            }
            if (context.Country.Any())
            {
                return;
            }
        }
    }
}
