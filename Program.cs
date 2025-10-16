using System;

namespace LabWork
{    class Cone
    {
        private readonly double _baseX;
        private readonly double _baseY;
        private readonly double _baseZ;
        private readonly double _apexX;
        private readonly double _apexY;
        private readonly double _apexZ;
        private readonly double _radius;

        public Cone(double baseX, double baseY, double baseZ,
                    double apexX, double apexY, double apexZ,
                    double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радіус повинен бути додатним числом", nameof(radius));

            _baseX = baseX;
            _baseY = baseY;
            _baseZ = baseZ;
            _apexX = apexX;
            _apexY = apexY;
            _apexZ = apexZ;
            _radius = radius;
        }

                private double CalculateHeight()
        {
            double dx = _apexX - _baseX;
            double dy = _apexY - _baseY;
            double dz = _apexZ - _baseZ;

            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        
        public double GetSlantHeight()
        {
            double height = CalculateHeight();
            return Math.Sqrt(_radius * _radius + height * height);
        }

        
        public override string ToString()
        {
            return $"Конус: Основа({_baseX:F1}, {_baseY:F1}, {_baseZ:F1}), " +
                   $"Вершина({_apexX:F1}, {_apexY:F1}, {_apexZ:F1}), " +
                   $"Радіус={_radius:F2}, Твірна={GetSlantHeight():F2}";
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Пошук конуса з найбільшою твірною ===\n");

    
            Console.Write("Введіть кількість конусів (n): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Помилка: введіть додатне ціле число!");
                return;
            }

           
            Cone[] cones = new Cone[n];

           
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Конус #{i + 1} ---");

                Console.Write("Центр основи - X: ");
                if (!double.TryParse(Console.ReadLine(), out double baseX))
                {
                    Console.WriteLine("Помилка вводу! Використовую тестові дані.");
                    cones[i] = GenerateTestCone(i);
                    continue;
                }

                Console.Write("Центр основи - Y: ");
                if (!double.TryParse(Console.ReadLine(), out double baseY))
                {
                    Console.WriteLine("Помилка вводу! Використовую тестові дані.");
                    cones[i] = GenerateTestCone(i);
                    continue;
                }

                Console.Write("Центр основи - Z: ");
                if (!double.TryParse(Console.ReadLine(), out double baseZ))
                {
                    Console.WriteLine("Помилка вводу! Використовую тестові дані.");
                    cones[i] = GenerateTestCone(i);
                    continue;
                }

                Console.Write("Вершина - X: ");
                if (!double.TryParse(Console.ReadLine(), out double apexX))
                {
                    Console.WriteLine("Помилка вводу! Використовую тестові дані.");
                    cones[i] = GenerateTestCone(i);
                    continue;
                }

                Console.Write("Вершина - Y: ");
                if (!double.TryParse(Console.ReadLine(), out double apexY))
                {
                    Console.WriteLine("Помилка вводу! Використовую тестові дані.");
                    cones[i] = GenerateTestCone(i);
                    continue;
                }

                Console.Write("Вершина - Z: ");
                if (!double.TryParse(Console.ReadLine(), out double apexZ))
                {
                    Console.WriteLine("Помилка вводу! Використовую тестові дані.");
                    cones[i] = GenerateTestCone(i);
                    continue;
                }

                Console.Write("Радіус основи: ");
                if (!double.TryParse(Console.ReadLine(), out double radius))
                {
                    Console.WriteLine("Помилка вводу! Використовую тестові дані.");
                    cones[i] = GenerateTestCone(i);
                    continue;
                }

                try
                {
                    cones[i] = new Cone(baseX, baseY, baseZ, apexX, apexY, apexZ, radius);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}. Використовую тестові дані.");
                    cones[i] = GenerateTestCone(i);
                }
            }

        
            Console.WriteLine("\n=== Всі конуси ===\n");
            for (int i = 0; i < cones.Length; i++)
            {
                Console.WriteLine($"#{i + 1}: {cones[i]}");
            }

            
            Cone maxCone = cones[0];
            double maxSlantHeight = maxCone.GetSlantHeight();

            for (int i = 1; i < cones.Length; i++)
            {
                double currentSlantHeight = cones[i].GetSlantHeight();
                if (currentSlantHeight > maxSlantHeight)
                {
                    maxSlantHeight = currentSlantHeight;
                    maxCone = cones[i];
                }
            }

           
            Console.WriteLine("\n=== Результат ===\n");
            Console.WriteLine("Конус з найбільшою твірною:");
            Console.WriteLine(maxCone);
        }

        
        private static Cone GenerateTestCone(int index)
        {
        
            double[][] testData = new double[][]
            {
                new double[] { 0, 0, 0, 0, 0, 5, 3 },      
                new double[] { 1, 1, 1, 1, 1, 8, 4 },       
                new double[] { -2, 0, 0, -2, 0, 10, 5 },    
                new double[] { 0, 0, 0, 3, 4, 0, 2 },       
                new double[] { 0, 0, 0, 0, 0, 12, 5 }      
            };

            int idx = index % testData.Length;
            return new Cone(
                testData[idx][0], testData[idx][1], testData[idx][2],  
                testData[idx][3], testData[idx][4], testData[idx][5],  
                testData[idx][6]                                        
            );
        }
    }
}
