using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    class Board
    {
        public static Dictionary<string, BoardSquare> Square { get; set; } = new Dictionary<string, BoardSquare> { };
        public TableLayoutPanel LayoutPanel { get; set; }

        public Board()
        {
            LayoutPanel = new TableLayoutPanel
            {
                ColumnCount = 8,
                RowCount = 8,
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13));
            LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13));
            LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13));
            LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13));
            LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13));
            LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13));
            LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13));
            LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13));

            LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13));
            LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13));
            LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13));
            LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13));
            LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13));
            LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13));
            LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13));
            LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13));

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {

                    Panel square = new Panel
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0)
                    };
                    LayoutPanel.Controls.Add(square);
                    if (!((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0)))
                    {
                        square.BackColor = Color.Black;
                        square.Margin = new Padding(1);
                    }
                    BoardSquare boardsquare = new BoardSquare
                    {
                        Panel = square,
                        Address = Address.FlipRows(Address.ConvertFromInt(j) + i),
                        FillColor = square.BackColor
                    };
                    Square.Add(Address.FlipRows(Address.ConvertFromInt(j) + i), boardsquare);
                    BoardSquare.Find.Add(square, boardsquare);
                }
            }

            foreach (KeyValuePair<string, BoardSquare> key in Square)
            {
                BoardSquare square = Square[key.ToString().Substring(1, 2)];                                       
                square.Panel.MouseEnter += EventHandler.SquareMouseEnterEvent;
                square.Panel.MouseHover += EventHandler.SquareMouseEnterEvent;
                square.Panel.MouseMove += EventHandler.BoardMouseMoveEvent;
            }
        }
    }
}
