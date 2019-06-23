using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    public class Level
    {
        public int currentLevel;

        Player player;
        Position exit;
        List<Enemy> enemyList= new List<Enemy>();
        List<Trap> trapList= new List<Trap>();
    }
}
