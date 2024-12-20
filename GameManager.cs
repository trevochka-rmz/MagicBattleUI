using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardChessUI
{
    public class GameManager
    {
        private const int WizardCost = 40;
        private GameState gameState;
        private List<Wizard> availableWizards = new List<Wizard>();
        private List<string> battleLog = new List<string>();
        private bool isBattleOver = false;
        private bool PlayerTurn = true; // True — ход игрока, False — ход врага.

        public GameManager()
        {
            gameState = new GameState();
            InitializeAvailableWizards();
            InitializeEnemyTeam();
        }

        private void InitializeAvailableWizards()
        {
            availableWizards.Add(new Wizard("Арканист", 80, 25));
            availableWizards.Add(new Wizard("Элементалист", 100, 20));
            availableWizards.Add(new Wizard("Мастер теней", 70, 30));
            availableWizards.Add(new Wizard("Огненный маг", 90, 27));
            availableWizards.Add(new Wizard("Страж земли", 110, 18));
        }

        private void InitializeEnemyTeam()
        {
            gameState.EnemyTeam.Add(new Wizard("Тёмный маг", 85, 22));
            gameState.EnemyTeam.Add(new Wizard("Некромант", 95, 20));
            gameState.EnemyTeam.Add(new Wizard("Призыватель", 90, 25));
            battleLog.Add("Команда тёмных магов готова.");
        }

        public List<Wizard> GetAvailableWizards()
        {
            return availableWizards;
        }

        public int GetPlayerEnergy()
        {
            return gameState.PlayerEnergy;
        }

        public List<Character> GetPlayerTeam()
        {
            return gameState.PlayerTeam.GetAliveCharacters();
        }

        public List<Character> GetEnemyTeam()
        {
            return gameState.EnemyTeam.GetAliveCharacters();
        }

        public List<string> GetBattleLog()
        {
            return new List<string>(battleLog);
        }

        public bool AddWizardToPlayerTeam(int wizardIndex)
        {
            if (wizardIndex >= 0 && wizardIndex < availableWizards.Count)
            {
                var selectedWizard = availableWizards[wizardIndex];
                if (!gameState.PlayerTeam.Contains(selectedWizard) && gameState.PlayerEnergy >= WizardCost)
                {
                    gameState.PlayerTeam.Add(selectedWizard);
                    gameState.DeductEnergy(WizardCost);
                    return true;
                }
            }
            return false;
        }

        public string ExecuteNextTurn()
        {
            string logEntry = string.Empty;

            if (PlayerTurn)
            {
                var playerCharacter = gameState.PlayerTeam.GetAliveCharacters().FirstOrDefault();
                var enemyCharacter = gameState.EnemyTeam.GetAliveCharacters().FirstOrDefault();

                if (playerCharacter != null && enemyCharacter != null)
                {
                    playerCharacter.CastSpell(enemyCharacter);
                    logEntry = $"{playerCharacter.Name} атаковал {enemyCharacter.Name}.";
                    if (!enemyCharacter.IsAlive)
                    {
                        logEntry += $" {enemyCharacter.Name} погиб.";
                    }
                }
            }
            else
            {
                var enemyCharacter = gameState.EnemyTeam.GetAliveCharacters().FirstOrDefault();
                var playerCharacter = gameState.PlayerTeam.GetAliveCharacters().FirstOrDefault();

                if (enemyCharacter != null && playerCharacter != null)
                {
                    enemyCharacter.CastSpell(playerCharacter);
                    logEntry = $"{enemyCharacter.Name} атаковал {playerCharacter.Name}.";
                    if (!playerCharacter.IsAlive)
                    {
                        logEntry += $" {playerCharacter.Name} погиб.";
                    }
                }
            }

            // Проверка завершения боя
            if (gameState.PlayerTeam.GetAliveCharacters().Count == 0)
            {
                logEntry = "Бой завершён. Вы проиграли.";
                battleLog.Add(logEntry);
                return "Бой завершён. Вы проиграли.";
            }

            if (gameState.EnemyTeam.GetAliveCharacters().Count == 0)
            {
                logEntry = "Бой завершён. Вы победили.";
                battleLog.Add(logEntry);
                return "Бой завершён. Вы победили.";
            }

            // Переключаем очередь
            PlayerTurn = !PlayerTurn;

            battleLog.Add(logEntry);
            return logEntry;
        }



        public bool StartBattle()
        {
            while (gameState.PlayerTeam.GetAliveCharacters().Count > 0 && gameState.EnemyTeam.GetAliveCharacters().Count > 0)
            {
                foreach (var playerCharacter in gameState.PlayerTeam.GetAliveCharacters())
                {
                    var target = gameState.EnemyTeam.GetAliveCharacters().FirstOrDefault();
                    if (target != null)
                    {
                        playerCharacter.CastSpell(target);
                        battleLog.Add($"{playerCharacter.Name} атакует {target.Name}, нанося {playerCharacter.MagicPower} урона!");
                    }
                }

                foreach (var enemyCharacter in gameState.EnemyTeam.GetAliveCharacters())
                {
                    var target = gameState.PlayerTeam.GetAliveCharacters().FirstOrDefault();
                    if (target != null)
                    {
                        enemyCharacter.CastSpell(target);
                        battleLog.Add($"{enemyCharacter.Name} атакует {target.Name}, нанося {enemyCharacter.MagicPower} урона!");
                    }
                }
            }

            isBattleOver = true;
            return gameState.PlayerTeam.GetAliveCharacters().Count > 0;
        }
    }


}
