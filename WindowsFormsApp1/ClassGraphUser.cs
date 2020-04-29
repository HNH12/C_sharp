using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphUser
{
	public class ClassGraphUser
	{
		private int[][] _graph;

		public ClassGraphUser(RichTextBox richTextBox)
		{
			string[] lines = richTextBox.Text.Split('\n');
			int countVertex = lines.Length;

			_graph = new int[countVertex][];
			for (int i = 0; i < countVertex; i++)
			{
				_graph[i] = new int[countVertex];
				string[] elements = lines[i].Split(' ');
				for (int j = 0; j < countVertex; j++)
				{
					_graph[i][j] = int.Parse(elements[j]);
				}
			}
		}

		/// <summary>
		/// Возвращает количество вершин
		/// </summary>
		/// <returns></returns>
		public int GetCountVertex()
		{
			return _graph.Length;
		}

		/// <summary>
		/// Возвращает количество рёбер
		/// </summary>
		/// <returns></returns>
		public int GetCountEdge()
		{
			int countEdge = 0;
			int countVertex = GetCountVertex();
			int[][] copyGraph = new int[countVertex][];

			for (int i = 0; i < countVertex; i++)
			{
				copyGraph[i] = new int[countVertex];
				for (int j = 0; j < countVertex; j++)
				{
					copyGraph[i][j] = _graph[i][j];
				}
			}

			for (int i = 0; i < countVertex; i++)
			{
				for (int j = 0; j < countVertex; j++)
				{
					if (copyGraph[i][j] == 1 && copyGraph[j][i] == 1)
					{
						copyGraph[j][i] = 0;
						countEdge++;
					}
					else
					{
						if (copyGraph[i][j] == 1)
						{
							countEdge++;
						}
					}
				}
			}

			return countEdge;
		}

		/// <summary>
		/// Возвращает стоймость ребра между указанными вершинами
		/// </summary>
		/// <param name="firstVertex"></param>
		/// <param name="secondVertex"></param>
		/// <returns></returns>
		public int GetCostEdge(int firstVertex, int secondVertex)
		{
			return _graph[firstVertex][secondVertex];
		}

		/// <summary>
		/// Проверяет, есть ли ребро между указанными вершинами
		/// </summary>
		/// <param name="firstVertex"></param>
		/// <param name="secondVertex"></param>
		/// <returns></returns>
		public bool Edge(int firstVertex, int secondVertex)
		{
			if (_graph[firstVertex][secondVertex] != 0)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Удаляет ребро между указанными вершинами
		/// </summary>
		/// <param name="firstVertex"></param>
		/// <param name="secondVertex"></param>
		public void DeleteEdge(int firstVertex, int secondVertex)
		{
			_graph[firstVertex][secondVertex] = 0;
		}

		/// <summary>
		/// Создаёт ребро между указанными вершинами
		/// </summary>
		/// <param name="firstVertex"></param>
		/// <param name="secondVertex"></param>
		public void CreatEdge(int firstVertex, int secondVertex)
		{
			_graph[firstVertex][secondVertex] = 1;
		}

		public int[][] GetGraph()
		{
			return _graph;
		}
	}
}
