﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.gyak.Abstractions
{
    public class Toy : Label
    {

        public Toy()
        {
            AutoSize = false;
            Width = 50;
            Height = Width;
            Paint += Ball_Paint
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected abstract void DrawImage(Graphics graphics);
       

        public void MoveBall()
        {

            Left += 1;
        }
    }
}
