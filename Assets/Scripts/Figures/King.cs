using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class King : BaseFigure
{
    private int maxSteps = 1;

    protected override void InitFigure()
    {
        figureName = "King";
        weight = int.MaxValue;
    }

    public override List<Coordinate> Move(Coordinate coordinate)
    {
        List<Coordinate> result = new List<Coordinate>();

        coordinate.GetDiagonalMoves(result, maxSteps);
        coordinate.GetStraightMoves(result, maxSteps);

        return result;
    }

    public override List<Coordinate> GetInitialPosition()
    {
        return new List<Coordinate>() {
                new Coordinate('E', initialRow),
            };
    }
}