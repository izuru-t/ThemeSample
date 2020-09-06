using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Kanami.Windows.Froms.Controls
{
    public partial class Label : System.Windows.Forms.Label
    {
        private XmlDocument xdoc = new XmlDocument();
        private XmlNode themeNode;

        protected override void OnPaint(PaintEventArgs e)
        {
            // デザイン時には処理しない
            if (!this.DesignMode)
            {
                var settingPath = ConfigurationManager.AppSettings["controlSettingPath"];
                var themeName = ConfigurationManager.AppSettings["ThemeName"];

                if (string.IsNullOrEmpty(settingPath))
                    return;

                xdoc.Load(settingPath);
                themeNode = xdoc.SelectSingleNode(string.Format("/root/Themes/Theme[@Name='{0}']", themeName));

                var commonSetting = new CommonSetting();
                this.ForeColor = commonSetting.GetColor("ForeColor", this.ForeColor);
                this.BackColor = commonSetting.GetColor("BGColor", this.BackColor);
                this.Font = commonSetting.GetFontSetting();

                // ラベル専用の設定がある場合は上書き
                setLabelColor();
                setLabelFont(this.Font);
                setLabelStyle();
            }
            base.OnPaint(e);
        }
        #region 設定読み込み
        /// <summary>
        /// ラベルの色を設定する
        /// </summary>
        private void setLabelColor()
        {
            var colorSetting = themeNode.SelectSingleNode("/root/Themes/Theme/labelSettings/Setting[@Name='Color']");
            this.ForeColor = Util.GetColor(colorSetting, "ForeColor", this.ForeColor);
            this.BackColor = Util.GetColor(colorSetting, "BackColor", this.BackColor);
        }
        /// <summary>
        /// ラベルのフォントを設定する
        /// </summary>
        /// <param name="baseFont">元のフォント</param>
        private void setLabelFont(Font baseFont)
        {
            // フォント設定
            var labelFontSetting = themeNode.SelectSingleNode("/root/Themes/Theme/labelSettings/Setting[@Name='Font']");
            var fontFamily = baseFont.FontFamily.Name;
            var fontSize = baseFont.Size;
            FontStyle fontStyle = baseFont.Style;
            if (labelFontSetting != null)
            {
                if (labelFontSetting.Attributes["FontFamily"] != null)
                    fontFamily = labelFontSetting.Attributes["FontFamily"].Value;
                if (labelFontSetting.Attributes["FontSize"] != null)
                    fontSize = int.Parse(labelFontSetting.Attributes["FontSize"].Value);
                if (labelFontSetting.Attributes["FontStyle"] != null)
                    fontStyle = (labelFontSetting.Attributes["FontStyle"].Value == "Italic" ? FontStyle.Italic : (labelFontSetting.Attributes["FontStyle"].Value == "Bold" ? FontStyle.Bold : FontStyle.Regular));
            }
            this.Font = new Font(fontFamily, fontSize, fontStyle);
        }
        /// <summary>
        /// ラベルのスタイルを設定する
        /// </summary>
        private void setLabelStyle()
        {

            // スタイル設定
            var labelStyleSetting = themeNode.SelectSingleNode("/root/Themes/Theme/labelSettings/Setting[@Name='Style']");

            var z = this.FlatStyle;
            var x = this.BorderStyle;
            if (labelStyleSetting != null)
            {
                if (labelStyleSetting.Attributes["FlatStyle"] != null)
                    this.FlatStyle = Util.GetFlatStyle(labelStyleSetting.Attributes["FlatStyle"].Value);
                if (labelStyleSetting.Attributes["BorderStyle"] != null)
                    this.BorderStyle = Util.GetBorderStyle(labelStyleSetting.Attributes["BorderStyle"].Value);
            }
        }
        #endregion
    }
}
