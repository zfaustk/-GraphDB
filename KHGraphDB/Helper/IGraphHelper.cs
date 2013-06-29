using System;
using System.Collections.Generic;
using KHGraphDB.Structure.Interface;
namespace KHGraphDB.Helper
{
    interface IGraphHelper
    {
        #region Add
        /// <summary>
        /// 增加一条已有边
        /// </summary>
        /// <param name="e">一条边</param>
        /// <returns>添加成功时，返回该边，否则返回null</returns>
        KHGraphDB.Structure.Interface.IEdge AddEdge(KHGraphDB.Structure.Interface.IEdge e);
        /// <summary>
        /// 增加一条边
        /// </summary>
        /// <param name="vSource">起点</param>
        /// <param name="vTarget">终点</param>
        /// <param name="theAttributes">边的属性</param>
        /// <returns>添加成功时，返回该边，否则返回null</returns>
        KHGraphDB.Structure.Interface.IEdge AddEdge(KHGraphDB.Structure.Interface.IVertex vSource, KHGraphDB.Structure.Interface.IVertex vTarget, System.Collections.Generic.IDictionary<string, object> theAttributes = null);
        /// <summary>
        /// 增加一条边
        /// </summary>
        /// <param name="ID">ID，如果此ID以存在则不能添加</param>
        /// <param name="vSource">起点</param>
        /// <param name="vTarget">终点</param>
        /// <param name="theAttributes">边的属性</param>
        /// <returns>添加成功时，返回该边，否则返回null</returns>
        KHGraphDB.Structure.Interface.IEdge AddEdge(string ID, KHGraphDB.Structure.Interface.IVertex vSource, KHGraphDB.Structure.Interface.IVertex vTarget, System.Collections.Generic.IDictionary<string, object> theAttributes = null);
        /// <summary>
        /// 增加一个已有类型
        /// </summary>
        /// <param name="t">类型</param>
        /// <returns>添加成功时，返回该类型，否则返回null</returns>
        KHGraphDB.Structure.Interface.IType AddType(KHGraphDB.Structure.Interface.IType t);
        /// <summary>
        /// 增加一个类型
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="Name">名字</param>
        /// <param name="theAttributes">类型属性</param>
        /// <returns>添加成功时，返回该类型，否则返回null</returns>
        KHGraphDB.Structure.Interface.IType AddType(string ID, string Name, System.Collections.Generic.IDictionary<string, object> theAttributes = null);
        /// <summary>
        /// 增加一个类型
        /// </summary>
        /// <param name="Name">名字</param>
        /// <returns>添加成功时，返回该类型，否则返回null</returns>
        KHGraphDB.Structure.Interface.IType AddType(string Name);
        /// <summary>
        /// 添加一个已有节点(到类型)
        /// </summary>
        /// <param name="v">点</param>
        /// <param name="type">类型，为空时为添加离散节点</param>
        /// <returns>添加成功时，返回该点，否则返回null</returns>
        KHGraphDB.Structure.Interface.IVertex AddVertex(KHGraphDB.Structure.Interface.IVertex v, KHGraphDB.Structure.Type type = null);
        /// <summary>
        /// 添加一个节点
        /// </summary>
        /// <param name="theAttributes">属性</param>
        /// <param name="type">类型，为空时为添加离散节点</param>
        /// <returns>添加成功时，返回该点，否则返回null</returns>
        KHGraphDB.Structure.Interface.IVertex AddVertex(System.Collections.Generic.IDictionary<string, object> theAttributes, KHGraphDB.Structure.Type type = null);
        /// <summary>
        /// 添加一个节点
        /// </summary>
        /// <param name="theAttributes">属性</param>
        /// <param name="type">类型，为空时为添加离散节点</param>
        /// <returns>添加成功时，返回该点，否则返回null</returns>
        KHGraphDB.Structure.Interface.IVertex AddVertex(string ID, System.Collections.Generic.IDictionary<string, object> theAttributes, KHGraphDB.Structure.Type type = null);
        #endregion

        #region Remove
        bool RemoveEdge(KHGraphDB.Structure.Interface.IEdge e);
        bool RemoveEdge(string ID);
        bool RemoveType(KHGraphDB.Structure.Interface.IType t);
        bool RemoveType(string ID);
        bool RemoveVertex(KHGraphDB.Structure.Interface.IVertex v);
        bool RemoveVertex(string ID);
        #endregion

        #region select

        #region Collection
        System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IEdge> SelectEdges(string key, object value, KHGraphDB.Structure.Interface.IVertex vSource, KHGraphDB.Structure.Interface.IVertex vTarget, string orderbyKey = null, System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IEdge> edges = null);
        System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IEdge> SelectEdges(string key, object value, string orderbyKey = null, System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IEdge> edges = null);
        System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IEdge> SelectParallelEdges(KHGraphDB.Structure.Interface.IEdge edge, string orderbyKey = null, System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IEdge> edges = null);
        System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IEdge> SelectParallelEdges(KHGraphDB.Structure.Interface.IVertex vSource, KHGraphDB.Structure.Interface.IVertex vTarget, string orderbyKey = null, System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IEdge> edges = null);
        System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IType> SelectTypes(string key, object value, string orderbyKey = null, System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IType> types = null);
        System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IVertex> SelectVerteics(string key, object value, KHGraphDB.Structure.Interface.IType type, string orderbyKey = null);
        System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IVertex> SelectVerteics(string key, object value, string orderbyKey = null, System.Collections.Generic.IEnumerable<KHGraphDB.Structure.Interface.IVertex> vertics = null);
        #endregion

        #region single
        KHGraphDB.Structure.Interface.IEdge SelectSingleEdge(string ID);
        KHGraphDB.Structure.Interface.IEdge SelectSingleEdge(string key, object value);
        KHGraphDB.Structure.Interface.IType SelectSingleType(string ID);
        KHGraphDB.Structure.Interface.IType SelectSingleType(string key, object value);
        KHGraphDB.Structure.Interface.IType SelectSingleTypeName(string Name);
        KHGraphDB.Structure.Interface.IVertex SelectSingleVertex(string ID);
        KHGraphDB.Structure.Interface.IVertex SelectSingleVertex(string key, object value);
        #endregion

        #endregion

        #region Algorithm

        /// <summary>
        /// 找到两个节点之间的一条路径
        /// </summary>
        /// <param name="vSource">起始点</param>
        /// <param name="vTarget">终点</param>
        /// <returns>路径中点的集合</returns>
        IEnumerable<IVertex> FindPathVertex(IVertex vSource, IVertex vTarget);

        /// <summary>
        /// 找到两个节点之间的一条路径,路径上的边具有某种标志
        /// </summary>
        /// <param name="vSource">起始点</param>
        /// <param name="vTarget">终点</param>
        /// <param name="AttrKey">边所应该具有的标志</param>
        /// <returns>路径中点的集合</returns>
        IEnumerable<IVertex> FindPathVertexAttrExist(IVertex vSource, IVertex vTarget, string AttrKey);

        /// <summary>
        /// 找到两个节点之间的一条路径,路径上的边的某种标志应该有某值
        /// </summary>
        /// <param name="vSource">起始点</param>
        /// <param name="vTarget">终点</param>
        /// <param name="AttrKey">边所应该具有的标志</param>
        /// <param name="value">该标志所对应的值</param>
        /// <returns>路径中点的集合</returns>
        IEnumerable<IVertex> FindPathVertexAttrExist(IVertex vSource, IVertex vTarget, string AttrKey, object value);

        /// <summary>
        /// 找到两个节点之间的一条路径,应用自定义的适配函数
        /// </summary>
        /// <param name="vSource">起始点</param>
        /// <param name="vTarget">终点</param>
        /// <param name="Adapter">适配函数</param>
        /// <returns>路径中点的集合</returns>
        IEnumerable<IVertex> FindPathVertexAdapt(IVertex vSource, IVertex vTarget, Func<IVertex, bool> Adapter);
        #endregion

    }
}
