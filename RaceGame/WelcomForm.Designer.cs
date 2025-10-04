namespace Race
{
    partial class WelcomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelWhoIsWarrior = new Label();
            textBoxNameValue = new TextBox();
            buttonStart = new Button();
            SuspendLayout();
            // 
            // labelWhoIsWarrior
            // 
            labelWhoIsWarrior.AutoSize = true;
            labelWhoIsWarrior.Font = new Font("Microsoft YaHei", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelWhoIsWarrior.ForeColor = SystemColors.ControlLightLight;
            labelWhoIsWarrior.Location = new Point(89, 58);
            labelWhoIsWarrior.Margin = new Padding(7, 0, 7, 0);
            labelWhoIsWarrior.Name = "labelWhoIsWarrior";
            labelWhoIsWarrior.Size = new Size(215, 36);
            labelWhoIsWarrior.TabIndex = 0;
            labelWhoIsWarrior.Text = "Кто ты ВОИН?";
            // 
            // textBoxNameValue
            // 
            textBoxNameValue.Location = new Point(55, 97);
            textBoxNameValue.Name = "textBoxNameValue";
            textBoxNameValue.Size = new Size(279, 43);
            textBoxNameValue.TabIndex = 1;
            textBoxNameValue.KeyDown += TextBoxNameValue_KeyDown;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(89, 176);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(215, 45);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Поехали";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += ButtonStart_Click;
            // 
            // WelcomForm
            // 
            AutoScaleDimensions = new SizeF(17F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(384, 261);
            Controls.Add(buttonStart);
            Controls.Add(textBoxNameValue);
            Controls.Add(labelWhoIsWarrior);
            Font = new Font("Microsoft YaHei", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(7);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WelcomForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Идентификация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelWhoIsWarrior;
        private TextBox textBoxNameValue;
        private Button buttonStart;
    }
}