using AutoMapper;
using DesafioBlipAPI.Controllers.Response;

namespace DesafioBlipAPI.Services
{
    public class GitHubBlipRepositorioCSharpService : IGitHubBlipRepositorioCSharpService
    {
        private readonly GitHubApiService _apiService;
        private readonly IMapper _mapper;

        public GitHubBlipRepositorioCSharpService(GitHubApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        public async Task<List<GitHubBlipRepositorioCSharpResponse>> ExibirOsCincoRepositoriosMaisAntigosCSharpDaApiAsync(int count)
        {
            var oldestCSharpRepos = await _apiService.BuscarRepositoriosCSharpAntigos(count);

            var repoResponses = _mapper.Map<List<GitHubBlipRepositorioCSharpResponse>>(oldestCSharpRepos);

            return repoResponses;
        }
    }
}
