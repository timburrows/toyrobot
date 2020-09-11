using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using ToyRobot.Components;
using ToyRobot.ConsoleApp.Options;
using ToyRobot.Math;
using ToyRobot.Scene;

namespace ToyRobot.ConsoleApp
{
    public class Application
    {
        private RobotEntity _robot;
        private BoardEntity _board;

        public Application()
        {
            _board = new BoardEntity();
        }
        public void Run(IEnumerable<string> args)
        {
            var scene = new RootComponent();
            _board.AttachTo(scene);

            while (true)
            {
                var command = Console.ReadLine()?.Split(' ').ToArray();
                
                var result = Parser.Default.ParseArguments<PlaceOptions, MoveOptions, LeftOptions, RightOptions, ReportOptions>(command)
                    .MapResult(
                        (PlaceOptions options) => DoPlace(options, scene),
                        (MoveOptions options) => DoMove(options),
                        (LeftOptions options) => DoLeft(options),
                        (RightOptions options) => DoRight(options),
                        (ReportOptions options) => DoReport(options),
                        _ => 1
                    );
                
                if (result != null && (int) result == 1)
                {
                    return;
                }
            }
        }

        private object DoReport(ReportOptions options)
        {
            _robot.Report();
            return null;
        }

        private object DoPlace(PlaceOptions options, RootComponent scene)
        {
            if (_robot == null)
            {
                _robot = new RobotEntity();
                _robot.AttachTo(scene);
            }

            _robot.Place(new Vector(options.PosX, options.PosY, 0f), options.Facing);
            
            Console.WriteLine($"Robot is at {_robot.GetPosition().X}, {_robot.GetPosition().Y} " +
                              $"facing {Orientation.FromVector(_robot.GetOrientation()).CardinalDirection}");

            return null;
        }

        private object DoMove(MoveOptions options)
        {
            _robot.Move();
            return null;
        }

        private object DoLeft(LeftOptions options)
        {
            _robot.RotateLeft();
            return null;
        }

        private object DoRight(RightOptions options)
        {
            _robot.RotateRight();
            return null;
        }
    }
}