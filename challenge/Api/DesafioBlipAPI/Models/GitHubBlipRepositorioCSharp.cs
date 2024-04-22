using System.Text.Json.Serialization;

namespace DesafioBlipAPI.Models
{
    public class GitHubBlipRepositorioCSharp
    {
        [JsonPropertyName("owner")]
        public GitHubBlipRepositorioCSharpOwner? Owner { get; set; }

        [JsonPropertyName("description")]
        public string? Descricao { get; set; }

        [JsonPropertyName("full_name")]
        public string? NomeCompleto { get; set; }

        [JsonPropertyName("language")]
        public string? Linguagem { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? DataDeCriacao { get; set; }
    }
}
