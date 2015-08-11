using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHMetroApp
{
    class MetroLink
    {
        //地铁路径类，对应站点间的连接线路
        #region 字段

            private MetroNode _mNode1;
            private MetroNode _mNode2;
            private MetroLine _mLine;
            private int _mWeight = 1;
            private int _mFlag;

        #endregion

        #region 属性

            //获取和设置与该路径关联的站点1
            public MetroNode Node1
            {
                get { return _mNode1; }
                set { _mNode1 = value; }
            }

            //获取和设置与该路径关联的站点2
            public MetroNode Node2
            {
                get { return _mNode2; }
                set { _mNode2 = value; }
            }

            //获取和设置与该路径隶属的总线路
            public MetroLine Line
            {
                get { return _mLine; }
                set { _mLine = value; }
            }
            
            //获取该路径的权重
            public int Weight
            {
                get { return _mWeight; }
            }

            //0与-1表示正反方向（相同两站只有一条路径），1，2...表示第一，第二...条路径
            public int Flag
            {
                get { return _mFlag; }
                set { _mFlag = value; }
            }

        #endregion

        #region 方法

            //构造函数
            public MetroLink(MetroNode node1, MetroNode node2, MetroLine line, int flag)
            {
                this.Node1 = node1;
                this.Node2 = node2;
                this.Line = line;
                this.Flag = flag;
            }

            //判断路径是否与规定站点直接关联
            public bool IsContainNode(MetroNode searchNode)
            {
                if (this.Node1 == searchNode || this.Node2 == searchNode)
                    return true;
                return false;
            }

        #endregion
    }
}
