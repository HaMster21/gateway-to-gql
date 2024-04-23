﻿namespace gateway;

public static class ServiceSchemas
{
    public static ServiceSchemaEndpoint Spieler = new() { ServiceName = "spieler", SchemaEndpoint = new Uri("http://spieler:8080/graphql/") };
}

public class ServiceSchemaEndpoint
{
    public string ServiceName { get; init; } = string.Empty;
    public Uri SchemaEndpoint { get; init; } = new Uri("http://localhost");
}
