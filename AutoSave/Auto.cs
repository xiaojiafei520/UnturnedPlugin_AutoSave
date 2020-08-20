using Logger = Rocket.Core.Logging.Logger;
using Rocket.Core.Plugins;
using System;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using UnityEngine;

namespace AutoSave
{
    public class AutoSave : RocketPlugin<AutoSaveConfiguration>
    {
        protected override void Load()
        {
            Logger.LogWarning("####################################");
            Logger.LogWarning("#            AutoSave              #");
            Logger.LogWarning("#              v 1.1               #");
            Logger.LogWarning("#          QQ:2946491890           #");
            Logger.LogWarning("#          SmallGarfield           #");
            Logger.LogWarning("####################################");
            Instance = this;
        }

        protected override void Unload()
        {
        }

        public void FixedUpdate()
        {
            AutoSaveEvent();
        }

        public static AutoSave Instance;
        public DateTime start = DateTime.Now;
        public bool msgYorN;
        public void AutoSaveEvent()
        {
            if (!Configuration.Instance.Enabled)
            {
                return;
            }
            if (start != null && (DateTime.Now - start).TotalSeconds > Configuration.Instance.SaveInterval)
            {
                if (!msgYorN)
                {
                    UnturnedChat.Say(Configuration.Instance.SaveMsg, UnturnedChat.GetColorFromName(Configuration.Instance.MsgColor, Color.green));
                    msgYorN = true;
                }
                SaveManager.save();
                msgYorN = false;
                start = DateTime.Now;
                Logger.Log("Saved at " + DateTime.Now);
            }
        }
    }
}
