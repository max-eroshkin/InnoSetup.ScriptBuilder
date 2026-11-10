// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Net.Http;
using System.Net.Http.Headers;

/// <summary>
/// Содержит методы работы с <see cref="HttpClient"/>.
/// </summary>
public static class HttpClientExtensions
{
    /// <summary>
    /// Загружает строку.
    /// </summary>
    /// <param name="client"><see cref="HttpClient"/>.</param>
    /// <param name="url">Url.</param>
    /// <param name="headers">Headers.</param>
    public static string DownloadString(this HttpClient client, string url, Action<HttpResponseHeaders>? headers = null)
    {
        var response = client.GetAsync(url).GetAwaiter().GetResult();

        headers?.Invoke(response.Headers);

        return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    }
}
