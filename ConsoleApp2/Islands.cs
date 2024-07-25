// A C# program to count the number of rectangular
// islands where every island is separated by
// a line
using System;

class GFG
{

	// This function takes a matrix of 'X' and 'O'
	// and returns the number of rectangular
	// islands of 'X' where no two islands are
	// row-wise or column-wise adjacent, the
	// islands may be diagonally adjacent
	static int countIslands(int[,] mat, int m, int n)
	{

		// Initialize result
		int count = 0;

		// Traverse the input matrix
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				// If current cell is 'X', then check
				// whether this is top-leftmost of a
				// rectangle. If yes, then increment
				// count
				if (mat[i, j] == 'X')
				{
					if ((i == 0 || mat[i - 1, j] == 'O') &&
						(j == 0 || mat[i, j - 1] == 'O'))
						count++;
				}
			}
		}

		return count;
	}

	// Driver program
	public static void Main2()
	{

		// Size of given matrix is m X n
		//int m = 6;
		//int n = 3;
		//int[,] mat = { {'O', 'O', 'O'},
		//			{'X', 'X', 'O'},
		//			{'X', 'X', 'O'},
		//			{'O', 'O', 'X'},
		//			{'O', 'O', 'X'},
		//			{'X', 'X', 'O'}
		//			};

		int m = 5;
		int n = 5;

		int[,] mat = new int[,] { { 'X', 'X', 'O', 'O', 'O' },
								  { 'O', 'X', 'O', 'O', 'X' },
								  { 'X', 'O', 'O', 'X', 'X' },
								  { 'O', 'O', 'O', 'O', 'O' },
								  { 'X', 'O', 'X', 'X', 'O' } };


		Console.WriteLine("Number of rectangular "
		+ "islands is: " + countIslands(mat, m, n));

		//Console.ReadKey();
	}
}

// This code is contributed by Sam007.
