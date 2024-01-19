﻿namespace Book_Pipelines.Chapter5.Decorator
{
    public class ReportPipeline : AbstractPipeline
    {
        private List<AbstractPipeline> pipelines;

        public ReportPipeline(List<AbstractPipeline> pipelines)
        {
            this.pipelines = pipelines;
        }

        public override void Process(IBasicEvent basicEvent)
        {
            pipelines.ForEach(x => x.Process(basicEvent));
        }
    }
}
