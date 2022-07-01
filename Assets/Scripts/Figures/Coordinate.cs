using System.Collections.Generic;
using UnityEngine;

public class Coordinate
{
    public static int MinColumn = 'A';
    public static int MaxColumn = 'H';
    public static int MinRow = 1;
    public static int MaxRow = 8;

    public bool valid { get; private set; }
    public int column { get; private set; }
    public int row { get; private set; }

    public Coordinate(int c, int r)
    {
        valid = Check(c, r);
        column = valid ? c : 0;
        row = valid ? r : 0;
    }

    public static Coordinate operator+(Coordinate c, Direction d)
    {
        Coordinate coordinate = new Coordinate(c.column + d.horizontal, c.row + d.vertical);

        coordinate.valid = coordinate.valid && c.valid;

        return coordinate;
    }

    private bool Check(int column, int row)
    {
        return (column >= MinColumn && column <= MaxColumn) && (row >= MinRow && row <= MaxRow);
    }

    public string Description()
    {
        return char.ToString((char)column) + row.ToString();
    }

    // ABSTRACTION
    private void Repeat(Direction direction, List<Coordinate> result, int maxSteps)
    {
        Coordinate coordinate = this;

        do
        {
            maxSteps--;
            coordinate += direction;
            if (coordinate.valid)
            {
                result.Add(coordinate);
            }
        } while (coordinate.valid && maxSteps > 0);
    }

    private void GetDiagonalMovesInternal(List<Coordinate> result, int maxSteps)
    {
        if (valid)
        {
            Repeat(Direction.ForwardRight, result, maxSteps);
            Repeat(Direction.ForwardLeft, result, maxSteps);
            Repeat(Direction.BackwardRight, result, maxSteps);
            Repeat(Direction.BackwardLeft, result, maxSteps);
        }
    }

    private void GetStraightMovesInternal(List<Coordinate> result, int maxSteps)
    {
        if (valid)
        {
            Repeat(Direction.Forward, result, maxSteps);
            Repeat(Direction.Backward, result, maxSteps);
            Repeat(Direction.Right, result, maxSteps);
            Repeat(Direction.Left, result, maxSteps);
        }
    }

    // POLYMORPHISM
    public void GetDiagonalMoves(List<Coordinate> result)
    {
        GetDiagonalMovesInternal(result, int.MaxValue);
    }

    // POLYMORPHISM
    public void GetStraightMoves(List<Coordinate> result)
    {
        GetStraightMovesInternal(result, int.MaxValue);
    }

    // POLYMORPHISM
    public void GetDiagonalMoves(List<Coordinate> result, int maxSteps)
    {
        GetDiagonalMovesInternal(result, maxSteps);
    }

    // POLYMORPHISM
    public void GetStraightMoves(List<Coordinate> result, int maxSteps)
    {
        GetStraightMovesInternal(result, maxSteps);
    }

    public List<Coordinate> GetValidMoves(List<Direction> directions)
    {
        List<Coordinate> result = new List<Coordinate>();

        if (valid)
        {
            foreach (Direction direction in directions)
            {
                Coordinate coordinate = this + direction;

                if (coordinate.valid)
                {
                    result.Add(coordinate);
                }
            }
        }

        return result;
    }
}

public class Direction
{
    public int horizontal;
    public int vertical;

    public static Direction Forward { get { return new Direction(0, 1); } }
    public static Direction Backward { get { return new Direction(0, -1); } }
    public static Direction Right { get { return new Direction(1, 0); } }
    public static Direction Left { get { return new Direction(-1, 0); } }

    public static Direction ForwardRight { get { return new Direction(1, 1); } }
    public static Direction ForwardLeft { get { return new Direction(-1, 1); } }
    public static Direction BackwardRight { get { return new Direction(1, -1); } }
    public static Direction BackwardLeft { get { return new Direction(-1, -1); } }


    public Direction(int h, int v)
    {
        horizontal = h;
        vertical = v;
    }

    public static Direction operator*(Direction a, int m)
    {
        return new Direction(a.horizontal * m, a.vertical * m);
    }

    public static Direction operator+(Direction a, Direction b)
    {
        return new Direction(a.horizontal + b.horizontal, a.vertical + b.vertical);
    }
}