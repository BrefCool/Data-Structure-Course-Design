using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Xml;

namespace SHMetroApp
{
    public partial class MetroGraphView : UserControl
    {
    #region 字段
        
        private MetroGraph _Graph = new MetroGraph();
        private int _scrollX;
        private int _scrollY;
        private float _zoomScale = 1;
        private bool _editStatus = false;
        private MetroNode _clickNode;
        private MetroNode _startNode;
        private MetroNode _endNode;
        private MetroPath _shortestPath;
        private Point _mouseLastLocation = Point.Empty;
        private Point _mouseDownLocation = Point.Empty;

    #endregion

    #region 委托（用于自定义事件）
        
        public delegate void valueChangedHandler(object sender, EventArgs e);
        public event valueChangedHandler clickNodeChanged;
    
    #endregion

    #region 属性

        //获取地铁线路图
        public MetroGraph Graph
        {
            get { return _Graph; }
        }

        //获取水平滚动量
        public int scrollX
        {
            get { return _scrollX; }
            set 
            { 
                _scrollX = value;
                Invalidate();
            }
        }

        //获取竖直滚动量
        public int scrollY
        {
            get { return _scrollY; }
            set 
            {
                _scrollY = value;
                Invalidate();
            }
        }

        //获取缩放比例
        public float zoomScale
        {
            get { return _zoomScale; }
            set 
            { 
                _zoomScale = value;
                Invalidate();
            }
        }

        //获取线路图当前的状态（是否可编辑）
        public bool editStatus
        {
            get { return _editStatus; }
        }

        //获取或设置所点击站点（编辑模式使用)
        public MetroNode clickNode
        {
            get { return _clickNode; }
            set { _clickNode = value; }
        }

        //获取或设置起始站点
        public MetroNode startNode
        {
            get { return _startNode; }
            set { _startNode = value; }
        }

        //获取或设置目的站点
        public MetroNode endNode
        {
            get { return _endNode; }
            set { _endNode = value; }
        }

        //获取或设置最短路径
        public MetroPath shortestPath
        {
            get { return _shortestPath; }
            set { _shortestPath = value; }
        }

    #endregion

    #region 方法

        //构造函数
        public MetroGraphView()
        {
            InitializeComponent();

            //优化绘图
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        //切换线路图的编辑状态
        public void toggleEditStatus()
        {
            _editStatus ^= true;
        }

        //从数据文件中读取地铁线路图
        public void openGraph(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return;

            if (!System.IO.File.Exists(fileName))
                return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            var graph = xmlDoc.DocumentElement;
            this.scrollX = int.Parse(graph.Attributes["ScrollX"].Value);
            this.scrollY = int.Parse(graph.Attributes["ScrollY"].Value);
            this.zoomScale = float.Parse(graph.Attributes["ZoomScale"].Value);

            //读取总线路
            this.Graph.Lines.Clear();
            foreach (System.Xml.XmlNode lineNode in graph.SelectNodes("Lines/Line"))
            {
                this.Graph.Lines.Add(new MetroLine(lineNode.Attributes["Name"].Value, Color.FromArgb(int.Parse(lineNode.Attributes["Color"].Value))));
            }

            //读取站点
            this.Graph.Nodes.Clear();
            foreach (System.Xml.XmlNode nodeNode in graph.SelectNodes("Nodes/Node"))
            {
                this.Graph.Nodes.Add(new MetroNode(nodeNode.Attributes["Name"].Value,
                    int.Parse(nodeNode.Attributes["X"].Value), int.Parse(nodeNode.Attributes["Y"].Value)));
            }

            //读取路径
            foreach (System.Xml.XmlNode nodeNode in graph.SelectNodes("Nodes/Node"))
            {
                MetroNode node1 = this.Graph.Nodes.Find(delegate(MetroNode node)
                {
                    return node.Name == nodeNode.Attributes["Name"].Value;
                });

                foreach (System.Xml.XmlNode linkNode in nodeNode.SelectNodes("Link"))
                {
                    MetroNode node2 = this.Graph.Nodes.Find(delegate(MetroNode node)
                    {
                        return node.Name == linkNode.Attributes["To"].Value;
                    });

                    MetroLine line = this.Graph.Lines.Find(delegate(MetroLine l)
                    {
                        return l.Name == linkNode.Attributes["Line"].Value;
                    });

                    node1.Links.Add(new MetroLink(node1, node2, line, int.Parse(linkNode.Attributes["Flag"].Value)));
                }
            }

            Invalidate();
        }

        //保存地铁线路图
        public void saveGraph(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<?xml version=\"1.0\" encoding=\"gb2312\"?><MetroGraph/>");

            var graph = xmlDoc.DocumentElement;
            addAtrribute(graph, "ScrollX", this.scrollX.ToString());
            addAtrribute(graph, "ScrollY", this.scrollY.ToString());
            addAtrribute(graph, "ZoomScale", this.zoomScale.ToString());

            //保存总线路
            var lines = addChildNode(graph, "Lines");
            foreach (var line in this.Graph.Lines)
            {
                var lineNode = addChildNode(lines, "Line");
                addAtrribute(lineNode, "Name", line.Name);
                addAtrribute(lineNode, "Color", line.LineColor.ToArgb().ToString());
            }

            //保存站点
            var nodes = addChildNode(graph, "Nodes");
            foreach (var node in this.Graph.Nodes)
            {
                var nodeNode = addChildNode(nodes, "Node");
                addAtrribute(nodeNode, "Name", node.Name);
                addAtrribute(nodeNode, "X", node.X.ToString());
                addAtrribute(nodeNode, "Y", node.Y.ToString());

                //保存与站点相关路径
                foreach (var link in node.Links)
                {
                    var linkNode = addChildNode(nodeNode, "Link");
                    addAtrribute(linkNode, "To", (link.Node1.Name == node.Name) ? link.Node2.Name : link.Node1.Name);
                    addAtrribute(linkNode, "Line", link.Line.Name);
                    addAtrribute(linkNode, "Weight", link.Weight.ToString());
                    addAtrribute(linkNode, "Flag", link.Flag.ToString());
                }
            }

            xmlDoc.Save(fileName);
        }

        //添加xml节点
        private XmlNode addChildNode(XmlNode parentNode, string childNodeName)
        {
            var childNode = parentNode.OwnerDocument.CreateNode(XmlNodeType.Element, childNodeName, string.Empty);
            parentNode.AppendChild(childNode);
            return childNode;
        }

        //添加xml节点属性
        private XmlAttribute addAtrribute(XmlNode parentNode, string atrributeName, string value)
        {
            var attribute = parentNode.OwnerDocument.CreateAttribute(atrributeName);
            attribute.Value = value;
            parentNode.Attributes.Append(attribute);
            return attribute;
        }

        //获取点击的节点
        public MetroNode getNodeFromClickLocation(Point clickLocation)
        {
            Point newLocation = new Point((int)((clickLocation.X - this.scrollX) / this.zoomScale),
                (int)((clickLocation.Y - this.scrollY) / this.zoomScale));
            return this.Graph.Nodes.Find(n => getNodeArea(n).Contains(newLocation));
        }

        //获取每个节点的有效点击区域
        private Rectangle getNodeArea(MetroNode node)
        {
            int r = node.Links.Count > 2 ? 8 : 5;
            return new Rectangle(node.X - r, node.Y - r, 2 * r, 2 * r);
        }

        #region 绘图区域

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                //线路图的移动和缩放
                e.Graphics.TranslateTransform(this.scrollX, this.scrollY);
                e.Graphics.ScaleTransform(this.zoomScale, this.zoomScale);

                //绘制线路图
                paintGraph(e.Graphics, this.Graph);

                //绘制总线路标识
                paintLines(e.Graphics, this.Graph);
            }

            private void paintLines(Graphics g, MetroGraph Graph)
            {
                g.ResetTransform();
                int count = Graph.Lines.Count;

                if (count == 0)
                    return;

                Rectangle rc = new Rectangle(20, 20, 180, (count + 1) * 20);
                using (Brush brush = new SolidBrush(Color.White))
                {
                    g.FillRectangle(brush, rc);
                }
                g.DrawRectangle(Pens.Black, rc);

                int y = rc.Y + 20;
                foreach (MetroLine line in Graph.Lines)
                {
                    using (Pen pen = new Pen(line.LineColor, 8))
                    {
                        g.DrawLine(pen, rc.X + 20, y, rc.X + 100, y);
                    }

                    SizeF sf = g.MeasureString(line.Name, this.Font);
                    g.DrawString(line.Name, this.Font, Brushes.Black, rc.X + 110, y - sf.Height / 2);

                    y += 20;
                }
            }

            private void paintGraph(Graphics g, MetroGraph Graph)
            {
                //绘制路径
                foreach (var link in Graph.Links.Where(f => f.Flag >= 0))
                {
                    paintLink(g, link);
                }

                //绘制站点
                foreach (var node in Graph.Nodes)
                {
                    paintNode(g, node);
                }
            }

            private void paintLink(Graphics g, MetroLink Link)
            {
                Point p1 = new Point(Link.Node1.X, Link.Node1.Y);
                Point p2 = new Point(Link.Node2.X, Link.Node2.Y);

                using(Pen pen = new Pen(Link.Line.LineColor,5))
                {
                    pen.LineJoin = LineJoin.Round;
                    if (Link.Flag == 0)
                    {
                        g.DrawLine(pen, p1, p2);
                    }
                    else if (Link.Flag > 0)
                    {
                        float scale = (pen.Width / 2) / getDistance(p1, p2);

                        float angle = (float)(Math.PI / 2);
                        if (Link.Flag == 2) angle *= -1;

                        //平移线段
                        var pt3 = Rotate(p2, p1, angle, scale);
                        var pt4 = Rotate(p1, p2, -angle, scale);

                        g.DrawLine(pen, pt3, pt4); 
                    }
                }
                
            }

            private Point Rotate(Point v, Point o, float angle, float scale)
            {
                v.X -= o.X;
                v.Y -= o.Y;
                double rx = scale * Math.Cos(angle);
                double ry = scale * Math.Sin(angle);
                double x = o.X + v.X * rx - v.Y * ry;
                double y = o.Y + v.X * ry + v.Y * rx;
                return new Point((int)x, (int)y);
            }

            private float getDistance(Point p1, Point p2)
            {
                return (float)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
            }
            
            private void paintNode(Graphics g, MetroNode Node)
            {
                int count = Node.Links.Count;
                Color color = (count > 2 || count == 0) ? Color.Black : Node.Links[0].Line.LineColor;
                int r = count > 2 ? 8 : 5;
                Rectangle rc = new Rectangle(Node.X - r, Node.Y - r, 2 * r, 2 * r);
                g.FillEllipse(Brushes.White, rc);
                using (Pen pen = new Pen(color))
                {
                    g.DrawEllipse(pen, rc);
                }

                var sz = g.MeasureString(Node.Name, this.Font).ToSize();
                Point pt = new Point(Node.X - sz.Width / 2, Node.Y + (rc.Height >> 1) + 4);
                g.DrawString(Node.Name, Font, Brushes.Black, pt);
            } 
            
        #endregion

        #region 事件区域
            
            protected override void OnMouseDown(MouseEventArgs e)
            {
                _mouseDownLocation = e.Location;
                _mouseLastLocation = e.Location;
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                var node = getNodeFromClickLocation(e.Location);
                if (node != null)
                {
                    if (this.editStatus)
                    {
                        this.clickNode = node;
                        clickNodeChanged(this.clickNode, new EventArgs());
                        if (e.Button == MouseButtons.Right)
                        {
                            ContextMenuStrip cms = new ContextMenuStrip();
                            Bitmap bm = new Bitmap(Application.StartupPath + "\\delete.ico");
                            cms.Items.Add("删除站点", bm,new EventHandler(deleteNode));
                            cms.Show(this, e.X, e.Y);
                        }
                    }
                    else
                    {
                        if (this.startNode == null)
                            this.startNode = node;
                        else
                        {
                            this.endNode = node;
                        }
                    }
                }
                else
                {
                    if (this.editStatus)
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            ContextMenuStrip cms = new ContextMenuStrip();
                            cms.Items.Add("新建站点", null, new EventHandler(createNode));
                            cms.Items.Add("新建线路", null, new EventHandler(createLine));
                            cms.Show(this, e.X, e.Y);
                            _mouseLastLocation = e.Location;
                        }
                    }
                }

                Invalidate();
            }

            private void deleteNode(object sender, EventArgs e)
            {
                foreach (var link in this.clickNode.Links)
                {
                    MetroNode tmpNode = (link.Node1.Name == this.clickNode.Name) ? link.Node2 : link.Node1;
                    foreach (var tmplink in tmpNode.Links)
                    {
                        if (tmplink.Node1.Name == this.clickNode.Name || tmplink.Node2.Name == this.clickNode.Name)
                        {
                            tmpNode.deleteLink(tmplink);
                            break;
                        }
                    }
                }

                Graph.deleteNode(this.clickNode);
                Invalidate();
            }

            private void createNode(object sender, EventArgs e)
            {
                Point insertLocation = _mouseLastLocation;
                MetroNode newNode = new MetroNode("新的站点", (int)((insertLocation.X - this.scrollX) / this.zoomScale),
                    (int)((insertLocation.Y - scrollY) / this.zoomScale));

                Graph.addNode(newNode);
                Invalidate();
            }

            private void createLine(object sender, EventArgs e)
            {

            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                if (this.editStatus)
                {
                    var node = getNodeFromClickLocation(e.Location);
                    if (node != null)
                    {
                        this.Cursor = Cursors.SizeAll;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        
                        var lastNode = getNodeFromClickLocation(_mouseLastLocation);
                        if (e.Button == MouseButtons.Left)
                        {
                            if (lastNode == null)
                            {
                                this.scrollX += e.X - _mouseLastLocation.X;
                                this.scrollY += e.Y - _mouseLastLocation.Y;
                            }
                            else
                            {
                                lastNode.X = (int)((e.X - this.scrollX) / this.zoomScale);
                                lastNode.Y = (int)((e.Y - this.scrollY) / this.zoomScale);
                                clickNodeChanged(lastNode, new EventArgs());
                                Invalidate();
                            }
                            _mouseLastLocation = e.Location;
                        }
                    }
                }
                else
                {
                    var node = getNodeFromClickLocation(e.Location);
                    if (node != null)
                    {
                        this.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;

                        if (e.Button == MouseButtons.Left)
                        {
                            this.scrollX += e.X - _mouseLastLocation.X;
                            this.scrollY += e.Y - _mouseLastLocation.Y;
                            _mouseLastLocation = e.Location;
                        }
                    }
                }
            }

            protected override void OnMouseWheel(MouseEventArgs e)
            {
                this.zoomScale += (e.Delta > 0 ? 0.1f : -0.1f);
            }
            
        #endregion
    #endregion
    }
}
