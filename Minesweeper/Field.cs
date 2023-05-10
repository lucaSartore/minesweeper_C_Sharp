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
        int size_x;
        int size_y;
        Tile[,] tiles;


        public Field(Difficulty difficulty): base()
        {
            base.Margin = new Padding(0, 0, 0, 0);

            // chouse size_x and size_y based on difficulty
            switch (difficulty)
            {
                case Difficulty.EASY:
                    size_x = 8;
                    size_y = 8;
                    break;
                case Difficulty.MEDIUM:
                    size_x = 16;
                    size_y = 16;
                    break;
                case Difficulty.HARD:
                    size_x = 30;
                    size_y = 16;
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

            for(int x=0; x < size_x; x++)
            {
                for(int y=0; y < size_y; y++)
                {
                    tiles[x, y] = new Tile(false, x, y);
                    tiles[x, y].Margin = new Padding(0, 0, 0, 0);
                    base.Controls.Add(tiles[x, y], x, y);
                }
            }
        }
    }
}
