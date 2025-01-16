namespace GoNet.Core.Models
{
    public class ThingPlayer
    {
        static Random Random = new Random();

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IdPlayer { get; set; }
        public Player Player { get; set; }

        public ThingPlayer(Guid id, string name, Guid idPlayer, Player player) {
            Id = id;
            Name = name;
            IdPlayer = idPlayer;   
            Player = player;
        }

        public static ThingPlayer CreateRandom(Guid idPlayer, Player player)
        {
            string name = NameRandom();

            var thing = new ThingPlayer(Guid.NewGuid(), name, idPlayer, player);

            return thing;
        }

        private static string NameRandom()
        {
            string[] names = new string[6]
                { "шляпа", "часы", "портфель", "солнечные очки", "кольцо", "обувь" };

            var index = Random.Next(names.Length);

            return names[index];
        }
    }
}
