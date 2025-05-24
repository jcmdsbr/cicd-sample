using System.Text;
using System.Text.Json;
using Markdig;

namespace Ifsp.Api.Clients;

public interface IOpenAiService
{
    Task<string?> HandleAsync(ChatRequest request);
}

public record ChatRequest(string Name);

public class OpenAiService(HttpClient httpClient) : IOpenAiService
{
    public async Task<string?> HandleAsync(ChatRequest request)
    {
        var requestBody = new
        {
            model = "gpt-4.1-nano-2025-04-14",
            messages = new[]
            {
                new
                {
                    role = "user", content = $$"""
                                               
                                                               Você é um especialista em antropologia cultural e linguística. Sua tarefa é explicar, de forma clara, detalhada e objetiva, o significado do nome "{parametro}" nas seguintes culturas: indígenas (de diferentes regiões, especialmente América Latina), europeias, asiáticas e americanas (incluindo culturas nativas da América do Norte e do Sul).
                                               
                                                               Para cada grupo cultural, forneça:
                                               
                                                               1. Contexto histórico ou linguístico do nome.
                                                               2. Significados simbólicos ou culturais relevantes.
                                                               3. Exemplos ou variações se existirem.
                                               
                                                               Se o nome não tiver significado conhecido em alguma cultura, informe claramente que não há registro.
                                               
                                                               Formate a resposta de forma organizada, usando subtítulos para cada cultura.
                                               
                                                               Nome para análise: "{{request.Name}}"

                                               """
                }
            }
        };

        var json = JsonSerializer.Serialize(requestBody);
        using var content = new StringContent(json, Encoding.UTF8, "application/json");

        using var response = await httpClient.PostAsync(string.Empty, content);

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var jsonDocument = JsonDocument.Parse(responseBody);
        var message = jsonDocument.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return !string.IsNullOrEmpty(message) ? Markdown.ToPlainText(message) : message;
    }
}