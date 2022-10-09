namespace GildedRose.ItemUpdates;

public class UpdateItemConjured : IUpdateable
{
    public static void UpdateItemQuality(Program.Item item)
    {
        item.Quality = item.Quality > 2 ? item.Quality - 2 : item.Quality = (item.Quality == 1 ? item.Quality - 1 : item.Quality);
        item.SellIn--;    }
}