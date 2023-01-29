namespace Pokemon_Evrimpleri.Models
{
    public class Sprites
    {
        public SVGRepository other { get; set; }
    }
    public class SVGRepository
    {
        public DW dream_world { get; set; }
    }
    public class DW
    {
        public string front_default { get; set; }
    }
    public class Type
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class TypeOrder
    {
        public int slot { get; set; }
        public Type type { get; set; }
    }
    public class Single
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class PokemonSpecies
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public Single[] results { get; set; }
    }
    public class Pokemon
    {
        public string name { get; set; }
        public TypeOrder[] types { get; set; }
        public Sprites sprites { get; set; }
    }
}
