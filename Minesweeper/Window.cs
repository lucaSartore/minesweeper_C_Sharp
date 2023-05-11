using Minesweeper.Properties;
using System.Reflection.Emit;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace Minesweeper
{
    public partial class Window : Form
    {
        private Field field;

        private PictureBox FlagPicture;


        private Label FlagTextLable;

        public Window()
        {
            InitializeComponent();
            InitializeLogic();
        }


        private void InitializeLogic()
        {
            field = new Field(Difficulty.EASY, this);

            field.Location = new Point(100, 100);
            difficulty_selector.SelectedIndex = 0;
            Controls.Add(field);
            SetMinSize();
            KeepFieldCenter();

            // 
            // picture
            // 
            FlagPicture = new PictureBox();
            panel_flag.Controls.Add(FlagPicture);
            FlagPicture.Image = Image.FromFile("../../../assets/flag.png");
            FlagPicture.SizeMode = PictureBoxSizeMode.Zoom;
            FlagPicture.Location = new Point(5, 12);
            FlagPicture.Name = "falg_box";
            FlagPicture.Size = new Size(50, 52);
            FlagPicture.TabIndex = 0;
            FlagPicture.TabStop = false;

            /// 
            /// lable
            /// 

            FlagTextLable = new Label();

            panel_flag.Controls.Add(FlagTextLable);

            FlagTextLable.AutoSize = true;
            FlagTextLable.Location = new Point(76, 22);
            FlagTextLable.Name = "FlagTextLable";
            FlagTextLable.Size = new Size(59, 25);
            FlagTextLable.TabIndex = 1;
            FlagTextLable.Font = new Font(FlagTextLable.Font.FontFamily, 10, FontStyle.Bold);
            FlagTextLable.Text = "No Bomb Flagd";
        }

        public void SetFlagLable(string s)
        {
            FlagTextLable.Text = s;
        }


        private void difficulty_selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            switch (difficulty_selector.SelectedIndex)
            {

                case 0:
                    Controls.Remove(field);
                    field = new Field(Difficulty.EASY, this);
                    Controls.Add(field);
                    SetMinSize();
                    KeepFieldCenter();
                    break;
                case 1:
                    Controls.Remove(field);
                    field = new Field(Difficulty.MEDIUM, this);
                    Controls.Add(field);
                    SetMinSize();
                    KeepFieldCenter();
                    break;
                case 2:
                    Controls.Remove(field);
                    field = new Field(Difficulty.HARD, this);
                    Controls.Add(field);
                    KeepFieldCenter();
                    SetMinSize();
                    break;
            }
            if (FlagTextLable != null)
            {
                FlagTextLable.Text = "No Bomb Flagd";
            }
        }


        // keep it center when rezized
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            KeepFieldCenter();
        }

        private void KeepFieldCenter()
        {
            if (field != null)
            {
                int height_game_stats = game_stats.Height;

                // Calculate the new position of the button when the form is resized
                int width = field.Width;
                int height = field.Height - height_game_stats;
                int x = (ClientSize.Width - width) / 2; // Center horizontally
                int y = (ClientSize.Height - height) / 2; // Center vertically

                // Set the new position of the button
                field.Location = new System.Drawing.Point(x, y);
            }
        }

        private void SetMinSize()
        {
            int min_height = field.Height + game_stats.Height + 100;
            int min_width = Math.Max(field.Width + 100, 750);

            MinimumSize = new System.Drawing.Size(min_width, min_height);
        }

        private void Window_Load(object sender, EventArgs e)
        {

        }

        private void reset_burron_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}