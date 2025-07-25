namespace UT;

protected class UnitTests
{
    [Fact]
    public void TresMasSiete()
    {
        var expected = "1010";
        var calc = new BinaryCalculator();
        var actual = calc.Suma("11", "111");
        Console.WriteLine($"TresMasSiete: {actual}\n");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SieteMenosTres()
    {
        var expected = "100";
        var calc = new BinaryCalculator();
        var actual = calc.Resta("111", "11");
        Console.WriteLine($"SieteMenosTres: {actual}\n");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TresPorCinco()
    {
        var expected = "1111";
        var calc = new BinaryCalculator();
        var actual = calc.Multi("11", "101");
        Console.WriteLine($"TresPorCinco: {actual}\n");
        Assert.Equal(expected, actual);
    }
}