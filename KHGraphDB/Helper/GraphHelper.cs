using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Structure;
using KHGraphDB.Structure.Interface;

namespace KHGraphDB.Helper
{
    public class GraphHelper
    {
        /// <summary>
        /// 获取和设置相关联的图
        /// </summary>
        IGraph Graph { get { return _Graph; } set { _Graph = value; } }
        IGraph _Graph;

        public GraphHelper(IGraph g)
        {
            Graph = g;
        }

        public IVertex AddVertex(string ID, IDictionary<string, object> theAttributes, KHGraphDB.Structure.Type type = null)
        {
            IVertex v = Graph.Vertices.SingleOrDefault(m => m.KHID == ID);
            if (v == null)
            {
                v = new Vertex(ID, theAttributes);
                Graph.AddVertex(v, type);
            }
            else
            {
                foreach (var key in theAttributes.Keys)
                {
                    v[key] = theAttributes[key];
                }
                if(type != null)
                    type.AddVertex(v);
            }
            return v;
        }

        public bool RemoveVertex(string ID)
        {
            IVertex v = Graph.Vertices.SingleOrDefault(m => m.KHID == ID);
            return Graph.RemoveVertex(v);
        }

        public IVertex SelectVerteics(string ID)
        {
            return Graph.Vertices.SingleOrDefault(m => m.KHID == ID);
        }

        public IEnumerable<IVertex> SelectVerteics(string key, object value, string orderbyKey = null, IEnumerable<IVertex> vertics = null)
        {
            if (null == vertics)
                vertics = Graph.Vertices;
            return from v in vertics
                   where v[key] == value
                   orderby (orderbyKey==null)?null:v[orderbyKey]
                   select v;
        }

    }
}
