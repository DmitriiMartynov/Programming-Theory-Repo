using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Queen : BaseFigure
{
    protected override void InitFigure()
    {
        figureName = "Queen";
        weight = 9;
    }

    public override List<Coordinate> Move(Coordinate coordinate)
    {
        List<Coordinate> result = new List<Coordinate>();

        coordinate.GetDiagonalMoves(result);
        coordinate.GetStraightMoves(result);

        return result;
    }

    public override List<Coordinate> GetInitialPosition()
    {
        return new List<Coordinate>() {
                new Coordinate('D', initialRow)
            };
    }
}
