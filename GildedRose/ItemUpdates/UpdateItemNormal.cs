namespace GildedRose.ItemUpdates;

public class UpdateItemNormal : IUpdateable
{
    public static void UpdateItemQuality(Program.Item item)
    {
        item.Quality = item.Quality > 0  ? item.Quality - 1 : item.Quality;
        item.Quality = item.SellIn < 0 && item.Quality > 0 ? item.Quality - 1 : item.Quality;
        item.SellIn--;
    }
}