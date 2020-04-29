using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphUser;

namespace OperationsOnGraph
{
	public class ClassOperationsOnGraph
	{
		private ClassGraphUser _graph;

		public ClassOperationsOnGraph(RichTextBox richTextBox) 
		{
			_graph = new ClassGraphUser(richTextBox);
		}

		/// <summary>
		/// Проверяет граф на наличие петель
		/// </summary>
		/// <returns></returns>
		private bool DiagonalElements()
		{
			for (int i = 0; i < _graph.GetCountVertex(); i++)
				if (_graph.Edge(i, i))
					return true;
			return false;
		}

		/// <summary>
		/// Копирование графа
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="countVertex"></param>
		private void CopyGraph(int[][] a, int[][] b, int countVertex)
		{
			for (int i = 0; i < countVertex; i++)
			{
				for (int j = 0; j < countVertex; j++)
				{
					b[i][j] = a[i][j];
				}
			}
		}

		/// <summary>
		/// Преобразует граф в ориентированный
		/// </summary>
		/// <param name="graph"></param>
		/// <param name="countVertex"></param>
		private void DirectedGraph(int[][] graph, int N)
		{
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (graph[i][j] == 1 && graph[j][i] == 1)
					{
						graph[j][i] = 0;
					}
				}
			}
		}

		/// <summary>
		/// Умножение матриц
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="res"></param>
		private void MultiplicationMatrix(int[][] a, int[][] b, int[][] res)
		{
			int N = a.Length;
			int[][] mul = new int[N][];
			for (int i = 0; i < N; i++)
			{
				mul[i] = new int[N];
				for (int j = 0; j < N; j++)
				{
					mul[i][j] = 0;
					for (int k = 0; k < N; k++)
						mul[i][j] += a[i][k] * b[k][j];
				}
			}
			CopyGraph(mul, res, N);
		}

		/// <summary>
		/// Количество путей заданной длины
		/// </summary>
		/// <param name="lengthWay"></param>
		/// <returns></returns>
		public int GetCountWay(int lengthWay)
		{
			int count = new int();
			int N = _graph.GetCountVertex();

			int[][] res = new int[N][];
			for (int i = 0; i < N; i++)
				res[i] = new int[N];

			int[][] g = new int[N][];
			for (int i = 0; i < N; i++)
				g[i] = new int[N];

			CopyGraph(_graph.GetGraph(), g, N);
			DirectedGraph(g, N);
			CopyGraph(g, res, N);

			while (lengthWay > 1)
			{
				int[][] mult = new int[N][];
				for (int i = 0; i < N; i++)
					mult[i] = new int[N];

				MultiplicationMatrix(g, res, mult);
				CopyGraph(mult, res, N);
				lengthWay--;
			}

			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (i != j)
						count += res[i][j];
				}
			}
			return count;
		}

		/// <summary>
		/// Находит произвольное максимальное покрытие
		/// </summary>
		/// <returns></returns>
		public List<int> FindMaxIndependent()
		{
			List<int> maxIndependent = new List<int>();

			int countVertexes = _graph.GetCountVertex();
			bool[] visitedVertexes = new bool[countVertexes];

			visitedVertexes[0] = true;
			maxIndependent.Add(0);

			int currentVertex = 0;
			for (int i = 0; i < countVertexes; i++)
				if (!_graph.Edge(currentVertex, i) && !visitedVertexes[i])
				{
					for (int j = 0; j < countVertexes; j++)
						if (_graph.Edge(currentVertex, j))
							visitedVertexes[j] = true;

					maxIndependent.Add(i);
					currentVertex = i;
					visitedVertexes[i] = true;
					i = -1;
				}
			return maxIndependent;
		}

		/// <summary>
		/// Поиск в глубину с некоторыми изменениями под топологическую сортировку
		/// </summary>
		/// <param name="blackColor"></param>
		/// <param name="greyColor"></param>
		/// <param name="v"></param>
		/// <param name="flag"></param>
		private void DFS_TopologicalSort(Stack<int> blackColorVertexes, bool[] greyColorVertexes, int v, ref bool flag)
		{
			int countVertexes = _graph.GetCountVertex();

			Stack<int> processVertexes = new Stack<int>();
			processVertexes.Push(v);
			greyColorVertexes[v] = true;

			while (processVertexes.Count != 0)
			{
				int currentVertex = processVertexes.Pop();
				for (int i = 0; i < countVertexes; i++)
				{
					if (_graph.Edge(currentVertex, i) && greyColorVertexes[i])
						flag = true;

					else
					{
						if (_graph.Edge(currentVertex, i) && !blackColorVertexes.Contains(i))
						{
							processVertexes.Push(currentVertex);
							currentVertex = i;
							greyColorVertexes[i] = true;
							i = -1;
						}
					}
				}
				blackColorVertexes.Push(currentVertex);
				greyColorVertexes[currentVertex] = false;
			}
		}

		private int[][] InitializationEmptyMatrix(int countVertexes)
		{
			int[][] newGraf = new int[countVertexes][];

			for (int i = 0; i < countVertexes; i++)
			{
				newGraf[i] = new int[countVertexes];
				for (int j = 0; j < countVertexes; j++)
					newGraf[i][j] = 0;
			}
			return newGraf;
		}

		private void FindNewIndex(int[] numbVertexes, int countVertexes,
			ref int changedIndex_J, ref int changedIndex_I, int j, int i)
		{
			for (int c = 0; c < countVertexes; c++)
			{
				if (numbVertexes[c] == j)
				{
					changedIndex_J = c;
				}
			}

			for (int c = 0; c < countVertexes; c++)
			{
				if (numbVertexes[c] == i)
				{
					changedIndex_I = c;
				}
			}
		}

		/// <summary>
		/// Топологическая сортировка графа
		/// </summary>
		/// <param name="blackColor"></param>
		/// <returns></returns>
		private int[][] TopologicalSort(Stack<int> blackColor)
		{
			int countVertexes = _graph.GetCountVertex();

			int[] numbVertexes = new int[countVertexes];
			int[][] newGraf = InitializationEmptyMatrix(countVertexes);

			for (int i = 0; i < countVertexes; i++)
				numbVertexes[i] = blackColor.Pop();

			for (int i = 0; i < countVertexes; i++)
			{
				for (int j = 0; j < countVertexes; j++)
				{
					if (_graph.Edge(i, j))
					{
						_graph.DeleteEdge(i, j);

						int changedIndex_J = new int();
						int changedIndex_I = new int();

						FindNewIndex(numbVertexes, countVertexes, ref changedIndex_J, ref changedIndex_I, j, i);

						newGraf[changedIndex_I][changedIndex_J] = 1;
					}
				}
			}
			return newGraf;
		}

		/// <summary>
		/// Вывод стека отсортированных вершин и отсортированного графа
		/// </summary>
		/// <returns></returns>
		public (int[][], Stack<int>) TopologicalSortGraphAndStack()
		{
			int countVertex = _graph.GetCountVertex();
			Stack<int> blackColor = new Stack<int>();
			bool[] greyColor = new bool[countVertex];
			bool flag = false;

			for (int i = 0; i < countVertex; i++)
			{
				if (!blackColor.Contains(i))
					DFS_TopologicalSort(blackColor, greyColor, i, ref flag);

				if (flag)
					return (null, null);
			}

			Stack<int> sortedVertex = new Stack<int>(blackColor);
			return (TopologicalSort(blackColor), sortedVertex);
		}

		/// <summary>
		/// Поиск в глубину
		/// </summary>
		/// <param name="visitedVertexes"></param>
		/// <param name="v"></param>
		private void DFS(bool[] visitedVertexes, int v = 0)
		{
			int countVertexes = _graph.GetCountVertex();

			Stack<int> processVertexes = new Stack<int>();
			processVertexes.Push(v);
			visitedVertexes[v] = true;

			while (processVertexes.Count != 0)
			{
				int currentVertex = processVertexes.Pop();
				for (int i = 0; i < countVertexes; i++)
				{
					if (_graph.Edge(currentVertex, i) && !visitedVertexes[i])
					{
						processVertexes.Push(currentVertex);
						currentVertex = i;
						visitedVertexes[i] = true;
						i = 0;
					}
				}
			}
		}

		/// <summary>
		/// Проверяет граф на связность
		/// </summary>
		/// <returns></returns>
		private bool CheckConnectivity()
		{
			int countVertexes = _graph.GetCountVertex();
			bool[] visitedVertexes = new bool[countVertexes];

			int numberConnectivityCompanents = 0;

			for (int i = 0; i < countVertexes; i++)
				if (!visitedVertexes[i])
				{
					numberConnectivityCompanents++;
					DFS(visitedVertexes, i);
				}

			if (numberConnectivityCompanents == 1)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Проверяет является ли граф деревом
		/// </summary>
		/// <returns></returns>
		public bool CheckTree()
		{
			if (!CheckConnectivity())
				return false;
			if (DiagonalElements())
				return false;

			int countVertex = _graph.GetCountVertex();
			int countEdge = _graph.GetCountEdge();

			if (countVertex - countEdge == 1)
				return true;
			else
				return false;
		}
	}
}
