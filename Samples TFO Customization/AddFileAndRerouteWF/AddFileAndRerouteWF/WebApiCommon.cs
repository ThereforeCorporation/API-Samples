using System;
using System.Collections.Generic;
using System.Text;
using Therefore.WebAPI;

namespace AddFileAndRerouteWF
{
    public class WebApiCommon
    {
        WebApiClient _client;
        int _instanceNo;
        int _tokenNo;

        public WebApiCommon(WebApiClient client, int instanceNo, int tokenNo)
        {
            if (client == null || instanceNo <= 0 || tokenNo <= 0)
                throw new ArgumentException("Argument invalid or null.");

            _client = client;
            _instanceNo = instanceNo;
            _tokenNo = tokenNo;
        }

        public GetDocumentIndexDataResponse GetIndexData(int docNo)
        {
            if (docNo <= 0)
                throw new ArgumentException("Argument invalid.");

            return _client.SendRequest<GetDocumentIndexDataParams, GetDocumentIndexDataResponse>(new GetDocumentIndexDataParams() { DocNo = docNo }).Result;
        }

        public void RouteWFInstance(int taskNo, string info = "Routed by Azure function.")
        {
            if (taskNo <= 0)
                throw new ArgumentException("Argument invalid.");

            // instance needs to be claimed before routing
            ClaimWorkflowInstanceParams claimParam = new ClaimWorkflowInstanceParams() { InstanceNo = _instanceNo, TokenNo = _tokenNo };
            ClaimWorkflowInstanceResponse claimResp = _client.SendRequest<ClaimWorkflowInstanceParams, ClaimWorkflowInstanceResponse>(claimParam).Result;

            // routing to manual task
            FinishCurrentWorkflowTaskParams finishTaskParam = new FinishCurrentWorkflowTaskParams() { InstanceNo = _instanceNo, TokenNo = _tokenNo, NextTaskNo = taskNo, TextInformation = info };
            FinishCurrentWorkflowTaskResponse finishTaskResp = _client.SendRequest<FinishCurrentWorkflowTaskParams, FinishCurrentWorkflowTaskResponse>(finishTaskParam).Result;
        }

        public void AddStreamsToDoc(AddStreamsToDocumentParams addStreamParams)
        {
            if (addStreamParams == null || addStreamParams.ConversionOptions == null || addStreamParams.DocNo <= 0)
                throw new ArgumentException("Argument invalid.");

            AddStreamsToDocumentResponse addStreamResp = _client.SendRequest<AddStreamsToDocumentParams, AddStreamsToDocumentResponse>(addStreamParams).Result;
        }

        public GetDocumentResponse GetDocument(int docNo, bool isStreamsInfoAndDataNeeded)
        {
            if (docNo <= 0)
                throw new ArgumentException("Argument invalid.");
            return _client.SendRequest<GetDocumentParams, GetDocumentResponse>(new GetDocumentParams() { DocNo = docNo, IsStreamsInfoAndDataNeeded = isStreamsInfoAndDataNeeded }).Result;
        }

        public WSStreamInfo[] GetAllFilesStreamInfoFromDocument(int docNo)
        {
            var document = GetDocument(docNo, true);
            return document.StreamsInfo;
        }
    }
}
