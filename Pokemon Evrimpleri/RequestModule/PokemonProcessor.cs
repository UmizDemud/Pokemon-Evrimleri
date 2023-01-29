namespace Pokemon_Evrimpleri.RequestModule
{
    using Microsoft.AspNetCore.Http.Extensions;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using NuGet.Common;
    using Pokemon_Evrimpleri.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class PokemonProcessor
    {
        // Available paths: pokemon-species, pokemon/name, pokemon/id
        private const string BASE_URL = "https://pokeapi.co/api/v2/";
        public static Dictionary<int, PokemonModel> records { get; } = new Dictionary<int, PokemonModel>();

        public static async Task<T> Load<T>(string path)
        {
            using (HttpResponseMessage response = await RequestModule.FetchClient.GetAsync(path))
            {
                if (response.IsSuccessStatusCode)
                {
                    T body = await response.Content.ReadAsAsync<T>();

                    return body;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public static async Task Setup()
        {
            Pokemon temp;
            for (var i = 1; i <= 20; i++)
            {
                if (!records.ContainsKey(i))
                {
                    temp = await Load<Pokemon>(BASE_URL + "pokemon/" + (i));
                    records.Add(i, new PokemonModel(
                    char.ToUpper(temp.name[0]) + temp.name.Substring(1),
                    getTypes(temp),
                    temp.sprites.other.dream_world.front_default
                    ));
                }

            }
        }
        public static async Task<PokemonModel[]> ProcessIntoModel(int from, int limit)
        {
            PokemonModel[] result = new PokemonModel[limit];
            Pokemon temp;
            for (var i = 1; i <= limit; i++)
            {
                if (!records.ContainsKey(from + i))
                {
                    temp = await Load<Pokemon>(BASE_URL + "pokemon/" + (from + i));
                    result[i - 1] = new PokemonModel(
                    char.ToUpper(temp.name[0]) + temp.name.Substring(1),
                    getTypes(temp),
                    temp.sprites.other.dream_world.front_default
                    );
                    records.Add(from + i, result[i - 1]);
                }

                result[i - 1] = records[from + i];
            }

            return result;
        }
        public static async Task<PokemonModel> ProcessOneIntoModel(int id)
        {
            if (!records.ContainsKey(id))
            {
                var temp = await Load<Pokemon>(BASE_URL + "pokemon/" + id);
                records.Add(id, new PokemonModel(
                char.ToUpper(temp.name[0]) + temp.name.Substring(1),
                getTypes(temp),
                temp.sprites.other.dream_world.front_default
                ));
            }

            return records[id];
        }
        private static string[] getTypes(Pokemon poke)
        {
            string[] result = new string[poke.types.Length];
            for (int j = 0; j < poke.types.Length; j++)
            {
                result[j] = poke.types[j].type.name;
            }

            return result;
        }
    }
}
