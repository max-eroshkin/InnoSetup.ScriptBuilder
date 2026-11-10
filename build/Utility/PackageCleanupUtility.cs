// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

/// <summary>
/// Содержит методы очистки пакетов в гитлабе.
/// <code>
/// PackageCleanupUtility.Print(From&lt;IPublish&gt;(), x => x.VersionType == VersionType.Feature);
/// PackageCleanupUtility.Delete(From&lt;IPublish&gt;(), x => x.VersionType == VersionType.Feature);
/// </code>
/// </summary>
[PublicAPI]
public static class PackageCleanupUtility
{
    /// <summary>
    /// Выводит в консоль все пакеты.
    /// </summary>
    /// <param name="build">IPublish build.</param>
    public static void PrintAll(IPublish build)
    {
        var packageInfos = DownloadPackageInfos(build);

        foreach (var nameGrouping in packageInfos.GroupBy(x => x.Name))
        {
            Console.WriteLine(nameGrouping.Key);

            foreach (var versionGrouping in nameGrouping
                         .GroupBy(x => x.VersionComponents)
                         .OrderByDescending(x => x.Key))
            {
                HostUtility.Debug($"   {versionGrouping.Key}");

                foreach (var packageInfo in versionGrouping.OrderDescending())
                {
                    Console.WriteLine("       {0}  ({1:yyyy.MM.dd})", packageInfo.Version, packageInfo.CreatedAt);
                }
            }
        }
    }

    /// <summary>
    /// Выводит в консоль пакеты в соответствии с фильтром <paramref name="predicate"/>.
    /// </summary>
    /// <param name="build">IPublish build.</param>
    /// <param name="predicate">predicate.</param>
    public static void Print(
        IPublish build,
        Func<NugetPackageInfo, bool> predicate)
    {
        var packageInfos = DownloadPackageInfos(build);
        var toDelete = packageInfos
            .Where(predicate)
            .OrderByDescending(x => x.CreatedAt)
            .GroupBy(x => x.Name);

        int count = 0;
        foreach (var grouping in toDelete)
        {
            HostUtility.Debug($"*** {grouping.Key}");
            var keep = grouping.First();
            HostUtility.Warning(keep.Version);
            foreach (var delete in grouping.Skip(1))
            {
                HostUtility.Error(delete.Version);
                count++;
            }
        }

        HostUtility.Debug($"Total {count} to delete");
    }

    /// <summary>
    /// Удаляет пакеты в соответствии с фильтром <paramref name="predicate"/>.
    /// </summary>
    /// <param name="build">IPublish build.</param>
    /// <param name="predicate">predicate.</param>
    public static void Delete(
        IPublish build,
        Func<NugetPackageInfo, bool> predicate)
    {
        var packageInfos = DownloadPackageInfos(build);
        var toDelete = packageInfos
            .Where(predicate)
            .OrderByDescending(x => x.CreatedAt)
            .GroupBy(x => x.Name);

        var httpClient = new HttpClient();
        var baseUrl = build.NugetSource!.Replace("/nuget/index.json", string.Empty);

        int count = 0;
        foreach (var grouping in toDelete)
        {
            HostUtility.Debug($"*** {grouping.Key}");
            var keep = grouping.First();
            HostUtility.Warning(keep.Version);
            foreach (var delete in grouping.Skip(1))
            {
                var url = $"{baseUrl}/{delete.Id}?private_token={build.NugetApiKey}";
                httpClient.DeleteAsync(url).Wait();
                HostUtility.Error($"{delete.Version} deleted");
                count++;
            }
        }

        HostUtility.Debug($"Total {count} deleted");
    }

    private static IEnumerable<NugetPackageInfo> DownloadPackageInfos(IPublish ipublish)
    {
        JsonSerializerOptions serializerOptions = new() { PropertyNameCaseInsensitive = true };

        var baseUrl = ipublish.NugetSource!.Replace("/nuget/index.json", string.Empty);

        int page = 1;

        var httpClient = new HttpClient();

        do
        {
            var url = $"{baseUrl}?private_token={ipublish.NugetApiKey}" +
                      $"&per_page=100&page={page}&package_type=nuget&order_by=created_at&sort=asc";

            var jsonString = httpClient.DownloadString(
                url,
                headers =>
                {
                    if (headers.TryGetValues("X-Next-Page", out var values) &&
                        int.TryParse(values.First(), out var pageNumber))
                    {
                        page = pageNumber;
                    }
                    else
                    {
                        page = -1;
                    }
                });

            var packageInfos = JsonSerializer.Deserialize<List<NugetPackageInfo>>(
                jsonString,
                serializerOptions)!;

            foreach (var packageInfo in packageInfos)
            {
                yield return packageInfo;
            }
        }
        while (page > 0);
    }
}
