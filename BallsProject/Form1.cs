﻿using BallsProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsProject
{
    public partial class Form1 : Form
    {

        
        private List<Ball> _balls = new List<Ball>();

        private BallFactory _factory;
        public BallFactory Factory
        {
            get { return _factory; }
            set
            {
                _factory = value;
                DisplayNext();
            }
        }



        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

       

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Toy _nextToy;

        private IToyFactory _factory2;
        public IToyFactory Factory2
        {
            get { return _factory2; }
            set
            {
                _factory2 = value;
                DisplayNext();
            }
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            _balls.Add(ball);
            ball.Left = -ball.Width;
            mainPanel.Controls.Add(ball);
        }


        private void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = lblNext.Top + lblNext.Height + 20;
            _nextToy.Left = lblNext.Left;


            Controls.Add(_nextToy);
        }


        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var ball in _balls)
            {
                ball.MoveBall();
                if (ball.Left > maxPosition)
                    maxPosition = ball.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestBall = _balls[0];
                mainPanel.Controls.Remove(oldestBall);
                _balls.Remove(oldestBall);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factory2 = new IToyFactory();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorPicker = new ColorDialog();

            colorPicker.Color = button.BackColor;
            if (colorPicker.ShowDialog() != DialogResult.OK)
                return;

            button.BackColor = colorPicker.Color;
        }
    }
}