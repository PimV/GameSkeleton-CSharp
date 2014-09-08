using GameSkeletonCSharp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameSkeletonCSharp.Model
{
    public class Dot : Entity
    {

        public Dot(double x, double y)
            : base(x, y)
        {
            this.Height = 30;
            this.Width = 30;
            this.moveSpeed = 0;
        }

        public override UIElement draw()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = this.Width;
            ellipse.Height = this.Height;
            ellipse.Fill = new SolidColorBrush(Colors.Red);
            Canvas.SetLeft(ellipse, this.X - ellipse.Width / 2);
            Canvas.SetTop(ellipse, this.Y - ellipse.Height / 2);
            return ellipse;
        }

    }
}
