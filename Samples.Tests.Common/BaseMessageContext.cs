using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.BizTalk.Message.Interop;

namespace Samples.Tests.Common
{
    
    public class BaseMessageContext : IBaseMessageContext, ICloneable
    {
        public Dictionary<string,Property> Properties
        {
            get;
            private set;
        }
        public BaseMessageContext()
        {
            this.Properties = new Dictionary<string, Property>();
        }
        public BaseMessageContext(Dictionary<string,Property> nvps)
        {
            this.Properties = nvps;
        }
        #region IBaseMessageContext Members

        public void AddPredicate(string strName, string strNameSpace, object obj)
        {
            throw new NotImplementedException();
        }

        public uint CountProperties
        {
            get { return (uint)Properties.Count; }
        }

        public ContextPropertyType GetPropertyType(string strName, string strNameSpace)
        {
            throw new NotImplementedException();
        }

        public bool IsPromoted(string strName, string strNameSpace)
        {
            string key = strNameSpace+strName;
            if (this.Properties.ContainsKey(key))
            {
                return this.Properties[key].IsPromoted;
            }
            return false;
        }

        public void Promote(string strName, string strNameSpace, object obj)
        {
            Write(strName, strNameSpace, obj, true);
        }

        public object Read(string strName, string strNamespace)
        {
            string key = strNamespace+strName;
            if (false == this.Properties.ContainsKey(key))
            {
                //string error = String.Format("Property {0} name {1} namespace does not exist", strName, strNamespace);
                //throw new InvalidOperationException(error);
                return null;
            }
            return this.Properties[key].Value;
        }

        public object ReadAt(int index, out string strName, out string strNamespace)
        {            
           KeyValuePair<string,Property> result = this.Properties.ElementAt(index);

           strNamespace = result.Value.Namespace;
           strName = result.Value.Name;         
           return result.Value.Value;
        }

        public void Write(string strName, string strNamespace, object obj)
        {
            Write(strName, strNamespace, obj, false);
        }
        private void Write(string strName, string strNamespace, object obj, bool isPromoted)
        {
            string key = strNamespace+strName;
            this.Properties.Remove(key);
            this.Properties.Add(key, 
                new Property() { IsPromoted = isPromoted, Name = strName, Namespace = strNamespace, Value = obj });
        }
        #endregion

        #region ICloneable Members

        public object Clone()
        {
            Dictionary<string, Property> result = new Dictionary<string, Property>(this.Properties.Count);
            foreach (var pair in this.Properties)
                result.Add(pair.Key, pair.Value);
            return new BaseMessageContext(result);
        }

        #endregion
    }
}
