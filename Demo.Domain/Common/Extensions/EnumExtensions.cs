using Demo.Domain.Enums;

namespace Demo.Domain.Common.Extensions;

public static class EnumExtensions
{
    public static readonly string CategoryValidList = string.Join(", ", Category.List.Select(x => x.Name + "-" + x.Value));
}
