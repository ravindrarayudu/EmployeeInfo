using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.Common.Extensions
{
    public static class ObjExtensions
    {
        public static void IfNotNullCallAction<T>(this T obj, Action<T> action, Action actionIfNull = null) where T : class
        {
            if (obj != null)
            {
                action(obj);
            }
            else if (actionIfNull != null)
            {
                actionIfNull();
            }
        }
    }
}
