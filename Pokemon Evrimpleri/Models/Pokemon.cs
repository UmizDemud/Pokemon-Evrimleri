using static System.Net.WebRequestMethods;

namespace Pokemon_Evrimpleri.Models
{
    public class PokemonModel
    {
        public string name { get; set; }
        public object[] types { get; set; }
        public string imageUrl { get; set; }

        public PokemonModel(string _name, string[] _types, string _imageUrl)
        {
            name = _name;
            types = _types;
            imageUrl= _imageUrl;
        }
    }
}
