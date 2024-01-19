﻿using Book_Pipelines.Chapter_2.AbstractFactoryNM;
using Book_Pipelines.Chapter7.Chain_Of_Responsibility.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Pipelines.Chapter7.Observer
{
    public class IoTFactory: AbstractFactory<IIoTEventData>
    {
        public override Processor GetPipeline(BasicEvent basicEvent)
        {
            return basicEvent.Type switch
            {
                "TypeC" => PipelineDirector.BuildTypeCPipeline(),
                "TypeR" => PipelineDirector.BuildTypeCPipeline(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
