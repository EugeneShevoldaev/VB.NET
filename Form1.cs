namespace FuelCalculator
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System.Windows.Forms;
    public partial class MainMenuForm : Form
    {
        // public static — чтобы другие формы могли обратиться
        public static List<double> DO1 = new List<double>();
        public static List<double> DO2 = new List<double>();
        public static List<double> HFO1 = new List<double>();
        public static List<double> HFO2 = new List<double>();
        public static List<double> HFO1_setting = new List<double>();
        public static List<double> HFO2_setting = new List<double>();

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            Helper.LoadNumbersFromFile("DO1.txt", DO1);
            Helper.LoadNumbersFromFile("DO2.txt", DO2);
            Helper.LoadNumbersFromFile("HFO1.txt", HFO1);
            Helper.LoadNumbersFromFile("HFO2.txt", HFO2);
            Helper.LoadNumbersFromFile("HFO1_setting.txt", HFO1_setting);
            Helper.LoadNumbersFromFile("HFO2_setting.txt", HFO2_setting);
        }

        private void btnCalculateAtLevel_Click(object sender, EventArgs e)
        {
            CalculateTanksLevelForm form = new CalculateTanksLevelForm();
            form.ShowDialog();
        }
    }
}


