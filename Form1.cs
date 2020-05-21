using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class MemoryGrid : Form
    {
        public MemoryGrid()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            this.Width = 400;
            this.Height = 400;
            Grid.BackColor = Color.LightSteelBlue;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
        }
    }
}
