namespace Graph
{
	/// <summary>
	/// Represents a graph data structure.
	/// </summary>
	public class Graph
	{
		/// <summary>
		/// Gets the list of vertices in the graph.
		/// </summary>
		public List<GraphVertex> Vertices { get; }

		/// <summary>
		/// Initializes a new instance of the Graph class.
		/// </summary>
		public Graph()
		{
			Vertices = new List<GraphVertex>();
		}

		/// <summary>
		/// Adds a vertex with the specified name to the graph.
		/// </summary>
		/// <param name="vertexName">The name of the vertex to add.</param>
		public void AddVertex(string vertexName)
		{
			Vertices.Add(new GraphVertex(vertexName));
		}

		/// <summary>
		/// Finds and returns the vertex with the specified name.
		/// </summary>
		/// <param name="vertexName">The name of the vertex to find.</param>
		/// <returns>The vertex with the specified name, or null if not found.</returns>
		public GraphVertex FindVertex(string vertexName)
		{
			foreach (var vertex in Vertices)
			{
				if (vertex.Name.Equals(vertexName))
				{
					return vertex;
				}
			}
			return null;
		}

		/// <summary>
		/// Adds an edge between two vertices with the specified names and weight.
		/// </summary>
		/// <param name="firstName">The name of the first vertex.</param>
		/// <param name="secondName">The name of the second vertex.</param>
		/// <param name="weight">The weight of the edge.</param>
		public void AddEdge(string firstName, string secondName, int weight)
		{
			var v1 = FindVertex(firstName);
			var v2 = FindVertex(secondName);

			if (v1 is null && v2 is null)
			{
				throw new ArgumentException("One or both vertices not found.");
			}

			v1.AddEdge(v2, weight);
			v2.AddEdge(v1, weight);
		}
	}
}