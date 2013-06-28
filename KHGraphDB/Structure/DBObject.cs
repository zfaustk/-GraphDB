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
        #region EventHandler
        public event ObjectAttributeGhangeEventHandler OnAttributeGhange = new ObjectAttributeGhangeEventHandler(AttributeGhange);
        private static void AttributeGhange(IDBObject sender) { ; }
        #endregion


        #region private members

        protected String _khID;

        protected IDictionary<string, object> _Attributes;

        protected IDictionary<string, object> _AlgorithmObj;

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
                if (theKey == null) return null;
                return _Attributes.ContainsKey(theKey)? _Attributes[theKey] : null;
            }
            set
            {
                if (theKey == null) return;
                _Attributes[theKey] = value;
                OnAttributeGhange(this);
            }
        }

        public bool RemoveAttribute(string theKey)
        {

            if(_Attributes.ContainsKey(theKey)){
                OnAttributeGhange(this);
                return _Attributes.Remove(theKey);
            }
            return false;
        }

        #endregion

        #region protected methods

        protected void InitDBObject()
        {
            InitDBObject(null,null);
        }

        protected void InitDBObject(string ID)
        {
            InitDBObject(ID, null);
        }

        protected void InitDBObject(IDictionary<string, object> attributes)
        {
            InitDBObject(null, attributes);
        }

        protected void InitDBObject(string ID,IDictionary<string, object> attributes)
        {
            _khID = (ID == null)? Guid.NewGuid().ToString() : ID;
            _Attributes = (attributes == null) ?
                new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase) :
                new Dictionary<string, object>(attributes,StringComparer.OrdinalIgnoreCase);
            _AlgorithmObj = new Dictionary<string, object>();
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
            sb.AppendFormat("DBObject - KHID:{0} Type:{1}", _khID, this.GetType().Name);

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

        #region AlgorithmObj

        public void SetAlgorithmObj(string Key, object value)
        {
            _AlgorithmObj[Key] = value;
        }

        public object GetAlgorithmObj(string Key)
        {
            return _AlgorithmObj.ContainsKey(Key) ? _AlgorithmObj[Key] : null;
        }

        public bool RemoveAlgorithmObj(string Key)
        {
            if (_AlgorithmObj.ContainsKey(Key))
                return _AlgorithmObj.Remove(Key);
            return false;
        }

        public IDictionary<string, object> AlgorithmObjs
        {
            get { return _AlgorithmObj; }
        }

        #endregion

        #region Other
        public virtual string AttributesToString()
        {
            String s = "";
            foreach (var key in _Attributes.Keys)
            {
                if (_Attributes[key] != null)
                    s += key + " : " + _Attributes[key].ToString() + " \n";
                else
                    s += key + "* \n";
            }
            return s;
        }
        #endregion




        
    }
}
