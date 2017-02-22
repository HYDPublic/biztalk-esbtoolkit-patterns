using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.BizTalk.Component.Interop;

namespace Samples.Tests.Common
{
    public class ResourceTracker : IResourceTracker
    {
        public List<object> Resources;

        public ResourceTracker()
        {
            this.Resources = new List<object>();
        }
        #region IResourceTracker Members

        public void AddResource(object obj)
        {
            this.Resources.Add(obj);
        }

        public void DisposeAll()
        {
            foreach (object r in Resources)
            {
                IDisposable resource = r as IDisposable;
                if(null != resource)
                    resource.Dispose();
            }        
        }

        #endregion
    }
}
