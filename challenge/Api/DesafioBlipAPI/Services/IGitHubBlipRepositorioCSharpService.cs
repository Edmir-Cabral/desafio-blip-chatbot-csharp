using DesafioBlipAPI.Controllers.Response;

namespace DesafioBlipAPI.Services
{
    public interface IGitHubBlipRepositorioCSharpService
    {
        Task<List<GitHubBlipRepositorioCSharpResponse>> ExibirOsCincoRepositoriosMaisAntigosCSharpDaApiAsync(int count);
    }
}
