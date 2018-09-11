﻿using System;
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
        private CBoardElement mController;

        private Color mColor;



        public VBoardElement(Color iColor)
        {
            mColor = iColor;
        }






        public Color Color { get => mColor; set => mColor = value; }

        public CBoardElement Controller { get => mController; set => mController = value; }
    }
}
