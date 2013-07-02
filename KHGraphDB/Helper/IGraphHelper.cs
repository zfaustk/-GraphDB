﻿using System;
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
        IEdge AddEdge(IEdge e);
        /// <summary>
        /// 增加一条边
        /// </summary>
        /// <param name="vSource">起点</param>
        /// <param name="vTarget">终点</param>
        /// <param name="theAttributes">边的属性</param>
        /// <returns>添加成功时，返回该边，否则返回null</returns>
        IEdge AddEdge(IVertex vSource, IVertex vTarget, System.Collections.Generic.IDictionary<string, object> theAttributes = null);
        /// <summary>
        /// 增加一条边
        /// </summary>
        /// <param name="ID">ID，如果此ID以存在则不能添加</param>
        /// <param name="vSource">起点</param>
        /// <param name="vTarget">终点</param>
        /// <param name="theAttributes">边的属性</param>
        /// <returns>添加成功时，返回该边，否则返回null</returns>
        IEdge AddEdge(string ID, IVertex vSource, IVertex vTarget, System.Collections.Generic.IDictionary<string, object> theAttributes = null);
        /// <summary>
        /// 增加一个已有类型
        /// </summary>
        /// <param name="t">类型</param>
        /// <returns>添加成功时，返回该类型，否则返回null</returns>
        IType AddType(IType t);
        /// <summary>
        /// 增加一个类型
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="Name">名字</param>
        /// <param name="theAttributes">类型属性</param>
        /// <returns>添加成功时，返回该类型，否则返回null</returns>
        IType AddType(string ID, string Name, System.Collections.Generic.IDictionary<string, object> theAttributes = null);
        /// <summary>
        /// 增加一个类型
        /// </summary>
        /// <param name="Name">名字</param>
        /// <returns>添加成功时，返回该类型，否则返回null</returns>
        IType AddType(string Name);
        /// <summary>
        /// 添加一个已有节点(到类型)
        /// </summary>
        /// <param name="v">点</param>
        /// <param name="type">类型，为空时为添加离散节点</param>
        /// <returns>添加成功时，返回该点，否则返回null</returns>
        IVertex AddVertex(IVertex v, KHGraphDB.Structure.Type type = null);
        /// <summary>
        /// 添加一个节点
        /// </summary>
        /// <param name="theAttributes">属性</param>
        /// <param name="type">类型，为空时为添加离散节点</param>
        /// <returns>添加成功时，返回该点，否则返回null</returns>
        IVertex AddVertex(System.Collections.Generic.IDictionary<string, object> theAttributes, KHGraphDB.Structure.Type type = null);
        /// <summary>
        /// 添加一个节点
        /// </summary>
        /// <param name="theAttributes">属性</param>
        /// <param name="type">类型，为空时为添加离散节点</param>
        /// <returns>添加成功时，返回该点，否则返回null</returns>
        IVertex AddVertex(string ID, System.Collections.Generic.IDictionary<string, object> theAttributes, KHGraphDB.Structure.Type type = null);
        #endregion

        #region Remove
        bool RemoveVertex(IVertex v);
        bool RemoveVertex(string ID);
        bool RemoveEdge(IEdge e);
        bool RemoveEdge(string ID);
        bool RemoveType(IType t);
        bool RemoveType(string ID);
        bool RemoveTypeByName(string Name);
        #endregion

        #region select

        #region Collection
        IEnumerable<IEdge> Edges { get; }
        IEnumerable<IEdge> SelectEdges(string key, object value, IVertex vSource, IVertex vTarget, string orderbyKey = null, IEnumerable<IEdge> edges = null, Func<IEdge, bool> compare = null);
        IEnumerable<IEdge> SelectEdges(string key, object value, string orderbyKey = null, IEnumerable<IEdge> edges = null, Func<IEdge, object, bool> compare = null);
        IEnumerable<IEdge> SelectParallelEdges(IEdge edge, string orderbyKey = null, IEnumerable<IEdge> edges = null);
        IEnumerable<IEdge> SelectParallelEdges(IVertex vSource, IVertex vTarget, string orderbyKey = null, IEnumerable<IEdge> edges = null);

        IEnumerable<IType> Types { get; }
        IEnumerable<IType> SelectTypes(string key, object value, string orderbyKey = null, IEnumerable<IType> types = null, Func<IType, bool> compare = null);

        IEnumerable<IVertex> Verteics { get; }
        IEnumerable<IVertex> SelectVerteics(string key, object value, string orderbyKey = null, IEnumerable<IVertex> vertics = null);
        IEnumerable<IVertex> SelectVerteics(string key, object value, IType type, string orderbyKey = null, Func<IVertex, bool> compare = null);
        #endregion

        #region single
        IEdge SelectSingleEdge(string ID);
        IEdge SelectSingleEdge(string key, object value);
        IType SelectSingleType(string ID);
        IType SelectSingleType(string key, object value);
        IType SelectSingleTypeName(string Name);
        IVertex SelectSingleVertex(string ID);
        IVertex SelectSingleVertex(string key, object value);
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
