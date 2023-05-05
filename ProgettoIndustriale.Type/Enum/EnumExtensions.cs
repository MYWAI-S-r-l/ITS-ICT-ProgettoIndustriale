using System.ComponentModel;
using System.Reflection;
using ProgettoIndustriale.Type.Attribute;

namespace ProgettoIndustriale.Type.Enum;

public static class EnumExtensions
{
    public static string Description(this System.Enum e)
    {
        FieldInfo fi = e.GetType().GetField(e.ToString());
        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        string ret = attributes.Length > 0 ? attributes[0].Description : e.ToString();

        return ret;
    }

    public static string AliasInUI(this System.Enum e)
    {
        FieldInfo fi = e.GetType().GetField(e.ToString());
        AliasInUIAttribute[] attributes =
            (AliasInUIAttribute[])fi.GetCustomAttributes(typeof(AliasInUIAttribute), false);
        return attributes.Length > 0 ? attributes[0].AliasInUI : e.ToString();
    }
}
