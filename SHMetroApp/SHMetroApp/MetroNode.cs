using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHMetroApp
{
    class MetroNode
    {
        //地铁站点类
        #region 字段
 
            private string _mName = "";
            private int _mX;
            private int _mY;
            private List<MetroLink> _mLinks = new List<MetroLink>();        
        
        #endregion

        #region 属性

            //获取与设置站点名字
            public string Name
            {
                get { return _mName; }
                set { _mName = value; }
            }

            //获取与设置站点在图中X轴数值
            public int X
            {
                get { return _mX; }
                set { _mX = value; }
            }

            //获取与设置站点在图中Y轴数值
            public int Y
            {
                get { return _mY; }
                set { _mY = value; }
            }

            //获取与该站点关联的路线集合
            public List<MetroLink> Links
            {
                get { return _mLinks; }
            }
        #endregion

        #region 方法

            //构造函数
            public MetroNode(string newName, int x, int y)
            {
                this.Name = newName;
                this.X = x;
                this.Y = y;
            }

            //添加与该站点关联的路线
            public bool addLink (MetroLink newLink)
            {
                try
                {
                    _mLinks.Add(newLink);
                }
                catch (System.Exception ex)
                {
                    return false;
                }
                return true;
            }

            //删除与该站点关联的路线
            public bool deleteLink(MetroLink killLink)
            {
                try
                {
                    _mLinks.Remove(killLink);
                }
                catch (System.Exception ex)
                {
                    return false;
                }
                return true;
            }

            //重载toString()
            public override string ToString()
            {
                return this.Name;
            }

        #endregion
    }
}
