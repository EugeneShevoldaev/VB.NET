namespace FuelCalculator
{
    partial class MainMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCalculateAtLevel = new Button();
            btnCalculateAtTime = new Button();
            btnDansity = new Button();
            btnHistory = new Button();
            btnSettingsOfCalculate = new Button();
            label1 = new Label();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnCalculateAtLevel
            // 
            btnCalculateAtLevel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCalculateAtLevel.ForeColor = Color.Blue;
            btnCalculateAtLevel.Location = new Point(63, 148);
            btnCalculateAtLevel.Name = "btnCalculateAtLevel";
            btnCalculateAtLevel.Size = new Size(232, 36);
            btnCalculateAtLevel.TabIndex = 0;
            btnCalculateAtLevel.Text = "ПОДСЧЕТ КОЛИЧЕСТВА";
            btnCalculateAtLevel.UseVisualStyleBackColor = true;
            btnCalculateAtLevel.Click += btnCalculateAtLevel_Click;
            // 
            // btnCalculateAtTime
            // 
            btnCalculateAtTime.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCalculateAtTime.ForeColor = Color.Blue;
            btnCalculateAtTime.Location = new Point(63, 219);
            btnCalculateAtTime.Name = "btnCalculateAtTime";
            btnCalculateAtTime.Size = new Size(232, 36);
            btnCalculateAtTime.TabIndex = 0;
            btnCalculateAtTime.Text = "РАСХОД ПО ЧАСАМ РАБОТЫ";
            btnCalculateAtTime.UseVisualStyleBackColor = true;
            // 
            // btnDansity
            // 
            btnDansity.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnDansity.ForeColor = Color.Blue;
            btnDansity.Location = new Point(63, 290);
            btnDansity.Name = "btnDansity";
            btnDansity.Size = new Size(232, 36);
            btnDansity.TabIndex = 0;
            btnDansity.Text = "ПЕРЕСЧЕТ ПЛОТНОСТИ";
            btnDansity.UseVisualStyleBackColor = true;
            // 
            // btnHistory
            // 
            btnHistory.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnHistory.ForeColor = Color.Blue;
            btnHistory.Location = new Point(63, 361);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(232, 36);
            btnHistory.TabIndex = 0;
            btnHistory.Text = "ИСТОРИЯ ЗАМЕРОВ";
            btnHistory.UseVisualStyleBackColor = true;
            // 
            // btnSettingsOfCalculate
            // 
            btnSettingsOfCalculate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSettingsOfCalculate.ForeColor = Color.Blue;
            btnSettingsOfCalculate.Location = new Point(63, 432);
            btnSettingsOfCalculate.Name = "btnSettingsOfCalculate";
            btnSettingsOfCalculate.Size = new Size(232, 36);
            btnSettingsOfCalculate.TabIndex = 0;
            btnSettingsOfCalculate.Text = "НАСТРОЙКИ ВЫЧИСЛЕНИЙ";
            btnSettingsOfCalculate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Maroon;
            label1.Location = new Point(66, 48);
            label1.Name = "label1";
            label1.Size = new Size(227, 21);
            label1.TabIndex = 1;
            label1.Text = "ТОПЛИВНЫЙ КАЛЬКУЛЯТОР";
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnExit.ForeColor = Color.FromArgb(192, 0, 0);
            btnExit.Location = new Point(61, 492);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(232, 36);
            btnExit.TabIndex = 0;
            btnExit.Text = "ВЫХОД";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 643);
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(btnSettingsOfCalculate);
            Controls.Add(btnHistory);
            Controls.Add(btnDansity);
            Controls.Add(btnCalculateAtTime);
            Controls.Add(btnCalculateAtLevel);
            Name = "MainMenuForm";
            Text = "МЕНЮ";
            Load += MainMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalculateAtLevel;
        private Button btnCalculateAtTime;
        private Button btnDansity;
        private Button btnHistory;
        private Button btnSettingsOfCalculate;
        private Label label1;
        private Button btnExit;
    }
}
