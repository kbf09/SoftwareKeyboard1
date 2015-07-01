﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HongliangSoft.Utilities.Gui;
using System.Windows.Forms;
using System.Drawing;


namespace SoftwareKeyboard
{
    public partial class Form1 : Form
    {

        Button[] btns = new Button[100];
        string hiragana = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもや ゆ よらりるれろわ を んがぎぐげござじずぜぞだぢづでどばびぶべぼぱぴぷぺぽぁぃぅぇぉ  っ  ゃ ゅ ょ";
        Dictionary<string, string> henkan = new Dictionary<string, string>() {
            {"あ", "a"},{"い", "i"},{"う", "u"},{"え", "e"}, {"お", "o"},
            {"か", "ka"},{"き","ki"},{"く","ku"},{"け","ke"},{"こ","ko"},
            {"さ","sa"},{"し","si"},{"す","su"},{"せ","se"},{"そ","so"},
            {"た","ta"},{"ち","ti"},{"つ","tu"},{"て","te"},{"と","to"},
            {"な","na"},{"に","ni"},{"ぬ","nu"},{"ね","ne"},{"の","no"},
            {"は","ha"},{"ひ","hi"},{"ふ","hu"},{"へ","he"},{"ほ","ho"},
            {"ま","ma"},{"み","mi"},{"む","mu"},{"め","me"},{"も","mo"},
            {"や","ya"},{" "," "},{"ゆ","yu"},{"a",""},{"よ","yo"},
            {"ら","ra"},{"り","ri"},{"る","ru"},{"れ","re"},{"ろ","ro"},
            {"わ","wa"},{"b"," "},{"を","wo"},{"c",""},{"ん","nn"},
            {"が","ga"},{"ぎ","gi"},{"ぐ","gu"},{"げ","ge"},{"ご","go"},
            {"ざ","za"},{"じ","zi"},{"ず","zu"},{"ぜ","ze"},{"ぞ","zo"},
            {"だ","da"},{"ぢ","di"},{"づ","du"},{"で","de"},{"ど","do"},
            {"ば","ba"},{"び","bi"},{"ぶ","bu"},{"べ","be"},{"ぼ","bo"},
            {"ぱ","pa"},{"ぴ","pi"},{"ぷ","pu"},{"ぺ","pe"},{"ぽ","po"},
            {"ぁ","la"},{"ぃ","li"},{"ぅ","lu"},{"ぇ","le"},{"ぉ","lo"},
            {"d"," "},{"e"," "},{"っ","ltu"},{"      "," "},{"          "," "},
            {"ゃ","lya"},{"         "," "},{"ゅ","lyu"},{"             "," "},{"ょ","lyo"},
        };
        int size = 90;
        int nowButtonNumber = 1;
        Form2 f2 = new Form2();
        int protectedKeyCnt = 0;

        
        public Form1()
        {
            InitializeComponent();
        }

        
        // 非アクティブにするおまじない
        private const int WS_EX_NOACTIVATE = 0x8000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;
                if (!base.DesignMode)
                {
                    p.ExStyle = p.ExStyle | (WS_EX_NOACTIVATE);
                }
                return p;
            }
        }

        // 非アクティブにするおまじないここまで

        /**
         * キーボードフックしてるメソッド
         * 
         * PCのキー入力をすべてここで受け取ってる
         */

        private void keyHookProc(object sender, KeyboardHookedEventArgs e)
        {

            if (protectedKeyCnt == 1)
            {
                protectedKeyCnt = 0;
                return;
            }
            protectedKeyCnt++;

            btns[nowButtonNumber].BackColor = f2.BtnsColorselect();
            btns[nowButtonNumber].ForeColor = f2.FontColorselect();

            switch (e.KeyCode)
            {
                case Keys.Down:
                    nowButtonNumber += 1;
                    if (nowButtonNumber >= hiragana.Length) nowButtonNumber -= hiragana.Length;
                    btns[nowButtonNumber].Select();
                    break;

                case Keys.Right:
                    nowButtonNumber += 5;
                    if (nowButtonNumber >= hiragana.Length) nowButtonNumber -= hiragana.Length;
                    btns[nowButtonNumber].Select();

                    break;
                case Keys.Up:
                     nowButtonNumber -= 1;
                    if (nowButtonNumber < 0) nowButtonNumber += hiragana.Length;
                    btns[nowButtonNumber].Select();
                    break;
                case Keys.Left:
                     nowButtonNumber -= 5;
                    if (nowButtonNumber < 0) nowButtonNumber += hiragana.Length;
                    btns[nowButtonNumber].Select();
                    break;
                case Keys.Space:
                    f2.Show();
                    //f2.ShowDialog(this);
                    //System.Threading.Thread.Sleep(5000);
                    //this.Close();
                    //this.Hide();
                    break;
                case Keys.Enter:
                    SendKeys.Send(hiragana.Substring(nowButtonNumber,1));
                    break;

            }
            btns[nowButtonNumber].BackColor = f2.CursorColorselect();
        }

        private static KeyboardHook keyHook;

        /**
         *
         * 初期設定
         * ボタンの生成とかをしている
         * 
         */



        private void Form1_Load(object sender, EventArgs e)
        {
            keyHook = new KeyboardHook();
            keyHook.KeyboardHooked += new KeyboardHookedEventHandler(keyHookProc);
            int i, j, sum = 0;

            // とりあえずウィンドウとサイズを固定
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Size = new Size(size * 18 + 15, size * 5 + 40);

            // 最前面にする
            //this.TopMost = true;

            for (i = 0; i < 18; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    //Buttonクラスのインスタンスを作成する
                    btns[sum] = new System.Windows.Forms.Button();

                    //Buttonコントロールのプロパティを設定する
                    btns[sum].Name = "id."+ sum;
                    btns[sum].Text = this.hiragana.Substring(sum, 1);
                    btns[sum].Font = new Font("MS UI Gothic", 29);
                    btns[sum].BackColor = f2.BtnsColorselect();
                    btns[sum].ForeColor = f2.FontColorselect();

                    //サイズと位置を設定する
                    btns[sum].Location = new Point(size * i, size * j);
                    btns[sum].Size = new System.Drawing.Size(size, size);
                    

                    //フォームに追加する
                    this.Controls.Add(btns[sum]);
                    btns[sum].Click += new EventHandler(btn_click);
                    sum++;
                }

            }

            //Color cursorColor = f2.CursorColorselect();

            // 「あ」にフォーカス
            btns[0].Select();
            btns[0].BackColor = f2.CursorColorselect();

            // 今のフォーカスは「あ」なのでもどす
            nowButtonNumber = 0;
            this.Resize += new System.EventHandler(this.Form1_Resize);

            
        }


        /*
         * ボタンをクリックしたときに呼び出されるメソッド
         * 
         */
        void btn_click(object sender, EventArgs e)
        {
            SendKeys.Send(henkan[((Button)sender).Text]);
        }
        
        /*
         * フォームの大きさが変わった時に呼び出されるメソッド
         */ 
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            size = control.Size.Height / 10;
            //ChengeBtnSize(size);
        }

        /*
         * ボタンの大きさを一つずつ変更するメソッド
         * 
         */
        private void ChengeBtnSize(int size)
        {
            foreach (Button btn in this.btns)
            {
                btn.Size = new Size(size, size);
            }
        }
    }
}
