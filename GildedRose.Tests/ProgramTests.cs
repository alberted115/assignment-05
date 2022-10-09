using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace GildedRose.Tests;

public class ProgramTests
{
    private Program _program;
    public ProgramTests()
    {
        _program = new Program();
        _program.Items = new List<Item>();

    }

    [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
    }

    [Fact]
    public void Add_one_item_and_update()
    {
        Item item1 = new Item() { Name = "Cloak of Stamina", Quality = 20, SellIn = 10 };
        _program.Items.Add(item1);
        _program.UpdateQuality();
        item1.Quality.Should().Be(19);
    }
    

    [Fact]
    public void add_aged_brie_and_update()
    {
        _program.Items.Add(new Item() { Name = "Aged Brie" ,Quality = 0,SellIn = 2});
        _program.UpdateQuality();
    }

    [Fact]
    public void add_sulfaras_hand_of_ragnaros_and_update()
    {
        _program.Items.Add(new Item() { Name = "Sulfuras, Hand of Ragnaros" ,Quality =80,SellIn = 1});
        _program.UpdateQuality();
        _program.Items[0].Quality.Should().Be(80);
    }

    [Fact]
    public void add_Backstage_passes_to_a_TAFKAL80ETC_concert_and_update()
    {
        _program.Items.Add(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert",Quality =30,SellIn = 2});
        _program.UpdateQuality();
        _program.Items[0].Quality.Should().Be(33);

    }

    [Fact]
    public void item_quality_updated_80_times()
    {
        _program.Items.Add(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert",Quality =30,SellIn = 2});
        _program.Items.Add(new Item() { Name = "Aged Brie" ,Quality = 2,SellIn = 60});

        for (int i = 0; i < 80; i++)
        {
            _program.UpdateQuality();
        }
        _program.Items[1].Quality.Should().Be(50);
    }

    [Fact]
    public void Item_with_negative_sellin()
    {
        _program.Items.Add(new Item() { Name = "Sulfuras, Hand of Ragnaros" ,Quality =80,SellIn = -1});
        _program.UpdateQuality();
        _program.Items[0].SellIn.Should().Be(-1);
    }

    [Fact]
    public void concert_tickets_different_dates()
    {
        _program.Items.Add(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert",Quality =30,SellIn = 13});
        _program.Items.Add(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert",Quality =30,SellIn = 10});
        _program.Items.Add(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert",Quality =30,SellIn = 5});
        _program.Items.Add(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert",Quality =30,SellIn = -5});
        _program.UpdateQuality();
        _program.Items[1].Quality.Should().Be(32);
    }

    [Fact]
    public void items_with_sellIn_below_0_decrease_by_two()
    {
        
        _program.Items.Add(new Item() { Name = "Cloak of Strength",Quality =30,SellIn = -1});
        _program.UpdateQuality();
        _program.Items[0].Quality.Should().Be(28);
    }
    
    [Fact]
    public void test()
    {
        
        _program.Items.Add(new Item() { Name = "Aged Brie",Quality =30,SellIn = -5});
        _program.UpdateQuality();
        _program.Items[0].Quality.Should().Be(32);
    }

    
    //Conjured item tests, udkommenteret da conjured items ikke er implementeret i denne version
    
    /*[Fact]
    public void conjured_item_degrades_faster()
    {
        _program.Items.Add(new Item() { Name = "Conjured mana cake",Quality =6,SellIn = 5});
        _program.UpdateQuality();
        _program.Items[0].Quality.Should().Be(4);

    }*/
    
    
    
    
}