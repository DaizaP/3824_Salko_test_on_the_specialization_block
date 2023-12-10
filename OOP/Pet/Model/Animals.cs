
namespace Pet.Model
{
    public abstract class Animals
    {
        protected string BirthDate { get; }
        protected string Name { get; }
        protected List<string> Commands { get; set; }

        public abstract string getName();
        public abstract string getBirthDate();
        public abstract List<string> getCommand();
        public abstract void addCommands(string commands);

        protected Animals(string birthDate, string name, List<string> commands)
        {
            BirthDate = birthDate;
            Name = name;
            Commands = commands;
        }

        public override string ToString()
        {
            return $"Имя:{Name}. Дата рождения: {BirthDate}, Команды {String.Join(", ", Commands)}";
        }

    }
}
