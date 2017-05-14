using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * translate the maze generation program in the following book into C#
 * 
 * 奥村晴彦『C言語による最新アルゴリズム事典』技術評論社，1991年
 */
public class MazeGenerator : MonoBehaviour {

	const int XMAX = 20;
	const int YMAX = 20;
	const int MAXSITE = (XMAX * YMAX / 4);

	const string TEXNAME = "Bricks Texture 03";

	int ii = 0;
	int jj = 0;
	int[,] map;


	// 24 x 4
	int[][] dirtable_ = new int[][]{
		new int[] {0,1,2,3},
		new int[] {0,1,3,2},
		new int[] {0,2,1,3},

		new int[] {0,2,3,1},
		new int[] {0,3,1,2},
		new int[] {0,3,2,1,},

		new int[] {1,0,2,3},
		new int[] {1,0,3,2},
		new int[] {1,2,0,3},

		new int[] {1,2,3,0},
		new int[] {1,3,0,2},
		new int[] {1,3,2,0,},

		new int[] {2,0,1,3},
		new int[] {2,0,3,1},
		new int[] {2,1,0,3},

		new int[] {2,1,3,0},
		new int[] {2,3,0,1},
		new int[] {2,3,1,0,},

		new int[] {3,0,1,2},
		new int[] {3,0,2,1},
		new int[] {3,1,0,2},

		new int[] {3,1,2,0},
		new int[] {3,2,0,1},
		new int[] {3,2,1,0,},
	};

	int[] dx = new int[] { 2, 0, -2,  0 };
	int[] dy = new int[] { 0, 2,  0, -2 };

	int nsite = 0;
	int[] xx = new int[MAXSITE];
	int[] yy = new int[MAXSITE];

	private int rand(int from, int to) {
		int seed = System.Environment.TickCount;
		System.Random rand = new System.Random(seed);
		return (int)rand.Next (from, to);
	}

	private void add(int i, int j)
	{
		xx[nsite] = i;
		yy[nsite] = j;
		nsite++;
	}

	private int select()
	{
		if (nsite == 0)
			return 0;
		nsite--;
		int r = rand(0, nsite);
		ii = xx[r];
		xx[r] = xx[nsite];
		jj = yy[r];
		yy[r] = yy[nsite];
		return 1;
	}


	// Use this for initialization
	// http://marunouchi-tech.i-studio.co.jp/2241/

	private GameObject createCube(float x, float y) {
		Texture texture1 = (Texture)Resources.Load ("_original");
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.GetComponent<Renderer>().material.mainTexture = texture1; 
		print (cube.GetComponent<Renderer> ().material.mainTexture);
		cube.transform.position = new Vector3 (x, 0.6f, y);
		cube.transform.localScale = new Vector3(1.0f, 1.9f, 1.0f);
		return cube;
	}

	void Start () {
		map = new int[XMAX + 1, YMAX + 1];

		for (int i = 0; i <= XMAX; i++) {
			for (int j = 0; j <= YMAX; j++) {
				map[i, j] = 1;
			}
		}

		for (int i = 3; i <= XMAX - 3; i++) {
			for (int j = 3; j <= YMAX - 3; j++) {
				map [i, j] = 0;
			}
		}

		map[2, 3] = 0;
		map[XMAX - 2, YMAX - 3] = 0;

		for (int i = 4; i <= XMAX - 4; i += 2) {
			add (i, 2);
			add (i, YMAX - 2);
		}

		for (int j = 4; j <= YMAX - 4; j += 2) {
			add (2, j);
			add (XMAX - 2, j);
		}
			
		int d = 0;
		int i1 = 0;
		int j1 = 0;
		while (select () == 1) {
			while (true) {
				var tt = dirtable_[rand(0, 24)];
				for (d = 3; d >= 0; d--) {
					int t = tt [d];
					i1 = ii + dx [t];
					j1 = jj + dy [t];
					print (t);
					print (i1);
					print (j1);
					if (map [i1, j1] == 0) break;
				}
				if (d < 0)
					break;
				map [(ii + i1) / 2, (jj + j1) / 2] = 1;
				ii = i1; 
				jj = j1;
				map[ii, jj] = 1;
				add(ii, jj);
			}
		}


		float scale = 1.05f;
		for (int j = 2; j <= YMAX - 2; j++) {
			for (int i = 2; i <= XMAX - 2; i++) {
				print (map [i, j]);
				if (map [i, j] >= 1) {
					createCube ((float)i*scale, (float)j*scale);
				}
			}
		}
	}
	
	void Update () {
		
	}
}
