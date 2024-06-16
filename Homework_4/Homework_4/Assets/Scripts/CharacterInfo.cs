using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework
{
    public sealed class CharacterInfo
    {
        public event Action<CharacterStat> OnStatAdded;
        public event Action<CharacterStat> OnStatRemoved;
    
        private readonly HashSet<CharacterStat> stats = new();

        public void AddStat(CharacterStat stat)
        {
            if (this.stats.Add(stat))
            {
                this.OnStatAdded?.Invoke(stat);
            }
        }
        
        public void RemoveStat(CharacterStat stat)
        {
            if (this.stats.Remove(stat))
            {
                this.OnStatRemoved?.Invoke(stat);
            }
        }

        public CharacterStat GetStat(string name)
        {
            foreach (var stat in this.stats)
            {
                if (stat.Name == name)
                {
                    return stat;
                }
            }

            throw new Exception($"Stat {name} is not found!");
        }

        public CharacterStat[] GetStats()
        {
            return this.stats.ToArray();
        }
    }
}