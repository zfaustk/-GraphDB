using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KHGraphDB.Structure.Interface;

namespace KHGraphDB.Algorithm
{
    public interface IAlgorithm
    {

        /// <summary>
        /// Begin of the algorithm , add Attribute key to store the reference to vertex
        /// </summary>
        void BeginAlgorithm(IGraph theGraph);

        /// <summary>
        /// End of the algorithm , remove Attribute key
        /// </summary>
        void EndAlgorithm(IGraph theGraph);

    }
}
