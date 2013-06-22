using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Structure.Interface;

namespace KHGraphDB.Structure
{
    public class DBObject : IDBObject
    {

        #region private members

        protected String _khID;

        protected IDictionary<string, object> _Attributes;

        #endregion

        #region IDBObject

        public string KHID
        {
            get { return _khID; }
        }

        public IDictionary<string, object> Attributes
        {
            get { return _Attributes; }
        }

        public object this[string theKey]
        {
            get
            {
                return _Attributes[theKey];
            }
            set
            {
                _Attributes[theKey] = value;
            }
        }

        public bool RemoveAttribute(string theKey)
        {
            return _Attributes.Remove(theKey);
        }

        #endregion

        #region protected methods

        protected void InitDBObject()
        {
            InitDBObject(null);
        }

        protected void InitDBObject(IDictionary<string, object> attributes)
        {
            _khID = Guid.NewGuid().ToString();

            _Attributes = (attributes == null) ? new Dictionary<string, object>() : attributes;
        }

        #endregion

        #region overrides

        public override bool Equals(object obj)
        {
            var tmp = obj as DBObject;

            if (tmp != null)
            {
                return tmp.KHID.Equals(_khID);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _khID.GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("DBObject - UUID:{0} Type:{1}", _khID, this.GetType().Name);

            //list all attributes
            if (_Attributes.Count > 0)
            {
                sb.Append("Attributes -> ");

                foreach (var a in _Attributes)
                {
                    sb.AppendFormat("{0}:{1} ", a.Key, (a.Value is DBObject) ? ((DBObject)a.Value).KHID : a.Value);
                }
            }

            return sb.ToString();
        }

        #endregion




        
    }
}
