using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialType
{
    public class Coordinate : IParsable<Coordinate>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public static Coordinate Parse(string s, IFormatProvider? provider)
        {
            if (TryParse(s, provider, out var result))
            {
                return result;
            }
            throw new FormatException($"Invalid coordinate format: {s}");
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Coordinate result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result = null;
                return false;
            }

            var parts = s.Split(',');
            if (parts.Length == 2 &&
                double.TryParse(parts[0], out double latitude) &&
                double.TryParse(parts[1], out double longitude))
            {
                result = new Coordinate { Latitude = latitude, Longitude = longitude };
                return true;
            }

            result = null;
            return false;
        }
    }
}