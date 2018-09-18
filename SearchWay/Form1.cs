using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SearchWay
{
    public partial class Form1 : Form
    {
        Graphics fonG; //рисуем в блоке
        Image fon, defImg; //рисунок в блоке
        Point mouse; //позиция мыши
        bool enabledMove = true;
        int speed = 15;
        int moveX = 0, moveY = 0; //сдвиг
        
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            InitialBigImg();
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            /*fon = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            fonG = Graphics.FromImage(fon);*/
        }
        void Draw(int mvX, int mvY)
        {
            moveX += mvX; moveY += mvY;
            fonG.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
            fonG.DrawImageUnscaled(defImg, moveX, moveY);
            pictureBox1.Image = fon;
            pictureBox1.Invalidate();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Draw();
            if (enabledMove)
            {
                //точное определение координат для данной задачи
                mouse = Cursor.Position;
                mouse.Y = mouse.Y - this.Location.Y - 31;
                mouse.X = mouse.X - this.Location.X - 8;
                if (mouse.X < pictureBox1.Width * 0.2 && moveX < 0)
                    if (mouse.Y < pictureBox1.Width * 0.2 && moveY < 0) Draw(speed, speed);
                    else if (mouse.Y > pictureBox1.Width * 0.8 && moveY > -defImg.Height + pictureBox1.Height + 3) Draw(speed, -speed);
                    else Draw(speed, 0);
                else if (mouse.X > pictureBox1.Width * 0.8 && moveX > -defImg.Width + pictureBox1.Width + 3)
                    if (mouse.Y < pictureBox1.Width * 0.2 && moveY < 0) Draw(-speed, speed);
                    else if (mouse.Y > pictureBox1.Width * 0.8 && moveY > -defImg.Height + pictureBox1.Height + 3) Draw(-speed, -speed);
                    else Draw(-speed, 0);
                else if (mouse.Y < pictureBox1.Width * 0.2 && moveY < 0) Draw(0, speed);
                else if (mouse.Y > pictureBox1.Width * 0.8 && moveY > -defImg.Height + pictureBox1.Height + 3) Draw(0, -speed);
                else
                {
                    pictureBox1.Image = fon;
                    pictureBox1.Invalidate();
                }
            }
        }
        void InitialBigImg()
        {
            defImg = new Bitmap("C:\\img10.jpg");
            fon = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            fonG = Graphics.FromImage(fon);
            timer1.Enabled = true;
            pictureBox1.Image = defImg;
            pictureBox1.Invalidate();
        }
    }
}
