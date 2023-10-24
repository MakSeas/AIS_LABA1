

using System.Security.Cryptography;
using AIS_LABA1Lib;

//int[] arr = new int[20];

//Random randomNumber = new System.Random();


//Console.WriteLine("В массиве следующие элементы: ");

//for (int i=0;i<arr.Length;i++)
//{
//    int number=randomNumber.Next();
//    arr[i] = number;

//    Console.WriteLine($"Элемент {i} = {number}");
//}

//Console.WriteLine();

//while (true)
//{
//    Console.WriteLine("Действия: \n" +
//        "0 - Найти минимальное значение\n" +
//        "1 - Найти максимальное значение\n" +
//        "2 - Найти элемент в массиве\n\n");

//    int act = int.Parse(Console.ReadLine());

//    FindIndex findIndex = new FindIndex(new MaxMinFinder());
//    FindIndex findElement = new FindIndex(new LinearFinder());

//    switch (act)
//    {
//        case 0:
//            {
//                Console.WriteLine($"Минимальное число в массиве = {arr[findIndex.GetIndex(arr, 0)]}\n");
//            }break;
//        case 1:
//            {
//                Console.WriteLine($"Максимальное число в массиве = {arr[findIndex.GetIndex(arr, 0)]}\n");
//            }
//            break;
//        case 3:
//            {
//                Console.Write("Введите искомое число: ");
//                int toFind=int.Parse(Console.ReadLine());

//                Console.WriteLine($"Число {toFind} имеет индекс {findElement.GetIndex(arr, toFind)} в массиве\n");
//            }break;

//        default:
//            {

//            }break;
//    }
//}

int[] array=null;

Class a=new ClassA();
Class b=new ClassB();

a.DoAlgorithm(array, 10);

Console.WriteLine();

b.DoAlgorithm(array, 10);

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
interface IMinMaxFindable
{
    int GetIndex(int[] array, int numberToFind);
}

class MaxMinFinder:IMinMaxFindable
{
    public int GetIndex(int[] array, int numberToFind)
    {
        int max = int.MinValue;
        int index = 0;

        if (numberToFind == 0)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }
        }
        else
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < max)
                {
                    max = array[i];
                    index = i;
                }
            }
        }

        return index;
    }
}

class LinearFinder:IMinMaxFindable
{
    public int GetIndex(int[] array, int numberToFInd)
    {
        int index = 0;
        bool wasFound = false;

        for (int i=0;i<array.Length;i++)
        {
            if (array[i] == numberToFInd)
            {
                index = i;
                wasFound = true;

                break;
            }
        }

        if (!wasFound) Console.WriteLine("Такого элемента в указанном массиве не найдено");

        return index;
    }
}

class InterpollationFinder : IMinMaxFindable
{
    public int GetIndex(int[] array, int numberToFind)
    {
        int index = 0;
        bool wasFound = false;

        int midIndex=(array.Length-1)/2;
        int low=0;
        int high=array.Length-1;

        while (true)
        {
            midIndex = low + ((numberToFind - array[low]) * (high - low)) / (array[high] - array[low]);
            if (array[midIndex] < numberToFind)
                low = midIndex + 1;
            else if (array[midIndex] > numberToFind)
                high = midIndex - 1;
            else if (numberToFind == array[midIndex])
            {
                index=midIndex;

                break;
            }
        }

        return index;
    }
}

class FindIndex
{
    IMinMaxFindable actionInstance;
    public FindIndex(IMinMaxFindable actionInstance)
    {
        this.actionInstance = actionInstance;
    }

    public int GetIndex(int[] array, int toFInd)
    {

        return actionInstance.GetIndex(array,toFInd);
    }
}