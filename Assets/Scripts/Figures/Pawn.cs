using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Pawn : BaseFigure
{
    // POLYMORPHISM
    protected override void FillInitialRow()
    {
        initialRow = (color == "White") ? Coordinate.MinRow + 1 : Coordinate.MaxRow - 1;
    }

    protected override void InitFigure()
    {
        figureName = "Pawn";
        weight = 1;
    }

    public override List<Coordinate> Move(Coordinate coordinate)
    {
        List<Direction> directions = new List<Direction>();

        if (color == "White")
        {
            if (coordinate.row == initialRow)
            {
                directions.Add(Direction.Forward);
                directions.Add(Direction.Forward * 2);
            }
            else if ((coordinate.row >= initialRow + 1) && (coordinate.row <= Coordinate.MaxRow - 1))
            {
                directions.Add(Direction.Forward);
            }
        }
        else
        {
            if (coordinate.row == initialRow)
            {
                directions.Add(Direction.Backward);
                directions.Add(Direction.Backward * 2);
            }
            else if ((coordinate.row >= Coordinate.MinRow + 1) && (coordinate.row <= initialRow - 1))
            {
                directions.Add(Direction.Backward);
            }
        }

        return coordinate.GetValidMoves(directions);
    }

    public override List<Coordinate> GetInitialPosition()
    {
        List<Coordinate> result = new List<Coordinate>();

        for (int i = Coordinate.MinColumn; i <= Coordinate.MaxColumn; i++)
        {
            result.Add(new Coordinate(i, initialRow));
        }

        return result;
    }
}
