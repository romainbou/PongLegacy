﻿using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    interface IAutoLoadable
    {
        void LoadContent(ContentManager content);
    }
}
