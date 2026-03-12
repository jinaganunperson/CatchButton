namespace CatchButton
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            clickbutton = new Button();
            btnReset = new Button();
            SuspendLayout();
            // 
            // clickbutton
            // 
            clickbutton.BackColor = Color.FromArgb(255, 192, 128);
            clickbutton.Font = new Font("맑은 고딕", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 129);
            clickbutton.Location = new Point(341, 219);
            clickbutton.Name = "clickbutton";
            clickbutton.Size = new Size(412, 155);
            clickbutton.TabIndex = 0;
            clickbutton.Text = "나를 잡아봐";
            clickbutton.UseVisualStyleBackColor = false;
            clickbutton.Click += button1_Click;
            clickbutton.MouseEnter += button1_MouseEnter;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("맑은 고딕", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnReset.ForeColor = Color.Red;
            btnReset.Location = new Point(925, 20);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(154, 57);
            btnReset.TabIndex = 1;
            btnReset.Text = "다시 시작";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(18F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1089, 636);
            Controls.Add(btnReset);
            Controls.Add(clickbutton);
            Name = "Form1";
            Text = "버튼 잡기 게임";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button clickbutton;
        private Button btnReset;
    }
}
