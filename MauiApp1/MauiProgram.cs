using System.Diagnostics;
using System.Text.Json;

namespace MauiApp1;

public static class MauiProgram
{
    static HttpClient _client;

    static String url = "http://localhost:5251/api/test";

    static JsonSerializerOptions _serializerOptions;

    public static List<String> Items { get; private set; }

    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        RefreshDataAsync();
        return builder.Build();
	}

    public static async Task<List<String>> RefreshDataAsync()
    {
        Items = new List<String>();

        Uri uri = new Uri(string.Format(url, string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<List<String>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return Items;
    }
}
