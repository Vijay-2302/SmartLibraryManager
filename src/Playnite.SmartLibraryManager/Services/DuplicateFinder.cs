using System.Collections.Generic;
using Playnite.SDK.Models;
using Playnite.SmartLibraryManager.Models;
using Playnite.SmartLibraryManager.Utilities;

namespace Playnite.SmartLibraryManager.Services;
public static class DuplicateFinder
{
    public static List<DuplicateGameGroup> FindDuplicates(IEnumerable<Game> games)
    {
        Dictionary<string, List<Game>> duplicateGames = new();
        foreach (Game game in games)
        {
            string normalizedTitle = TitleNormalizer.Normalize(game.Name);
            if(!duplicateGames.ContainsKey(normalizedTitle))
            {
                duplicateGames[normalizedTitle] = new List<Game>{ game };
            }
            else
            {
                duplicateGames[normalizedTitle].Add(game);
            }
        }
        List<DuplicateGameGroup> duplicateGroups = new();
        foreach (var item in duplicateGames)
        {
            if(item.Value.Count > 1) {
                var duplicateGameGroup = new DuplicateGameGroup {
                    NormalizedTitle = item.Key,
                    Games = item.Value
                };

                duplicateGroups.Add(duplicateGameGroup);
            }
        }
        return duplicateGroups;
    }
}