using System;
using System.Linq;

namespace GenerycTypesHw
{
    public static class ArrayHelper<TArr>
    {
        public static TArr Pop(ref TArr[] arr)
        {
            TArr el = arr[arr.Length - 1];
            Array.Resize(ref arr, arr.Length - 1);
            return el;
        }
        public static int Push (ref TArr[] arr, TArr el)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = el;
            return arr.Length;
        }
        public static TArr Shift(ref TArr[] arr)
        {
            TArr el = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
                arr[i] = arr[i + 1];
            Array.Resize(ref arr, arr.Length - 1);
            return el;
        }
        public static int UnShift(ref TArr[] arr, TArr el)
        {
            Array.Resize(ref arr, arr.Length + 1);
            for (int i = arr.Length - 1; i >= 1; i--)
                arr[i] = arr[i - 1];
            arr[0] = el;
            return arr.Length;
        }
        public static TArr[] Slice(TArr[] arr, int begin_index = 0, int end_index = 0)
        {
            int length = 0;
            int j = 0;
            TArr[] newArr = new TArr[length];
            if (end_index == 0) end_index = arr.Length;
            if (begin_index > arr.Length - 1 || end_index > arr.Length) return newArr;
            if (begin_index >= 0 && end_index > 0 && end_index <= arr.Length)
            {
                for (int i = begin_index; i < end_index; i++)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[j] = arr[i];
                    j++;
                }
            }
            if (begin_index >=0 && end_index < 0)
            {
                for (int i = begin_index; i < arr.Length + end_index; i++)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[j] = arr[i];
                    j++;
                }
            }
           /* if (begin_index > 0 && end_index < 0)
            {
                for (int i = begin_index; i < arr.Length + end_index; i++)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[j] = arr[begin_index];
                    j++;
                }
            }*/
            if (begin_index < 0)
            {
                
                for (int i = arr.Length + begin_index; i < arr.Length; i++)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[j] = arr[i];
                    j++;
                }
            }
            return newArr;
        }
        public static void ShowArray(TArr[] arr)
        {
            foreach (TArr el in arr)
                Console.Write($"{el} ");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = { "Слон", "Крокодил", "Зебра", "Носорог", "Тигр", "Лев", "Ягуар" };
            Console.WriteLine("Ваш массив: ");
            ArrayHelper<string>.ShowArray(arr);
            Console.WriteLine("Ваш массив после применения метода Pop:");
            Console.WriteLine($"Удалили:  {ArrayHelper<string>.Pop(ref arr)}");
            Console.WriteLine("Осталось:");
            ArrayHelper<string>.ShowArray(arr);
            Console.WriteLine("Ваш массив после применения метода Push:");
            Console.WriteLine($"Обновленная длина вашего массива: {ArrayHelper<string>.Push(ref arr, "Пингвин")}");
            Console.WriteLine("Сам массив: ");
            ArrayHelper<string>.ShowArray(arr);
            Console.WriteLine("Ваш массив после применения метода Shift:");
            Console.WriteLine($"Удалили: {ArrayHelper<string>.Shift(ref arr)}");
            Console.WriteLine("Осталось:");
            ArrayHelper<string>.ShowArray(arr);
            Console.WriteLine("Ваш массив после применения метода UnShift:");
            Console.WriteLine($"Обновленная длина вашего массива: {ArrayHelper<string>.UnShift(ref arr, "Жираф")}");
            Console.WriteLine("Сам массив: ");
            ArrayHelper<string>.ShowArray(arr);
            Console.WriteLine("Метод slice: ");
            string[] newArr = ArrayHelper<string>.Slice(arr, 1, -3);
            ArrayHelper<string>.ShowArray(newArr);
        }
    }
}

