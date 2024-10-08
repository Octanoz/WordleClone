﻿using System.Text.Json.Serialization;

namespace WordleClone.Frontend.Components.Model;

public class WordDefinition
{
    public string Word { get; set; }
    public List<Phonetic> Phonetics { get; set; }
    public List<Meaning> Meanings { get; set; }
    public License License { get; set; }
    public List<string> SourceUrls { get; set; }
}

public class Definition
{
    [JsonPropertyName("definition")]
    public string Defined { get; set; }
    public List<object> Synonyms { get; set; }
    public List<object> Antonyms { get; set; }
    public string Example { get; set; }
}

public class License
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Meaning
{
    public string PartOfSpeech { get; set; }
    public List<Definition> Definitions { get; set; }
    public List<string> Synonyms { get; set; }
    public List<string> Antonyms { get; set; }
}

public class Phonetic
{
    public string Audio { get; set; }
    public string SourceUrl { get; set; }
    public License License { get; set; }
    public string Text { get; set; }
}



