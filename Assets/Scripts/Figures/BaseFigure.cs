using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFigure : MonoBehaviour
{
    protected int initialRow;
    private string m_color;

    public string figureName { get; protected set; }
    public int weight { get; protected set; }

    // INCAPSULATION
    public string color
    {
        get
        {
            return m_color;
        }
        set
        {
            m_color = value;
            FillInitialRow();
        }
    }

    public abstract List<Coordinate> Move(Coordinate coordinate);
    public abstract List<Coordinate> GetInitialPosition();
    protected abstract void InitFigure();

    private void InitColor()
    {
        if (color != "White" && color != "Black")
        {
            color = "White"; // default color
        }
    }

    protected virtual void FillInitialRow()
    {
        // default initial row, Pawn will rewrite it
        initialRow = (color == "White") ? Coordinate.MinRow : Coordinate.MaxRow;
    }

    public void Start()
    {
        InitColor();
        FillInitialRow();
        InitFigure();
    }
}