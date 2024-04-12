using System.Collections.Generic;

namespace Expertsystem.Modules.ModuleName.Models.LocationData
{
    public class CountryStatesModel
    {
        public Dictionary<string, List<string>> CountryStates { get; set; }

        public Dictionary<string, string> CountryAreaCode { get; set; }

        public CountryStatesModel()
        {
            CountryStates = new Dictionary<string, List<string>>
            {
                {"US", new List<string>
                    {
                        "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
                        "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
                        "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
                        "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
                        "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
                    }
                },
                {"CA", new List<string>
                    {
                        "AB", "BC", "MB", "NB", "NL", "NS", "ON", "PE", "QC", "SK", "NT", "NU", "YT"
                    }
                },
                {"AU", new List<string>
                    {
                        "NSW", "QLD", "SA", "TAS", "VIC", "WA", "ACT", "NT"
                    }
                }
            };

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