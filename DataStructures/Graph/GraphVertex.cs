namespace Graph
{
	/// <summary>
	/// Represents a vertex in a graph.
	/// </summary>
	public class GraphVertex
	{
		/// <summary>
		/// Gets the name of the vertex.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Gets the list of edges connected to this vertex.
		/// </summary>
		public List<GraphEdge> Edges { get; private set; }

		/// <summary>
		/// Initializes a new instance of the GraphVertex class with the specified name.
		/// </summary>
		/// <param name="name">The name of the vertex.</param>
		public GraphVertex(string name)
		{
			Name = name;
			Edges = new List<GraphEdge>();
		}

		/// <summary>
		/// Adds an edge to the list of edges connected to this vertex.
		/// </summary>
		/// <param name="newEdge">The edge to add.</param>
		public void AddEdge(GraphEdge newEdge)
		{
			Edges.Add(newEdge);
		}

		/// <summary>
		/// Adds an edge connecting this vertex to another vertex with the specified weight.
		/// </summary>
		/// <param name="vertex">The vertex to connect to.</param>
		/// <param name="edgeWeight">The weight of the edge.</param>
		public void AddEdge(GraphVertex vertex, int edgeWeight)
		{
			AddEdge(new GraphEdge(vertex, edgeWeight));
		}

		/// <summary>
		/// Returns the name of the vertex.
		/// </summary>
		/// <returns>The name of the vertex.</returns>
		public override string ToString()
		{
			return Name;
		}
	}
}