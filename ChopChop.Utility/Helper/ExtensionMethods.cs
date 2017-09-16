using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;



namespace ChopChop.Utility
{
    public static class ExtensionMethods
    {
        public static SelectList ToSelectList<TEnum>(this TEnum obj, object selectedValue)
  where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return new SelectList(Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                .Select(x =>
                    new SelectListItem
                    {
                        Text = x.DisplayName(),//Enum.GetName(typeof(TEnum), x),
                        Value = (Convert.ToInt32(x)).ToString()
                    }), "Value", "Text", selectedValue);
        }
        public static string DisplayName(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            EnumDisplayNameAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(EnumDisplayNameAttribute))
                        as EnumDisplayNameAttribute;

            return attribute == null ? value.ToString() : attribute.DisplayName;
        }
        

    }
}
