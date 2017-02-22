using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.BizTalk.Component.Interop;

namespace Samples.Tests.Common
{
    public class PipelineStage
    {
        public static Guid DecoderId             = new Guid("9d0e4103-4cce-4536-83fa-4a5040674ad6");
        public static Guid DisassemblingParserId = new Guid("9d0e4105-4cce-4536-83fa-4a5040674ad6");
        public static Guid ValidateId            = new Guid("9d0e410d-4cce-4536-83fa-4a5040674ad6");
        public static Guid PartyResolverId       = new Guid("9d0e410e-4cce-4536-83fa-4a5040674ad6");
        public static Guid EncoderId             = new Guid("9d0e4108-4cce-4536-83fa-4a5040674ad6");
        public static Guid AssemblingSerializerId= new Guid("9d0e4107-4cce-4536-83fa-4a5040674ad6");
        public static Guid AnyId                 = new Guid("9d0e4101-4cce-4536-83fa-4a5040674ad6");
    }
    public class BasePipelineContext : IPipelineContext
    {
        ResourceTracker resourceTracker = null;
        Guid stageId;

        public BasePipelineContext()
        {
            resourceTracker = new ResourceTracker();
            stageId = PipelineStage.AnyId;
        }

        #region IPipelineContext Members

        public int ComponentIndex
        {
            get { throw new NotImplementedException(); }
        }

        public IDocumentSpec GetDocumentSpecByName(string DocSpecName)
        {
            throw new NotImplementedException();
        }

        public IDocumentSpec GetDocumentSpecByType(string DocType)
        {
            throw new NotImplementedException();
        }

        public Microsoft.BizTalk.Bam.EventObservation.EventStream GetEventStream()
        {
            throw new NotImplementedException();
        }

        public string GetGroupSigningCertificate()
        {
            throw new NotImplementedException();
        }

        public Microsoft.BizTalk.Message.Interop.IBaseMessageFactory GetMessageFactory()
        {
            return new BaseMessageFactory();
        }

        public Guid PipelineID
        {
            get { throw new NotImplementedException(); }
        }

        public string PipelineName
        {
            get { throw new NotImplementedException(); }
        }

        public IResourceTracker ResourceTracker
        {
            get { return this.resourceTracker; }
        }

        public Guid StageID
        {
            get { return stageId; }
        }

        public int StageIndex
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
