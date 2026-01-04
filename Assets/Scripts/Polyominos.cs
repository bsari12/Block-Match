using UnityEngine;

public static class Polyominos 
{
    private static readonly int[][,] polyominos = new int[][,]
    {
        // --- TEKLİ NOKTA (Monomino) ---
        new int[,] { {1} },

        // --- ÇUBUKLAR (Lines) ---
        new int[,] { {1, 1} }, // 1x2 Yatay
        new int[,] { {1}, {1} }, // 2x1 Dikey
        new int[,] { {1, 1, 1} }, // 1x3 Yatay
        new int[,] { {1}, {1}, {1} }, // 3x1 Dikey
        new int[,] { {1, 1, 1, 1, 1} }, // 1x5 Yatay (Block Blast klasiği)

        // --- KARELER (Squares) ---
        new int[,] { 
            {1, 1}, 
            {1, 1} 
        },
        new int[,] { 
            {1, 1, 1}, 
            {1, 1, 1}, 
            {1, 1, 1} 
        },

        // --- L ŞEKİLLERİ (3x3 Büyük L) ---
        // Normal L
        new int[,] {
            {0, 0, 1},
            {0, 0, 1},
            {1, 1, 1}
        },
        // 90 Derece Sağ
        new int[,] {
            {1, 0, 0},
            {1, 0, 0},
            {1, 1, 1}
        },
        // 180 Derece (Ters L)
        new int[,] {
            {1, 1, 1},
            {1, 0, 0},
            {1, 0, 0}
        },
        // 270 Derece
        new int[,] {
            {1, 1, 1},
            {0, 0, 1},
            {0, 0, 1}
        },

        // --- KÜÇÜK L (2x2) ---
        new int[,] {
            {1, 0},
            {1, 1}
        },
        new int[,] {
            {1, 1},
            {1, 0}
        },
        new int[,] {
            {0, 1},
            {1, 1}
        },
        new int[,] {
            {1, 1},
            {0, 1}
        },

        // --- T ŞEKLİ ---
        new int[,] {
            {0, 1, 0},
            {1, 1, 1}
        },
        new int[,] {
            {1, 1, 1},
            {0, 1, 0}
        },
        new int[,] {
            {1, 0},
            {1, 1},
            {1, 0}
        },

        // --- Z ve S ŞEKİLLERİ ---
        new int[,] {
            {1, 1, 0},
            {0, 1, 1}
        },
        new int[,] {
            {0, 1, 1},
            {1, 1, 0}
        }
    };

    static Polyominos()
    {
        foreach(var polyomino in polyominos)
        {
            ReverseRows(polyomino);
        }

    }

    public static int[,] Get(int index) => polyominos[index];
    public static int Length => polyominos.Length;


    private static void ReverseRows(int[,] polyomino)
    {
        var polyominoRows = polyomino.GetLength(0);
        var polyominoColumns = polyomino.GetLength(1);

        for(var r = 0; r< polyominoRows/2; ++r)
        {
            var topRow = r;
            var bottomRow = polyominoRows - 1 -r;

            for(var c = 0; c < polyominoColumns; ++c)
            {
                (polyomino[bottomRow, c], polyomino[topRow, c]) = (polyomino[topRow, c], polyomino[bottomRow, c]);
            }
        }
    }





}
