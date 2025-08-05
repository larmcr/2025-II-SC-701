using System.Text;

namespace UT;

public class BinaryCalculator
{
  private int FromBinToDec(string bin)
  {
    var result = 0;
    var reverse = bin.ToArray().Reverse();
    var exp = 0;
    var valor = "";
    foreach (var character in reverse)
    {
      var digit = int.Parse(character.ToString());
      var value = (int)(digit * Math.Pow(2, exp));
      exp++;
      result += value;
    }
    Console.WriteLine($"FromBinToDec: {bin} -> {result}");
    return result;
  }

  private string FromDecToBin(int dec)
  {
    var list = new List<int>();
    var (quo, rem) = Math.DivRem(Math.Abs(dec), 2);
    list.Add(rem);
    while (quo > 1)
    {
      (quo, rem) = Math.DivRem(quo, 2);
      list.Add(rem);
    }
    list.Add(quo);
    list.Reverse();
    while (list.Count > 0 && list.First() == 0)
    {
      list.RemoveAt(0);
    }
    var result = new StringBuilder();
    list.ForEach((item) =>
    {
      result.Append(item);
    });
    Console.WriteLine($"FromDecToBin: {dec} -> {result}");
    return result.ToString();
  }
  public string Suma(string a, string b)
  {
    Console.WriteLine($"Suma: {a} y {b}");
    var aInt = FromBinToDec(a);
    var bInt = FromBinToDec(b);
    var suma = aInt + bInt;
    return FromDecToBin(suma);
  }

  public string Resta(string a, string b)
  {
    Console.WriteLine($"Resta: {a} y {b}");
    var aInt = FromBinToDec(a);
    var bInt = FromBinToDec(b);
    var resta = -aInt + -bInt;
    return FromDecToBin(resta);
  }

  public string Multi(string a, string b)
  {
    return "";
  }

  public string Div(string a, string b)
  {
    var aInt = FromBinToDec(a);
    var bInt = FromBinToDec(b);
    var div = aInt / bInt;
    return FromDecToBin(div);
  }
}