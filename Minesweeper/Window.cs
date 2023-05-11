namespace Minesweeper
{
    public partial class Window : Form
    {
        private Field field;

        public Window()
        {
            InitializeComponent();
            InitializeLogic();
        }


        private void InitializeLogic()
        {
            field = new Field(Difficulty.EASY);

            field.Location = new Point(100, 100);

            Controls.Add(field);
            SetMinSize();
            KeepFieldCenter();
        }



        private void difficulty_selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (difficulty_selector.SelectedIndex)
            {

                case 0:
                    Controls.Remove(field);
                    field = new Field(Difficulty.EASY);
                    Controls.Add(field);
                    SetMinSize();
                    KeepFieldCenter();
                    break;
                case 1:
                    Controls.Remove(field);
                    field = new Field(Difficulty.MEDIUM);
                    Controls.Add(field);
                    SetMinSize();
                    KeepFieldCenter();
                    break;
                case 2:
                    Controls.Remove(field);
                    field = new Field(Difficulty.HARD);
                    Controls.Add(field);
                    KeepFieldCenter();
                    SetMinSize();
                    break;
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
            int min_width = Math.Max(field.Width + 100, 600);

            MinimumSize = new System.Drawing.Size(min_width, min_height);
        }

    }
}