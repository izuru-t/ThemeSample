using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Kanami.Windows.Froms.Controls
{
    public static class Util
    {
        /// <summary>
        /// 指定された属性の色情報を取得する
        /// </summary>
        /// <param name="colorSetting">カラー設定の入ったXMLNode</param>
        /// <param name="attr">属性名</param>
        /// <param name="baseColor">元の色</param>
        /// <returns></returns>
        public static Color GetColor(XmlNode colorSetting, string attr, Color baseColor)
        {
            Color color = baseColor;
            // カラー設定
            if (colorSetting != null)
            {
                if (colorSetting.Attributes[attr] != null)
                    color = ColorTranslator.FromHtml(colorSetting.Attributes[attr].Value);
            }
            return color;
        }
        /// <summary>
        /// FlatStyleを文字列から列挙型に変換
        /// </summary>
        /// <param name="styleName">FlatStyle名</param>
        /// <returns>列挙型</returns>
        public static FlatStyle GetFlatStyle(string styleName)
        {
            FlatStyle style = FlatStyle.Standard;
            switch (styleName)
            {
                case "Standard":
                    style = FlatStyle.Standard;
                    break;
                case "System":
                    style = FlatStyle.System;
                    break;
                case "Popup":
                    style = FlatStyle.Popup;
                    break;
                case "Flat":
                    style = FlatStyle.Flat;
                    break;
                default:
                    style = FlatStyle.Standard;
                    break;
            }
            return style;
        }
        /// <summary>
        /// BorderStyleを文字列から列挙型に変換
        /// </summary>
        /// <param name="styleName"></param>
        /// <returns></returns>
        public static BorderStyle GetBorderStyle(string styleName) 
        {
            BorderStyle style = BorderStyle.None;
            switch (styleName)
            {
                case "None":
                    style = BorderStyle.None;
                    break;
                case "FixedSingle":
                    style = BorderStyle.FixedSingle;
                    break;
                case "Fixed3D":
                    style = BorderStyle.Fixed3D;
                    break;
                default:
                    style = BorderStyle.None;
                    break;
            }
            return style;
        }
    }
}
