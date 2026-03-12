using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        SoundPlayer escapeSound = new SoundPlayer("escape.wav");
        SoundPlayer catchSound = new SoundPlayer("catch.wav");

        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            catchSound.Play();

            score += 100;

            int newWidth = (int)(clickbutton.Width * 0.9);
            int newHeight = (int)(clickbutton.Height * 0.9);

            if (newWidth > 10 && newHeight > 10)
            {
                clickbutton.Size = new Size(newWidth, newHeight);
            }

            UpdateTitle();

            MessageBox.Show($"축하합니다~!");
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            escapeSound.Play();

            score -= 10;

            Random rd = new Random();
            int maxX = this.ClientSize.Width - clickbutton.Width;
            int maxY = this.ClientSize.Height - clickbutton.Height;

            if (maxX < 0) maxX = 0;
            if (maxY < 0) maxY = 0;

            int nextX = rd.Next(0, maxX + 1);
            int nextY = rd.Next(0, maxY + 1);

            clickbutton.Location = new Point(nextX, nextY);

            UpdateTitle();
        }

        private void UpdateTitle()
        {
            this.Text = $"점수: {score} | 버튼 위치: ({clickbutton.Left}, {clickbutton.Top})";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                escapeSound.Load();
                catchSound.Load();
            }
            catch {}

            UpdateTitle(); 
        }
    }
}