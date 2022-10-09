namespace GildedRose.ItemUpdates;

public class UpdateItemTickets : IUpdateable
{
    public static void UpdateItemQuality(Program.Item item)
    {
        item.Quality = item.SellIn < 0 ? item.Quality = 0 : item.Quality;
        item.Quality = item.Quality < 50 ? item.Quality + 1 : item.Quality;
        item.Quality = item.SellIn < 11 && item.Quality < 50? item.Quality + 1 : item.Quality;
        item.Quality = item.SellIn < 6 && item.Quality < 50? item.Quality + 1 : item.Quality;
        item.SellIn--;
    }
}