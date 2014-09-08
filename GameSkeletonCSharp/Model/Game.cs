using GameSkeletonCSharp.controller;
using GameSkeletonCSharp.controller.actions;
using GameSkeletonCSharp.helper;
using GameSkeletonCSharp.Model;
using GameSkeletonCSharp.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GameSkeletonCSharp.model
{
    public class Game
    {
        #region helpers
        private helper.Timer hqTimer;
        public Boolean GameRunning { get; set; }
        public Boolean Running { get; set; }
        #endregion
        #region
        public List<Dot> Dots { get; set; }
        public List<Rectangle> Rectangles { get; set; }
        #endregion
        #region views
        public GameCanvas Canvas { get; set; }
        public MainWindow GameWindow { get; set; }
        #endregion
        #region controllers
        public ActionContainer ActionsContainer { get; set; }
        public Boolean ProcessInput { get; set; }
        #endregion
        #region threads
        public Thread GameLoopThread { get; set; }
        public Thread ControllerThread { get; set; }
        #endregion

        public Game()
        {
            initModels();
            initView();
            this.Running = true;
            runGameLoop();
        }

        public void restartGame()
        {
            this.GameLoopThread.Abort();
            initModels();
            runGameLoop();
        }

        private void runGameLoop()
        {
            this.GameLoopThread = new Thread(new ThreadStart(gameLoop));
            this.GameLoopThread.IsBackground = true;
            this.GameLoopThread.Start();
        }

        /**
         * Initialize Models
         */
        private void initModels()
        {
            //Non-game specific models
            this.ActionsContainer = new ActionContainer();
            hqTimer = new helper.Timer();

            //Game specific models
            this.Dots = new List<Dot>();
            this.Rectangles = new List<Rectangle>();
        }

        /**
         * Initialize Views
         */
        private void initView()
        {
            this.GameWindow = new MainWindow(this);
            this.Canvas = new GameCanvas(this, this.GameWindow);
            this.GameWindow.Show();
        }

        /**
         * Game loop
         */
        private void gameLoop()
        {
            double TARGET_FPS = 60;
            double OPTIMAL_TIME = 1000 / TARGET_FPS;

            hqTimer.Start();
            long lastLoopTime = hqTimer.ElapsedMilliSeconds;

            long lastFpsTime = 0;
            int fps = 0;

            while (this.Running)
            {
                long now = hqTimer.ElapsedMilliSeconds;
                long updateLength = now - lastLoopTime;
                lastLoopTime = now;
                double delta = updateLength / OPTIMAL_TIME;

                lastFpsTime += updateLength;
                fps++;

                if (lastFpsTime >= 1000)
                {
                    lastFpsTime = 0;
                    fps = 0;
                }

                this.handleInput();
                this.gameLogic(delta);
                this.renderGame(delta);
                this.checkGameStatus();

                Thread.Sleep(25);
                if (lastLoopTime - hqTimer.ElapsedMilliSeconds + OPTIMAL_TIME > 0)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(lastLoopTime - hqTimer.ElapsedMilliSeconds + OPTIMAL_TIME));
                }

            }
        }

        /**
         * Handle the input from the controllers
         */
        private void handleInput()
        {

            lock (this.ActionsContainer)
            {
                ControllerAction action;
                while (this.ActionsContainer.Count > 0)
                {
                    this.ActionsContainer.TryDequeue(out action);
                    if (action == null)
                    {
                        continue;
                    }
                    action.execute();
                }
            }
            this.ProcessInput = false;
        }


        /**
         * Update Models
         */
        private void gameLogic(double dt)
        {

        }

        /**
         * Update View
         */
        private void renderGame(double dt)
        {
            this.Canvas.update();
        }

        /**
         * Check the game status
         */
        private void checkGameStatus()
        {

        }
    }
}
