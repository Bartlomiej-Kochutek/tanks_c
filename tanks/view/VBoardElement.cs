using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using tanks.controller;


namespace tanks.view
{
    public class VBoardElement
    {
        private CBoardElement controller;

        private Color color;



        public VBoardElement(Color iColor)
        {
            color = iColor;
        }






        public Color Color { get => color; set => color = value; }

        public CBoardElement Controller { get => controller; set => controller = value; }
    }
}
