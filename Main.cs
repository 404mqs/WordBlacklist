using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Linq;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace WordBlacklist
{
    public class MQSPlugin : RocketPlugin<Config>

    {
        public static MQSPlugin Instance;

        protected override void Load()
        {
            {
                MQSPlugin.Instance = this;
                ChatManager.onChatted += onChat;
                Logger.LogWarning("++++++++++++++++++++++++++++++++++++++");
                Logger.LogWarning($"[{Name}] has been loaded! ");
                Logger.LogWarning("Dev: MQS#7816");
                Logger.LogWarning("Join this Discord for Support: https://discord.gg/Ssbpd9cvgp");
                Logger.LogWarning("++++++++++++++++++++++++++++++++++++++");

            }
        }

        protected override void Unload()
        {
            Logger.LogWarning("++++++++++++++++++++++++++++++++++++++");
            Logger.LogWarning($"[{Name}] has been unloaded! ");
            Logger.LogWarning("++++++++++++++++++++++++++++++++++++++");
            ChatManager.onChatted -= onChat;

        }

        private void onChat(SteamPlayer player, EChatMode mode, ref Color chatted, ref bool isRich, string text, ref bool isVisible)
        {
            {
                if (player.isAdmin && Configuration.Instance.IgnoreAdmins)
                {
                    return;
                }

                if (Configuration.Instance.Restricted.Any(w => w.name.ToLower().Contains(text.ToLower())))
                {
                    var iconURL = "https://png.pngtree.com/element_our/png_detail/20181205/forbidden-vector-icon-png_256703.jpg";
                    ChatManager.serverSendMessage(MQSPlugin.Instance.Translate("WordBlacklisted"), UnityEngine.Color.red, null, player, EChatMode.SAY, iconURL, true);
                    isVisible = false;

                }
            }
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "WordBlacklisted", "You said a word that is on the blacklist. Please moderate!" }

        };

    }
}


