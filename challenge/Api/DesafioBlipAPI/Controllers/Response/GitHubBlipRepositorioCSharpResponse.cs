using System.Text.Json.Serialization;

namespace DesafioBlipAPI.Controllers.Response
{
    public class GitHubBlipRepositorioCSharpResponse
    {
        [JsonPropertyName("description")]
        public string? Descricao { get; set; }

        [JsonPropertyName("full_name")]
        public string? NomeCompleto { get; set; }

        [JsonPropertyName("avatar_url")]
        public string? AvatarUrl { get; set; }
    }
}
