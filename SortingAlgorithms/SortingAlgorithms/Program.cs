using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Loading file...");

            int[] list = readFromFile();

            Console.WriteLine("File loaded.");
            Console.WriteLine();
            Console.WriteLine("Choose a sorting algorithm (Select '1' or '2')");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Insertion Sort");
            Console.WriteLine("3. Selection Sort");
            Console.WriteLine();

            bool done = true;
            while (done)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        bubbleSort(list);
                        done = false;
                        break;
                    case "2":
                        insertionSort(list);
                        done = false;
                        break;
                    case "3":
                        selectionSort(list);
                        done = false;
                        break;
                    default:
                        Console.WriteLine("That was an invalid selection. Please select '1' or '2'.");
                        break;
                } 
            }

            Console.WriteLine();
            Console.WriteLine("Press 'enter' to exit");
            Console.ReadLine();
        }

        static int[] readFromFile()
        {
            string numbersString = File.ReadAllText(@"C:\dev\data\unsorted-numbers.txt");
            string[] numbersList = numbersString.Split(',');
            int[] numbers = Array.ConvertAll<string, int>(numbersList, int.Parse);
            
            /*
            int[] numbers = new int[numbersList.Length];
            for (int i = 0; i < numbersList.Length; i++)
            {
                numbers[i] = int.Parse(numbersList[i]);
            }
            */
            return numbers;
        }

        static void bubbleSort(int[] list)
        {
            Console.WriteLine();
            printList("Unsorted List", list);

            for (int i = list.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine();
            printList("Sorted list", list);
        }

        static void insertionSort(int[] list)
        {
            Console.WriteLine();
            printList("Unsorted List", list);

            for (int i = 0; i < list.Length - 1; i++)
            {
                int j = i + 1;
                while (j > 0)
                {
                    if (list[j - 1] > list[j])
                    {
                        int temp = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = temp;
                    }
                    j--;
                }
            }

            Console.WriteLine();
            printList("Sorted list", list);
        }

        static void selectionSort(int[] list)
        {
            Console.WriteLine();
            printList("Unsorted List", list);

            for (int i = 0; i < list.Length - 1; i++)
            {
                int j = i;

                for (int k = i + 1; k < list.Length; k++)
                {
                    if (list[k] < list[j])
                    {
                        j = k;
                    }
                }

                int temp = list[j];
                list[j] = list[i];
                list[i] = temp;
            }

            Console.WriteLine();
            printList("Sorted List", list);
        }

        static void printList(string listName, int[] list)
        {
            Console.WriteLine("-- " + listName + " --");
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}