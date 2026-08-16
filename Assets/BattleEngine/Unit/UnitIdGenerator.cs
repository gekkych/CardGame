namespace BattleEngine.Unit
{
    public class UnitIdGenerator
    {
        private static int counter = 0;

        public static int Get()
        {
            counter++;
            return counter;
        }

        public static void Reset()
        {
            counter = 0;
        }
    }
}