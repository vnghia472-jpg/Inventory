using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Tên Key Vault và Secret
string keyVaultName = "nghia2";
string secretName = "nghia";

// Endpoint Key Vault
var kvUri = new Uri($"https://{keyVaultName}.vault.azure.net/");

// Dùng Managed Identity (Azure tự cấp)
var client = new SecretClient(kvUri, new DefaultAzureCredential());

app.MapGet("/", async () =>
{
    KeyVaultSecret secret = await client.GetSecretAsync(secretName);
    return Results.Text(secret.Value, "text/plain; charset=utf-8");

});

app.Run();