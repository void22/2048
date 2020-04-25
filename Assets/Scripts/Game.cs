using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Game
    {
        #region Fields
        private readonly int[] _positions = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        private readonly GameManager _gameManager;
        private List<Tile> _tiles = new List<Tile>();
        private List<Tile[]> _columns = new List<Tile[]>();
        private List<Tile[]> _rows = new List<Tile[]>();
        private List<Tile> _emptyTiles = new List<Tile>();
        #endregion

        #region Properties
        public int Score { get; set; }
        #endregion

        #region Constructor
        public Game(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        #endregion

        #region Methods
        public void Create()
        {
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

            _columns.Add(new Tile[] { _tiles[0], _tiles[4], _tiles[8], _tiles[12] });
            _columns.Add(new Tile[] { _tiles[1], _tiles[5], _tiles[9], _tiles[13] });
            _columns.Add(new Tile[] { _tiles[2], _tiles[6], _tiles[10], _tiles[14] });
            _columns.Add(new Tile[] { _tiles[3], _tiles[7], _tiles[11], _tiles[15] });

            _rows.Add(new Tile[] { _tiles[0], _tiles[1], _tiles[2], _tiles[3] });
            _rows.Add(new Tile[] { _tiles[4], _tiles[5], _tiles[6], _tiles[7] });
            _rows.Add(new Tile[] { _tiles[8], _tiles[9], _tiles[10], _tiles[11] });
            _rows.Add(new Tile[] { _tiles[12], _tiles[13], _tiles[14], _tiles[15] });

            _emptyTiles.AddRange(_tiles);
        }

        public void Init()
        {
            SetRandomTile();
            SetRandomTile();
            UpdateTiles();

            Score = 0;
        }

        public void Update(GameManager.Direction direction)
        {
            ResetMergedFlags();

            bool tileMoved = false;

            for (int i = 0; i < 4; i++)
            {
                switch (direction)
                {
                    case GameManager.Direction.Left:
                        while (ShiftLeft(_rows[i])) { tileMoved = true; }
                        break;

                    case GameManager.Direction.Right:
                        while (ShiftRight(_rows[i])) { tileMoved = true; }
                        break;

                    case GameManager.Direction.Up:
                        while (ShiftLeft(_columns[i])) { tileMoved = true; }
                        break;

                    case GameManager.Direction.Down:
                        while (ShiftRight(_columns[i])) { tileMoved = true; }
                        break;
                }
            }

            if (tileMoved)
            {
                UpdateEmptyList();
                SetRandomTile();

                if (!IsValidMoveExist())
                    GameOver();
            }

            UpdateTiles();
        }

        private void GameWon()
        {
            _gameManager.State = GameManager.GameState.Stopped;
        }

        private void GameOver()
        {
            _gameManager.State = GameManager.GameState.Stopped;
        }

        private void UpdateTiles()
        {
            for (int i = 0; i < 16; i++)
            {
                if (_tiles[i].Value == 0)
                {
                    _tiles[i].Hide();
                }
                else
                {
                    _tiles[i].Show();
                }
            }
        }

        private void ResetMergedFlags()
        {
            foreach (Tile tile in _tiles)
                tile.Merged = false;
        }

        private void UpdateEmptyList()
        {
            _emptyTiles.Clear();

            foreach (Tile tile in _tiles)
                if (tile.Value == 0)
                    _emptyTiles.Add(tile);
        }

        private bool IsValidMoveExist()
        {
            if (_emptyTiles.Count > 0)
                return true;
            else
            {
                // check columns
                for (int i = 0; i < _columns.Count; i++)
                    for (int j = 0; j < _rows.Count - 1; j++)
                        if (_tiles[(j * 4) + i].Value == _tiles[((j + 1) * 4) + i].Value)
                            return true;

                // check rows
                for (int i = 0; i < _rows.Count; i++)
                    for (int j = 0; j < _columns.Count - 1; j++)
                        if (_tiles[(i * 4) + j].Value == _tiles[(i * 4) + j + 1].Value)
                            return true;

            }
            return false;
        }

        private bool ShiftLeft(Tile[] tiles)
        {
            for (int i = 0; i < tiles.Length - 1; i++)
            {
                if (tiles[i].Value == 0 && tiles[i + 1].Value != 0)
                {
                    tiles[i].Value = tiles[i + 1].Value;
                    tiles[i + 1].Value = 0;

                    return true;
                }

                if (tiles[i].Value != 0  
                    && tiles[i].Value == tiles[i + 1].Value
                    && tiles[i].Merged == false
                    && tiles[i + 1].Merged == false)
                {
                    tiles[i].Value *= 2;
                    tiles[i + 1].Value = 0;
                    tiles[i].Merged = true;
                    Score += tiles[i].Value;

                    if (tiles[i].Value == 2048)
                        GameWon();

                    return true;
                }
            }

            return false;
        }

        private bool ShiftRight(Tile[] tiles)
        {
            for (int i = tiles.Length - 1; i > 0; i--)
            {
                if (tiles[i].Value == 0 && tiles[i - 1].Value != 0)
                {
                    tiles[i].Value = tiles[i - 1].Value;
                    tiles[i - 1].Value = 0;

                    return true;
                }

                if (tiles[i].Value != 0
                    && tiles[i].Value == tiles[i - 1].Value
                    && tiles[i].Merged == false
                    && tiles[i - 1].Merged == false)
                {
                    tiles[i].Value *= 2;
                    tiles[i - 1].Value = 0;
                    tiles[i].Merged = true;
                    Score += tiles[i].Value;

                    if (tiles[i].Value == 2048)
                        GameWon();

                    return true;
                }
            }

            return false;
        }

        private void SetRandomTile()
        {
            if (_emptyTiles.Count > 0)
            {
                int index = Random.Range(0, _emptyTiles.Count);
                int chance = Random.Range(0, 9);

                // 10% chance to get tile with value of 4
                if (chance == 0)
                    _emptyTiles[index].Value = 4;
                else
                    _emptyTiles[index].Value = 2;

                _emptyTiles.RemoveAt(index);
            }
        }
        #endregion
    }
}
