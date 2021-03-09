using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_2
{
    public sealed class SingletonSettings
    {
        private static SingletonSettings _instance;
        private static readonly object locker = new object();
        private SingletonSettings()
        {
            BackColor = Color.White;
            FontColor = Color.Black;
            FontFamily = "Arial";
            FontSize = 9;
            FormWidth = 700;
            FormHeight = 450;
        }

        public static SingletonSettings GetInstance()
        {
            if (_instance == null)
            {
                lock (locker)
                {
                    if (_instance == null)
                        _instance = new SingletonSettings();
                }
            }

            return _instance;
        }


  
        public string FontFamily { get; set; }
        public Color BackColor { get; set; }
        public Color FontColor { get; set; }

        public int FontSize { get; set; }

        public int FormWidth { get; set; }
        public int FormHeight { get; set; }
    }
}
