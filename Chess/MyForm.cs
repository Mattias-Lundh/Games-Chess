using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    class MyForm : Form
    {
        public MyForm()
        {
            TableLayoutPanel panel = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 2,
                BackColor = Color.Aquamarine,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 0)
            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 80));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));

            Controls.Add(panel);
            Board board = new Board { };
            panel.Controls.Add(board.LayoutPanel);
            Game game1 = new Game(board);
            game1.StartGame();
        }
    }
}
