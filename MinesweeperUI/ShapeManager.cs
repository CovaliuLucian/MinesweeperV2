using GameState;
using Generator;
using MinesweeperUI.Drawables;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using Color = SFML.Graphics.Color;

namespace MinesweeperUI
{
    public class ShapeManager
    {
        private readonly Board board;
        private static readonly Vector2f RectangleSize = new Vector2f(200, 99);
        private static readonly Vector2f ResetSize = new Vector2f(100, 99);

        public TextRectangle FlagsRectangle { get; private set; }
        public TextRectangle TimeRectangle { get; private set; }
        public Drawable ResetRectangle { get; private set; }
        public Dictionary<Point, Drawable> Squares { get; private set; }

        public bool ShouldUpdate = true;

        private static readonly Font Font = new Font("ARIAL.TTF");

        public IEnumerable<Drawable> AllDrawables
        {
            get
            {
                var list = new List<Drawable> {FlagsRectangle, TimeRectangle, ResetRectangle};
                list.AddRange(Squares.Values);
                return list;
            }
        }

        public ShapeManager(Board board)
        {
            this.board = board;
            TimeRectangle = GetTimeRectangle();
            Update();
        }

        public void Update()
        {
            UpdateTime();
            if (ShouldUpdate)
            {
                Squares = GetTileRectangles();
                FlagsRectangle = GetFlagsRectangle();
                ResetRectangle = GetResetRectangle();
            }

            ShouldUpdate = false;
        }

        private void UpdateTime()
        {
            TimeRectangle?.UpdateText(board.TimeKeeper.GetTime().ToScoreString());
        }

        private TextRectangle GetFlagsRectangle()
        {
            var rectangle = new RectangleShape(RectangleSize)
            {
                FillColor = Color.Red,
                Position = new Vector2f(1, 1),
                OutlineThickness = .5f
            };
            var text = new Text(board.FlagsLeft.ToScoreString(), Font)
            {
                CharacterSize = 75,
                Position = new Vector2f(25, 1),
                FillColor = Color.White,
                LetterSpacing = 3
            };
            return new TextRectangle(rectangle, text);
        }

        private TextRectangle GetTimeRectangle()
        {
            var rectangle = new RectangleShape(RectangleSize)
            {
                FillColor = Color.Red,
                Position = new Vector2f(300, 1),
                OutlineThickness = .5f
            };
            var text = new Text(board.TimeKeeper.GetTime().ToScoreString(), Font)
            {
                CharacterSize = 75,
                Position = new Vector2f(325, 1),
                FillColor = Color.White, 
                LetterSpacing = 3
            };
            return new TextRectangle(rectangle, text);
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
                    var justEmpty = true;

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
                        var text = new Text(tile.TileValue.ToValue(), Font)
                        {
                            CharacterSize = 40,
                            Position = new Vector2f(5 + i * increment + .3f * increment, 105 + j * increment),
                            FillColor = Color.Red
                        };
                        toDraw.Add(new Point(i, j), new TileSquare(square, text));
                        justEmpty = false;
                    }

                    if (tile.TileState == TileState.Flag)
                    {
                        toDraw.Add(new Point(i, j), new TileFlag(square));
                        justEmpty = false;
                    }

                    if (justEmpty)
                    {
                        toDraw.Add(new Point(i, j), new TileSquare(square, tile.TileState));
                    }
                }
            }

            return toDraw;
        }
    }
}