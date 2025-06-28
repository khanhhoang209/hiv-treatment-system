using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Repository.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        var member = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault();
        if (member == null) return enumValue.ToString();

        var display = member.GetCustomAttribute<DisplayAttribute>();
        return display?.GetName() ?? enumValue.ToString();
    }
}