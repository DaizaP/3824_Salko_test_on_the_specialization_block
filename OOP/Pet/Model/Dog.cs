
namespace Pet.Model
{
    public class Dog : Pet
    {
        public Dog(string birthDate, string name, List<string> commands) : base(birthDate, name, commands)
        {
        }

        public override string ToString()
        {
            return $"Имя:{Name}. Вид: Собака. Дата рождения: {BirthDate}. Команды: {String.Join(", ", Commands)}";
        }
    }
}
