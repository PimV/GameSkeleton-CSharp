using GameSkeletonCSharp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameSkeletonCSharp.Model
{
    public class Rectangle : Entity
    {

        public Rectangle(double x, double y)
            : base(x, y)
        {
            this.Height = 30;
            this.Width = 30;
            this.moveSpeed = 0;
        }

        public override UIElement draw()
        {
            System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
            rect.Width = this.Width;
            rect.Height = this.Height;
            rect.Fill = new SolidColorBrush(Colors.Blue);
            Canvas.SetLeft(rect, this.X - rect.Width / 2);
            Canvas.SetTop(rect, this.Y - rect.Height / 2);
            return rect;
        }

    }
}
