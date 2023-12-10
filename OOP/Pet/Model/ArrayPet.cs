
namespace Pet.Model
{
    public class ArrayPet<Pets>
    {
        internal List<Animals> petArray = new();

        public void AddPet(Animals pet)
        {
            petArray.Add(pet);
        }
        public Animals FindPet(string name)
        {
            return petArray.Find(item => item.getName().Equals(name));
        }

        public void PrintAllPet()
        {
            foreach (Animals product in petArray)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}
