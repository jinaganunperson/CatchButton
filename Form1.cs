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
        int missCount = 0; // 놓친 횟수를 저장할 변수
        Size initialSize;  // 처음 버튼 크기를 저장할 변수

        public Form1()
        {
            InitializeComponent();
            // 게임 시작 시의 버튼 크기를 기억해둡니다 (나중에 초기화용)
            initialSize = clickbutton.Size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            catchSound.Play();
            score += 100;

            // 버튼 크기 10% 축소
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
            // 게임 오버 상태라면 더 이상 도망가지 않음
            if (missCount >= 20) return;

            escapeSound.Play();
            score -= 10;
            missCount++; // 놓친 횟수 증가

            // 20번 놓쳤을 때 처리
            if (missCount >= 20)
            {
                clickbutton.Enabled = false; // 버튼 비활성화
                UpdateTitle();
                MessageBox.Show("Game Over");
                return;
            }

            // 랜덤 이동 로직
            Random rd = new Random();
            int maxX = Math.Max(0, this.ClientSize.Width - clickbutton.Width);
            int maxY = Math.Max(0, this.ClientSize.Height - clickbutton.Height);

            clickbutton.Location = new Point(rd.Next(0, maxX + 1), rd.Next(0, maxY + 1));
            UpdateTitle();
        }

        // [다시 시작] 버튼을 클릭했을 때 (이 버튼의 Name은 btnReset으로 가정)
        private void btnReset_Click_1(object sender, EventArgs e)
        {
            // 1. 모든 정보 초기화
            score = 0;
            missCount = 0;

            // 2. 버튼 상태 복구
            clickbutton.Enabled = true;
            clickbutton.Size = initialSize; // 처음 크기로 복구
            clickbutton.Location = new Point(100, 100); // 원하는 시작 위치로 고정

            // 3. 제목 업데이트
            UpdateTitle();
            MessageBox.Show("게임을 다시 시작합니다!", "리셋");
        }

        private void UpdateTitle()
        {
            this.Text = $"점수: {score} | 위치: ({clickbutton.Left}, {clickbutton.Top})";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try { escapeSound.Load(); catchSound.Load(); } catch { }
            UpdateTitle();
        }
    }
}