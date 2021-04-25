using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace HomeWork3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class PointClass
    {
        public float X;
        public float Y;
    }
    public struct PointStruct
    {
        public float X;
        public float Y;
    }
    public struct PointDouble
    {
        public double X;
        public double Y;
    }

    public struct PointStructDouble
    {
        public double X;
        public double Y;
    }
    public class BechmarkClass
    {
        PointClass a = new PointClass();
        PointClass b = new PointClass();

        PointStruct a1 = new PointStruct();
        PointStruct b1 = new PointStruct();

        PointStructDouble a2 = new PointStructDouble();
        PointStructDouble b2 = new PointStructDouble();

        public float DistanceRef(PointClass pointClass1, PointClass pointClass2)
        {
            float X = pointClass1.X - pointClass2.X;
            float Y = pointClass2.Y - pointClass2.Y;
            return (float)Math.Sqrt((X * X) + (Y * Y));
        }
        public float DistanceVal(PointStruct pointStruct1, PointStruct pointStruct2)
        {
            float X = pointStruct1.X - pointStruct2.X;
            float Y = pointStruct1.Y - pointStruct2.Y;
            return (float)Math.Sqrt((X * X) + (Y * Y));
        }
        public double DistanceValDouble(PointStructDouble pointStructDouble1, PointStructDouble pointStructDouble2)
        {
            double X = pointStructDouble1.X - pointStructDouble2.X;
            double Y = pointStructDouble1.Y - pointStructDouble2.Y;
            return Math.Sqrt((X * X) + (Y * Y));
        }
        public float DistanceValShort(PointStruct pointStruct1, PointStruct pointStruct2)
        {
            float X = pointStruct1.X - pointStruct2.X;
            float Y = pointStruct1.Y - pointStruct2.Y;
            return (X * X) + (Y * Y);
        }

        [Benchmark]
        public void Test1()
        {
            DistanceRef(a, b);
        }
        [Benchmark]
        public void Test2()
        {
            DistanceVal(a1, b1);
        }
        [Benchmark]
        public void Test3()
        {
            DistanceValDouble(a2, b2);
        }
        [Benchmark]
        public void Test4()
        {
            DistanceValShort(a1, b1);
        }
    }
}
/// <summary>
///| Method |      Mean |     Error |    StdDev |    Median |
//| ------- | ---------:|----------:|----------:| ---------:|
//  | Test1 | 5.4676 ns | 0.0923 ns | 0.0771 ns | 5.4502 ns |
//  | Test2 | 5.6359 ns | 0.6743 ns | 1.9881 ns | 4.2139 ns |
//  | Test3 | 0.0510 ns | 0.0458 ns | 0.0450 ns | 0.0357 ns |
//  | Test4 | 1.4568 ns | 0.1904 ns | 0.5555 ns | 1.6889 ns |
/// </summary>
/// 



/*Напишите тесты производительности для расчёта дистанции между точками с помощью BenchmarkDotNet.
Рекомендуем сгенерировать заранее массив данных, чтобы расчёт шёл с различными значениями, но сам код генерации должен происходить вне участка кода, время которого
будет тестироваться.

Для каких методов потребуется написать тест:
1.Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).

2.Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).

3.Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).

4.Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float).

Результаты можно оформить в виде списка или таблицы, в которой наглядно можно будет увидеть время выполнения того или иного метода.*/
