using System.Net;

namespace AOC.Solvers;

public class InputProvider : IInputProvider
{
    private readonly HttpClient _httpClient;

    public InputProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IEnumerable<string> LineByLine(short year, short day)
    {
        var content = GetInput(year, day).Result;
        using var sr = new StreamReader(content.ReadAsStream());
        while (!sr.EndOfStream)
        {
            yield return sr.ReadLine() ?? string.Empty;
        }
    }

    private async Task<HttpContent> GetInput(short year, short day)
    {
        var url = $"{year}/day/{day}/input";
        var response = await _httpClient.GetAsync(url);
        if (response.StatusCode != HttpStatusCode.OK)
            throw new HttpRequestException($"Exception occured while getting input for {year}/{day}");

        return response.Content;
    }
}
