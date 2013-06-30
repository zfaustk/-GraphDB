using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KHGraphDB.Structure.Interface;

namespace KHGraphDB.Structure
{
    public class Edge : DBObject, IEdge
    {
        #region Private Attributes

        private IGraph _Graph;

        private IVertex _Source;

        private IVertex _Target;

        #endregion

        #region Constructors

        public Edge(IVertex theSource, IVertex theTarget)
            : this(null,theSource, theTarget, null)
        {
        }

        public Edge(string ID,IVertex theSource, IVertex theTarget)
            : this(ID, theSource, theTarget, null)
        {
        }

        public Edge(IVertex theSource, IVertex theTarget, IDictionary<string, object> attributes)
            : this(null, theSource, theTarget, attributes)
        {
        }

        public Edge(string ID,IVertex theSource, IVertex theTarget, IDictionary<string, object> attributes)
        {
            if (theSource == null)
            {
                throw new ArgumentException("source-vertex cannot be null");
            }
            if (theTarget == null)
            {
                throw new ArgumentException("target-vertex cannot be null");
            }

            InitDBObject(ID,attributes);

            _Source = theSource;
            _Target = theTarget;

        }

        #endregion

        #region Properties

        public IGraph Graph
        {
            get
            {
                return _Graph;
            }
            set
            {
                _Graph = value;
            }
        }

        public IVertex Source
        {
            get { return _Source; }
        }

        public IVertex Target
        {
            get { return _Target; }
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            var tmp = obj as Edge;

            if (tmp != null)
            {
                return tmp.KHID.Equals(_khID)
                    && tmp.Source.Equals(_Source)
                    && tmp.Target.Equals(_Target);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _khID.GetHashCode()
                + _Source.GetHashCode()
                + _Target.GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Edge - From:{0} To:{1} ", _Source.KHID, _Target.KHID);

            if (_Attributes.Count > 0)
            {
                sb.Append("Attributes -> ");
                foreach (var a in _Attributes)
                {
                    sb.AppendFormat("{0}:{1} ", a.Key, a.Value);
                }
            }

            return sb.ToString();
        }

        #endregion

    }
}
