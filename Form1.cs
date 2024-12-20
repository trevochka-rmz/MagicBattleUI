using System;
using System.Windows.Forms;
using WizardChessUI;

namespace WizardChessUI
{
    public partial class Form1 : Form
    {
        private GameManager gameManager;
        private int currentBattleLogIndex;

        public Form1()
        {
            InitializeComponent();
            gameManager = new GameManager();
            InitializeAvailableWizardsList();
            UpdateEnergyLabel();
        }

        private void InitializeAvailableWizardsList()
        {
            var availableWizards = gameManager.GetAvailableWizards();
            listBoxAvailableWizards.Items.Clear();
            foreach (var wizard in availableWizards)
            {
                listBoxAvailableWizards.Items.Add($"{wizard.Name} (HP: {wizard.Health}, MP: {wizard.MagicPower})");
            }
        }

        private void UpdateEnergyLabel()
        {
            labelEnergy.Text = $"Энергия: {gameManager.GetPlayerEnergy()}";
        }

        private void UpdatePlayerTeamList()
        {
            var playerTeam = gameManager.GetPlayerTeam();
            listBoxPlayerTeam.Items.Clear();
            foreach (var wizard in playerTeam)
            {
                listBoxPlayerTeam.Items.Add($"{wizard.Name} (HP: {wizard.Health}, MP: {wizard.MagicPower})");
            }
        }

        private void buttonAddToTeam_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxAvailableWizards.SelectedIndex;
            if (selectedIndex >= 0)
            {
                var success = gameManager.AddWizardToPlayerTeam(selectedIndex);
                if (success)
                {
                    UpdatePlayerTeamList();
                    UpdateEnergyLabel();
                }
                else
                {
                    MessageBox.Show("Недостаточно энергии или волшебник уже в команде.");
                }
            }
        }

        private void buttonStartBattle_Click(object sender, EventArgs e)
        {
            if (listBoxPlayerTeam.Items.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одного волшебника для начала боя.");
                return;
            }

            currentBattleLogIndex = 0;
            listBoxBattleLog.Items.Clear();

            var initialLog = "Бой начался!";
            listBoxBattleLog.Items.Add(initialLog);
            MessageBox.Show(initialLog);

            buttonNextTurn.Enabled = true;
            buttonStartBattle.Enabled = false;
        }

        private void buttonNextTurn_Click(object sender, EventArgs e)
        {
            var logEntry = gameManager.ExecuteNextTurn();
            listBoxBattleLog.Items.Add(logEntry);

            if (logEntry.Contains("Бой завершён."))
            {
                buttonNextTurn.Enabled = false;
                buttonStartBattle.Enabled = true;

                // Показываем итог боя
                MessageBox.Show(logEntry);
            }

            UpdatePlayerTeamList();
        }

    }
}
