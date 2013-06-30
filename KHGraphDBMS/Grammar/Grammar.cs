using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Helper;
using KHGraphDB.Structure;
using KHGraphDB.Structure.Interface;

namespace KHGraphDBMS.Grammar
{
    public class Grammar
    {
        /// <summary>
        /// 获取关联的图形数据库
        /// </summary>
        public IGraph Graph { get { return _graph; } }
        private IGraph _graph;

        /// <summary>
        /// 小帮手
        /// </summary>
        private GraphHelper gHelper;

        public Grammar(IGraph g)
        {
            _graph = g;
            gHelper = new GraphHelper(g);

        }

        public void Demo()
        {

            IVertex v1 = gHelper.AddVertex(new Dictionary<string, object>()
            {
                {"name","Peiming"} , {"age",20}
            });

            IVertex v2 = gHelper.AddVertex(new Dictionary<string, object>()
            {
                {"name","Yidong"}
            });

            gHelper.AddEdge(v1, v2, new Dictionary<string, object>()
            {
                {"distance",10}
            });
        }

        public void Exert(string str)
        {
            IVertex v = gHelper.AddVertex(new Dictionary<string, object>()
            {
                {"name","OKok"} , {"age",20}
            });
            
        }
        
    }
}
