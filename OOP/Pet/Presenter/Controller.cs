using Pet.Model;
using Pet.View;

namespace Pet.Presenter
{
    internal class Controller
    {
        private static ArrayPet<Animals> arrayPet = new();
        private static Request request = new();

        public static void Run()
        {
            bool active = true;
            int mainMenuPoint = -1;
            while (active)
            {
                Interface.MainMenu();

                while (mainMenuPoint < 0 || mainMenuPoint > 4)
                {
                    try
                    {
                        mainMenuPoint = int.Parse(request.InputRequest("Главное меню"));
                    }
                    catch (Exception e)
                    {
                        request.OutputRequest(e.Message);
                    }
                }
                switch (mainMenuPoint)
                {
                    case 0:
                        request.OutputRequest("До свидания!");
                        active = false;
                        break;
                    case 1:
                        ChoiceAddTypePet();
                        mainMenuPoint = -1;
                        break;
                    case 2:
                        PetMenu();
                        mainMenuPoint = -1;
                        break;
                    case 3:
                        arrayPet.PrintAllPet();
                        mainMenuPoint = -1;
                        break;
                    case 4:
                        GetCountPet();
                        mainMenuPoint = -1;
                        break;
                }
            }
        }

        internal static void ChoiceAddTypePet()
        {
            int typePetMenuPoint = -1;
            Interface.TypePetMenu();
            while (typePetMenuPoint < 0 || typePetMenuPoint > 3)
            {
                try
                {
                    typePetMenuPoint = int.Parse(request.InputRequest("Вид животного"));
                }
                catch (Exception e)
                {
                    request.OutputRequest(e.Message);
                }
            }
            switch (typePetMenuPoint)
            {
                case 0:
                    break;
                case 1:
                    AddPet("Собака");
                    break;
                case 2:
                    AddPet("Кошка");
                    break;
                case 3:
                    AddPet("Хомяк");
                    break;
            }
        }

        internal static void AddPet(string typePet)
        {
            if (typePet == "Собака")
            {
                arrayPet.AddPet(new Dog(AddPetBirthDate(), AddPetName(), AddPetCommand()));
                AddCount();
                request.OutputRequest("Собака добавлена.");
            }
            else if (typePet == "Кошка")
            {
                arrayPet.AddPet(new Cat(AddPetBirthDate(), AddPetName(), AddPetCommand()));
                AddCount();
                request.OutputRequest("Кошка добавлена.");
            }
            else if (typePet == "Хомяк")
            {
                arrayPet.AddPet(new Hamster(AddPetBirthDate(), AddPetName(), AddPetCommand()));
                AddCount();
                request.OutputRequest("Хомяк добавлен.");
            }
        }

        internal static List<string> AddPetCommand()
        {
            List<string> commands = new();
            bool valid = false;

            while (valid == false)
            {
                try
                {
                    string tmp = request.InputRequest("Команды (Разделитель ', ')");
                    string[] tmpStr = tmp.Split(", ");
                    foreach (string t in tmpStr)
                    {
                        if (commands.Find(item => item.Equals(t)) != t)
                        {
                            commands.Add(t);
                        }
                    }
                    valid = true;
                }
                catch (Exception e)
                {
                    request.OutputRequest(e.Message);
                    valid = false;
                }
            }
            request.OutputRequest($"Добавленные команды: {String.Join(", ", commands)}");
            return commands;
        }

        internal static string AddPetBirthDate()
        {
            bool valid = false;
            string birthDate = "";

            while (valid == false)
            {
                try
                {
                    birthDate = request.InputRequest("Дата рождения (YYYY-MM-DD)");
                    valid = Validator.validBirthDate(birthDate);
                }
                catch (Exception e)
                {
                    request.OutputRequest(e.Message);
                    valid = false;
                }
            }
            request.OutputRequest($"Добавленная дата рождения: {birthDate}");
            return birthDate;
        }

        internal static string AddPetName()
        {
            bool valid = false;
            string name = "";

            while (valid == false)
            {
                try
                {
                    name = request.InputRequest("Имя (Кирилица)");
                    valid = Validator.validName(name);
                }
                catch (Exception e)
                {
                    request.OutputRequest(e.Message);
                    valid = false;
                }
            }
            request.OutputRequest($"Добавленное имя: {name}\n");
            return name;
        }

        internal static void PetMenu()
        {
            int petMenuPoint = -1;
            bool active = true;
            string findNameRequest = request.InputRequest("Имя животного");
            Animals foundPet = arrayPet.FindPet(findNameRequest);
            if (foundPet == null)
            {
                request.OutputRequest("Животное не найдено.");
            }
            else
            {
                while (active)
                {
                    Interface.PetMenu(foundPet.getName());

                    while (petMenuPoint < 0 || petMenuPoint > 2)
                    {
                        try
                        {
                            petMenuPoint = int.Parse(request.InputRequest("Меню животного"));
                        }
                        catch (Exception e)
                        {
                            request.OutputRequest(e.Message);
                        }
                    }
                    switch (petMenuPoint)
                    {
                        case 0:
                            active = false;
                            break;
                        case 1:
                            bool valid = false;
                            while (valid == false)
                            {
                                try
                                {
                                    List<string> tmp = AddPetCommand();
                                    foreach (string t in tmp)
                                    {
                                        if (foundPet.getCommand().Find(item => item.Equals(t)) != t)
                                        {
                                            foundPet.addCommands(t);
                                        }
                                    }
                                    valid = true;
                                }
                                catch (Exception e)
                                {
                                    request.OutputRequest(e.Message);
                                    valid = false;
                                }
                            }
                            petMenuPoint = -1;
                            break;
                        case 2:
                            request.OutputRequest(String.Join(", ", foundPet.getCommand()));
                            petMenuPoint = -1;
                            break;
                    }

                }
            }
        }

        internal static void GetCountPet()
        {
            try
            {
                using (ICounter counter = new ICounter())
                {
                    request.OutputRequest($"Количество животных в реестре: {counter.getCount()}\n");
                }
            }
            catch (Exception e)
            {
                request.OutputRequest(e.Message);
            }
        }
        internal static void AddCount()
        {
            try
            {
                using (ICounter counter = new ICounter())
                {
                    counter.add();
                }
            }
            catch (Exception e)
            {
                request.OutputRequest(e.Message);
            }
        }
    }
}

