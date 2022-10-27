using Microsoft.AspNetCore.Mvc;

namespace MvcClient.Controllers
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Net.Http.Headers;
    using Discord;
    using Discord.Rest;
    using Microsoft.AspNetCore.Authentication;

    public class GuildsController : Controller
    {
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            //var discord = new DiscordRestClient(new DiscordRestConfig
            //{
            //    DefaultRetryMode = RetryMode.RetryRatelimit | RetryMode.RetryTimeouts | RetryMode.Retry502
            //});

            //await discord.LoginAsync(TokenType.Bearer, accessToken, true);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var uri = new Uri($"https://discord.com/api/v10/users/@me/guilds");

            var response = await client.GetAsync(uri, cancellationToken);
            //response.Content.

            return View();
        }
    }
}
