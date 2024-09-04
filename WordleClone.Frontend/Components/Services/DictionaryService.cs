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

            return wordDefinitions.FirstOrDefault() ?? new WordDefinition()
            {
                Word = "word not found",
                Meanings =
                [
                    new Meaning()
                    {
                        PartOfSpeech = "noun",
                        Definitions =
                        [
                            new Definition()
                            {
                                Defined = "word not found"
                            }
                        ]
                    }
                ]
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null!;
        }
    }
}
