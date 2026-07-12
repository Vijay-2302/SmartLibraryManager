using Playnite.SDK;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using Playnite.SmartLibraryManager.Utilities;

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

        public Plugin(IPlayniteAPI api) : base(api)
        {
        }

        public override IEnumerable<GameMenuItem> GetGameMenuItems(GetGameMenuItemsArgs args)
        {
            yield return new GameMenuItem
            {
                Description = "Smart Library Manager",
                Action = (menuArgs) =>
                {
                    if (args.Games.Count == 0)
                    {
                        PlayniteApi.Dialogs.ShowMessage("No game selected.");
                        return;
                    }
                    Game game = args.Games[0];

                    string normalizedTitle = TitleNormalizer.Normalize(game.Name);

                    PlayniteApi.Dialogs.ShowMessage(
                        $"Original: {game.Name}\n\nNormalized: {normalizedTitle}"
                    );
                }
            };
        }
    }
}