﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Pipelines.Chapter_2.BuilderAbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract AbstractPipeline GetPipeline(BasicEvent basicEvent);
    }
}