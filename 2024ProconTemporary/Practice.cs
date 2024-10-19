
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024ProconTemporary
{
    public class Practice
    {
        public static int pieceX;
        public static int pieceY;
        static Random random = new Random();
        public static List<List<int>> answer = new List<List<int>>();
        public static List<List<int>> queues = new List<List<int>>();
        public static List<List<int>> AnsTes = new List<List<int>>()
        {
                    new List<int>{ 1,1,2,1,3,2,0,3,1,2,1,3,0,3,1,2,2,3,0,2,0,2,2,0,2,3,0,3,3,0,2,1},
                    new List<int>{ 2,0,3,1,3,0,3,2,1,3,2,1,0,2,1,0,3,2,2,1,3,2,2,2,0,0,0,0,0,3,0,0},
                    new List<int>{2,0,1,0,1,3,2,2,3,2,1,3,1,3,0,3,0,1,2,0,1,1,0,3,2,3,2,3,0,3,0,3 },
                    new List<int>{0,0,0,3,0,3,1,1,1,0,1,2,0,0,1,2,1,3,0,1,0,1,1,1,2,1,1,0,1,3,0,1 },
                    new List<int>{1,3,1,2,3,2,2,2,2,0,1,2,1,0,1,0,1,3,0,3,2,3,1,0,2,0,2,0,3,0,3,2 },
                    new List<int>{2,3,1,2,0,0,0,1,1,3,2,3,2,0,3,3,1,2,1,0,2,2,3,2,3,2,2,2,2,2,3,2 },
                    new List<int>{0,2,0,3,2,1,1,1,1,2,3,3,0,1,3,0,1,0,1,3,0,2,3,0,3,0,0,2,3,2,3,3 },
                    new List<int>{3,3,3,0,2,2,0,3,2,2,2,0,0,2,3,2,1,0,1,1,2,1,1,0,3,0,2,1,2,2,1,3 },
                    new List<int>{3,0,1,3,3,3,3,2,1,0,1,2,2,0,1,2,3,1,1,1,0,0,1,3,3,2,2,3,2,0,1,0 },
                    new List<int>{2,0,3,3,0,1,2,2,1,3,3,3,2,3,2,3,3,0,2,3,2,2,2,0,1,3,3,3,0,0,0,0 },
                    new List<int>{2,3,2,3,0,3,2,1,3,3,1,2,0,3,0,3,3,0,3,2,0,3,1,1,1,3,1,0,3,2,1,2 },
                    new List<int>{0,0,0,0,3,0,1,2,0,3,0,0,0,1,0,3,2,1,0,3,1,2,2,3,1,0,0,1,3,1,2,0 },
                    new List<int>{ 0,3,1,0,1,3,0,1,1,2,3,1,2,1,2,2,3,3,0,1,2,3,1,3,1,2,3,1,0,0,0,0},
                    new List<int>{3,0,3,2,3,2,0,0,0,1,3,3,3,2,1,2,2,3,2,3,3,3,1,3,0,0,2,3,3,3,1,2 },
                    new List<int>{1,3,3,0,0,3,1,3,3,1,3,2,1,3,0,0,0,1,3,1,1,2,0,3,2,2,1,0,1,0,2,0 },
                    new List<int>{2,0,1,1,3,0,3,0,3,3,2,1,3,0,3,2,1,1,2,2,3,3,2,2,1,3,3,2,0,3,3,1 },
                    new List<int>{0,2,1,2,0,2,1,3,1,2,2,1,1,2,1,1,2,3,3,2,3,3,2,2,2,0,1,3,2,1,0,0 },
                    new List<int>{2,3,0,0,3,0,2,3,1,1,3,3,1,2,2,0,2,3,0,2,1,1,3,2,2,2,3,1,3,0,3,3 },
                    new List<int>{0,2,1,2,0,1,2,0,2,1,0,3,2,2,3,3,0,1,1,1,1,0,0,3,3,0,1,0,2,3,0,2 },
                    new List<int>{1,1,2,2,3,0,3,3,2,3,0,3,1,3,1,0,0,3,3,1,1,3,0,0,3,2,1,0,1,0,1,3 },
                    new List<int>{3,1,0,0,2,0,0,0,0,2,0,0,0,3,3,1,3,1,2,0,1,1,3,1,2,2,2,3,2,2,2,0 },
                    new List<int>{2,3,0,2,3,0,3,0,3,0,3,3,0,0,0,2,0,2,0,3,2,2,2,2,2,0,2,3,2,2,2,0 },
                    new List<int>{1,0,3,3,1,2,2,2,3,2,2,0,0,0,3,0,1,1,2,2,0,0,2,3,3,0,2,2,1,1,3,0 },
                    new List<int>{3,1,1,1,0,3,1,2,2,3,2,0,0,1,3,1,2,3,1,3,1,2,0,3,1,0,1,0,1,3,3,2 },
                    new List<int>{0,3,3,2,3,2,0,2,0,2,3,0,0,3,3,1,0,1,1,1,1,0,3,3,2,3,0,0,1,2,3,2 },
                    new List<int>{2,1,2,1,0,2,2,2,3,3,2,0,1,0,3,2,2,2,3,2,0,0,0,3,3,1,3,2,2,2,1,3 },
                    new List<int>{1,3,1,1,1,3,0,0,3,1,3,0,1,0,2,0,3,0,2,1,0,2,1,2,2,1,2,1,1,0,2,0 },
                    new List<int>{3,2,2,3,1,0,2,2,2,2,2,3,2,2,1,1,3,2,2,2,3,0,1,2,2,1,1,3,3,3,3,0 },
                    new List<int>{1,0,1,1,1,1,2,3,0,2,2,2,0,2,3,3,3,0,3,0,2,2,1,1,2,0,0,2,2,1,2,0 },
                    new List<int>{1,2,1,2,1,2,0,0,2,1,2,2,3,0,2,1,3,3,1,2,0,0,1,3,3,1,3,1,0,1,0,0 },
                    new List<int>{1,2,1,2,2,0,3,2,1,1,0,0,2,1,1,1,1,1,2,1,0,0,3,1,2,1,0,0,3,0,0,1 },
                    new List<int>{3,3,3,0,1,3,0,2,1,2,1,0,1,0,0,2,2,3,1,0,3,0,1,0,1,3,3,1,2,3,3,1 },
        };
        public static List<List<int>> QuesTes = new List<List<int>>()
        {
             new List<int> { 0,0,1,0,1,0,2,2,1,3,0,0,3,2,2,3,3,3,2,3,2,1,3,2,1,2,2,2,0,3,1,1 },
             new List<int> {2,1,2,0,2,3,2,3,2,3,3,0,3,2,0,1,3,0,0,1,3,0,1,2,2,1,2,0,0,0,0,0 },
             new List<int> {3,2,1,0,0,2,1,1,3,1,3,3,2,3,1,2,3,0,0,2,0,1,2,0,1,3,3,0,2,0,3,3},
             new List<int> {1,2,2,1,0,1,0,1,2,1,3,0,0,1,0,0,3,0,1,0,3,1,1,1,3,1,1,1,1,0,0,0},
             new List<int> {1,0,3,1,0,2,3,1,0,3,3,3,3,2,3,0,2,1,0,1,2,2,2,2,2,2,2,1,0,1,0,0,},
             new List<int> {3,1,1,1,2,1,3,2,0,1,0,2,2,2,3,2,0,0,3,3,3,3,0,3,2,2,2,2,2,2,2,2},
             new List<int> {3,2,2,0,0,0,2,3,1,3,0,3,0,3,0,1,2,0,0,2,2,1,3,3,1,3,3,0,1,3,1,1},
             new List<int> {3,3,2,2,1,2,0,3,1,0,1,1,2,0,3,3,2,2,0,0,0,2,1,2,0,3,1,2,2,3,2,1},
             new List<int> {0,1,0,2,3,3,1,0,2,0,3,2,2,3,1,2,1,0,2,1,3,2,3,3,1,3,3,1,0,1,1,0},
             new List<int> {0,0,3,3,3,3,3,1,2,2,2,3,3,1,1,3,2,0,2,2,0,0,2,3,2,2,3,0,3,3,0,0},
             new List<int> {0,0,1,2,0,0,1,0,3,0,2,2,3,1,1,3,3,3,3,1,3,2,2,2,2,3,3,3,1,1,3,3},
             new List<int> {1,1,0,0,1,1,2,3,0,1,0,2,0,3,3,0,3,2,3,3,2,1,2,0,0,1,0,0,0,0,0,0},
             new List<int> {0,2,2,1,1,1,3,1,2,1,3,3,0,2,0,3,1,3,0,0,1,1,2,1,2,1,0,3,3,3,0,0},
             new List<int> {0,3,2,3,3,2,2,2,0,1,3,3,0,3,3,2,0,2,2,0,3,3,2,1,3,3,1,1,3,3,0,3},
             new List<int> {1,1,3,1,2,0,2,3,3,0,1,1,3,3,1,0,2,1,1,0,0,1,2,2,3,0,3,0,0,0,3,3},
             new List<int> {0,2,2,3,3,2,2,0,3,2,1,2,2,2,3,0,3,1,1,3,3,1,1,1,1,3,3,3,3,0,3,1},
             new List<int> {0,1,2,3,2,2,1,1,2,3,1,2,1,3,1,0,1,3,0,3,0,2,3,0,1,2,2,1,2,2,2,2},
             new List<int> {2,1,3,0,0,3,0,1,2,0,1,0,1,2,2,1,3,3,0,2,3,1,2,3,3,2,3,3,2,2,3,3},
             new List<int> {1,3,2,3,0,2,1,2,3,2,2,0,0,0,0,1,2,1,0,0,0,3,2,1,1,1,3,0,3,0,1,2},
             new List<int> {1,3,2,3,3,3,1,1,0,2,0,2,1,2,1,0,0,1,1,0,1,0,3,0,3,0,3,3,3,1,3,3},
             new List<int> {2,0,0,3,0,0,1,2,2,1,0,0,2,0,1,3,3,3,3,2,1,0,2,2,2,0,2,1,0,1,0,3},
             new List<int> {2,3,2,2,3,0,2,3,0,3,0,2,2,2,3,0,2,2,0,3,0,2,0,0,0,2,2,2,3,0,0,3},
             new List<int> {0,0,2,0,1,0,1,3,1,1,0,2,0,1,2,3,2,2,2,3,3,0,1,3,2,0,3,2,3,2,2,1},
             new List<int> {2,0,1,1,2,2,3,3,3,0,1,2,1,0,1,2,0,3,3,1,3,0,3,3,2,1,0,1,1,3,1,1},
             new List<int> {2,1,1,2,3,3,0,0,3,3,0,2,0,0,2,3,0,0,1,0,1,1,2,2,3,0,3,2,1,3,3,1},
             new List<int> {0,0,3,3,1,0,3,3,0,2,2,0,2,0,3,1,3,2,1,3,2,2,3,1,2,2,1,2,2,2,2,2},
             new List<int> {2,0,1,0,1,0,0,0,2,1,2,1,1,0,1,0,1,1,2,3,0,2,2,0,1,2,1,1,3,3,3,1},
             new List<int> {2,3,1,0,2,2,0,3,1,0,2,1,2,1,2,3,3,2,2,1,3,1,3,3,2,3,2,2,2,2,2,1},
             new List<int> {2,3,1,1,1,0,3,0,1,2,1,1,2,0,2,2,0,0,2,3,1,0,2,1,3,3,0,2,0,2,2,2},
             new List<int> {0,3,0,2,2,0,3,0,1,3,1,1,2,0,2,0,3,1,3,1,0,1,0,1,1,3,2,1,2,1,0,2},
             new List<int> {2,3,0,2,3,0,1,3,2,3,2,0,2,0,1,2,0,0,3,1,1,0,3,1,3,0,1,1,2,1,1,2},
             new List<int> {1,3,0,2,3,0,3,3,1,3,1,0,2,0,2,0,3,0,3,0,1,0,3,1,3,0,0,1,1,2,1,2},
        };
        public static List<List<int>> AnsTes2 = new List<List<int>>()
        {
                new List<int>{1,1,2,1,3,2,0,3,1,2,1,3,0,3,1,2,2,3,0,2,0,2,2,0,2,3,0,3,3,0,2,1},
        };
        public static List<List<int>> QuesTes2 = new List<List<int>>()
        {
                //
                new List<int> {0,0,1,0,1,0,2,2,1,3,0,0,3,2,2,3,3,3,2,3,2,1,3,2,1,2,2,2,0,3,1,1},
            //端から大体そろうように引っこ抜く端と引っこ抜いたものを同時に考えて互いがそろうように
        };
        public static void Practices()
        {
            pieceX = 32;
            pieceY = 32;
            Question();
            Answer(AnsTes);
        }
       

        public static void Question()
        {
            for (int y = 0; y < pieceY; y++)
            {
                List<int> ansOne = new List<int>();
                for (int x = 0; x < pieceX; x++)
                {
                    ansOne.Add(random.Next(0, 4));
                }
                answer.Add(ansOne);

            }


        }
        public static void Answer(List<List<int>> ans)
        {

            Random rand = new Random();
            List<List<int>> ansChange = new List<List<int>>();
            List<int> shuffle = new List<int>();
            int j = 0;
            for (int y = 0; y < pieceY; y++)
            {
                for (int x = 0; x < pieceX; x++)
                {
                    shuffle.Add(ans[y][x]);
                }
            }
            List<int> result = shuffle.OrderBy(x => rand.Next()).ToList();
            for (int y = 0; y < pieceY; y++)
            {
                List<int> queuesOne = new List<int>();
                for (int x = 0; x < pieceX; x++, j++)
                {
                    queuesOne.Add(result[j]);
                }
                queues.Add(queuesOne);
            }
        }

    }
}
