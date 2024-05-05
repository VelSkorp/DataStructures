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
		public List<GraphVertex> Vertices { get; private set; }

		/// <summary>
		/// Initializes a new instance of the Graph class.
		/// </summary>
		public Graph()
		{
			Vertices = new List<GraphVertex>();
		}

		/// <summary>
		///     <para>
		///         Adds a vertex with the specified name to the graph.
		///     </para>
		///     <para>
		///         Time Complexity: O(1), operation of adding an item to a List and creating a new GraphVertex instance has a constant time complexity.
		///     </para>
		///     <para>
		///         Space Complexity: O(n), where n is the number of vertices in the graph.
		///     </para>
		/// </summary>
		/// <param name="vertexName">The name of the vertex to add.</param>
		public void AddVertex(string vertexName)
		{
			Vertices.Add(new GraphVertex(vertexName));
		}

		/// <summary>
		///     <para>
		///         Finds and returns the vertex with the specified name.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the number of vertices in the graph.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
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
		///     <para>
		///         Adds an edge between two vertices with the specified names and weight.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the number of vertices in the graph.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
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