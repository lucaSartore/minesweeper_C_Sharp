using System.Transactions;

namespace Minesweeper
{

	public class Tile: Button
	{
		// dimention of the button
		private const int DIMENTION = 100;
        // color of the button when unpresd
        private readonly static Color UN_PRESSED_COLOR= Color.FromArgb(255,40,40,40);
        // color of the button when presd
        private readonly static Color PRESSED_COLOR = Color.LightGray;
        // color of the button when player is defeated
        private readonly static Color DEFEAT_COLOR = Color.Red;

        // whether thid tile contain a bomb or not
        private readonly bool HasBomb;
		// whether the user has flagd the item or not
		private bool IsFlagd;
        // X position in the map
        private readonly int PosX;
		// Y position in the map
        private readonly int PosY;

        // constructor, specify if it has a bomb in it, and the relative position in the grif
        public Tile(bool HasBomb, int PosX, int PosY) : base()
		{
            base.BackColor = UN_PRESSED_COLOR;
            base.Size = new Size(DIMENTION, DIMENTION);
            this.IsFlagd = false;
			this.HasBomb = HasBomb;
			this.PosX = PosX;
			this.PosY = PosY;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left)
            {
                if (HasBomb)
                {
                    base.BackColor = DEFEAT_COLOR;
                }
                else
                {
                    base.BackColor = PRESSED_COLOR;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                // toggle the flag
                IsFlagd = !IsFlagd;
                Console.WriteLine("Right click");
            }
        }

    }
}
