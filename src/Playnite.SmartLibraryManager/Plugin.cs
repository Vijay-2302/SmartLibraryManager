using Playnite.SDK;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using Playnite.SmartLibraryManager.Services;

namespace Playnite.SmartLibraryManager
{
    public class Plugin : GenericPlugin
    {
        public override Guid Id
        {
            get
            {
                return Guid.Parse("b9b4819d-8744-4b98-a1c5-61d8a87d4b4e");
            }
        }

        public Plugin(IPlayniteAPI api) : base(api){}

        public override IEnumerable<MainMenuItem> GetMainMenuItems(GetMainMenuItemsArgs args)
        {
            yield return new MainMenuItem
            {
                MenuSection = "@Smart Library Manager",
                Description = "Find Duplicate Games",
                Action = (menuArgs) =>
                {
                    var duplicateGames = DuplicateFinder.FindDuplicates(
                        PlayniteApi.Database.Games);
                    PlayniteApi.Dialogs.ShowMessage(duplicateGames.Count + " Duplicates Found");
                }
            };
        }
    }
}