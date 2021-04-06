package homework2;

import java.util.*;
import java.util.List;
import java.awt.*;
import java.awt.event.*;
import java.awt.geom.Line2D;

import javax.swing.*;

public class GraphEditor extends JFrame {	
    int width=50;
    int height=50;
    List<Node> nodes;
    List<Edge> edges;
    
    int extraEdgeWidth = 14;
    int extraEdgeHeight = 20;
    int defaultEdgeWidth = 20;
    int heightCorrection = 4;
    
    int edgeXCorrection = 7;
    int edgeYCorrection = 25;
    
    Node selectedNode = null;
    Edge selectedEdge = null;
    
    public GraphEditor(String name, int frameWidth, int frameHeight) {
    	this.setTitle(name);
    	this.setSize(1000,700);
    	this.setLocation(300,100);
    	this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    	nodes = new LinkedList<Node>();
    	edges = new LinkedList<Edge>();
    }
    
    public void addNode(String key, String value, int x, int y) { 
    	nodes.add(new Node(key, value, x, y));
    	this.repaint();
    }
    
    public void addEdge(String key, String value, Node node1, Node node2) {
    	if(node1 != node2) {
    		edges.add(new Edge(key, value, node1, node2));
    		this.repaint();
    	}
    }
        
    public boolean SelectComponent( int x, int y) {
    	Graphics g = this.getGraphics();
		FontMetrics f = g.getFontMetrics();
    	boolean nodeFound = false;
    	boolean edgeFound = false;
    	for (Node n : nodes) {
    		String nodeInfo = n.key+", "+n.value;
    		int nodeWidth = Math.max(width, f.stringWidth(nodeInfo)+width/2);
    		if(CalculateDistance2Points(x, y, n.x-nodeWidth/2, n.y-height/2)<nodeWidth) {
    			selectedNode = n;
    			selectedEdge = null;
    	    	nodeFound = true;
    			this.repaint();
    		}
    	}
    	if(nodeFound == false) {
    		for(Edge e : edges) {
    			String edgeInfo = e.key+", "+e.value;
    			int edgeWidth = Math.max(20, f.stringWidth(edgeInfo));
        		int eX = (e.node1.x + e.node2.x) /2;
        		int eY = (e.node1.y + e.node2.y) /2;
        		if(CalculateDistance2Points(x, y, eX - (edgeWidth+edgeXCorrection), eY - edgeYCorrection)<edgeWidth) {
        			selectedEdge = e;
        			selectedNode = null;
        	    	edgeFound= true;
        			this.repaint();
        		}
    		}
    	}
    	return edgeFound || nodeFound;
    }
    
    public boolean IsSelected() {
    	return nodes.contains(selectedNode) || edges.contains(selectedEdge);
    }
    
    public boolean NodeIsSelected() {
    	return nodes.contains(selectedNode);
    }
    
    public void DeselectAll() {
    	selectedNode = null;
    	selectedEdge = null;
    	this.repaint();
    }
    
    
    public void MoveSelected(int x, int y) {
    	selectedNode.x = x;
    	selectedNode.y = y;
    	this.repaint();
    }
    
    public boolean NodeFound(int x, int y) {
    	Graphics g = this.getGraphics();
		FontMetrics f = g.getFontMetrics();
    	boolean nodeFound = false;
    	for (Node n : nodes) {
    		String nodeInfo = n.key+", "+n.value;
    		int nodeWidth = Math.max(width, f.stringWidth(nodeInfo)+width/2);
    		if(CalculateDistance2Points(x, y, n.x-nodeWidth/2, n.y-height/2)<nodeWidth) {
    	    	nodeFound = true;
    		}
    	}
    	return nodeFound;
    }
    
    public Node GetSecondNode(int x, int y) {
    	Graphics g = this.getGraphics();
		FontMetrics f = g.getFontMetrics();
    	Node node = null;
    	for (Node n : nodes) {
    		String nodeInfo = n.key+", "+n.value;
    		int nodeWidth = Math.max(width, f.stringWidth(nodeInfo)+width/2);
    		if(CalculateDistance2Points(x, y, n.x-nodeWidth/2, n.y-height/2)<nodeWidth) {
    	    	node = n;
    		}
    	}
    	return node;
    }
    
    public boolean EdgeBetween(Node n1, Node n2) {
    	boolean hasEdge = false;
    	for(Edge e: edges) {
    		if((e.node1 == n1 && e.node2 == n2) || (e.node1 == n2 && e.node2 == n1)){
    			hasEdge = true;
    		}
    	}
    	return hasEdge;
    }
    
    public void DeleteSelectedNode() {
    	List<Edge> toRemove = new LinkedList<Edge>();
    	for (Edge e : edges) {
    	  if (e.node1 == selectedNode || e.node2 == selectedNode) {
    	    toRemove.add(e);
    	  }
    	}
    	edges.removeAll(toRemove);
    	nodes.remove(selectedNode);
    	selectedNode = null;
    	this.repaint();
    }
    
    public void DeleteSelectedEdge() {
    	edges.remove(selectedEdge);
    	selectedEdge = null;
    	this.repaint();
    }
    
    public void EditNode(String key, String value) {
    	if(!key.isEmpty()) {
    		selectedNode.key = key;
    	}
    	if(!value.isEmpty()) {
    		selectedNode.value = value;
    	}
    	this.repaint();
    }
    
    public void EditEdge(String key, String value) {
    	if(!key.isEmpty()) {
    		selectedEdge.key = key;
    	}
    	if(!value.isEmpty()) {
    		selectedEdge.value = value;
    	}
    	this.repaint();
    }
    
    public void paint(Graphics g) {
    	this.paintComponents(this.getGraphics());
    	FontMetrics f = g.getFontMetrics();
    	int nodeHeight = Math.max(height, f.getHeight());
    	g.setFont(new Font("default", Font.BOLD, 12));
    	Graphics2D g2d = (Graphics2D) g;
    	g2d.setStroke(new BasicStroke(3));

    	g.setColor(Color.black);
    	for (Edge e : edges) {
    		String edgeInfo = e.key+", "+e.value;
    		int edgeWidth = Math.max(defaultEdgeWidth, f.stringWidth(edgeInfo));
    		int eX = (e.node1.x + e.node2.x) /2;
    		int eY = (e.node1.y + e.node2.y) /2;
    		g.drawLine(e.node1.x, e.node1.y, e.node2.x, e.node2.y);
    		if(e == selectedEdge) {
        		g.setColor(Color.orange);
    		}else {
        		g.setColor(Color.white);
    		}
    		g.fillRect(eX-edgeWidth/2-extraEdgeWidth/2, eY-extraEdgeHeight/2, edgeWidth+extraEdgeWidth, extraEdgeHeight);
    		g.setColor(Color.black);
    		g.drawString(edgeInfo, eX-edgeWidth/2, eY+f.getHeight()/2-heightCorrection);
    	}

    	for (Node n : nodes) {
    		String nodeInfo = n.key+", "+n.value;
    		int nodeWidth = Math.max(width, f.stringWidth(nodeInfo)+width/2);
    		if(n == selectedNode) {
        		g.setColor(Color.orange);
    		}else {
        		g.setColor(Color.white);
    		}
    		g.fillOval(n.x-nodeWidth/2, n.y-nodeHeight/2, 
    				nodeWidth, nodeHeight);
    		g.setColor(Color.black);
    		g.drawOval(n.x-nodeWidth/2, n.y-nodeHeight/2, 
	    		nodeWidth, nodeHeight);
    		g.drawString(nodeInfo, n.x-f.stringWidth(nodeInfo)/2,
    				n.y+f.getHeight()/2-heightCorrection);
    	}
    }
    
    public double CalculateDistance2Points(int x1, int y1, int x2, int y2) {
    	int xDif = Math.abs(x2 - x1);
    	int yDif = Math.abs(y2 - y1);
    	return Math.sqrt(yDif * yDif + xDif * xDif);
    }
}