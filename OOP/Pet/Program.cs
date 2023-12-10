using Pet.Presenter;
internal class Program
{
    private static void Main(string[] args)
    {
        Pet.Model.ICounter counter = new Pet.Model.ICounter();
        Controller.Run();
        
    }
}