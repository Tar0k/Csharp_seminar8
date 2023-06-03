namespace Csharp_seminar8;

public static class Functions
{
    /// <summary>
    /// Request correct user input of int variable.
    /// </summary>
    /// <param name="variableDescription">variable description in input line</param>
    /// <returns>A 32-bit integer, which inserted by user in console.</returns>
    public static int  GetUserInt(string variableDescription = "целочисленное значение")
    {
        while (true)
        {
            Console.Write($"Введите {variableDescription}: ");
            var userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("!!!НИЧЕГО НЕ ВВЕДЕНО!!!");
                continue;
            }
            if (int.TryParse(userInput, out var userInt)) return userInt;
            Console.WriteLine("!!!НЕ КОРРЕКТНЫЙ ВВОД!!!");
        }
    }
    
    /// <summary>
    /// Create 2D array with random integer values
    /// </summary>
    /// <param name="rows">number of rows</param>
    /// <param name="columns">number of columns</param>
    /// <param name="minElement">minimum random generated element</param>
    /// <param name="maxElement">maximum random generated element</param>
    /// <returns>A Int[rows,columns] array filled with random values between minElement and maxElement.</returns>
    public static int[,] Generate2DIntArray(
        int rows,
        int columns,
        int minElement = 1,
        int maxElement = 10
        )
    {
        var array = new int[rows, columns];
        var random = new Random();
        for (var row = 0; row < array.GetLength(0); row++)
        {
            for (var column = 0; column < array.GetLength(1); column++)
            {
                array[row, column] = random.Next(minElement, maxElement);
            }
        }
    
        return array;
    }
    
    /// <summary>
    /// Create 2D array with random double values
    /// </summary>
    /// <param name="rows">number of rows</param>
    /// <param name="columns">number of columns</param>
    /// <param name="decimalPlaces">number of symbols past dot</param>
    /// <param name="minElement">minimum random generated element</param>
    /// <param name="maxElement">maximum random generated element</param>
    /// <returns>A Double[rows,columns] array filled with random values between minElement and maxElement.</returns>
    public static double[,] Generate2DDoubleArray(
        int rows,
        int columns,
        int decimalPlaces = 0,
        int minElement = 1, 
        int maxElement = 10
        )
    {
        var array = new double[rows, columns];
        var random = new Random();
        for (var row = 0; row < array.GetLength(0); row++)
        {
            for (var column = 0; column < array.GetLength(1); column++)
            {
                array[row, column] = Math.Round(random.NextDouble() * (maxElement - minElement) + minElement, decimalPlaces);
            }
        }
        return array;
    }
    
    /// <summary>
    /// Print out 2D array
    /// </summary>
    /// <param name="array">array, to be printed out</param>
    public static void Print2DArray(int[,] array) 
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    
    /// <summary>
    /// Print out 2D array
    /// </summary>
    /// <param name="array">array, to be printed out</param>
    public static void Print2DArray(double[,] array) 
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    /// <summary>
    /// Print out 2D array with aligned columns by adding filler in front.
    /// </summary>
    /// <param name="array">array, to be printed out</param>
    /// <param name="filler">symbol, which to be added to string in front</param>
    public static void AdvancedPrint2DArray(int[,] array, string filler = " ")
    {
        var maxLengthElement = LookingForLongestElement(array);
        
        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(IntToStringWithLength(array[i,j], maxLengthElement, filler) + " ");
            }
            Console.WriteLine();
        }   
        
        
        int LookingForLongestElement(int[,] arr)
        {
            var length = 0;
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j].ToString().Length > length) length = array[i, j].ToString().Length;
                }
            }

            return length;
        }

        string IntToStringWithLength(int value, int length, string fillerText)
        {
            var text = value.ToString();
            while (text.Length < length) text = fillerText + text;
            return text;
        }
    }
}