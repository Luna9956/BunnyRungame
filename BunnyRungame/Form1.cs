using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunnyRungame
{
    public partial class Form1 : Form
    {
        int gravity;
        int gravityValue = 8;
        int obstaclespeed = 15;
        int score = 0;
        int highscore = 0;
        bool gameOver = false;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            RestartGame();
          
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !gameOver)
            {
                Jump();
            }
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }

        }
        private void Jump()
        {            
                gravity = -gravityValue; // Apply an upward force  
        }
        private void GameTimerEvent(object sender, EventArgs e)
        {
            
            lblscore.Text = "Score:" +score;
            lblhighscore.Text = "highscore:" + highscore;
            Player.Top += gravity;
            gravity += 1;
            pictureBox1.Left -= obstaclespeed;
            
            

            if (Player.Bottom >= 290) // Check if the player is on or slightly above the ground
            {
                Player.Top = 290 - Player.Height;
                gravity = 0; // Reset gravity when the player is on the ground
            }
            if (pictureBox1.Left < -100)
            {
                pictureBox1.Left = random.Next(1200, 3000);
                score += 1;
            }

            if (pictureBox1.Bounds.IntersectsWith(Player.Bounds) )
            {
                gametimer.Stop();
                Player.Image = Properties.Resources.deadgm_removebg_preview;
                
                lblscore.Text += "Game Over !! press enter to restart.";
                gameOver = true;
                if(score> highscore)
                {
                    highscore = score;
                }
            }
            if(score>10)
            {
                obstaclespeed = 30;
                gravityValue = 15;
            }
        }
        private void RestartGame()
        {
            Player.Location = new Point(101, 290);
            Player.Image = Properties.Resources.gameRabbit;
            score = 0;
            gravityValue = 8;
            gravity = gravityValue;
            obstaclespeed = 15;
            pictureBox1.Left = random.Next(1200, 3000);
            gametimer.Start();
            gameOver = false;
            
        }
    }
}
