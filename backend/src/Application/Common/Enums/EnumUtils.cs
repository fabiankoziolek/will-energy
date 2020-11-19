using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace WillEnergy.Application.Common.Enums
{
    public static class EnumUtils
    {
        public static bool TryParseWithMemberName<TEnum>(string value, out TEnum result)
            where TEnum : struct
        {
            result = default;

            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            var enumType = typeof(TEnum);

            foreach (var name in Enum.GetNames(typeof(TEnum)))
            {
                if (name.Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    result = Enum.Parse<TEnum>(name);
                    return true;
                }

                var memberAttribute
                    = enumType.GetField(name).GetCustomAttribute(typeof(EnumMemberAttribute)) as EnumMemberAttribute;

                if (memberAttribute is null)
                {
                    continue;
                }

                if (memberAttribute.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    result = Enum.Parse<TEnum>(name);
                    return true;
                }
            }

            return false;
        }

        public static TEnum GetEnum<TEnum>(string value)
            where TEnum : struct
        {
            return TryParseWithMemberName(value, out TEnum result)
                ? result
                : throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("Type", "Value not supported.") });
        }
    }
}
