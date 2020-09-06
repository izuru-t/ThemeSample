using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Kanami.Windows.Froms.Controls
{
    public partial class Form : System.Windows.Forms.Form
    {
        private XmlDocument xdoc = new XmlDocument();
        private XmlNode themeNode;
        #region コンストラクタ
        public Form()
        {
            InitializeComponent();
        }

        public Form(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        #endregion
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

                // フォーム専用の設定がある場合は上書き
                setFormColor();
            }
            base.OnPaint(e);
        }
        /// <summary>
        /// フォームの色を設定する
        /// </summary>
        private void setFormColor()
        {
            var colorSetting = themeNode.SelectSingleNode("/root/Themes/Theme/formSettings/Setting[@Name='Color']");
            this.ForeColor = Util.GetColor(colorSetting, "ForeColor", this.ForeColor);
            this.BackColor = Util.GetColor(colorSetting, "BackColor", this.BackColor);
        }
    }
}
