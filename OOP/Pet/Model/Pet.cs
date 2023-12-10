
namespace Pet.Model
{
     public class Pet : Animals
    {
        public Pet(string birthDate, string name, List<string> commands) : base(birthDate, name, commands)
        {
        }

        public override string getBirthDate()
        {
            return BirthDate;
        }

        public override List<string> getCommand()
        {
            return Commands;
        }

        public override string getName()
        {
            return Name;
        }

        public override void addCommands(string commands)
        {

            Commands.Add(commands);
        }

    }
}
