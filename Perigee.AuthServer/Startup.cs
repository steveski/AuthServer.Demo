// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Perigee.AuthServer;

using IdentityServer4;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public IWebHostEnvironment Environment { get; }

    public Startup(IWebHostEnvironment environment)
    {
        Environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // uncomment, if you want to add an MVC-based UI
        services.AddControllersWithViews();

        services.AddAuthentication()
            .AddGoogle("Google", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.ClientId = "xxx";
                options.ClientSecret = "yyy";
            })
            .AddFacebook("Facebook", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.ClientId = "xxx";
                options.ClientSecret = "yyy";
            })
            .AddTwitter("Twitter", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.ConsumerKey = "xxx";
                options.ConsumerSecret = "yyy";
            })
            .AddMicrosoftAccount("Microsoft", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.ClientId = "xxx";
                options.ClientSecret = "yyy";

            })
            .AddAmazon("Amazon", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.ClientId = "xxx";
                options.ClientSecret = "yyy";
            })
            .AddApple("Apple", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.ClientId = "xxx";
                options.ClientSecret = "yyy";
            })
            .AddDiscord("Discord", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.ClientId = "xxx";
                options.ClientSecret = "yyy";
                options.Scope.Add("guilds");
            })
            .AddInstagram("Instagram", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.ClientId = "xxx";
                options.ClientSecret = "yyy";
            });


        var builder = services.AddIdentityServer(options =>
        {
            // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
            options.EmitStaticAudienceClaim = true;
        })
            .AddInMemoryIdentityResources(AuthConfig.IdentityResources)
            .AddInMemoryApiScopes(AuthConfig.ApiScopes)
            .AddInMemoryClients(AuthConfig.Clients);

        if (Environment.IsDevelopment())
        {
            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            builder.AddTestUsers(TestUsers.Users);
        }

    }

    public void Configure(IApplicationBuilder app)
    {
        if (Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add MVC
        app.UseStaticFiles();
        app.UseRouting();
        
        app.UseIdentityServer();

        // uncomment, if you want to add MVC
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }

}
