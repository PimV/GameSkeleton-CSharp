using GameSkeletonCSharp.controller.actions;
using GameSkeletonCSharp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameSkeletonCSharp.Controller.actions
{
    class LeftClickAction : ControllerAction
    {
        private double x;
        private double y;

        public LeftClickAction(Game game, Point p)
            : base(game)
        {
            this.x = p.X;
            this.y = p.Y;
        }

        public override void execute()
        {
            this.game.Entities.Add(new Model.Rectangle(this.x, this.y));
        }

    }
}
