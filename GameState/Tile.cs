namespace GameState
{
    public class Tile
    {
        public TileState TileState { get; set; } = TileState.Unknown;
        public TileValue TileValue { get; set; } = TileValue.Empty;

        public Tile(TileValue tileValue)
        {
            TileValue = tileValue;
        }

        public Tile()
        {

        }

        public Tile Clone()
        {
            return new Tile
            {
                TileState = TileState,
                TileValue = TileValue
            };
        }

        public bool IsNumber => TileValue != TileValue.Bomb && TileValue != TileValue.Empty;
        public bool IsBomb => TileValue == TileValue.Bomb && TileState != TileState.Flag;

        public bool ShouldRenderText =>
            TileState == TileState.Known && IsNumber;

        public override string ToString()
        {
            return TileValue == TileValue.Bomb ? "*" : TileValue.ToString("d");
        }
    }
}