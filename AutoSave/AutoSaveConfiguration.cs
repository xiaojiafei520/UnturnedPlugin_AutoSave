using Rocket.API;
namespace AutoSave
{
    public class AutoSaveConfiguration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public int SaveInterval;
        public string SaveMsg;
        public string MsgColor;

        public void LoadDefaults()
        {
            Enabled = true;
            SaveInterval = 180;
            SaveMsg = "服务器保存中...";
            MsgColor = "green";
        }
    }
}
