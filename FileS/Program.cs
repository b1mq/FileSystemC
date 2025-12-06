using FileS.Domain.Entities;

//var PoemM = new PoemManager();

//void GeneratePoems()
//{
//    //просто набросал что бы не заморачиватсья
//    string[] poets = new string[]
//{
//    "William Shakespeare",
//    "William Wordsworth",
//    "Emily Dickinson",
//    "Robert Frost",
//    "T.S. Eliot"
//};
//    string[] poems = new string[]
//    {
//    "Sonnet 18",
//    "Daffodils",
//    "Because I Could Not Stop for Death",
//    "The Road Not Taken",
//    "The Love Song of J. Alfred Prufrock"
//    };
//    int[] years = new int[]
//    {
//    1609,
//    1807,
//    1863,
//    1916,
//    1915
//    };
//    Random rand = new Random();
//    for (int i = 0; i < poets.Length; i++)
//    {
//        string poet = poets[rand.Next(0, poets.Length)];
//        string poms = poems[rand.Next(0, poems.Length)];
//        int year = years[rand.Next(0, years.Length)];
//        PoemM.AddPoem(poms,poet, year,"0");
//    }
//    //PoemM.LoadPoemsFromJson(@"C:/Users/Admin/Desktop/MyPoem", "MyPoem");
//    //PoemM.DisplayPoemWithName("Daffodils", @"C:/Users/Admin/Desktop/MyPoem", "MyDPoem");
//    //PoemM.DisplayPoemWithYear(1915, @"C:/Users/Admin/Desktop/MyPoem", "MyYearPoem");
//}
//Receipt GenerateReceipt(){
//    var names = new string[]
//{
//    "Маргарита",
//    "Борщ",
//    "Тирамису",
//    "Пад Тай",
//    "Бефстроганов"
//};

//    var cuisines = new string[]
//    {
//    "Итальянская",
//    "Украинская",
//    "Итальянская",
//    "Тайская",
//    "Русская"
//    };
//    var TypeOfReceipt = new string[]
//{
//    "Дессерт",
//    "Первое",
//    "Второе",

//};
//    var ingredients = new List<string>[]
//    {
//    new() { "тесто", "томатный соус", "моцарелла", "базилик", "оливковое масло" },
//    new() { "свёкла", "капуста", "картофель", "морковь", "говядина", "томатная паста", "сметана" },
//    new() { "савоярди", "маскарпоне", "эспрессо", "яйца", "сахар", "какао" },
//    new() { "рисовая лапша", "креветки", "тофу", "ростки фасоли", "арахис", "лайм", "тамариндовый соус" },
//    new() { "говядина", "грибы", "сметана", "лук", "горчица", "мука" }
//    };

//    var cookingTimes = new double[]
//    {
//    15.0,
//    120.0,
//    30.0,
//    20.0,
//    45.0
//    };

//    var cookingSteps = new List<string>[]
//    {
//    new()
//    {
//        "Разогреть духовку до 250°C",
//        "Раскатать тесто и нанести соус",
//        "Выложить моцареллу",
//        "Выпекать 10–12 минут",
//        "Добавить базилик после выпечки"
//    },
//    new()
//    {
//        "Сварить мясной бульон",
//        "Обжарить свёклу с томатной пастой",
//        "Добавить капусту и картофель",
//        "Варить до готовности овощей",
//        "Заправить чесноком и зеленью"
//    },
//    new()
//    {
//        "Сварить крепкий кофе и остудить",
//        "Взбить желтки с сахаром",
//        "Добавить маскарпоне",
//        "Обмакивать печенье в кофе и выкладывать слоями",
//        "Посыпать какао, охладить 4–6 часов"
//    },
//    new()
//    {
//        "Замочить лапшу",
//        "Обжарить креветки и тофу",
//        "Добавить лапшу и соус",
//        "Перемешать с ростками и арахисом",
//        "Подать с долькой лайма"
//    },
//    new()
//    {
//        "Нарезать говядину тонкими полосками",
//        "Обжарить мясо и убрать",
//        "Обжарить лук и грибы",
//        "Вернуть мясо, добавить сметану и горчицу",
//        "Тушить 10 минут, подавать с гречкой или пюре"
//    }
//    };
//    var Kcal = new double[] { 123.5, 125.1, 121.4, 245.11, 902.23, 2810.1, 205.1, 768.2, 2850.3, 2019.5 };
//    Random rand = new Random();
//    string name = names[rand.Next(0, names.Length)];
//    string cuisine = cuisines[rand.Next(0, cuisines.Length)];
//    string TypeOfR = TypeOfReceipt[rand.Next(0, TypeOfReceipt.Length)];
//    List<string> ingredient = ingredients[rand.Next(0, ingredients.Length)];
//    double cookTime = cookingTimes[rand.Next(0, cookingTimes.Length)];
//    double kcal = Kcal[rand.Next(0, Kcal.Length)];
//    List<string> cookStep = cookingSteps[rand.Next(0, cookingSteps.Length)];
//    return new Receipt(name,cuisine,ingredient, cookTime,cookStep,kcal,TypeOfR);
//}
//var firstReceipt = GenerateReceipt();
//var RManagaer = new ReceiptManager
//{
//    Name = "MyManager",
//    ReceiptList = new List<Receipt> {  }

//};
//RManagaer.LoadReceiptsFromJson(@"C:/Users/Admin/Desktop/Receipt", "MyReceipts");
//RManagaer.DisplayReceipts();
//RManagaer.LoadReceiptWithSumKcal(450, @"C:/Users/Admin/Desktop/Receipt", "450Kcal");

//FileSystemApp.FindFileInDirectory(@"C:/Users/Admin/Desktop/Nums", "*.txt");
//FileSystemApp.DeleteFileInDirectory(@"C:/Users/Admin/Desktop/Nums", "*.txt");

FileSystemApp.ShowInfoInDirectory(@"C:/Users/Admin/Desktop/Nums");