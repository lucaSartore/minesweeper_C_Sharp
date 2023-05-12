

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
            components = new System.ComponentModel.Container();
            game_stats = new Panel();
            panel_flag = new Panel();
            gamemode_selector_pannel = new Panel();
            difficulty_selector = new ComboBox();
            timer_pannel = new Panel();
            time_text = new Label();
            reset_button = new Button();
            timer = new System.Windows.Forms.Timer(components);
            game_stats.SuspendLayout();
            gamemode_selector_pannel.SuspendLayout();
            timer_pannel.SuspendLayout();
            SuspendLayout();
            // 
            // game_stats
            // 
            game_stats.BackColor = SystemColors.MenuHighlight;
            game_stats.Controls.Add(panel_flag);
            game_stats.Controls.Add(gamemode_selector_pannel);
            game_stats.Controls.Add(timer_pannel);
            game_stats.Dock = DockStyle.Top;
            game_stats.Location = new Point(0, 0);
            game_stats.Margin = new Padding(3, 3, 3, 10);
            game_stats.Name = "game_stats";
            game_stats.Size = new Size(950, 77);
            game_stats.TabIndex = 0;
            // 
            // panel_flag
            // 
            panel_flag.Location = new Point(173, 0);
            panel_flag.Name = "panel_flag";
            panel_flag.Size = new Size(261, 77);
            panel_flag.TabIndex = 2;
            // 
            // gamemode_selector_pannel
            // 
            gamemode_selector_pannel.BackColor = SystemColors.MenuHighlight;
            gamemode_selector_pannel.Controls.Add(difficulty_selector);
            gamemode_selector_pannel.Dock = DockStyle.Left;
            gamemode_selector_pannel.Location = new Point(0, 0);
            gamemode_selector_pannel.Name = "gamemode_selector_pannel";
            gamemode_selector_pannel.Size = new Size(174, 77);
            gamemode_selector_pannel.TabIndex = 1;
            // 
            // difficulty_selector
            // 
            difficulty_selector.Anchor = AnchorStyles.None;
            difficulty_selector.AutoCompleteCustomSource.AddRange(new string[] { "Easy" });
            difficulty_selector.BackColor = SystemColors.ControlLightLight;
            difficulty_selector.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            difficulty_selector.Location = new Point(27, 21);
            difficulty_selector.Name = "difficulty_selector";
            difficulty_selector.Size = new Size(109, 33);
            difficulty_selector.TabIndex = 0;
            difficulty_selector.SelectedIndexChanged += difficulty_selector_SelectedIndexChanged;
            // 
            // timer_pannel
            // 
            timer_pannel.BackColor = SystemColors.MenuHighlight;
            timer_pannel.Controls.Add(time_text);
            timer_pannel.Controls.Add(reset_button);
            timer_pannel.Dock = DockStyle.Right;
            timer_pannel.Location = new Point(628, 0);
            timer_pannel.Name = "timer_pannel";
            timer_pannel.Size = new Size(322, 77);
            timer_pannel.TabIndex = 0;
            // 
            // time_text
            // 
            time_text.AutoSize = true;
            time_text.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point);
            time_text.Location = new Point(140, 17);
            time_text.Name = "time_text";
            time_text.Size = new Size(97, 45);
            time_text.TabIndex = 1;
            time_text.Text = "0:0:0";
            time_text.TextAlign = ContentAlignment.MiddleCenter;
            time_text.Click += label1_Click;
            // 
            // reset_button
            // 
            reset_button.BackColor = Color.DarkSalmon;
            reset_button.Location = new Point(21, 23);
            reset_button.Name = "reset_button";
            reset_button.Size = new Size(83, 34);
            reset_button.TabIndex = 0;
            reset_button.Text = "RESET";
            reset_button.UseVisualStyleBackColor = false;
            reset_button.Click += reset_burron_Click;
            // 
            // timer
            // 
            timer.Interval = 50;
            timer.Tick += timer1_Tick;
            // 
            // Window
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(950, 520);
            Controls.Add(game_stats);
            Name = "Window";
            Text = "Minesweeper";
            Load += Window_Load;
            game_stats.ResumeLayout(false);
            gamemode_selector_pannel.ResumeLayout(false);
            timer_pannel.ResumeLayout(false);
            timer_pannel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel game_stats;
        private Panel gamemode_selector_pannel;
        private Panel timer_pannel;
        private ComboBox difficulty_selector;
        private Panel panel_flag;
        private Button reset_button;
        private Label time_text;
        private System.Windows.Forms.Timer timer;
    }
}