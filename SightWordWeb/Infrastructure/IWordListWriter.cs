﻿using SightWordWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SightWordWeb.Infrastructure
{
    public interface IWordListWriter 
    {

        void Save(WordList wordList);

    }
}
