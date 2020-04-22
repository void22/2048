using UnityEngine;
using System.Collections.Generic;

public class Table
{
    readonly int[] _positions = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    int[] _values;
    List<int> _emptyPositions;
    List<Tile> _tiles;
    List<int[]> _columns;
    List<int[]> _rows;

    public void Init()
    {
        _values = new int[16];

        _columns = new List<int[]>();
        _columns.Add(new int[] { 0, 4, 8, 12 });
        _columns.Add(new int[] { 1, 5, 9, 13 });
        _columns.Add(new int[] { 2, 6, 10, 14 });
        _columns.Add(new int[] { 3, 7, 11, 15 });

        _rows = new List<int[]>();
        _rows.Add(new int[] { 0, 1, 2, 3 });
        _rows.Add(new int[] { 4, 5, 6, 7 });
        _rows.Add(new int[] { 8, 9, 10, 11 });
        _rows.Add(new int[] { 12, 13, 14, 15 });

        _emptyPositions = new List<int>();
        _emptyPositions.AddRange(_positions);

        _tiles = new List<Tile>();
        _tiles.Add(new Tile("0"));
        _tiles.Add(new Tile("1"));
        _tiles.Add(new Tile("2"));
        _tiles.Add(new Tile("3"));
        _tiles.Add(new Tile("4"));
        _tiles.Add(new Tile("5"));
        _tiles.Add(new Tile("6"));
        _tiles.Add(new Tile("7"));
        _tiles.Add(new Tile("8"));
        _tiles.Add(new Tile("9"));
        _tiles.Add(new Tile("10"));
        _tiles.Add(new Tile("11"));
        _tiles.Add(new Tile("12"));
        _tiles.Add(new Tile("13"));
        _tiles.Add(new Tile("14"));
        _tiles.Add(new Tile("15"));

        SetRandomTile();
        SetRandomTile();
    }

    public bool IsPositionEmpty(int x, int y)
    {
        return _values[(4 * y) + x] == 0;
    }

    public bool IsPositionEmpty(int index)
    {
        int x = index % 4;
        int y = index / 4;

        return _values[(4 * y) + x] == 0;
    }

    public void SetPosition(int x, int y, int value)
    {
        int index = (4 * y) + x;

        _values[index] = value;
        _emptyPositions.RemoveAt(index);
    }

    public void SetPosition(int index, int value)
    {
        int x = index % 4;
        int y = index / 4;

        _values[(4 * y) + x] = value;
        _emptyPositions.RemoveAt(index);
    }

    public int SetRandomTile()
    {
        int index = Random.Range(0, _emptyPositions.Count);

        SetPosition(index, 2);

        return index;
    }

    public void UpdateTiles()
    {
        for (int i = 0; i < 16; i++)
        {
            if (_values[i] == 0)
            {
                _tiles[i].Hide();
            }
            else
            {
                _tiles[i].ChangeTexture(_values[i]);
                _tiles[i].Show();
            }
        }
    }

    public void UpdateEmptyList()
    {
        _emptyPositions.Clear();

        for (int i = 0; i < _values.Length; i++)
            if (_values[i] == 0)
                _emptyPositions.Add(i);
    }

    public void Move(GameManager.Direction direction)
    {
        bool tileMoved = false;

        for (int i = 0; i < 4; i++)
        {
            switch (direction)
            {
                case GameManager.Direction.Left:
                    while (MoveLeft(i)) { tileMoved = true; }
                    break;

                case GameManager.Direction.Right:
                    while (MoveRight(i)) { tileMoved = true; }
                    break;

                case GameManager.Direction.Up:
                    while (MoveUp(i)) { tileMoved = true; }
                    break;

                case GameManager.Direction.Down:
                    while (MoveDown(i)) { tileMoved = true; }
                    break;
            }
        }

        if (tileMoved)
        {
            UpdateEmptyList();
            SetRandomTile();
        }
    }

    public bool MoveLeft(int index)
    {
        int[] row = _rows[index];

        for (int i = 0; i < 3; i++)
        {
            if (_values[row[i]] == 0 && _values[row[i + 1]] != 0)
            {
                _values[row[i]] = _values[row[i + 1]];
                _values[row[i + 1]] = 0;
                return true;
            }

            if (_values[row[i]] != 0 && _values[row[i]] == _values[row[i + 1]])
            {
                _values[row[i]] *= 2;
                _values[row[i + 1]] = 0;
                return true;
            }
        }

        return false;
    }

    public bool MoveRight(int index)
    {
        int[] row = _rows[index];

        for (int i = 3; i > 0; i--)
        {
            if (_values[row[i]] == 0 && _values[row[i - 1]] != 0)
            {
                _values[row[i]] = _values[row[i - 1]];
                _values[row[i - 1]] = 0;
                return true;
            }

            if (_values[row[i]] != 0 && _values[row[i]] == _values[row[i - 1]])
            {
                _values[row[i]] *= 2;
                _values[row[i - 1]] = 0;
                return true;
            }
        }

        return false;
    }

    public bool MoveUp(int index)
    {
        int[] col = _columns[index];

        for (int i = 0; i < 3; i++)
        {
            if (col[i] == 0 && col[i + 1] != 0)
            {
                col[i] = col[i + 1];
                col[i + 1] = 0;
                return true;
            }
        }

        return false;
    }

    public bool MoveDown(int index)
    {
        int[] col = _columns[index];

        for (int i = 3; i > 0; i--)
        {
            if (col[i] == 0 && col[i - 1] != 0)
            {
                col[i] = col[i - 1];
                col[i - 1] = 0;
                return true;
            }
        }

        return false;
    }
}
