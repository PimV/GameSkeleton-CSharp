using GameSkeletonCSharp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSkeletonCSharp.Controller
{
    public abstract class BaseController
    {
        protected Game game;

        public BaseController(Game game)
        {
            this.game = game;
        }

    }
}
