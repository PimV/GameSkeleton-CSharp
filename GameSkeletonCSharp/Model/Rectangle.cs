using GameSkeletonCSharp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
