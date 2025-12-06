namespace FileS.Domain.Entities
{
    public sealed record Receipt
            (string Name, string Cuisine, List<string> Ingredients, double CookingTime, List<string> CookingSteps, double Kcal, string TypeOfReceipt)
    {
        public void DisplayReceipt()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Cuisine);
            Console.WriteLine("Kcal:",Kcal);
            Console.WriteLine("Type of Receipt: ",TypeOfReceipt);
            Console.WriteLine("Ingridients");
            foreach (var item in Ingredients)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("CookingTime:",CookingTime);
            Console.WriteLine("Cooking steps:");
            foreach(var item in CookingSteps)
            {
                Console.WriteLine(item);
            }
        }


    };
       
}
