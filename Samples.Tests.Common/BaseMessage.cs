
using Microsoft.BizTalk.Message.Interop;
using System;
using System.Collections.Generic;

namespace Samples.Tests.Common
{
    public class BaseMessage : IBaseMessage, ICloneable
    {
        public IBaseMessagePart Body;
        public Dictionary<string, IBaseMessagePart> Parts;
        private BaseMessageContext context;
        private Guid messageID = new Guid() ;

        public BaseMessage()
        {
            messageID = Guid.NewGuid();
            context = new BaseMessageContext();
            Parts = new Dictionary<string, IBaseMessagePart>();
        }
      
        #region IBaseMessage Members

        public void AddPart(string partName, IBaseMessagePart part, bool bBody)
        {
            if (!bBody)
                this.Parts.Add(partName, part);
            else this.Body = part;
        }

        public IBaseMessagePart BodyPart
        {
            get { return this.Body; }
        }

        public string BodyPartName
        {
            get { return "body"; }
        }

        public IBaseMessageContext Context
        {
            get
            {
                return this.context;
            }
            set
            {
                this.context = value as BaseMessageContext;
            }
        }

        public System.Exception GetErrorInfo()
        {
            throw new System.NotImplementedException();
        }

        public IBaseMessagePart GetPart(string partName)
        {
            throw new System.NotImplementedException();
        }

        public IBaseMessagePart GetPartByIndex(int index, out string partName)
        {
            throw new System.NotImplementedException();
        }

        public void GetSize(out ulong lSize, out bool fImplemented)
        {
            throw new System.NotImplementedException();
        }

        public bool IsMutable
        {
            get { return false; }
        }

        public System.Guid MessageID
        {
            get { return messageID; }
            private set { messageID = value; }
        }

        public int PartCount
        {
            get { throw new System.NotImplementedException(); }
        }

        public void RemovePart(string partName)
        {
            throw new System.NotImplementedException();
        }

        public void SetErrorInfo(System.Exception errInfo)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            //BaseMessagePart part = this.BodyPart as BaseMessagePart;
            return new BaseMessage()
            {
                Context = this.context,
                Body = ((BaseMessagePart)this.Body).Clone() as BaseMessagePart,
            };
        }

        #endregion
    }
}
