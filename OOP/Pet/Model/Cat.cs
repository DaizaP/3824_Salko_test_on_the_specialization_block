
namespace Pet.Model
{
    public class Cat : Pet
    {
        public Cat(string birthDate, string name, List<string> commands) : base(birthDate, name, commands)
        {
        }

        public override string ToString()
        {
            return $"Имя:{Name}. Вид: Кот. Дата рождения: {BirthDate}. Команды: {String.Join(", ", Commands)}";
        }
    }
}
