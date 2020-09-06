using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Kanami.Windows.Froms.Controls
{
    public partial class Button : System.Windows.Forms.Button
    {
        private XmlDocument xdoc = new XmlDocument();
        private XmlNode themeNode;
        /// <summary>
        /// コントロール描画時に設定ファイルの内容を適用する
        /// (起動時に強制的に設定を適用する方法)
        /// </summary>
        /// <param name="e"></param>
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

                // ボタン専用の設定がある場合は上書き
                setButtonColor();
                setButtonFont(this.Font);
                setButtonStyle();

            }
            base.OnPaint(e);
        }
        #region 設定読み込み
        /// <summary>
        /// ボタンの色を設定する
        /// </summary>
        private void setButtonColor()
        {
            var colorSetting = themeNode.SelectSingleNode("/root/Themes/Theme/buttonSettings/Setting[@Name='Color']");
            this.ForeColor = Util.GetColor(colorSetting, "ForeColor", this.ForeColor);
            this.BackColor = Util.GetColor(colorSetting, "BackColor", this.BackColor);
        }
        /// <summary>
        /// ボタンのフォントを設定する
        /// </summary>
        /// <param name="baseFont">元のフォント</param>
        private void setButtonFont(Font baseFont)
        {
            // フォント設定
            var buttonFontSetting = themeNode.SelectSingleNode("/root/Themes/Theme/buttonSettings/Setting[@Name='Font']");
            var fontFamily = baseFont.FontFamily.Name;
            var fontSize = baseFont.Size;
            FontStyle fontStyle = baseFont.Style;
            if (buttonFontSetting != null)
            {
                if (buttonFontSetting.Attributes["FontFamily"] != null)
                    fontFamily = buttonFontSetting.Attributes["FontFamily"].Value;
                if (buttonFontSetting.Attributes["FontSize"] != null)
                    fontSize = int.Parse(buttonFontSetting.Attributes["FontSize"].Value);
                if (buttonFontSetting.Attributes["FontStyle"] != null)
                    fontStyle = (buttonFontSetting.Attributes["FontStyle"].Value == "Italic" ? FontStyle.Italic : (buttonFontSetting.Attributes["FontStyle"].Value == "Bold" ? FontStyle.Bold : FontStyle.Regular));
            }
            this.Font = new Font(fontFamily, fontSize, fontStyle);
        }
        /// <summary>
        /// ボタンのスタイルを設定する
        /// </summary>
        private void setButtonStyle() 
        {

            // スタイル設定
            var buttonStyleSetting = themeNode.SelectSingleNode("/root/Themes/Theme/buttonSettings/Setting[@Name='Style']");

            var z = this.FlatStyle;
            var x = this.FlatAppearance.BorderColor;
            var y = this.FlatAppearance.BorderSize;
            if (buttonStyleSetting != null)
            {
                if (buttonStyleSetting.Attributes["FlatStyle"] != null)
                    this.FlatStyle = Util.GetFlatStyle(buttonStyleSetting.Attributes["FlatStyle"].Value);
                if (buttonStyleSetting.Attributes["BorderColor"] != null)
                    this.FlatAppearance.BorderColor= ColorTranslator.FromHtml(buttonStyleSetting.Attributes["BorderColor"].Value);
                if (buttonStyleSetting.Attributes["BorderSize"] != null)
                    this.FlatAppearance.BorderSize = int.Parse(buttonStyleSetting.Attributes["BorderSize"].Value);
            }
        }
        #endregion        
    }
}
