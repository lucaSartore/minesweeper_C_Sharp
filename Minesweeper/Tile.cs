using System.Transactions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Minesweeper
{

	public class Tile: Button
	{
		// dimention of the button
		public const int DIMENTION = 50;
        // color of the button when unpresd
        private readonly static Color UN_PRESSED_COLOR= Color.FromArgb(255,40,40,40);
        // color of the button when presd
        private readonly static Color PRESSED_COLOR = Color.LightGray;
        // color of the button when player is defeated
        private readonly static Color DEFEAT_COLOR = Color.Red;
        // the image of a bomb
        private readonly Image BOMB_IMAGE = Image.FromFile("../../../assets/bomb.png");
        // the image of a falg
        private readonly Image FLAG_IMAGE = Image.FromFile("../../../assets/flag.png");


        // whether thid tile contain a bomb or not
        private readonly bool has_bomb;
		// whether the user has flagd the item or not
		private bool is_flags;
        // whether the user has flagd the item or not
        private bool has_been_clickd;
        // X position in the map
        private readonly int pos_x;
        // Y position in the map
        private readonly int pos_y;
        // a counter of the bombs adjacent to this yile
        private int adjacent_bombs;

        // the image containing ither the flag or the bomb
        private PictureBox image;

        // the original Field this tile is part of
        private Field field;

     

        // constructor, specify if it has a bomb in it, and the relative position in the grif
        public Tile(bool HasBomb, int PosX, int PosY, Field field) : base()
		{
            base.BackColor = UN_PRESSED_COLOR;
            base.Size = new Size(DIMENTION, DIMENTION);
            this.is_flags = false;
			this.has_bomb = HasBomb;
			this.pos_x = PosX;
			this.pos_y = PosY;
            this.field = field;
            this.adjacent_bombs = 0;
            this.has_been_clickd = false;

            // creating the image
            this.image = new PictureBox();
            image.Margin = new Padding(0, 0, 0, 0);
            image.Size = new Size(DIMENTION-4, DIMENTION-4);
            image.Location = new Point(2, 2);
            image.SizeMode = PictureBoxSizeMode.Zoom;

            // passing the clicl event up chain
            image.MouseUp += (sender, e) =>
            {
                this.OnMouseUp(e);
            };

            base.Controls.Add(image);
        }



        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!has_been_clickd)
            {
                if (e.Button == MouseButtons.Left && !is_flags)
                {
                    has_been_clickd = true;
                    if (has_bomb)
                    {
                        base.BackColor = DEFEAT_COLOR;
                        image.Image = BOMB_IMAGE;
                    }
                    else
                    {
                        base.BackColor = PRESSED_COLOR;
                        // click the adjacent tiles
                        if(adjacent_bombs == 0)
                        {
                            foreach ((int, int) delta in new (int, int)[] { (-1, 0), (0, -1), (1, 0), (0, 1) })
                            {
                                int x = pos_x + delta.Item1;
                                int y = pos_y + delta.Item2;
                                try
                                {
                                    field.GetTile(x, y).OnMouseUp(e);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    // reachd the border of the map... do notting
                                }
                            }
                        }
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {

                    // toggle the flag
                    is_flags = !is_flags;
                    if (is_flags)
                    {
                        image.Image = FLAG_IMAGE;
                    }
                    else
                    {
                        image.Image = null;
                    }
                }
            }
        }

        public void UpdateBombCount()
        {
            adjacent_bombs = 0;
            if (!has_bomb) {
                foreach ((int, int) delta in new (int, int)[] { (-1, -1), (-1, 0), (-1, 1), (0,-1), (0,1), (1,-1), (1,0), (1,1)})
                {
                    int x = pos_x + delta.Item1;
                    int y = pos_y + delta.Item2;
                    try
                    {
                        if(field.GetTile(x, y).has_bomb){
                            adjacent_bombs++;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // reachd the border of the map... do notting
                    }
                }
            }
        }

    }
}
