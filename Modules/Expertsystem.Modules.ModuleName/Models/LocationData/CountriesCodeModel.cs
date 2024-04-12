namespace Expertsystem.Modules.ModuleName.Models.LocationData
{
    public class CountriesCodeModel
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public CountriesCodeModel(string name, string code)
        {
            Name = name;
            Code = code;
        }

    }
}

