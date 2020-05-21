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
        Random rand = new Random();
        List<string> icons = null;
        Label labelOne = null;
        Label labelTwo = null;
        Timer timer = null;

        public MemoryGrid()
        {
            InitializeComponent();
            InitializeIconsList();
            InitializeGrid();
            InitializeTimer();
            FillTheGrid();
            GenerateIcons();
            
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(Timer_Tick);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelOne.BackColor = Color.LightSteelBlue;
            labelTwo.BackColor = Color.LightSteelBlue;
            labelOne = null;
            labelTwo = null;
            timer.Stop();
        }

        private void InitializeIconsList()
        {
            icons = new List<string>
            {
                    "e", "e", "b", "b", "d", "d", "k", "k",
                    "v", "v", "!", "!", "$", "$", "{", "{"
            };
        }

        private void InitializeGrid()
        {
            this.Width = 600;
            this.Height = 600;
            Grid.BackColor = Color.LightSteelBlue;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
        }

        private void FillTheGrid()
        {
            Label lable;
            for(int c = 0; c < 4; c++)
            {
                for(int r = 0; r < 4; r++)
                {
                    lable = new Label
                    {
                        Dock = DockStyle.Fill,
                        ForeColor = Color.LightSteelBlue,
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = false,
                        Font = new Font("Webdings", 72)

                        //Text = "e"
                        //Visible = false
                    };
                    lable.Click += new EventHandler(Lable_Click);
                    Grid.Controls.Add(lable, c, r);
                }
            }
        }

        private void Lable_Click(object sender, EventArgs e)
        {
            Label lable = (Label)sender;
            lable.ForeColor = Color.Black;
            if(labelOne == null)
            {
                labelOne = lable;
                return;
            }
            else
            {
                labelTwo = lable;
                if (labelTwo == labelOne)
                {
                    return;
                }
                if(labelTwo.Text == labelOne.Text)
                {
                    labelOne = null;
                    labelTwo = null;
                    return;
                }
                else
                {
                    timer.Start();
                    return;
                }
            }
        }

        private void GenerateIcons()
        {
            Label lable;
            for (int i = 0; i < 16; i++)
            {
                int randomIndex = rand.Next(0, icons.Count);
                lable = (Label)Grid.Controls[i];
                lable.Text = icons[randomIndex];
                icons.RemoveAt(randomIndex);
            }           
        }

        private void MemoryGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.R)
            {
                InitializeIconsList();
                //GenerateIcons();
            }
        }
    }
}
