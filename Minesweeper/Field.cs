using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{


    public enum Difficulty { EASY, MEDIUM, HARD}


    public class Field: TableLayoutPanel
    {
        private int size_x;
        private int size_y;
        private int number_of_bombs;
        public bool is_initialize;
        Tile[,] tiles;

        public Tile GetTile(int x, int y)
        {
            // check the ranges
            if (x < 0 || y < 0 || x >= size_x || y>= size_y)
            {
                throw new ArgumentOutOfRangeException();
            }
            return tiles[x, y];
        }

        public Field(Difficulty difficulty): base()
        {

            is_initialize = false;
            base.Margin = new Padding(0, 0, 0, 0);

            // chouse size_x and size_y based on difficulty
            switch (difficulty)
            {
                case Difficulty.EASY:
                    size_x = 8;
                    size_y = 8;
                    number_of_bombs = 10;
                    break;
                case Difficulty.MEDIUM:
                    size_x = 16;
                    size_y = 16;
                    number_of_bombs = 40;
                    break;
                case Difficulty.HARD:
                    size_x = 30;
                    size_y = 16;
                    number_of_bombs = 99;
                    break;
                default: 
                    throw new ArgumentException("unknown difficulty");
            }

            tiles = new Tile[size_x, size_y];


            // set the number of colum based on the difficulty
            base.ColumnCount = size_x;
            for(int i = 0; i < size_x; i++)
            {
                base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Tile.DIMENTION));
            }
            base.RowCount = size_y;
            for (int i = 0; i < size_y; i++)
            {
                base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Tile.DIMENTION));
            }

            base.Size = new Size(
                size_x * Tile.DIMENTION,
                size_y * Tile.DIMENTION
                );


            // putting no bombs in it
            for(int x=0; x < size_x; x++)
            {
                for(int y=0; y < size_y; y++)
                {
                    tiles[x, y] = new Tile(false, x, y, this);
                    tiles[x, y].Margin = new Padding(0, 0, 0, 0);
                    base.Controls.Add(tiles[x, y], x, y);
                }
            }
            
        }

        /// initialize the fheeld from the first click
        public void Initailize(int x_first_click, int y_first_click, MouseEventArgs e)
        {
            // flag that descrive if the position is close to a border, or close to a corner
            bool has_border_top_or_borrom = y_first_click == 0 || y_first_click == size_y-1;
            bool has_border_left_or_right = x_first_click == 0 || x_first_click == size_x-1;

            int tiles_to_generate = size_x*size_y;

            if (has_border_top_or_borrom && has_border_left_or_right)// on a corner
            {
                tiles_to_generate -= 4;
            }
            else if (has_border_top_or_borrom || has_border_left_or_right)// on a side, but not corner
            {
                tiles_to_generate -= 6;
            }
            else // on the center
            {
                tiles_to_generate -= 9;
            }


            int bomb_to_generate = number_of_bombs;
            int non_bomb_to_generate = tiles_to_generate - number_of_bombs;


            int index = 0;

            Random rand = new Random();

            // placing the bombs
            for (int x = 0; x < size_x; x++)
            {
                for (int y = 0; y < size_y; y++)
                {
                    // if we are not close to the first click
                    if(Math.Abs(x-x_first_click) > 1 || Math.Abs(y - y_first_click) > 1)
                    {
                        double probability_bomb = (double)bomb_to_generate / (double)(bomb_to_generate + non_bomb_to_generate);
                        if(rand.NextDouble() < probability_bomb)
                        {
                            // generate a bomb
                            tiles[x, y].BecameBomb();
                            bomb_to_generate--;
                        }
                        else
                        {
                            // generate non bomb
                            non_bomb_to_generate--;
                        }
                    }
                }
            }


            // calcualte the bomb counter
            for (int x = 0; x < size_x; x++)
            {
                for (int y = 0; y < size_y; y++)
                {
                        tiles[x, y].UpdateBombCount();
                }
            }

            is_initialize = true;

            // firing the click event on the original element
            tiles[x_first_click, y_first_click].OnMouseUpPubblic(e);

        }
        private static List<bool> ShuffleIntList(List<bool> list)
        {
            var random = new Random();
            var newShuffledList = new List<bool>();
            var listcCount = list.Count;
            for (int i = 0; i < listcCount; i++)
            {
                var randomElementInList = random.Next(0, list.Count);
                newShuffledList.Add(list[randomElementInList]);
                list.Remove(list[randomElementInList]);
            }
            return newShuffledList;
        }

    }
}
