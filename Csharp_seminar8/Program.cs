﻿using Microsoft.VisualBasic;
using static Csharp_seminar8.Functions;
var tasks = new Dictionary<int, Action>
{
    { 54, Task54 },
    { 56, Task56 },
    { 58, Task58 },
    { 62, Task62 },
};
var numbersOfTasks = tasks.Keys.ToArray();
tasks[GetTaskFromUser(numbersOfTasks)].Invoke();

void Task54()
{
    // Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
    //     Например, задан массив:
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // В итоге получается вот такой массив:
    // 7 4 2 1
    // 9 5 3 2
    // 8 4 4 2
    Console.WriteLine("Задача 54");
    var array = Generate2DIntArray(3, 4, 1, 10);
    Print2DArray(array);
    for (var row = 0; row < array.GetLength(0); row++)
    {
        var sortedRow = new int[array.GetLength(1)];
        for (var column = 0; column < array.GetLength(1); column++) sortedRow[column] = array[row, column];

        Array.Sort(sortedRow);
        Array.Reverse(sortedRow);
        
        for (var column = 0; column < array.GetLength(1); column++) array[row, column] = sortedRow[column];
    }
    Console.WriteLine("В итоге получается вот такой массив: ");
    Print2DArray(array);
}

void Task56()
{
    // Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
    //     Например, задан массив:
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // 5 2 6 7
    // Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
    Console.WriteLine("Задача 56");
    var array = Generate2DIntArray(4, 4, 1, 10);
    Print2DArray(array);
    var rowSum = new int[array.GetLength(0)];
    
    for (var row = 0; row < array.GetLength(0); row++)
    {
        for (var column = 0; column < array.GetLength(1); column++)
        {
            rowSum[row] += array[row, column];
        }
    }
    var result = (Array.IndexOf(rowSum, rowSum.Min()) + 1, rowSum.Min());
    Console.WriteLine($"Строка с наименьшей суммой: {result.Item1} ({result.Item2})");
}

void Task58()
{
    // Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
    //     Например, даны 2 матрицы:
    // 2 4 | 3 4
    // 3 2 | 3 3
    // Результирующая матрица будет:
    // 18 20
    // 15 18
    Console.WriteLine("Задача 58");
    var arr1 = Generate2DIntArray(2, 2, 1, 10);
    var arr2 = Generate2DIntArray(2, 2, 1, 10);
    Console.WriteLine("Массив 1");
    Print2DArray(arr1);
    Console.WriteLine("Массив 2");
    Print2DArray(arr2);
    if (arr1.GetLength(1) != arr2.GetLength(0))
    {
        Console.WriteLine("Данные матрицы нельзя перемножить!");
        Environment.Exit(0);
    }
    Console.WriteLine("Произведение матриц:");

    for (var row1 = 0; row1 < arr1.GetLength(0); row1++)
    {
        for (var column1 = 0; column1 < arr1.GetLength(1); column1++)
        {
            var temp = 0;
            for (var row2 = 0; row2 < arr2.GetLength(0); row2++)
            {
                temp += arr1[row1, row2] * arr2[row2, column1];
            }
            Console.Write(temp + " ");
        }
        Console.WriteLine();
    }
}

void Task62()
{
    // Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
    //     Например, на выходе получается вот такой массив:
    // 01 02 03 04
    // 12 13 14 05
    // 11 16 15 06
    // 10 09 08 07
    Console.WriteLine("Задача 62");
    var array = Generate2DIntArray(10, 10, 0, 0);

    var limitPlusRow = array.GetLength(0) - 1;
    var limitMinusRow = 0;
    var limitPlusColumn = array.GetLength(1) - 1;
    var limitMinusColumn = 0;

    var currentPos = (0, 0);
    array[0, 0] = 1;
    var isFinished = false;
    var iterator = 2;

    do
    {
        var temp = spiralCycle(
            iterator: iterator,
            limitPlusRow: limitPlusRow,
            limitMinusRow: limitMinusRow,
            limitPlusColumn: limitPlusColumn,
            limitMinusColumn: limitMinusColumn,
            currentPos: currentPos);
        isFinished = temp.Item1;
        iterator = temp.Item2;
        limitPlusRow = temp.Item3;
        limitMinusRow = temp.Item4;
        limitPlusColumn = temp.Item5;
        limitMinusColumn = temp.Item6;
        currentPos = temp.Item7;
    }
    while (isFinished == false);
    
    //Print2DArray(array);
    AdvancedPrint2DArray(array, "0");
    
    (bool, int, int, int, int, int, (int, int)) spiralCycle(
        int iterator,
        int limitPlusRow,
        int limitMinusRow,
        int limitPlusColumn,
        int limitMinusColumn,
        (int, int) currentPos)
    {
        var isCycleFinished = true;
        if (limitPlusColumn > currentPos.Item2)
        {
            isCycleFinished = false;
            for (var column = currentPos.Item2 + 1; column <= limitPlusColumn; column++)
            {
                array[currentPos.Item1, column] = iterator;
                iterator++;
                currentPos = (currentPos.Item1, column);
            }
            limitMinusRow++;
        }
        
        if (limitPlusRow > currentPos.Item1)
        {
            isCycleFinished = false;
            for (var row = currentPos.Item1 + 1; row <= limitPlusRow; row++)
            {
                array[row, currentPos.Item2] = iterator;
                iterator++;
                currentPos = (row, currentPos.Item2);
            }

            limitPlusColumn--;
        }

        if (limitMinusColumn < currentPos.Item2)
        {
            isCycleFinished = false;
            for (var column = currentPos.Item2 - 1; column >= limitMinusColumn; column--)
            {
                array[currentPos.Item1, column] = iterator;
                iterator++;
                currentPos = (currentPos.Item1, column);
            }
            limitPlusRow--;
            
        }
        
        if (limitMinusRow < currentPos.Item1)
        {
            isCycleFinished = false;
            for (var row = currentPos.Item1 - 1; row >= limitMinusRow; row--)
            {
                array[row, currentPos.Item2] = iterator;
                iterator++;
                currentPos = (row, currentPos.Item2);
            }
        
            limitMinusColumn++;
        }
        
        return (isCycleFinished, iterator, limitPlusRow, limitMinusRow, limitPlusColumn, limitMinusColumn, currentPos);
    }
    
    
}


int GetTaskFromUser(int[] availableTasks)
{
    var taskNumber = GetUserInt("номер задания");
    while (!availableTasks.Contains(taskNumber))
    {
        Console.WriteLine("!!!Данной задачи не заложено!!!");
        taskNumber = GetUserInt();
    }
    return taskNumber;
}