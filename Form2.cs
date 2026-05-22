using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FuelCalculator
{
    public partial class CalculateTanksLevelForm : Form
    {
        private readonly string logDir;
        private readonly string hfoFile;


        public CalculateTanksLevelForm()
        {
            InitializeComponent();
            numMainLevelLB.Maximum = MainMenuForm.HFO1.Count - 1;
            numSettingTankLB.Maximum = MainMenuForm.HFO1_setting.Count - 1;

            logDir = Path.Combine(Application.StartupPath, "Logs");
            hfoFile = Path.Combine(logDir, "Mazut.txt");
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }
        //вычисление объема по значению уровня в мазут основной запас лб
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int level = (int)numMainLevelLB.Value;
            double volume = Helper.CalculateVolume(level, MainMenuForm.HFO1);
            lblMainVolumeLB.Text = volume.ToString("F2");
        }

        private void numMainLevelLB_Leave(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }
        //вычисление тонножа по значению плотности и объему в основном запасе мазута лб
        private void txtDensityMainLB_Leave(object sender, EventArgs e)
        {
            //если поле плотности или поле объема пустое
            if (string.IsNullOrEmpty(txtDensityMainLB.Text) || string.IsNullOrEmpty(lblMainVolumeLB.Text))
            { lblMainTonnsLB.Text = "0.00"; return; }

            //если поле плотности не пустое
            double dens = (double.Parse(txtDensityMainLB.Text.Replace(".", ",")));
            double volume = double.Parse(lblMainVolumeLB.Text.Replace(".", ","));

            lblMainTonnsLB.Text = Helper.calculateTons(dens, volume).ToString("F2");
            UpdateHfoTotal();
        }
        //вычисление объема по значению уровня
        private void numSettingTankLB_Leave(object sender, EventArgs e)
        {
            //если поле уровня пустое

            int level = (int)numSettingTankLB.Value;
            double volume = Helper.CalculateVolume(level, MainMenuForm.HFO1_setting);
            txtSettingVolumeLB.Text = volume.ToString("F2");
            txtSettingDensityLB.Focus();
        }
        //вычисление тонножа в отстойном танке мазута лб по значению плотности и объему
        private void txtSettingDensityLB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSettingDensityLB.Text) || string.IsNullOrEmpty(txtSettingVolumeLB.Text))
            { lblSettingTankTonnLB.Text = "0.00"; return; }
            else
            {
                double dens = (double.Parse(txtSettingDensityLB.Text.Replace(".", ",")));
                double volume = double.Parse(txtSettingVolumeLB.Text.Replace(".", ","));
                lblSettingTankTonnLB.Text = Helper.calculateTons(dens, volume).ToString("F2");
            }
            UpdateHfoTotal();

        }

        private void txtSettingVolumeLB_Enter(object sender, EventArgs e)
        {
            numSettingTankLB.Value = 0;
        }

        //вычисление тонножа в расходном танке мазута лб по значениям плотности и объема
        private void txtServistankDensityLB_Leave(object sender, EventArgs e)
        {
            //если поля плотности или объема пустые или равны нулю
            if (string.IsNullOrEmpty(txtServistankDensityLB.Text) || string.IsNullOrEmpty(txtServistankVolumeLB.Text))
            { lblServiceTankTonnLB.Text = "0"; return; }
            else
            {
                double dens = (double.Parse(txtServistankDensityLB.Text.Replace(".", ",")));
                double volume = double.Parse(txtServistankVolumeLB.Text.Replace(".", ","));
                lblServiceTankTonnLB.Text = Helper.calculateTons(dens, volume).ToString("F2");
            }
            UpdateHfoTotal();
        }
        //метод суммирования объемов и тоннажей всех танков мазута лб и вывода результата в итоговые поля
        private void UpdateHfoTotal()
        {
            double totalVol = 0;
            double totalTon = 0;

            // 1. Основной танк (с проверкой на пустоту!)
            if (!string.IsNullOrEmpty(lblMainVolumeLB.Text))
                totalVol = double.Parse(lblMainVolumeLB.Text.Replace(".", ",")); // Не забудь Replace, если нужно

            if (!string.IsNullOrEmpty(txtSettingVolumeLB.Text))
                totalVol += double.Parse(txtSettingVolumeLB.Text.Replace(".", ","));

            if (!string.IsNullOrEmpty(txtServistankVolumeLB.Text))
                totalVol += double.Parse(txtServistankVolumeLB.Text.Replace(".", ","));


            // 2. Считаем тоннаж (тоже с проверкой первого)
            if (!string.IsNullOrEmpty(lblMainTonnsLB.Text))
                totalTon = double.Parse(lblMainTonnsLB.Text.Replace(".", ","));

            if (!string.IsNullOrEmpty(lblSettingTankTonnLB.Text))
                totalTon += double.Parse(lblSettingTankTonnLB.Text.Replace(".", ","));

            if (!string.IsNullOrEmpty(lblServiceTankTonnLB.Text))
                totalTon += double.Parse(lblServiceTankTonnLB.Text.Replace(".", ","));

            // 3. Выводим результат (этого не хватало)
            lblTotalVolumeLB.Text = totalVol.ToString("F2");
            lblTotalTonnLB.Text = totalTon.ToString("F2");
        }

        private void btnOpenHfoLog_Click(object sender, EventArgs e)
        {
            if (File.Exists(hfoFile))
            {
                Process.Start(new ProcessStartInfo(hfoFile) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("Журнал пока пуст. Сделайте первый замер.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveHfo_Click(object sender, EventArgs e)
        {
            // 1. Получаем текущую дату и время
            string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

            // 2. Собираем данные. 
            // Логика такая: если текст в поле пустой или пробелы -> пишем "0.00", иначе берём то, что есть.
            // Обрати внимание: у Labels и TextBoxs мы берем свойство .Text

            // --- Основной танк ---
            string volMain = string.IsNullOrWhiteSpace(lblMainVolumeLB.Text) ? "0.00" : lblMainVolumeLB.Text;
            string denMain = string.IsNullOrWhiteSpace(txtDensityMainLB.Text) ? "0.00" : txtDensityMainLB.Text; // Убедись, что имя контрола плотности верное
            string tonMain = string.IsNullOrWhiteSpace(lblMainTonnsLB.Text) ? "0.00" : lblMainTonnsLB.Text;

            // --- Отстойный танк ---
            string volSett = string.IsNullOrWhiteSpace(txtSettingVolumeLB.Text) ? "0.00" : txtSettingVolumeLB.Text;
            string denSett = string.IsNullOrWhiteSpace(txtSettingDensityLB.Text) ? "0.00" : txtSettingDensityLB.Text;
            string tonSett = string.IsNullOrWhiteSpace(lblSettingTankTonnLB.Text) ? "0.00" : lblSettingTankTonnLB.Text;

            // --- Расходный танк ---
            string volServ = string.IsNullOrWhiteSpace(txtServistankVolumeLB.Text) ? "0.00" : txtServistankVolumeLB.Text;
            string denServ = string.IsNullOrWhiteSpace(txtServistankDensityLB.Text) ? "0.00" : txtServistankDensityLB.Text;
            string tonServ = string.IsNullOrWhiteSpace(lblServiceTankTonnLB.Text) ? "0.00" : lblServiceTankTonnLB.Text;

            // --- ИТОГО ---
            string totalVol = string.IsNullOrWhiteSpace(lblTotalVolumeLB.Text) ? "0.00" : lblTotalVolumeLB.Text;
            string totalTon = string.IsNullOrWhiteSpace(lblTotalTonnLB.Text) ? "0.00" : lblTotalTonnLB.Text;

            // 3. Формируем итоговый блок текста (как мы договаривались)
            string block = $"{date}\n" +
                           $"Основной   | Об: {volMain} | Пл: {denMain} | Тн: {tonMain}\n" +
                           $"Отстойный  | Об: {volSett} | Пл: {denSett} | Тн: {tonSett}\n" +
                           $"Расходный  | Об: {volServ} | Пл: {denServ} | Тн: {tonServ}\n" +
                           $"ИТОГО      | Об: {totalVol} | Тн: {totalTon}\n" +
                           $"========================================\n\n";

            // 4. Записываем в файл (добавляем в конец)
            try
            {
                // Создаём папку Logs, если её ещё нет
                Directory.CreateDirectory(logDir);

                File.AppendAllText(hfoFile, block);
                File.AppendAllText(hfoFile, block);
                MessageBox.Show("Данные успешно сохранены в журнал.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
