

namespace Minesweeper
{
    partial class Window
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
            game_stats = new Panel();
            stats_splittr = new SplitContainer();
            progressBar1 = new ProgressBar();
            gamemode_selector_pannel = new Panel();
            difficulty_selector = new ComboBox();
            timer_pannel = new Panel();
            timer_text = new TextBox();
            game_stats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stats_splittr).BeginInit();
            stats_splittr.Panel2.SuspendLayout();
            stats_splittr.SuspendLayout();
            gamemode_selector_pannel.SuspendLayout();
            timer_pannel.SuspendLayout();
            SuspendLayout();
            // 
            // game_stats
            // 
            game_stats.BackColor = Color.DarkRed;
            game_stats.Controls.Add(stats_splittr);
            game_stats.Controls.Add(gamemode_selector_pannel);
            game_stats.Controls.Add(timer_pannel);
            game_stats.Dock = DockStyle.Top;
            game_stats.Location = new Point(0, 0);
            game_stats.Margin = new Padding(3, 3, 3, 10);
            game_stats.Name = "game_stats";
            game_stats.Size = new Size(1366, 77);
            game_stats.TabIndex = 0;
            // 
            // stats_splittr
            // 
            stats_splittr.Dock = DockStyle.Fill;
            stats_splittr.Location = new Point(322, 0);
            stats_splittr.Name = "stats_splittr";
            // 
            // stats_splittr.Panel1
            // 
            stats_splittr.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // stats_splittr.Panel2
            // 
            stats_splittr.Panel2.Controls.Add(progressBar1);
            stats_splittr.Size = new Size(868, 77);
            stats_splittr.SplitterDistance = 426;
            stats_splittr.TabIndex = 2;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.None;
            progressBar1.Location = new Point(64, 21);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(296, 34);
            progressBar1.TabIndex = 0;
            // 
            // gamemode_selector_pannel
            // 
            gamemode_selector_pannel.Controls.Add(difficulty_selector);
            gamemode_selector_pannel.Dock = DockStyle.Left;
            gamemode_selector_pannel.Location = new Point(0, 0);
            gamemode_selector_pannel.Name = "gamemode_selector_pannel";
            gamemode_selector_pannel.Size = new Size(322, 77);
            gamemode_selector_pannel.TabIndex = 1;
            // 
            // difficulty_selector
            // 
            difficulty_selector.Anchor = AnchorStyles.None;
            difficulty_selector.AutoCompleteCustomSource.AddRange(new string[] { "Easy" });
            difficulty_selector.BackColor = SystemColors.ControlLightLight;
            difficulty_selector.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            difficulty_selector.Location = new Point(57, 22);
            difficulty_selector.Name = "difficulty_selector";
            difficulty_selector.Size = new Size(182, 33);
            difficulty_selector.TabIndex = 0;
            difficulty_selector.SelectedIndexChanged += difficulty_selector_SelectedIndexChanged;
            // 
            // timer_pannel
            // 
            timer_pannel.Controls.Add(timer_text);
            timer_pannel.Dock = DockStyle.Right;
            timer_pannel.Location = new Point(1190, 0);
            timer_pannel.Name = "timer_pannel";
            timer_pannel.Size = new Size(176, 77);
            timer_pannel.TabIndex = 0;
            // 
            // timer_text
            // 
            timer_text.Anchor = AnchorStyles.None;
            timer_text.Location = new Point(35, 24);
            timer_text.Name = "timer_text";
            timer_text.Size = new Size(102, 31);
            timer_text.TabIndex = 0;
            timer_text.TextChanged += textBox1_TextChanged;
            // 
            // Window
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1366, 663);
            Controls.Add(game_stats);
            Name = "Window";
            Text = "Minesweeper";
            game_stats.ResumeLayout(false);
            stats_splittr.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stats_splittr).EndInit();
            stats_splittr.ResumeLayout(false);
            gamemode_selector_pannel.ResumeLayout(false);
            timer_pannel.ResumeLayout(false);
            timer_pannel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel game_stats;
        private Panel gamemode_selector_pannel;
        private Panel timer_pannel;
        private TextBox timer_text;
        private SplitContainer stats_splittr;
        private ProgressBar progressBar1;
        private ComboBox difficulty_selector;
    }
}