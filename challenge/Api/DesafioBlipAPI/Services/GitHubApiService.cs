using DesafioBlipAPI.Models;
using System.Text.Json;

namespace DesafioBlipAPI.Services
{
    public class GitHubApiService(IHttpClientFactory httpClientFactory)
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<List<GitHubBlipRepositorioCSharp>> BuscarRepositoriosCSharpAntigos(int count)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://api.github.com/");
            client.DefaultRequestHeaders.Add("User-Agent", "GitHubApi");

            var repositoriosCSharpAntigos = new List<GitHubBlipRepositorioCSharp>();
            var paginas = 1;
            var porPaginas = 100;

            while (repositoriosCSharpAntigos.Count < count)
            {
                var response = await client.GetAsync($"users/takenet/repos?page={paginas}&per_page={porPaginas}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Falha ao buscar repositórios. Status code: {response.StatusCode}");
                }

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var paginasRepositorios = await JsonSerializer.DeserializeAsync<List<GitHubBlipRepositorioCSharp>>(responseStream, _jsonSerializerOptions);

                if (paginasRepositorios == null)
                {
                    throw new Exception("A lista de repositórios da página é nula.");
                }

                foreach (var repo in paginasRepositorios)
                {
                    if (repo.Linguagem == "C#")
                    {
                        repositoriosCSharpAntigos.Add(repo);

                        if (repositoriosCSharpAntigos.Count >= count)
                        {
                            break;
                        }
                    }
                }

                paginas++;

                if (paginasRepositorios.Count < porPaginas)
                {
                    break;
                }
            }

            repositoriosCSharpAntigos = repositoriosCSharpAntigos.OrderBy(repo => repo.DataDeCriacao).Take(count).ToList();

            return repositoriosCSharpAntigos;
        }
    }
}
