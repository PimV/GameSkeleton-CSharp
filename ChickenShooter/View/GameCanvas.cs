using GameSkeletonCSharp.controller;
using GameSkeletonCSharp.Controller;
using GameSkeletonCSharp.model;
using GameSkeletonCSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameSkeletonCSharp.view
{
    public class GameCanvas : Canvas
    {

        private MainWindow gameWindow;
        private Game game;


        public GameCanvas(Game game, MainWindow gameWindow)
            : base()
        {

            this.game = game;
            this.gameWindow = gameWindow;

            this.Background = new SolidColorBrush(Colors.White);
            this.SetValue(Grid.ColumnProperty, 1);
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            this.MaxWidth = 500;
            this.MaxHeight = 300;
            this.SetValue(Grid.ColumnSpanProperty, 2);

            this.gameWindow.mainGrid.Children.Add(this);

            this.game.ControllerThread = new Thread(makeController);
            this.game.ControllerThread.Start();
        }

        public void makeController()
        {
            ClickController cc = new ClickController(this.game);

            //Sleep so thread stays alive
            while (this.game.Running)
            {
                Thread.Sleep(10);
            }
        }




        public void update()
        {
            //Utilize UI Thread to update GUI
            this.Dispatcher.Invoke(new Action(() =>
            {
                clearCanvas();
                //Methods where we loop through our models to draw them
                drawDots();
                drawRectangles();
            }));
        }



        private void drawDots()
        {
            foreach (Dot dot in this.game.Dots)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = dot.Width;
                ellipse.Height = dot.Height;
                ellipse.Fill = new SolidColorBrush(Colors.Red);
                Canvas.SetLeft(ellipse, dot.X - ellipse.Width / 2);
                Canvas.SetTop(ellipse, dot.Y - ellipse.Height / 2);
                this.Children.Add(ellipse);
            }
        }

        private void drawRectangles()
        {
            foreach (Model.Rectangle rectangle in this.game.Rectangles)
            {

                System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
                rect.Width = rectangle.Width;
                rect.Height = rectangle.Height;
                rect.Fill = new SolidColorBrush(Colors.Blue);
                Canvas.SetLeft(rect, rectangle.X - rect.Width / 2);
                Canvas.SetTop(rect, rectangle.Y - rect.Height / 2);
                this.Children.Add(rect);
            }
        }

        public void clearCanvas()
        {
            this.Children.Clear();
        }

    }
}
