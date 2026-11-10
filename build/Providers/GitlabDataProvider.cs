// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Platforma.Nuke;

/// <summary>
/// Содержит методы работы с gitlab api.
/// </summary>
public class GitlabDataProvider
{
    private readonly Regex _errorPattern = new(@"\{\s*\""message\""\:");
    private readonly JsonSerializerOptions _serializerOptions = new() { PropertyNameCaseInsensitive = true };
    private readonly string? _baseUrl;
    private readonly string _authToken;

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="nugetSource">Nuget source feed.</param>
    public GitlabDataProvider(NugetSource nugetSource)
    {
        IsDefinedNugetSource = nugetSource is { Url: not null, ClientId: not null, Secret: not null };
        _authToken = Convert.ToBase64String(
            Encoding.ASCII.GetBytes($"{nugetSource.ClientId ?? string.Empty}:{nugetSource.Secret ?? string.Empty}"));
        _baseUrl = nugetSource.Url?.Replace("/index.json", "/metadata/");
    }

    /// <summary>
    /// Возвращает, определены ли креды по nuget source.
    /// </summary>
    public bool IsDefinedNugetSource { get; }

    /// <summary>
    /// Последняя ошибка при получении информации о пакете из регистра.
    /// </summary>
    public string? LastError { get; set; }

    /// <summary>
    /// Возвращает, опубликована ли заданная версия пакета.
    /// </summary>
    /// <param name="packageId">Имя пакета.</param>
    /// <param name="version">Версия пакета.</param>
    /// <returns>Возвращает true, если пакет уже опубликован, false - не опубликован.</returns>
    public bool CheckPackage(string packageId, string version)
    {
        var packageInfos = GetPackageVersions(packageId);

        return packageInfos?.Any(x =>
            packageId.Equals(x.Name, StringComparison.OrdinalIgnoreCase) && x.Version == version) == true;
    }

    /// <summary>
    /// Возвращает доступные опубликованные версии пакета.
    /// </summary>
    /// <param name="packageId">Название пакета. Null - все пакеты в реестре.</param>
    public IList<NugetPackageInfo>? GetPackageVersions(string packageId)
    {
        if (string.IsNullOrEmpty(packageId) || !IsDefinedNugetSource)
            return null;

        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _authToken);

        var result = new List<NugetPackageInfo>();

        try
        {
            var url = GetPackageUrl(packageId);

            var jsonString = httpClient.DownloadString(url);

            // Ошибка загрузки
            if (!string.IsNullOrEmpty(LastError = GetErrorMessage(jsonString)))
                return null;

            var downloaded = JsonSerializer.Deserialize<PackageMetadata>(
                jsonString,
                _serializerOptions)!;

            result.AddRange(
                downloaded.items.SelectMany(x => x.items.Select(i => new NugetPackageInfo(
                    i.catalogEntry.id,
                    i.catalogEntry.version,
                    i.catalogEntry.published))));
        }
        catch
        {
            return null;
        }

        return result;
    }

    private string? GetErrorMessage(string jsonString)
    {
        if (_errorPattern.IsMatch(jsonString))
        {
            var errorInfo = JsonSerializer.Deserialize<ErrorInfo>(
                jsonString,
                _serializerOptions);

            return errorInfo?.Message ?? "Не удалось загрузить информацию о пакетах";
        }

        return null;
    }

    private string GetPackageUrl(string packageId)
    {
        return $"{_baseUrl}{packageId}/index.json";
    }

    /// <summary>
    /// Информация об обшибке.
    /// </summary>
    /// <param name="Message">Текст ошибки.</param>
    public record ErrorInfo(string Message);
}
