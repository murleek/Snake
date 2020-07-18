using Snake.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
	public partial class Form1 : Form
	{
		
		private List<Square> Snake = new List<Square>();
		private Square food = new Square();
		private Settings settings;
		public Form1()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
			InitializeComponent();
			settings = new Settings();
			gameTimer.Interval = 100 / settings.Speed;
			gameTimer.Tick += updateScreen;
			gameTimer.Start();
		}

		private void updateScreen(object sender, EventArgs e)
		{
			if (Input.KeyPress(Keys.Right) && settings.direction != Directions.Left)
				settings.direction = Directions.Right;
		
			else if (Input.KeyPress(Keys.Left) && settings.direction != Directions.Right)
				settings.direction = Directions.Left;
			
			else if (Input.KeyPress(Keys.Up) && settings.direction != Directions.Down)
				settings.direction = Directions.Up;
			
			else if (Input.KeyPress(Keys.Down) && settings.direction != Directions.Up)
				settings.direction = Directions.Down;

			else if (Input.KeyPress(Keys.K) && settings.isDebug == true)
				debugEat();
			

			movePlayer();
			
			pbCanvas.Invalidate();
		}
        // Debug eating
		private void debugEat()
		{
			Square body = new Square()
			{
				X = Snake[Snake.Count - 1].X,
				Y = Snake[Snake.Count - 1].Y
			};
			Snake.Add(body);
			settings.Score += 1;
			label3.Text = settings.Score.ToString();
		}
		private void movePlayer()
		{
			for (int i = Snake.Count - 1; i >= 0; i--)
			{
				if (i == 0)
				{
					switch (settings.direction)
					{
						case Directions.Right:
							Snake[i].X++;
							break;
						case Directions.Left:
							Snake[i].X--;
							break;
						case Directions.Up:
							Snake[i].Y--;
							break;
						case Directions.Down:
							Snake[i].Y++;
							break;
					}
					int maxXpos = pbCanvas.Size.Width / settings.Width;
					int maxYpos = pbCanvas.Size.Height / settings.Height;

                    if (Snake[i].X < 0)
						Snake[i].X = maxXpos;
					else if (Snake[i].X == maxXpos)
						Snake[i].X = 0;
					else if (Snake[i].Y < 0)
						Snake[i].Y = maxYpos;
					else if (Snake[i].Y == maxYpos)
						Snake[i].Y = 0;

					for (int j = 1; j < Snake.Count; j++)
					{
						if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
						{
							die();
						}
					}
					if (Snake[0].X == food.X && Snake[0].Y == food.Y)
					{
						eat();
					}
				}
				else
				{
					Snake[i].X = Snake[i - 1].X;
					Snake[i].Y = Snake[i - 1].Y;
				}
			}
		}
		private void keyDown(object sender, KeyEventArgs e)
		{
			Input.changeState(e.KeyCode, true);
		}
		private void keyUp(object sender, KeyEventArgs e)
		{
			Input.changeState(e.KeyCode, false);
		}
		private void updatePic(object sender, PaintEventArgs e)
		{
			Graphics canvas = e.Graphics;

			if (!settings.GameOver)
			{
				Brush snakeColour;

				for (int i = 0; i < Snake.Count; i++)
                {
                    snakeColour = i == 0 ? Brushes.Black : Brushes.Green;
					
                    canvas.FillRectangle(snakeColour, new Rectangle(
						Snake[i].X * settings.Width,
						Snake[i].Y * settings.Height,
						settings.Width, settings.Height
					));
					
					canvas.FillEllipse(Brushes.SpringGreen, new Rectangle(
						food.X * settings.Width,
						food.Y * settings.Height,
						settings.Width, settings.Height
					));
				}
			}
			else
			{
				label2.Text = $"Game is over";
				label2.Visible = true;
			}
		}
		private void startGame()
		{
			label2.Visible = false;
			settings = new Settings();
			Snake.Clear();
			Square head = new Square() { X = 10, Y = 5 };
			Snake.Add(head);
			label3.Text = settings.Score.ToString();
			generateFood();
		}
		private void generateFood()
		{
			int maxXpos = pbCanvas.Size.Width / settings.Width;
			int maxYpos = pbCanvas.Size.Height / settings.Height;

			Random rnd = new Random();

			food = new Square() { X = rnd.Next(0, maxXpos), Y = rnd.Next(0, maxYpos) };

		}
		private void eat()
		{
		   Square body = new Square()
			{
				X = Snake[Snake.Count - 1].X,
				Y = Snake[Snake.Count - 1].Y
			};
			Snake.Add(body);
			settings.Score += 1;
			label3.Text = settings.Score.ToString();
			generateFood();
		}
		private void die()
        {
            button2.Visible = true;
			settings.GameOver = true;
		}
        private void button2_Click(object sender, EventArgs e)
        {
			startGame();
            button2.Enabled = false;
            button2.Visible = false;
        }
		private void button1_Click(object sender, EventArgs e)
		{
		  
		   startGame();
		   button1.Enabled = false;
		   button1.Visible = false;
		}
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
