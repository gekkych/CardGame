namespace BattleEngine
{
    public abstract class Command
    {
        public abstract string name { get; }
        public abstract string description { get; }
        public abstract string execute(string[] args);
    }
}