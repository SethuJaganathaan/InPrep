using Base_Learning.Abstract;
using Base_Learning.Basic_Program;
using Base_Learning.ClassAndObject;
using Base_Learning.ConstAndReadonly;
using Base_Learning.DependencyInjection;
using Base_Learning.GenericCollection;
using Base_Learning.Shapes;
using Base_Learning.Statics;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    #region area of shape normal
    static void main(string[] args)
    {
        Rectangles rect = new Rectangles(10, 10);
        Circle circle = new Circle(2);

        //double cir = circle.CalculateArea();
        //double rects = rect.CalculateArea();
        //Console.WriteLine(rects);
        //Console.WriteLine(cir);

        IShape[] shapes = new IShape[] { rect, circle };
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Area: {shape.CalculateArea()}");
        }
    }
    #endregion

    #region area of shape loop
    static void maain(string[] args)
    {
        ARectangle aRect = new ARectangle(10, 20);
        ACircle aCircle = new ACircle(3);

        IAlphaShape[] Ashapes = { aRect, aCircle };
        foreach (var shape in Ashapes)
        {
            shape.PrintDescription();
            Console.WriteLine($"Area : {shape.CalculateArea()}");
        }
    }

    static void nain(string[] args)
    {
        ClassAndObj classandobj = new ClassAndObj("Shelby", 35);
        ShapeArea shapearea = new ShapeArea(50, 50);
        Console.WriteLine($"Area of shape is {shapearea.AreaCalculate()}");
        classandobj.Introduce();
    }
    #endregion

    #region static example
    static void Mainn(string[] args)
    {
        Console.WriteLine(Static69.StaticField);
        Static69.StaticMethod();

        Static69 static69 = new Static69();
        static69.NonStaticMethod2();
        static69.NonStaticMethod();
    }
    #endregion

    #region static and readonly example
    static void Maiiin(string[] args)
    {
        ConstAndReadonly constAndReadonly = new ConstAndReadonly("Cook");
        constAndReadonly.Testing();
    }
    #endregion

    #region remove duplicates
    static void Madin(string[] args)
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();
        string result = new string(input.Distinct().ToArray());
        Console.WriteLine("String with duplicates removed: " + result);
    }
    #endregion

    #region VowelCheck
    static void Maipn(string[] args)
    {

        Vowel vowel = new Vowel();

        for (int i = 0; true; i++)
        {
            Console.WriteLine("Press Q to quit");
            Console.WriteLine("Enter the letter");
            char letter = Console.ReadKey().KeyChar;

            if (letter == 'Q')
            {
                Console.WriteLine("Existing the program");
                break;
            }

            if (vowel.VowelCheck(letter))
            {
                Console.WriteLine("Its a Vowel");
            }
            else
            {
                Console.WriteLine("Not a vowel");
            }
        }

    }
    #endregion

    #region primenumber check
    static void Masin(string[] args)
    {
        for (int i = 0; true; i++)
        {
            Console.WriteLine("Enter the number to check");
            int number = Convert.ToInt32(Console.ReadLine());

            PrimeNumber prime = new PrimeNumber();

            if (prime.PrimeCheck(number))
            {
                Console.WriteLine($"{number} is a prime");
            }
            else
            {
                Console.WriteLine($"{number} is not a prime");
            }
        }
    }
    #endregion

    #region Reverse the string && palindrome
    static void Mailn(string[] args)
    {
        Console.WriteLine("Enter the string");
        string input = Console.ReadLine();

        string reversedString = "";

        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversedString += input[i];
        }

        if (reversedString == input)
        {
            Console.WriteLine("Its a palindrome");
        }
        else
        {
            Console.WriteLine("Its not a palindrome");
        }
        //Console.WriteLine($"Reversed string is {reversedString}");
    }
    #endregion

    #region reverse the order of words in a given string
    static void Maswin(string[] args)
    {
        Console.WriteLine("Enter the string of words");
        string input = Console.ReadLine();

        string[] words = input.Split(' ');
        Array.Reverse(words);

        string reversedWords = string.Join(" ", words);
        Console.WriteLine($"Reversed string: {reversedWords}");
    }
    #endregion

    #region How to reverse each word in a given string
    static void Maewin(string[] args)
    {
        Console.WriteLine("Enter the string");
        string input = Console.ReadLine();

        string[] words = input.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            char[] chars = words[i].ToCharArray();
            Array.Reverse(chars);

            words[i] = new string(chars);
        }

        string reversedstring = string.Join(" ", words);
        Console.WriteLine($"Reversed string is {reversedstring}");
    }
    #endregion

    #region How to count the occurrence of each character in a string
    static void Mainy(string[] args)
    {
        Console.WriteLine("Enter teh string");
        string input = Console.ReadLine();

        Dictionary<char, int> charcount = new Dictionary<char, int>();
        foreach (char c in input)
        {
            if (charcount.ContainsKey(c))
            {
                charcount[c]++;
            }
            else
            {
                charcount[c] = 1;
            }
        }

        foreach (var pair in charcount)
        {
            Console.WriteLine($"Character '{pair.Key}' occurs {pair.Value} times.");
        }
    }
    #endregion

    #region remove duplicate from, string
    static void Magin(string[] args)
    {
        Console.WriteLine("Enter the string");
        string input = Console.ReadLine();

        string res = new string(input.Distinct().ToArray());
        Console.WriteLine($"Duplicates removed in {res}");
    }
    #endregion

    #region How to find all possible substring of a given string
    static void Maoin(string[] args)
    {
        Console.WriteLine("Enter the string");
        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = i; j < input.Length; j++)
            {
                string substring = input.Substring(i, j - i);
                Console.WriteLine(substring);
            }
        }
    }
    #endregion

    #region Dependancy injection
    static void Maioin(string[] strings)
    {
        var serviceProvider = new ServiceCollection()
            .AddScoped<IDepend, Depend>()
            .AddTransient<IDepend, Depend>()
            //.AddTransient<IDepend>(_ => new Depend())
            .AddSingleton<IDepend, Depend>()
            //.AddSingleton<IDepend>(_ => new Depend())
            .BuildServiceProvider();

        Console.WriteLine("Scoped");
        for (int i = 0; i < 3; i++)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<IDepend>();
                service.PrintMessgage();
            }
        }

        Console.WriteLine("Transient");
        for (int i = 0; i < 3; i++)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<IDepend>();
                service.PrintMessgage();
            }
        }

        Console.WriteLine("Singleton");
        for (int i = 0; i < 3; i++)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<IDepend>();
                service.PrintMessgage();
            }
        }
    }

    static void Marin(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddScoped<IDepend, Depend>()
            .BuildServiceProvider();

        var serviceProvider2 = new ServiceCollection()
            .AddTransient<IDepend, Depend>()
            .BuildServiceProvider();

        var serviceProvider3 = new ServiceCollection()
            .AddSingleton<IDepend, Depend>()
            .BuildServiceProvider();


        Console.WriteLine("Scoped");
        for (int i = 0; i < 3; i++)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<IDepend>();
                service.PrintMessgage();
            }
        }

        Console.WriteLine("Transient");
        for (int i = 0; i < 4; i++)
        {
            //using (var scope2 = serviceProvider2.CreateScope())
            {
                //var service = scope2.ServiceProvider.GetService<IDepend>();
                var service = serviceProvider2.GetService<IDepend>();
                service.PrintMessgage();
            }
        }

        Console.WriteLine("Singleton");
        for (int i = 0; i < 4; i++)
        {
            var service = serviceProvider3.GetService<IDepend>();
            service.PrintMessgage();
        }
    }
    #endregion

    #region Generic List Collection   
    static void sMain(string[] args)
    {
        List<GModel> gModels = new List<GModel>();

        gModels.Add(new GModel { Name = "Luffy", Email = "luffy@gmail.com" });
        gModels.Add(new GModel { Name = "Zoro", Email = "zoro@gmail.com" });
        gModels.Add(new GModel { Name = "Sanji", Email = "sanji@gmail.com" });
        gModels.Add(new GModel { Name = "Dummy", Email = "dummy@gmail.com" });
        gModels.Add(new GModel { Name = "Test", Email = "test@gmail.com" });

        foreach (var lists in gModels)
        {
            Console.WriteLine($"{lists.Name} and {lists.Email}");
        }

        Console.WriteLine("Update name for Index [3] : ");
        gModels[3].Name = Console.ReadLine();
        Console.WriteLine($"{gModels[3].Name} and {gModels[3].Email}");

        gModels.RemoveAt(4);
        foreach (var lists in gModels)
        {
            Console.WriteLine($"{lists.Name} and {lists.Email}");
        }

    }
    #endregion

    #region Delegate
    delegate void MyDelegates(string Message);
    static void Mrain(string[] args)
    {
        MyDelegates delegateInstance = new MyDelegates(PrintMessage);
        delegateInstance("Hello Bruhh");
        MyDelegates delegatess = new MyDelegates(PrintMessageDumps);
        delegatess("Hello Sethu");

    }
    static void PrintMessage(string Message)
    {
        Console.WriteLine(Message);
    }
    static void PrintMessageDumps(string Message)
    {
        Console.WriteLine(Message);
    }
    #endregion

    #region Delegates areacalculate
    delegate float CalculateArea(float radius);
    delegate float CalculateAreaRectangle(float length, float width);

    static void Main(string[] args)
    {
        CalculateArea areas = new CalculateArea(Square);
        float area = areas(3);
        Console.WriteLine(area);

        CalculateAreaRectangle rectangleArea = new CalculateAreaRectangle(Rectangle);
        float areaRect = rectangleArea(2, 4);
        Console.WriteLine(areaRect);
    }

    static float Square(float size)
    {
        return size * size;
    }

    static float Rectangle(float len, float wid)
    {
        return len * wid;
    }
    #endregion

    #region Bubble Sort
    public static void MainBubbleSort(string[] args)
    {
        int[] arr1 = { 3,4,2,5,1 };
        int[] arr2 = { 10,7,9,6,8 };
        
        int[] merged = new int[arr1.Length + arr2.Length];
        
        for(int i = 0; i < arr1.Length; i++){
            merged[i] = arr1[i];
        }
        
        for(int i = 0; i < arr2.Length; i++){
            merged[arr1.Length + i] = arr2[i];
        }
        
        Console.WriteLine("Before Sorting");
        for(int i = 0; i < merged.Length; i++){
            Console.Write(merged[i] + " ");
        }
        
        //Array.Sort(merged);
        //foreach(int aftersort in merged){
            //Console.Write(aftersort + " ");
        //}
        
        Console.WriteLine("Sort Using Loop");
        for(int i = 0; i < merged.Length - 1; i++){
            for(int j = 0; j < merged.Length - 1 - i; j++){
                if(merged[j] > merged[j + 1]){
                    int temp = merged[j];
                    merged[j] = merged[j + 1];
                    merged[j + 1] = temp;
                }
            }
        }
        
        foreach(int after in merged){
            Console.WriteLine(after);
        }
    }
    #endregion
}
