namespace GildedRose.ItemUpdates;

public class UpdateItemBrie : IUpdateable
{
    public static void UpdateItemQuality(Program.Item item)
    {
        item.Quality = item.Quality < 50 ? item.Quality + 1 : item.Quality;
        item.Quality = item.SellIn < 0 && item.Quality < 50 ? item.Quality + 1 : item.Quality;
        item.SellIn--;
    }
}