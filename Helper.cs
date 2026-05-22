using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection.Metadata.Ecma335;

namespace FuelCalculator
{
    public static class Helper
    {
        //расчет тонножа по плотности и объему
        public static double calculateTons(double dens, double volume)
        {
        

            if (dens < 0.8 || dens > 1.0)
                {
                    MessageBox.Show("Плотность должна быть в диапазоне от 0.8 до 1.0", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                if (volume < 0)
                {
                    MessageBox.Show("Объем не может быть отрицательным", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            
            return dens * volume;

        }
        //расчет объема по уровню и калибровке
        public static double CalculateVolume(int level, List<double> calibration)
        {
            if (calibration == null || calibration.Count == 0)
                return 0;

            if (level >= 0 && level < calibration.Count)
                return calibration[level];

            return 0;
        }
        //загрузка данных из файла в список, с проверкой на ошибки
        public static void LoadNumbersFromFile(string filePath, List<double> numbers)
        {
            numbers.Clear();

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"Файл {filePath} не найден", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (string rawLine in File.ReadLines(filePath))
            {
                string line = rawLine.Trim();

                if (string.IsNullOrWhiteSpace(line)) continue;

                if (double.TryParse(line.Replace(".", ","), out double number))
                {
                    numbers.Add(number);
                }
                else
                {
                    MessageBox.Show($"Ошибка в файле {filePath}:\n{line}", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numbers.Clear();
                    return;
                }
            }
        }
    }

 
    } 
