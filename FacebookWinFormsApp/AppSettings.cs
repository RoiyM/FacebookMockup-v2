using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace BasicFacebookFeatures
{
    public class AppSettings
    {
        public Point LastWindowLocation { get; set; }

        public Size LastWindowSize { get; set; }

        public bool RememberUser { get; set; }

        public string LastAccessToken { get; set; }

        private AppSettings()
        {
            LastWindowLocation = new Point(60, 105);
            LastWindowSize = new Size(1057, 562);
            RememberUser = false;
            LastAccessToken = null;
        }

        public static AppSettings LoadFromFile()
        {
            AppSettings instance = new AppSettings();

            if (File.Exists(@"appSettings.xml"))
            {
                using (Stream stream = new FileStream(@"appSettings.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    instance = serializer.Deserialize(stream) as AppSettings;
                }
            }

            return instance;
        }

        public void SaveToFile()
        {
            using (Stream stream = new FileStream(@"appSettings.xml", FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }
    }
}
