using System.Text.Encodings.Web;
using System.Text.Json;

namespace FileS.Domain.Entities
{
    public class ReceiptManager
    {
        public required string Name { get; set; }
        public required List<Receipt> ReceiptList { get; set; }
        public void DisplayReceipts()
        {
            
            for (int i = 0; i < ReceiptList.Count; i++)
            {
                Console.WriteLine($"Receipt №{i}");
                ReceiptList[i].DisplayReceipt();
                Console.WriteLine();
            }
            
        }
        public void AddReceipt(string name, string cuisine, List<string> ingredients, double cookingTime, List<string> cookingSteps,double kcal,string Type)
        {
            ReceiptList.Add(new Receipt(name, cuisine, ingredients, cookingTime, cookingSteps,kcal,Type));
        }
        public void AddReceipt(Receipt r)
        {
            ReceiptList.Add(r);
        }
        public void RemoveReceipt(Receipt r)
        {
            ReceiptList.Remove(r);
        }
        public void RemoveReceipt(string name)
        {
            ReceiptList.RemoveAll(x => x.Name == name);
        }
        public List<Receipt> FindReceiptsWithCuisine(string cuisine)
        {
            var receipt = ReceiptList.Where(r => r.Cuisine == cuisine).ToList();
            return receipt;
        }
        public void LoadReceiptWithTypeOfCuisine(string cuisine,string directory,string filename)
        {
            var receipts = ReceiptList.Where(r => r.Cuisine == cuisine).ToList();
            if (Directory.Exists(directory))
            {
                string path = Path.Combine(directory, filename + ".json");
                var options = GetOptionToSerialize();
                File.WriteAllText(path, JsonSerializer.Serialize(receipts,options));
            }
        }
        public void LoadReceiptWithTimeToCooking(double CookTime, string directory, string filename)
        {
            var receipts = ReceiptList.Where(r => r.CookingTime == CookTime).ToList();
            if (Directory.Exists(directory))
            {
                string path = Path.Combine(directory, filename + ".json");
                var options = GetOptionToSerialize();
                File.WriteAllText(path, JsonSerializer.Serialize(receipts, options));
            }
        }
        public void LoadReceiptWithNameOfReceipt(string name, string directory, string filename)
        {
            var receipts = ReceiptList.Where(r => r.Name == name).ToList();
            if (Directory.Exists(directory))
            {
                string path = Path.Combine(directory, filename + ".json");
                var options = GetOptionToSerialize();
                File.WriteAllText(path, JsonSerializer.Serialize(receipts, options));
            }
        }
        public void LoadReceiptWithNameOfIngridient(string ingridient, string directory, string filename)
        {
            var receipts = ReceiptList.Where(r => r.Ingredients.Any(i => i == ingridient) ).ToList();
            if (Directory.Exists(directory))
            {
                string path = Path.Combine(directory, filename + ".json");
                var options = GetOptionToSerialize();
                File.WriteAllText(path, JsonSerializer.Serialize(receipts, options));
            }
        }
        public void LoadReceiptWithSumKcal(double kcal, string directory, string filename)
        {
            List<Receipt> receipts = new List<Receipt>();
            double kcalsum = 0;
            for (int i = 0; i < ReceiptList.Count; i++)
            {
                if (kcalsum >= kcal)
                {
                    break;
                }
                if (ReceiptList[i].Kcal + kcalsum <= kcal)
                {
                    receipts.Add(ReceiptList[i]);
                    kcalsum += ReceiptList[i].Kcal;
                }

            }
            if (Directory.Exists(directory))
            {
                string path = Path.Combine(directory, filename + ".json");
                var options = GetOptionToSerialize();
                File.WriteAllText(path, JsonSerializer.Serialize(receipts, options));
            }
        }
        private JsonSerializerOptions GetOptionToSerialize()
        {
            return new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
        }
        public override string ToString()
        {
            return $"Receipt Manager\nName:{Name}\nCount of receipts:{ReceiptList.Count}";
        }
        public void LoadReceiptsInJson(string directory,string filename)
        {
            var options = new JsonSerializerOptions
            {
                // долго не понимал почему в файле json вместо того что надо какие то странные иероглифы
                // оказывается проблема была в русском тексте
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            if (Directory.Exists(directory))
            {
                string path = Path.Combine(directory, filename + ".json");
                File.WriteAllText(path, JsonSerializer.Serialize(ReceiptList, options));
            }
               
        }


        public void LoadReceiptsFromJson(string directory,string filename)
        {
            string path = Path.Combine(directory, filename + ".json");
            
            if (File.Exists(path))
            {
                try
                {

                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    };
                    string json = File.ReadAllText(path);
                    ReceiptList = JsonSerializer.Deserialize<List<Receipt>>(json,options) ?? new List<Receipt>(); // с ?? new List<Receipt>() помог AI
                }
                catch (ArgumentNullException ex)
                {

                    throw new ArgumentNullException();
                }
            }


    
        }

    }
}
