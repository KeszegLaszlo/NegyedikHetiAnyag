﻿using _8.gyak.Abstractions;
using _8.gyak.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8.gyak
{
    public partial class Form1 : Form
    {

        private List<Abstractions.Toy> toys = new List<Toy>();

        private Toy _nextToy;
        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value;DisplayNext(); }
        }

        public List<Abstractions.Toy> Toys { get => toys; set => toys = value; }

        public Form1()
        {
            InitializeComponent();

            Factory = new BallFactory();
        }

        private void DisplayNext()
        {

            if (_nextToy != null)
                Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var ball in Toys)
            {
                ball.MoveBall();
                if (ball.Left>maxPosition)
                {
                    maxPosition = ball.Left;
                }
            }

            if (maxPosition>1000)
            {
                var oldestBall = Toys[0];
                mainPanel.Controls.Remove(oldestBall);
                Toys.Remove(oldestBall);
            }
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            Toys.Add(ball);
            ball.Left = -ball.Width;
            mainPanel.Controls.Add(Toys);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory new CarFactory();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }
    }
}
