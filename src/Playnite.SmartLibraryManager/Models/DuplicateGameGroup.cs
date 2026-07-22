using Playnite.SDK.Models;
using System.Collections.Generic;

namespace Playnite.SmartLibraryManager.Models;
public class DuplicateGameGroup
{
    public string NormalizedTitle { get; set; }
    public List<Game> Games { get; set; } = new List<Game>();
}