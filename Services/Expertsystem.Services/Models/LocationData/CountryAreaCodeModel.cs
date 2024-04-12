using System.Collections.Generic;

namespace Expertsystem.Models.LocationData
{
    public class CountryAreaCodeModel
    {
        public Dictionary<string, string> CountryAreaCode { get; set; }

        public CountryAreaCodeModel()
        {
            CountryAreaCode = new Dictionary<string, string>
            {
                {"US", "+1"},
                {"CA", "+1"},
                {"AU", "+61"},
                {"GB", "+44"},
                {"DE", "+49"},
                {"FR", "+33"},
                {"IT", "+39"},
                {"JP", "+81"},
                {"BR", "+55"},
                {"IN", "+91"},
                {"CN", "+86"},
                {"RU", "+7"},
            };
        }
    }
}
