using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Twitter_CSharp {
    class Utils {
        //---------------------------------------------------------------------------
        /// <summary>
        /// 指定されたURLの画像をImage型オブジェクトとして取得する
        /// </summary>
        /// <param name="url">画像データのURL(ex: http://example.com/foo.jpg) </param>
        /// <returns>         画像データ</returns>
        //---------------------------------------------------------------------------
        public static Image LoadImageFromURL(string url) {
            int buffSize = 65536; // 一度に読み込むサイズ
            MemoryStream imgStream = new MemoryStream();

            //------------------------
            // パラメータチェック
            //------------------------
            if (url == null || url.Trim().Length <= 0) {
                return null;
            }

            //----------------------------
            // Webサーバに要求を投げる
            //----------------------------
            WebRequest req = WebRequest.Create(url);
            BinaryReader reader = new BinaryReader(req.GetResponse().GetResponseStream());

            //--------------------------------------------------------
            // Webサーバからの応答データを取得し、imgStreamに保存する
            //--------------------------------------------------------
            while (true) {
                byte[] buff = new byte[buffSize];

                // 応答データの取得
                int readBytes = reader.Read(buff, 0, buffSize);
                if (readBytes <= 0) {
                    // 最後まで取得した->ループを抜ける
                    break;
                }

                // バッファに追加
                imgStream.Write(buff, 0, readBytes);
            }

            return new Bitmap(imgStream);
        }

        public static Bitmap ResizeImage(Image src, int width, int height) {
            Bitmap ret = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(ret);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(src, 0, 0, width, height);
            g.Dispose();
            return ret;
        }

        public static Bitmap Cut(Image src, Rectangle r) {
            Bitmap ret = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(ret);
            g.DrawImage(src, 0, 0, r, GraphicsUnit.Pixel);
            g.Dispose();
            return ret;
        }

        public static Bitmap Adjust(Image src, int width, int height) {
            if (height == 0 || src.Height == 0) return null;
            double asp1 = (double)width / (double)height;
            double asp2 = (double)src.Width / (double)src.Height;
            int w = width, h = height;
            if (asp1 < asp2) {
                double zoom = (double)height / (double)src.Height;
                w = (int)(zoom * src.Width);
            }
            else {
                double zoom = (double)width / (double)src.Width;
                h = (int)(zoom * src.Height);
            }
            Bitmap bmp = ResizeImage(src, w, h);
            Bitmap ret = Cut(bmp, new Rectangle(
                (w - width) / 2, (h - height) / 2, width, height));
            bmp.Dispose();
            return ret;
        }

        /// <summary>
        /// URLを既定のブラウザで開く
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns>Process</returns>
        public static Process OpenUrl(string url) {
            ProcessStartInfo pi = new ProcessStartInfo() {
                FileName = url,
                UseShellExecute = true,
            };

            return Process.Start(pi);
        }

        /// <summary>
        /// フォームに配置されているコントロールを名前で探す
        /// （フォームクラスのフィールドをフィールド名で探す）
        /// </summary>
        /// <param name="frm">コントロールを探すフォーム</param>
        /// <param name="name">コントロール（フィールド）の名前</param>
        /// <returns>見つかった時は、コントロールのオブジェクト。
        /// 見つからなかった時は、null(VB.NETではNothing)。</returns>
        public static object FindControlByFieldName(Panel frm, string name) {
            System.Type t = frm.GetType();

            System.Reflection.FieldInfo fi = t.GetField(
                name,
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.DeclaredOnly);

            if (fi == null)
                return null;

            return fi.GetValue(frm);
        }

        /// <summary>
        /// 指定のコントロール上の全てのジェネリック型 Tコントロールを取得する。
        /// </summary>
        /// <typeparam name="T">対象となる型</typeparam>
        /// <param name="top">指定のコントロール</param>
        /// <returns>指定のコントロール上の全てのジェネリック型 Tコントロールのインスタンス</returns>
        public static List<T> GetAllControls<T>(Control top) where T : Control {
            List<T> buf = new List<T>();
            foreach (Control ctrl in top.Controls) {
                if (ctrl is T) buf.Add((T)ctrl);
                buf.AddRange(GetAllControls<T>(ctrl));
            }
            return buf;
        }

        public IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent, Type type_find) {
            /*

            【機能】　　指定したparent例えばform1の上の全コントロールを再帰的に探索して
                        指定したType属性のコントロールのみを取り出す
            【使い方】　var result2a = GetSelfAndChildrenRecursive2(this, typeof(GroupBox));
            【説明】　　StackOverflow版のGetSelfAndChildrenRecursive()を改造した。

            */

            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls) {
                if (child.GetType() == type_find) {
                    controls.Add(child);
                }

                controls.AddRange(GetSelfAndChildrenRecursive(child, type_find));
            }

            return controls;
        }
    }
}
