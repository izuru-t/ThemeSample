using System.Configuration;
using System.Drawing;
using System.Xml;

namespace Kanami.Windows.Froms.Controls
{
    /// <summary>
    /// 共通設定情報の取得
    /// </summary>
    public class CommonSetting
    {
        private XmlDocument xdoc = new XmlDocument();
        private XmlNode themeNode;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CommonSetting() 
        {
            // 設定情報XMLの読込
            var settingPath = ConfigurationManager.AppSettings["controlSettingPath"];
            var themeName = ConfigurationManager.AppSettings["ThemeName"];
            if (string.IsNullOrEmpty(settingPath))
                return;

            xdoc.Load(settingPath);
            themeNode = xdoc.SelectSingleNode(string.Format("/root/Themes/Theme[@Name='{0}']", themeName));
        }
        /// <summary>
        /// カラー情報の取得
        /// </summary>
        /// <param name="attr">属性名</param>
        /// <param name="baseColor">元の色</param>
        /// <returns></returns>
        public Color GetColor(string attr, Color baseColor) 
        {
            if (themeNode != null) 
            {
                // 共通カラー設定
                var commonColorSetting = themeNode.SelectSingleNode("/root/Themes/Theme/commonSettings/Setting[@Name='Color']");
                if (commonColorSetting.Attributes[attr] != null)
                    return ColorTranslator.FromHtml(commonColorSetting.Attributes[attr].Value);
            }
            return baseColor;
        }
        /// <summary>
        /// フォント情報の取得
        /// </summary>
        /// <returns></returns>
        public Font GetFontSetting() 
        {
            var fontFamily = "MS UI Gothic";
            var fontSize = 9;
            FontStyle fontStyle = FontStyle.Regular;

            if (themeNode == null)
                return new Font(fontFamily, fontSize, fontStyle);

            // 共通フォント設定
            var commonFontSetting = themeNode.SelectSingleNode("/root/Themes/Theme/commonSettings/Setting[@Name='Font']");
            if (commonFontSetting != null)
            {
                if (commonFontSetting.Attributes["FontFamily"] != null)
                    fontFamily = commonFontSetting.Attributes["FontFamily"].Value;
                if (commonFontSetting.Attributes["FontSize"] != null)
                    fontSize = int.Parse(commonFontSetting.Attributes["FontSize"].Value);
                if (commonFontSetting.Attributes["FontStyle"] != null)
                    fontStyle = (commonFontSetting.Attributes["FontStyle"].Value == "Italic" ? FontStyle.Italic : (commonFontSetting.Attributes["FontStyle"].Value == "Bold" ? FontStyle.Bold : FontStyle.Regular));
            }
            return new Font(fontFamily, fontSize, fontStyle);
        }
    }
}
