using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.BizTalk.Message.Interop;
using System.IO;

namespace Samples.Tests.Common
{
    public class BaseMessagePart: IBaseMessagePart
    {
        private Stream bodyStream = null;
        private string charset = null;
        private string contentType = null;
        private Guid partID;

        public BaseMessagePart()
        {
            this.partID = Guid.NewGuid();
        }

        #region IBaseMessagePart Members

        public string Charset
        {
            get
            {
                return charset;
            }
            set
            {
                charset = value;
            }
        }
        public string ContentType
        {
            get
            {
                return contentType;
            }
            set
            {
                contentType = value;
            }
        }
        public System.IO.Stream Data
        {
            get
            {
                //if (null != bodyStream)
                //{
                //    bodyStream.Seek(0, SeekOrigin.Begin);
                //}
                return this.bodyStream;
            }
            set
            {
                bodyStream = value;
            }
        }

        public System.IO.Stream GetOriginalDataStream()
        {
            return CloneStream();
        }

        public void GetSize(out ulong lSize, out bool fImplemented)
        {
            throw new NotImplementedException();
        }

        public bool IsMutable
        {
            get { return false; }
        }

        public Guid PartID
        {
            get { return partID; }
        }

        public IBasePropertyBag PartProperties
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICloneable Members

        private Stream CloneStream()
        {
            MemoryStream cloneStream = new MemoryStream();
            int read = 0;
            int offset = 0;
            byte[] buffer = new byte[4096];
            this.bodyStream.Seek(0L, SeekOrigin.Begin);
            do{
                read = this.bodyStream.Read(buffer,offset,4096);
                cloneStream.Write(buffer, offset, read);
                offset += read;
            }while(read < this.bodyStream.Length);
            cloneStream.Seek(0L, SeekOrigin.Begin);
            return cloneStream;
        }

        public object Clone()
        {
            BaseMessagePart clone = new BaseMessagePart(){
            Data = this.CloneStream(),
            ContentType = this.ContentType,
            Charset = this.Charset
            };
            return clone;
        }

        #endregion
    }
}
