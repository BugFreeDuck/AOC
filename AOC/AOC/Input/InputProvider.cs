using System.Net;

namespace AOC.Input;

public interface IInputProvider
{
    Task<string> Get(short year, short day);
    IAsyncEnumerable<string> LineByLine(short year, short day);
}

public class InputProvider : IInputProvider
{
    private readonly HttpClient _httpClient;

    public InputProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> Get(short year, short day)
    {
        var content = await GetInput(year, day);
        return await content.ReadAsStringAsync();
    }

    public async IAsyncEnumerable<string> LineByLine(short year, short day)
    {
        var content = await GetInput(year, day);

        using var sr = new StreamReader(await content.ReadAsStreamAsync());
        while (!sr.EndOfStream)
        {
            yield return await sr.ReadLineAsync() ?? string.Empty;
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
