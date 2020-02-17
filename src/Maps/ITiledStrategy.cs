namespace Kazaam.Maps {
    /// <summary>
    /// Enforces a pattern strategy design pattern for loading Tiled map objects
    /// </summary>
    public interface ITiledStrategy {
        void Load(Map map, string layerName, int xPosition, int yPosition);
    }
}
