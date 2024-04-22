using DesafioBlipAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBlipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubBlipRepositorioCSharpController(IGitHubBlipRepositorioCSharpService gitHubService) : ControllerBase
    {
        private readonly IGitHubBlipRepositorioCSharpService _gitHubService = gitHubService;

        [HttpGet]
        public async Task<IActionResult> BuscarRepositoriosCsharpAntigosAsync()
        {
            try
            {
                var repositoriosCsharpAntigos = await _gitHubService.ExibirOsCincoRepositoriosMaisAntigosCSharpDaApiAsync(5);
                return Ok(repositoriosCsharpAntigos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro interno: {ex.Message}");
            }
        }
    }
}
