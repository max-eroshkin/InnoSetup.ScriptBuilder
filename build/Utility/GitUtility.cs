// Copyright (c) 2023-2026 Platforma. All rights reserved.

namespace Ci;

using System.Collections.Generic;
using System.Linq;
using Fallout.Common.Tooling;
using Serilog;
using static Fallout.Common.Tools.Git.GitTasks;

/// <summary>
/// Содержит методы для работы с git-репозиторием.
/// </summary>
[PublicAPI]
public static class GitUtility
{
    /// <summary>
    /// Возвращает апстримы ветки.
    /// </summary>
    public static IEnumerable<string> GetRemotes() => Git("remote").Select(x => x.Text);

    /// <summary>
    /// Создает новую ветку.
    /// </summary>
    /// <param name="name">Имя ветки.</param>
    public static void NewBranch(string name)
    {
        Git($"branch {name}");
    }

    /// <summary>
    /// Переключается на ветку.
    /// </summary>
    /// <param name="branchName">Имя ветки.</param>
    public static void Checkout(string branchName)
    {
        Git($"checkout {branchName}");
    }

    /// <summary>
    /// Вытягивает ветку.
    /// </summary>
    /// <param name="branchName">Имя ветки.</param>
    public static bool? Fetch(string branchName)
    {
        if (!HasRemote())
            return null;

        var heads = Git("ls-remote --heads", logOutput: false, logInvocation: false)
            .Select(x => x.Text.Replace("refs/heads/", string.Empty))
            .ToList();

        // фетчим, если ветка существует в апстриме
        if (heads.Contains(branchName, StringComparer.InvariantCultureIgnoreCase))
        {
            Git($"fetch -q origin {branchName}");
            return true;
        }

        return false;
    }

    /// <summary>
    /// Удаляет ветку.
    /// </summary>
    /// <param name="branchName">Имя ветки.</param>
    public static void DeleteBranch(string branchName)
    {
        Git($"branch -D {branchName}");
        foreach (var remote in GetRemotes())
        {
            DeleteRemote(remote, branchName);
        }
    }

    /// <summary>
    /// Удаляет ветку из апстрима.
    /// </summary>
    /// <param name="upstream">Апстрим.</param>
    /// <param name="branchName">Имя ветки.</param>
    public static void DeleteRemote(string upstream, string branchName)
    {
        Git($"push --porcelain {upstream} :refs/heads/{branchName}");
    }

    /// <summary>
    /// Сливает ветку в текущую.
    /// </summary>
    /// <param name="branchName">Имя ветки для слияния.</param>
    /// <param name="takeOurs">В случае конфликта оставлять свой вариант.</param>
    public static void Merge(string branchName, bool takeOurs = false)
    {
        ArgumentStringHandler arguments = $"merge {branchName} --no-ff --message ";
        arguments.AppendFormatted($"Merge branch '{branchName}'");
        if (takeOurs)
            arguments.AppendLiteral(" -s recursive -X ours");

        Git(arguments);
    }

    /// <summary>
    /// Ставит тег на текущем коммите.
    /// </summary>
    /// <param name="name">Имя тега.</param>
    /// <param name="hash">Хеш коммита.</param>
    public static void Tag(string name, string? hash = null)
    {
        Git($"tag {name} {hash ?? string.Empty}");
    }

    /// <summary>
    /// Возвращает хеш текущего коммита.
    /// </summary>
    public static string GetCurrentCommitHash() => Git("rev-parse HEAD").First().Text;

    /// <summary>
    /// Проверяет что ветка актуализирована.
    /// </summary>
    /// <param name="branchName">Имя ветки.</param>
    public static bool IsBranchUpToDate(string branchName)
    {
        var branches = Git("branch --list").Where(x => x.Text.EndsWith(branchName, StringComparison.Ordinal)).ToList();
        if (!Git($"branch --list {branchName}").Any())
        {
            Log.Error("Local branch {branchName} not found", branchName);
            return false;
        }

        var remotes = GetRemotes();
        var localCommitsCount = Convert.ToInt32(Git($"rev-list --count {branchName}").FirstOrDefault().Text);

        foreach (var remote in remotes)
        {
            if (!Git($"branch --list -a {remote}/{branchName}").Any())
            {
                Log.Error("Remote branch {remote}/{branchName} not found", remote, branchName);
                return false;
            }

            var remoteHash = Convert.ToInt32(Git($"rev-list --count {remote}/{branchName}").FirstOrDefault().Text);
            if (localCommitsCount < remoteHash)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Возвращает, есть ли апстримы.
    /// </summary>
    public static bool HasRemote()
    {
        var output = Git("remote");
        return output.Any();
    }

    /// <summary>
    /// Возвращает название текущей ветки.
    /// </summary>
    public static string GetCurrentBranch()
    {
        var result = Git("branch --show-current").First().Text;
        return result;
    }

    /// <summary>
    /// Гарантирует, что существует заданная ветка.
    /// </summary>
    /// <param name="branch">Имя ветки.</param>
    public static void EnsureBranch(string branch)
    {
        if (Fetch(branch) == false)
        {
            NewBranch(branch);
        }
    }

    /// <summary>
    /// Возвращает список тэгов.
    /// </summary>
    public static IList<string> GetTagList()
    {
        return Git("tag", logOutput: false, logInvocation: false)
            .Select(x => x.Text)
            .ToList();
    }
}
