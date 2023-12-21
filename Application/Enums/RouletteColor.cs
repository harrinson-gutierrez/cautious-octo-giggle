namespace Application.Enums
{
    public enum RouletteColor
    {
        RED,
        BLACK
    }

    static class RouletteColorExtension
    {

        public static RouletteColor GetRouletteColor(int number)
        {
            return number % 2 == 0 ? RouletteColor.RED : RouletteColor.BLACK;
        }
    }
}
