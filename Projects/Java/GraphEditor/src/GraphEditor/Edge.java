package homework2;

public class Edge {
	Node node1, node2;
	String key;
	String value;

	public Edge(String key, String value, Node node1, Node node2) {
		this.node1 = node1;
		this.node2 = node2;	    
		this.key = key;
		this.value = value;
	}
}
