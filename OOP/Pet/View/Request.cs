
namespace Pet.View
{
    public class Request
    {

        public string InputRequest(string input) 
        {
            Console.WriteLine($"Введите значение поля «{input}»\n");
            string res = Console.ReadLine();
            while (res == "") 
            {
                Console.WriteLine($"Некорректное значение!\n" +
                    $"Введите значение поля «{input}»\n"); ;
                res = Console.ReadLine();
            }
            return res;

        }
        public void OutputRequest(string output) 
        {
            Console.WriteLine(output);
        }
    }
}
