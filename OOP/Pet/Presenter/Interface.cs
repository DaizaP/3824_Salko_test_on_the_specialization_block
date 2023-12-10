
using Pet.View;

namespace Pet.Presenter
{
    public class Interface
    {
        private static Request request = new();
        internal static void MainMenu()
        {
            request.OutputRequest($"Главное меню.\n" +
                $"1. Добавить новое животное.\n" +
                $"2. Поиск животного.\n" +
                $"3. Вывести полный список животных.\n" +
                $"4. Кол-во записей.\n" +
                $"0. Выход.\n");
        }

        internal static void PetMenu(string name)
        {
            request.OutputRequest($"Меню животного {name}.\n" +
                $"1. Научить новой команде.\n" +
                $"2. Вывести список команд.\n" +
                $"0. В главное меню.\n");
        }

        internal static void TypePetMenu()
        {
            request.OutputRequest($"Вид животного.\n" +
                $"1. Собака.\n" +
                $"2. Кошка.\n" +
                $"3. Хомяк.\n" +
                $"0. В главное меню.\n");
        }
    }
}