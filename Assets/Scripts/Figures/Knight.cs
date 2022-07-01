using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Knight : BaseFigure
{
    protected override void InitFigure()
    {
        figureName = "Knight";
        weight = 3;
    }

    public override List<Coordinate> Move(Coordinate coordinate)
    {
        List<Direction> directions = new List<Direction>() {
            Direction.Forward * 2 + Direction.Right,
            Direction.Forward * 2 + Direction.Left,
            Direction.Backward * 2 + Direction.Right,
            Direction.Backward * 2 + Direction.Left,
            Direction.Right * 2 + Direction.Forward,
            Direction.Right * 2 + Direction.Backward,
            Direction.Left * 2 + Direction.Forward,
            Direction.Left * 2 + Direction.Backward,
        };

        return coordinate.GetValidMoves(directions);
    }

    public override List<Coordinate> GetInitialPosition()
    {
        return new List<Coordinate>() {
                    new Coordinate('B', initialRow),
                    new Coordinate('G', initialRow),
            };
    }
}
