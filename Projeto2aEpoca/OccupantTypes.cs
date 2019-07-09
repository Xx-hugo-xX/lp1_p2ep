using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto2aEpoca
{
    
    public enum OccupantTypes
    {
        /// <summary>
        /// Possible Cell Occupants
        /// </summary>
        empty = '.',
        player = '\u0398',
        enemy = '\u03A8',
        food = '\u03A9',
        weapon = '\u03EF',
        trap = '\u0416',
        map = '\u0524',
        exit
    };
}
