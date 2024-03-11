namespace RickAndMorty.Models
{
    public class ModeloPersonaje : DetallesPersonaje
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? species { get; set; }
        public string? image { get; set; }
        public string? status { get; set; }

    }

    public class DetallesPersonaje
    {
        public string? gender { get; set; }


    }
}
