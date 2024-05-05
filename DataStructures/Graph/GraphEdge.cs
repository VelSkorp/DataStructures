namespace Graph
{
	/// <summary>
	/// Represents an edge connecting two vertices in a graph.
	/// </summary>
	public class GraphEdge
	{
		/// <summary>
		/// Gets the vertex connected by this edge.
		/// </summary>
		public GraphVertex ConnectedVertex { get; }

		/// <summary>
		/// Gets the weight of the edge.
		/// </summary>
		public int EdgeWeight { get; }

		/// <summary>
		/// Initializes a new instance of the GraphEdge class with the specified connected vertex and weight.
		/// </summary>
		/// <param name="connectedVertex">The vertex connected by this edge.</param>
		/// <param name="weight">The weight of the edge.</param>
		public GraphEdge(GraphVertex connectedVertex, int weight)
		{
			ConnectedVertex = connectedVertex;
			EdgeWeight = weight;
		}
	}
}