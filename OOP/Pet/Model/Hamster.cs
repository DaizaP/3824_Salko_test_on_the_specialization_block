
namespace Pet.Model
{
    public class Hamster : Pet
    {
        public Hamster(string birthDate, string name, List<string> commands) : base(birthDate, name, commands)
        {
        }

        public override string ToString()
        {
            return $"Имя:{Name}. Вид: Хомяк. Дата рождения: {BirthDate}. Команды: {String.Join(", ", Commands)}";
        }
    }
}
