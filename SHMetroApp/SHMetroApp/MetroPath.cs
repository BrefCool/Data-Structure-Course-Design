using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHMetroApp
{
    public class MetroPath
    {
        #region 字段

            private MetroNode _startNode;
            private MetroNode _endNode;
            private int _totalWeight;
            private List<MetroLink> _links = new List<MetroLink>();
            
        #endregion

        #region 属性

            //获取和设置最短路径的起始站点
            public MetroNode startNode
            {
                get { return _startNode; }
                set { _startNode = value; }
            }

            //获取和设置最短路径的目的站点
            public MetroNode endNode
            {
                get { return _endNode; }
                set { _endNode = value; }
            }

            //获取和设置当前最短路径的总权值
            public int totalWeight
            {
                get { return _totalWeight; }
                set { _totalWeight = value; }
            }
            
            //获取最短路径中的所有线段
            public List<MetroLink> links
            {
                get { return _links; }
            }
            
        #endregion

        #region 方法

            public MetroPath(MetroNode start, MetroNode end,int total)
            {
                startNode = start;
                endNode = end;
                totalWeight = total;
            }

            public void changeLinks(MetroPath path)
            {
                this.links.Clear();
                this.links.AddRange(path.links);
            }
            
        #endregion
    }
}
