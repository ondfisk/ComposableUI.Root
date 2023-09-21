namespace ComposableUI.Root;

public class DownstreamApiConfiguration
{
    public required Uri BaseUrl { get; init; }
    public required string[] Scopes { get; init; }
}