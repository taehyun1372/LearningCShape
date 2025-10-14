// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var customColor = new Color(24, 35, 44);
Console.WriteLine(customColor.Red);
Console.WriteLine(customColor.Green);
Console.WriteLine(customColor.Blue);

public readonly struct Color
{
    public Color(int r, int g, int b)
    {
        Red = r;
        Green = g;
        Blue = b;
    }

    public int Red { get; }
    public int Green { get; }
    public int Blue { get; }
}