using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KHGraphDB.Structure;

namespace KHGraphDB.Helper
{
    public class GraphReader
    {
        /// <summary>
        /// 获取Reader所绑定的图
        /// </summary>
        public Graph Graph { get { return _graph ; } }
        private Graph _graph;

        /// <summary>
        /// 获取和设置数据库存储的位置
        /// </summary>
        public String Path { get; set; }

        public GraphReader(Graph g)
        {
            _graph = g;
        }

        bool Read(bool Create)
        {
            if (File.Exists(Path))
            {
                using (StreamReader sr = File.OpenText(Path))
                {
                    //
                    return true;
                }
            }
            else
            {
                if (Create)
                {
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

    }
}
