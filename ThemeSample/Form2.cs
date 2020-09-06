using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThemeSample
{
    public partial class Form2 : Kanami.Windows.Froms.Controls.Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="title">フォームタイトル</param>
        public Form2(string title)
        {
            InitializeComponent();
            this.Text = title;
        }
        /// <summary>
        /// 閉じるボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
