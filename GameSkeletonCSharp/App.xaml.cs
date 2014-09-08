using GameSkeletonCSharp.controller;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.InteropServices;
using GameSkeletonCSharp.helper;
using GameSkeletonCSharp.model;
using System.Threading;

namespace GameSkeletonCSharp
{
    public partial class App : Application
    {
        public App()
        {
            Game game = new Game();
        }
    }
}
