using System;
using System.Collections.Generic;
using System.Text;
using NSU.WormsGame.Entities;
namespace NSU.WormsGame.Services
{
    public interface IWormNamesGeneratorService
    {
        public string GenerateWormName(string baseName, List<Worm> worms);
    }
    internal class WormNamesGeneratorService : IWormNamesGeneratorService
    {
        public string GenerateWormName(string baseName, List<Worm> worms)
        {
            int tryCount = 0;

            while (true)
            {
                string newName = baseName + tryCount;
                Worm worm = worms.Find(worm => worm.Name.Equals(newName));
                if (worm == null)
                    return newName;

                tryCount++;
            }
        }
    }
}
