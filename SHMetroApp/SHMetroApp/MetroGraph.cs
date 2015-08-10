using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHMetroApp
{
    class MetroGraph
    {
        //地铁线路图类
        #region 字段

            private List<MetroNode> _mNodes = new List<MetroNode>();
            private List<MetroLine> _mLines = new List<MetroLine>();

        #endregion

        #region 属性

            //获取图的点集
            public List<MetroNode> Nodes
            {
                get { return _mNodes; }
            }
            
            //获取图的边集
            public IEnumerable<MetroLink> Links
            {
                get
                {
                    foreach (var node in this.Nodes)
                    {
                        foreach (var link in node.Links)
                        {
                            yield return link;
                        }
                    }
                }
            }

            //获取图的总线路集合
            public List<MetroLine> Lines
            {
                get { return _mLines; }
            }

        #endregion

        #region 方法
            
            //添加站点
            public bool addNode(MetroNode newNode)
            {
                try
                {
                    _mNodes.Add(newNode);
                }
                catch (System.Exception ex)
                {
                    return false;
                }
                return true;
            }

            //删除站点
            public bool deleteNode(MetroNode killNode)
            {
                try
                {
                    _mNodes.Remove(killNode);
                }
                catch (System.Exception ex)
                {
                    return false;
                }
                return true;
            }

            //添加总路线
            public bool addLine(MetroLine newLine)
            {
                try
                {
                    _mLines.Add(newLine);
                }
                catch (System.Exception ex)
                {
                    return false;
                }
                return true;
            }

            //删除总路线
            public bool deleteLine(MetroLine killLine)
            {
                try
                {
                    _mLines.Remove(killLine);
                }
                catch (System.Exception ex)
                {
                    return false;
                }
                return true;
            }
            
        #endregion
    }
}
