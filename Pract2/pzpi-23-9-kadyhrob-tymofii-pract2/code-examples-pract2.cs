using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class InstagramApiClient
{
    private readonly HttpClient _httpClient;

    public InstagramApiClient(string token)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.instagram.com/");
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<string> GetUserFeedAsync()
    {
        HttpResponseMessage response =
            await _httpClient.GetAsync("feed");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}

class Program
{
    static async Task Main()
    {
        var client = new InstagramApiClient("USER_ACCESS_TOKEN");
        string feed = await client.GetUserFeedAsync();

        Console.WriteLine(feed);
    }
}




using System;
using System.Collections.Generic;

public class UserCache
{
    private readonly Dictionary<int, string> _cache = new Dictionary<int, string>();

    public void SaveUserProfile(int userId, string profileData)
    {
        _cache[userId] = profileData;
        Console.WriteLine("Дані профілю збережено в кеші.");
    }

    public string GetUserProfile(int userId)
    {
        if (_cache.ContainsKey(userId))
        {
            Console.WriteLine("Дані отримано з кешу.");
            return _cache[userId];
        }

        Console.WriteLine("Дані відсутні в кеші.");
        return null;
    }
}

class Program
{
    static void Main()
    {
        var cache = new UserCache();

        cache.SaveUserProfile(1, "Username: user123, Followers: 1500");

        string profile = cache.GetUserProfile(1);

        Console.WriteLine(profile);
    }
}

