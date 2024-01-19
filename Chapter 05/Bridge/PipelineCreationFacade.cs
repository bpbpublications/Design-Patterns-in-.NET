﻿using Book_Pipelines.Chapter5.Bridge.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Pipelines.Chapter5.Bridge
{
    public static class PipelineCreationFacade
    {
        private static Configuration config = Configuration.Instance;
        private static FileLogger notificationClient = new FileLogger();
        public static AbstractPipeline BuildFileUploadPipeline(bool shouldBeFileProcessed, bool shouldEventBeStored, bool shouldSaveMetadata,
            ICommunicationClient<UploadFileInfo, int> fileUploadClient, ICommunicationClient<string, byte[]> fileDownloadClient,
            ICommunicationClient<string, string> searchApiClient, ICommunicationClient<string, string> storeApiClient
            )
        {
            var typeAPipelineBuilder = new FilePipelineBuilder<FileUploadPipeline>();
            return BuildExceptionHandlingPipeline(typeAPipelineBuilder.
                ShouldBeFilePreprocessed(shouldBeFileProcessed).
                ShouldBeEventStored(shouldEventBeStored).
                ShouldSaveMetadata(shouldSaveMetadata).
                SetUploadClient(fileUploadClient).
                SetDownloadClient(fileDownloadClient).
                SetSearchApiClient(searchApiClient).
                SetStoreApiClient(storeApiClient).
                Build());
        }
        public static AbstractPipeline BuildIoTPipeline(bool shouldSaveMetadata, ICommunicationClient<IoTData, string> apiClient)
        {
            var typeCPipelineBuilder = new IoTPipelineBuilder<IoTPipeline>();
            return BuildExceptionHandlingPipeline(typeCPipelineBuilder.
                ShouldSaveMetadata(shouldSaveMetadata).
                SetTargetApiClient(apiClient).
                Build());
        }

        public static AbstractPipeline BuildReportPipeline(List<AbstractPipeline> pipelines)
        {
            return BuildExceptionHandlingPipeline(new ReportPipeline(pipelines));
        }
        private static AbstractPipeline BuildExceptionHandlingPipeline(AbstractPipeline internalPipeline)
        {
            var exceptionPipelineBuilder = new ExceptionHandlingPipelineBuilder<ExceptionHandlingPipeline>();
            return exceptionPipelineBuilder.
                SetLoggingClient(new FileLogger()).
                SetInternalPipeline(internalPipeline).
                Build();
        }
    }
}
