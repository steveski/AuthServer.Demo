namespace Perigee.AuthServer;

using System.Collections.Generic;

public class Config : IConfig
{
    public Dictionary<string, IIdentityProvider> IdentityProviders { get; set; }

}

public interface IConfig
{
    Dictionary<string, IIdentityProvider> IdentityProviders { get; set; }
}

public interface IIdentityProvider
{
    string ClientId { get; set; }
    string ClientSecret { get; set; }

}

public class IdentityProvider : IIdentityProvider
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}
