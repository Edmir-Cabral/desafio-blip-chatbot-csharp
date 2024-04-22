using System.Text.Json.Serialization;

namespace DesafioBlipAPI.Models
{
    public class GitHubBlipRepositorioCSharpOwner
    {
        [JsonPropertyName("avatar_url")]
        public string? AvatarUrl { get; set; }
    }
}
