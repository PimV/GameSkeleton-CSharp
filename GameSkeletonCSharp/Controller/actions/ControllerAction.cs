using GameSkeletonCSharp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSkeletonCSharp.controller.actions
{
    public abstract class ControllerAction
    {

        protected Game game;

        public ControllerAction(Game game)
        {
            this.game = game;
        }

        public abstract void execute();




    }


}
