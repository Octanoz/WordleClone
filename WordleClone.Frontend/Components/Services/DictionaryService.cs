using System.Text.Json;
using WordleClone.Frontend.Components.Model;

namespace WordleClone.Frontend.Components.Services;

public class DictionaryService(HttpClient httpClient)
{
    private readonly HttpClient httpClient = httpClient;
    public async Task<WordDefinition> GetWordDefinition(string word)
    {
        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
        try
        {
            var response = await httpClient.GetStringAsync($"https://api.dictionaryapi.dev/api/v2/entries/en/{word}");
            var wordDefinitions = JsonSerializer.Deserialize<List<WordDefinition>>(response, options);

            return wordDefinitions?.FirstOrDefault() ?? FallbackDefinition(word);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching definition: {ex.Message}");
            return FallbackDefinition(word);
        }
    }

    private static WordDefinition FallbackDefinition(string word) => new()
    {
        Word = word,
        Meanings =
        [
            new Meaning
        {
            PartOfSpeech = "Unknown",
            Definitions =
            [
                new Definition
                {
                    Defined = "Definition not found."
                }
            ]
        }
        ]
    };
}
