using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace poc.console
{
    public static class EnumExtension
    {
        public static string EnumDisplayAttribute(this Enum value)
        {
            if (value is null)
                return string.Empty;

            return !(value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false)
                .SingleOrDefault() is DisplayAttribute attribute) ? value.ToString() : attribute.Description;
        }
    }

}
