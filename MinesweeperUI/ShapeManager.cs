using System;
using System.Collections.Generic;
using System.Drawing;
using GameState;
using Generator;
using SFML.Graphics;
using SFML.System;
using Color = SFML.Graphics.Color;

namespace MinesweeperUI
{
    public class ShapeManager
    {
        private readonly Board board;
        private static readonly Vector2f RectangleSize = new Vector2f(200, 99);
        private static readonly Vector2f ResetSize = new Vector2f(100, 99);

        public Drawable ScoreRectangle { get; private set; }
        public Drawable TimeRectangle { get; private set; }
        public Drawable ResetRectangle { get; private set; }
        public Dictionary<Point, Drawable> Squares { get; private set; }

        public bool ShouldUpdate = true;

        public IEnumerable<Drawable> AllDrawables
        {
            get
            {
                var list = new List<Drawable> {ScoreRectangle, TimeRectangle, ResetRectangle};
                list.AddRange(Squares.Values);
                return list;
            }
        }

        public ShapeManager(Board board)
        {
            this.board = board;
            ScoreRectangle = GetScoreRectangle();
            TimeRectangle = GetTimeRectangle();
            ResetRectangle = GetResetRectangle();
            Update();
        }

        public void Update()
        {
            if (ShouldUpdate)
            {
                Squares = GetTileRectangles();
            }

            ShouldUpdate = false;
        }

        private Drawable GetScoreRectangle()
        {
            return new RectangleShape(RectangleSize)
            {
                FillColor = Color.Red,
                Position = new Vector2f(1, 1),
                OutlineThickness = .5f
            };
        }

        private Drawable GetTimeRectangle()
        {
            return new RectangleShape(RectangleSize)
            {
                FillColor = Color.Red,
                Position = new Vector2f(300, 1),
                OutlineThickness = .5f
            };
        }

        private Drawable GetResetRectangle()
        {
            return new RectangleShape(ResetSize)
            {
                FillColor = Color.Green,
                Position = new Vector2f(200, 1),
                OutlineThickness = .5f
            };
        }

        private Dictionary<Point, Drawable> GetTileRectangles()
        {
            var toDraw = new Dictionary<Point, Drawable>();
            var increment = 490f / board.BoardSize;

            Console.WriteLine($"Square size: {increment}");

            for (var i = 0; i < board.BoardSize; i++)
            {
                for (var j = 0; j < board.BoardSize; j++)
                {
                    var position = new Vector2f(5 + i * increment, 105 + j * increment);
                    var square = new RectangleShape(new Vector2f(increment, increment))
                    {
                        FillColor = new Color((byte) (i * 10), (byte) (j * 10), 75),
                        Position = position,
                        OutlineThickness = 1f
                    };
                    var tile = board.GetTile(new Point(j, i));

                    if (tile.ShouldRenderText)
                    {
                        var text = new Text(tile.TileValue.ToValue(), new Font("ARIAL.TTF"))
                        {
                            CharacterSize = 40,
                            Position = new Vector2f(5 + i * increment + .3f * increment, 105 + j * increment),
                            FillColor = Color.Red
                        };
                        toDraw.Add(new Point(i + 50, j + 50), new TileSquare(square, text));
                    }
                    else
                    {
                        toDraw.Add(new Point(i, j), new TileSquare(square, tile.TileState));
                    }
                }
            }

            return toDraw;
        }
    }
}