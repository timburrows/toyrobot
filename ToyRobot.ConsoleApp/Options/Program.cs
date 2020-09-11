using System;
using ToyRobot.Components;
using ToyRobot.Math;
using ToyRobot.Scene;

namespace ToyRobot.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new Application().Run(args);
            
            // Ran out of time to convert to proper tests! :(
            // TestRobot();
            // TestBoard();
            // TestTransform();
        }

        private static void TestRobot()
        {
            RobotEntity robot;
            BoardEntity board;

            var scene = new RootComponent()
                .Attach(board = new BoardEntity())
                .Attach(robot = new RobotEntity());
            
            robot.Place(new Vector(3f, 3f, 0f), CardinalDirection.South);
            robot.Move();
            robot.Move();
            
            Console.WriteLine($"Robot position: {robot.GetPosition().X}, {robot.GetPosition().Y}");
            Console.WriteLine($"Robot orientation: {Orientation.FromVector(robot.GetOrientation()).CardinalDirection}");

            robot.RotateLeft();
            robot.RotateLeft();
            robot.Move();
            
            Console.WriteLine($"Robot position: {robot.GetPosition().X}, {robot.GetPosition().Y}");
            Console.WriteLine($"Robot orientation: {Orientation.FromVector(robot.GetOrientation()).CardinalDirection}");
            
            robot.Move();
            
            Console.WriteLine($"Robot position: {robot.GetPosition().X}, {robot.GetPosition().Y}");
            Console.WriteLine($"Robot orientation: {Orientation.FromVector(robot.GetOrientation()).CardinalDirection}");

            // Console.WriteLine($"Robot is spawned: {robot.IsSpawned}");
            
            robot.RotateLeft();
            Console.WriteLine($"Robot orientation: {Orientation.FromVector(robot.GetOrientation()).CardinalDirection}");
            
            robot.RotateLeft();
            Console.WriteLine($"Robot orientation: {Orientation.FromVector(robot.GetOrientation()).CardinalDirection}");
            robot.RotateLeft();
            Console.WriteLine($"Robot orientation: {Orientation.FromVector(robot.GetOrientation()).CardinalDirection}");
            robot.RotateLeft();
            Console.WriteLine($"Robot orientation: {Orientation.FromVector(robot.GetOrientation()).CardinalDirection}");
            
            robot.RotateRight();
            Console.WriteLine($"Robot orientation: {Orientation.FromVector(robot.GetOrientation()).CardinalDirection}");
            
            robot.RotateRight();
            Console.WriteLine($"Robot orientation: {Orientation.FromVector(robot.GetOrientation()).CardinalDirection}");
            robot.RotateRight();
            Console.WriteLine($"Robot orientation: {Orientation.FromVector(robot.GetOrientation()).CardinalDirection}");
            robot.RotateRight();
            Console.WriteLine($"Robot orientation: {Orientation.FromVector(robot.GetOrientation()).CardinalDirection}");

        }

        private static void TestBoard()
        {
            var board = new BoardEntity();
            var smallBoard = new BoardEntity(new Vector(1f, 1f, 1f));
            smallBoard.SetPosition(new Vector(4f, 4f, 4f));
            // var isOnBoard = board.IsMovementWithinBounds(smallBoard, new Vector(1f, 0f, 0f));
            smallBoard.AddRelativePosition(new Vector(1f, 0f, 0f));
            var isOnBoard = board.IsComponentWithinBounds(smallBoard);

            Console.WriteLine($"Is the small board on the big board? {isOnBoard}");
        }

        private static void TestTransform()
        {
            var trans = new Transform()
            {
                Rotation = Orientation.FromCardinal(CardinalDirection.North).Direction,
                Translation = new Vector(0f, 0f, 0f)
            };

            Console.WriteLine("FromCardinal...");
            Console.WriteLine($"Rotation: {trans.Rotation.X}, {trans.Rotation.Y}, {trans.Rotation.Z}");
            Console.WriteLine($"Translation: {trans.Translation.X}, {trans.Translation.Y}, {trans.Translation.Z}");


            trans = new Transform()
            {
                Rotation = Orientation.FromVector(new Vector(0f, 1f, 0f)).Direction,
                Translation = new Vector(1.0f, 0.0f, 0.0f)
            };

            Console.WriteLine("FromVector...");
            Console.WriteLine($"Rotation: {trans.Rotation.X}, {trans.Rotation.Y}, {trans.Rotation.Z}");
            Console.WriteLine($"Translation: {trans.Translation.X}, {trans.Translation.Y}, {trans.Translation.Z}");
        }
    }
}