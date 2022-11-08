using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunningStatic2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1 = new Label();
            this.Load += Form_Load; //обработчик события закреплен на загрузке формы
            //this.MouseMove += FormMouseMove;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Size = new Size(80, 80);
            label1.Text = $"Catch me!";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.AutoSize = false;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Orange;
            Controls.Add(label1);
           //CenterLabel(label1); //метод центрирования лейбла
        }
        private void FormMouseMove(object sender, MouseEventArgs e)
        {   //если указатель мыши ближе 20 px от левого края или ближе 20 px от правого края:
            if ((e.X > label1.Location.X - 20 ) && (e.X < label1.Location.X + label1.Width  + 20)
                //или если указатель мыши ближе 20 px от верхнего края или ближе 20 px от нижнего края:
                || ((e.Y > label1.Location.Y - 20) && e.Y < label1.Location.Y + label1.Height +20)
                )
            {   //если указатель ближе 20 px слева - сдвинуть левый край на 10 px вправо  
                //public double Left { get; set; } Возвращает или задает расстояние в точках между 
                //левым краем Label и левым краем рабочего листа.
                if (e.X > label1.Location.X - 20 && e.X < label1.Location.X) { label1.Left += 10; }

                //
                else if (e.X < label1.Location.X + label1.Width + 20 && e.X > label1.Location.X + label1.Width)
                { }
            }
                

        }
    }
}
