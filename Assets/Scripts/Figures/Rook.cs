using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Rook : BaseFigure
{
    protected override void InitFigure()
    {
        figureName = "Rook";
        weight = 5;
    }

    public override List<Coordinate> Move(Coordinate coordinate)
    {
        List<Coordinate> result = new List<Coordinate>();

        coordinate.GetStraightMoves(result);

        return result;
    }

    public override List<Coordinate> GetInitialPosition()
    {
        return new List<Coordinate>() {
                    new Coordinate('A', initialRow),
                    new Coordinate('H', initialRow),
            };
    }
}
