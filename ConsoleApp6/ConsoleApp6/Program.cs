using System.Linq;
using System.Runtime.CompilerServices;
using static Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    public class Exercise
    {
        public static bool AreAllPetsOfTheSameType(IEnumerable<Pet> pets)
        {
            //TODO your code goes 

            //return

            //  pets.All(Pet => Pet.PetType == PetType.Cat) ||
            //  pets.All(Pet => Pet.PetType == PetType.Dog) ||
            //  pets.All(Pet => Pet.PetType == PetType.Fish);


            var allPetTypes = Enum.GetValues(typeof(PetType)).Cast<PetType>();

            var isAllSameType = allPetTypes.Any(ptype => pets.All(pt => pt.PetType == ptype));
            return isAllSameType;



        }
    }

    public class Pet
    {
        public int Id { get; }
        public string Name { get; }
        public PetType PetType { get; }
        public float Weight { get; }

        public Pet(int id, string name, PetType petType, float weight)
        {
            Id = id;
            Name = name;
            PetType = petType;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Type: {PetType}, Weight: {Weight}";
        }
    }

    public enum PetType
    {
        Cat,
        Dog,
        Fish
    }
    private static void Main(string[] args)
    {
       
    }



}

