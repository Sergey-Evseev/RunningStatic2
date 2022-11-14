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
        Label label1;
        public Form1()
        {
            InitializeComponent();
            label1 = new Label();
            this.Load += Form_Load; //обработчик события закреплен на загрузке формы
            this.MouseMove += FormMouseMove; //на движении мыши по форме закреплен обработчик FormMouseMove
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
            LabelCenter(label1); //метод центрирования лейбла
        }
        private void FormMouseMove(object sender, MouseEventArgs e)
        {   //если указатель мыши ближе 20 points от левого края или ближе 20 points от правого края:
            if ((e.X > label1.Location.X - 20 ) && (e.X < label1.Location.X + label1.Width  + 20)
                //и если указатель мыши ближе 20 points от верхнего края или ближе 20 px от нижнего края:
                && ((e.Y > label1.Location.Y - 20) && e.Y < label1.Location.Y + label1.Height +20)
                )
            {   
                //если указатель ближе 20 pts слева - сдвинуть левый край на 10 points вправо  
                //public double Left { get; set; } Возвращает или задает расстояние в точках между 
                //левым краем Label и левым краем рабочего листа.
                if (e.X > label1.Location.X - 20 && e.X < label1.Location.X) { label1.Left += 10; }

                //или если указатель ближе 20 points от правого края  
                else if (e.X < label1.Location.X + label1.Width + 20 && e.X > label1.Location.X + label1.Width)
                { label1.Left -= 10; } //сдвинуть левый край на 10 точек влево относительно рабочей формы

                //**По вертикальным координатам вместо Location.Y (+Height) использую методы Top и Bottom 
                //или если указатель ближе 20 points от верхнего края (движение курсора сверху)  
                else if (e.Y > label1.Top - 20 && e.Y < label1.Top)
                {
                    label1.Top += 10;
                }
                //если указатель ближе 20 pts от нижнего края (движение снизу)
                else if (e.Y < label1.Bottom + 20 && e.Y > label1.Bottom)
                {
                    label1.Top -= 10;
                }
                //Проверка границ формы и возврат лейбла в центр
                //если лейбл за левой границей формы либо правый край лейбла за правым краем формы
                if ((label1.Location.X < 0 || label1.Location.X > ClientSize.Width - label1.Width) 
                    //если лейбл выше верхнего края формы либо его нижний край за нижнем краем формы
                    || (label1.Location.Y < 0 || label1.Location.Y > ClientSize.Height - label1.Height))
                {
                   LabelCenter(label1);
                }

            }//конец условия приближения ближе 20 pts
        } //конец метода-обработчика FormMouseMove

        void LabelCenter(Label label) //центрирование «статика»
        {
            label.Left = (ClientSize.Width - label.Size.Width) / 2;
            label.Top = (ClientSize.Height - label.Size.Height) / 2;
        }
    } //конец класса формы
}
