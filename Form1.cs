using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media; // 1. 소리 재생을 위해 반드시 추가해야 합니다.

namespace CatchButton
{
    public partial class Form1 : Form
    {
        // 2. 사운드 플레이어 객체 생성 (파일은 프로젝트의 bin\Debug 폴더에 있어야 합니다)
        // .wav 파일만 지원하며, 파일명이 정확해야 합니다.
        SoundPlayer escapeSound = new SoundPlayer("escape.wav");
        SoundPlayer catchSound = new SoundPlayer("catch.wav");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            catchSound.Play();

            MessageBox.Show("축하합니다~!!");
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            escapeSound.Play();

            Random rd = new Random();

            int maxX = this.ClientSize.Width - clickbutton.Width;
            int maxY = this.ClientSize.Height - clickbutton.Height;

            if (maxX < 0) maxX = 0;
            if (maxY < 0) maxY = 0;

            int nextX = rd.Next(0, maxX + 1);
            int nextY = rd.Next(0, maxY + 1);

            clickbutton.Location = new Point(nextX, nextY);
            this.Text = $"버튼위치: ({nextX}, {nextY})";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            escapeSound.Load();
            catchSound.Load();
        }
    }
}