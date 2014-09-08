using GameSkeletonCSharp.Controller.actions;
using GameSkeletonCSharp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameSkeletonCSharp.Controller
{
    public class ClickController : BaseController
    {

        public ClickController(Game game)
            : base(game)
        {
            addMouseListener();
        }

        public void addMouseListener()
        {
            game.Canvas.MouseDown += new MouseButtonEventHandler(mouseDownEvent);
        }

        private void mouseDownEvent(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                this.game.ActionsContainer.Enqueue(new RightClickAction(this.game, Mouse.GetPosition(this.game.Canvas)));
            }
            if (e.ChangedButton == MouseButton.Left)
            {
                this.game.ActionsContainer.Enqueue(new LeftClickAction(this.game, e.GetPosition(this.game.Canvas)));
            }
        }

    }
}
