namespace WizardChessUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.listBoxAvailableWizards = new System.Windows.Forms.ListBox();
            this.listBoxPlayerTeam = new System.Windows.Forms.ListBox();
            this.listBoxBattleLog = new System.Windows.Forms.ListBox();
            this.buttonAddToTeam = new System.Windows.Forms.Button();
            this.buttonStartBattle = new System.Windows.Forms.Button();
            this.buttonNextTurn = new System.Windows.Forms.Button();
            this.labelAvailableWizards = new System.Windows.Forms.Label();
            this.labelPlayerTeam = new System.Windows.Forms.Label();
            this.labelEnergy = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // listBoxAvailableWizards
            // 
            this.listBoxAvailableWizards.FormattingEnabled = true;
            this.listBoxAvailableWizards.ItemHeight = 16;
            this.listBoxAvailableWizards.Location = new System.Drawing.Point(12, 32);
            this.listBoxAvailableWizards.Name = "listBoxAvailableWizards";
            this.listBoxAvailableWizards.Size = new System.Drawing.Size(180, 164);
            this.listBoxAvailableWizards.TabIndex = 0;

            // 
            // listBoxPlayerTeam
            // 
            this.listBoxPlayerTeam.FormattingEnabled = true;
            this.listBoxPlayerTeam.ItemHeight = 16;
            this.listBoxPlayerTeam.Location = new System.Drawing.Point(212, 32);
            this.listBoxPlayerTeam.Name = "listBoxPlayerTeam";
            this.listBoxPlayerTeam.Size = new System.Drawing.Size(180, 164);
            this.listBoxPlayerTeam.TabIndex = 1;

            // 
            // listBoxBattleLog
            // 
            this.listBoxBattleLog.FormattingEnabled = true;
            this.listBoxBattleLog.ItemHeight = 16;
            this.listBoxBattleLog.Location = new System.Drawing.Point(12, 260);
            this.listBoxBattleLog.Name = "listBoxBattleLog";
            this.listBoxBattleLog.Size = new System.Drawing.Size(380, 164);
            this.listBoxBattleLog.TabIndex = 2;

            // 
            // buttonAddToTeam
            // 
            this.buttonAddToTeam.Location = new System.Drawing.Point(12, 202);
            this.buttonAddToTeam.Name = "buttonAddToTeam";
            this.buttonAddToTeam.Size = new System.Drawing.Size(180, 30);
            this.buttonAddToTeam.TabIndex = 3;
            this.buttonAddToTeam.Text = "Добавить в команду";
            this.buttonAddToTeam.UseVisualStyleBackColor = true;
            this.buttonAddToTeam.Click += new System.EventHandler(this.buttonAddToTeam_Click);

            // 
            // buttonStartBattle
            // 
            this.buttonStartBattle.Location = new System.Drawing.Point(212, 202);
            this.buttonStartBattle.Name = "buttonStartBattle";
            this.buttonStartBattle.Size = new System.Drawing.Size(180, 30);
            this.buttonStartBattle.TabIndex = 4;
            this.buttonStartBattle.Text = "Начать бой";
            this.buttonStartBattle.UseVisualStyleBackColor = true;
            this.buttonStartBattle.Click += new System.EventHandler(this.buttonStartBattle_Click);

            // 
            // buttonNextTurn
            // 
            this.buttonNextTurn.Enabled = false; // По умолчанию кнопка отключена
            this.buttonNextTurn.Location = new System.Drawing.Point(12, 430);
            this.buttonNextTurn.Name = "buttonNextTurn";
            this.buttonNextTurn.Size = new System.Drawing.Size(380, 30);
            this.buttonNextTurn.TabIndex = 5;
            this.buttonNextTurn.Text = "Следующий ход";
            this.buttonNextTurn.UseVisualStyleBackColor = true;
            this.buttonNextTurn.Click += new System.EventHandler(this.buttonNextTurn_Click);

            // 
            // labelAvailableWizards
            // 
            this.labelAvailableWizards.AutoSize = true;
            this.labelAvailableWizards.Location = new System.Drawing.Point(12, 12);
            this.labelAvailableWizards.Name = "labelAvailableWizards";
            this.labelAvailableWizards.Size = new System.Drawing.Size(128, 17);
            this.labelAvailableWizards.TabIndex = 6;
            this.labelAvailableWizards.Text = "Доступные маги:";

            // 
            // labelPlayerTeam
            // 
            this.labelPlayerTeam.AutoSize = true;
            this.labelPlayerTeam.Location = new System.Drawing.Point(212, 12);
            this.labelPlayerTeam.Name = "labelPlayerTeam";
            this.labelPlayerTeam.Size = new System.Drawing.Size(112, 17);
            this.labelPlayerTeam.TabIndex = 7;
            this.labelPlayerTeam.Text = "Команда игрока:";

            // 
            // labelEnergy
            // 
            this.labelEnergy.AutoSize = true;
            this.labelEnergy.Location = new System.Drawing.Point(12, 232);
            this.labelEnergy.Name = "labelEnergy";
            this.labelEnergy.Size = new System.Drawing.Size(73, 17);
            this.labelEnergy.TabIndex = 8;
            this.labelEnergy.Text = "Энергия: ";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 471);
            this.Controls.Add(this.labelEnergy);
            this.Controls.Add(this.labelPlayerTeam);
            this.Controls.Add(this.labelAvailableWizards);
            this.Controls.Add(this.buttonNextTurn);
            this.Controls.Add(this.buttonStartBattle);
            this.Controls.Add(this.buttonAddToTeam);
            this.Controls.Add(this.listBoxBattleLog);
            this.Controls.Add(this.listBoxPlayerTeam);
            this.Controls.Add(this.listBoxAvailableWizards);
            this.Name = "Form1";
            this.Text = "Magic Battle";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        // Поля для компонентов
        private System.Windows.Forms.ListBox listBoxAvailableWizards;
        private System.Windows.Forms.ListBox listBoxPlayerTeam;
        private System.Windows.Forms.ListBox listBoxBattleLog;
        private System.Windows.Forms.Button buttonAddToTeam;
        private System.Windows.Forms.Button buttonStartBattle;
        private System.Windows.Forms.Button buttonNextTurn;
        private System.Windows.Forms.Label labelAvailableWizards;
        private System.Windows.Forms.Label labelPlayerTeam;
        private System.Windows.Forms.Label labelEnergy;

    }
}
