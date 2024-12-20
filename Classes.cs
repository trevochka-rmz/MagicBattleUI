using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardChessUI
{
    // Интерфейс для коллекции персонажей
    public interface ICharacterCollection
    {
        void Add(Character character);
        bool Contains(Character character);
        List<Character> GetAliveCharacters();
    }

    // Реализация коллекции персонажей
    public class CharacterCollection : ICharacterCollection
    {
        private List<Character> characters;

        public CharacterCollection()
        {
            characters = new List<Character>();
        }

        public void Add(Character character)
        {
            characters.Add(character);
        }

        public bool Contains(Character character)
        {
            return characters.Contains(character);
        }

        public List<Character> GetAliveCharacters()
        {
            return characters.FindAll(character => character.IsAlive);
        }
    }

    [Serializable]
    public class GameState
    {
        public ICharacterCollection PlayerTeam { get; private set; }
        public ICharacterCollection EnemyTeam { get; private set; }
        public int PlayerEnergy { get; private set; }

        public GameState()
        {
            PlayerTeam = new CharacterCollection();
            EnemyTeam = new CharacterCollection();
            PlayerEnergy = 200; // Начальная энергия игрока
        }

        public void DeductEnergy(int amount)
        {
            if (PlayerEnergy >= amount)
            {
                PlayerEnergy -= amount;
            }
            else
            {
                throw new InvalidOperationException("Недостаточно энергии.");
            }
        }
    }

    [Serializable]
    public class Character
    {
        public string Name { get; set; } = string.Empty;
        public int Health { get; set; }
        public int MagicPower { get; set; }
        public bool IsAlive { get; set; }

        public virtual void CastSpell(Character target)
        {
            if (IsAlive && target != null)
            {
                target.TakeDamage(MagicPower);
                Console.WriteLine($"{Name} накладывает заклинание на {target.Name}, нанося {MagicPower} урона!");
            }
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                IsAlive = false;
                Console.WriteLine($"{Name} пал в бою.");
            }
        }

        public override string ToString()
        {
            return $"{Name},{Health},{MagicPower},{IsAlive}";
        }
    }

    [Serializable]
    public class Wizard : Character
    {
        public Wizard(string name, int health, int magicPower)
        {
            Name = name;
            Health = health;
            MagicPower = magicPower;
            IsAlive = true;
        }

        public override void CastSpell(Character target)
        {
            if (IsAlive && target != null)
            {
                target.TakeDamage(MagicPower);
                Console.WriteLine($"{Name} вызывает молнию на {target.Name}, нанося {MagicPower} урона!");
            }
        }
    }

    
    
}