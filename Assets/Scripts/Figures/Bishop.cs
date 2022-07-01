using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Bishop : BaseFigure
{
    protected override void InitFigure()
    {
        figureName = "Bishop";
        weight = 3;
    }

    public override List<Coordinate> Move(Coordinate coordinate)
    {
        List<Coordinate> result = new List<Coordinate>();

        coordinate.GetDiagonalMoves(result);

        return result;
    }

    public override List<Coordinate> GetInitialPosition()
    {
        return new List<Coordinate>() {
                new Coordinate('C', initialRow),
                new Coordinate('F', initialRow),
            };
    }
}
