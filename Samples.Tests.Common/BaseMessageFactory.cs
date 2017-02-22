using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.BizTalk.Message.Interop;
namespace Samples.Tests.Common
{
    public class BaseMessageFactory : IBaseMessageFactory
    {
        #region IBaseMessageFactory Members

        public IBaseMessage CreateMessage()
        {
            return new BaseMessage();
        }

        public IBaseMessageContext CreateMessageContext()
        {
            return new BaseMessageContext();
        }

        public IBaseMessagePart CreateMessagePart()
        {
            return new BaseMessagePart();
        }

        public IBasePropertyBag CreatePropertyBag()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
