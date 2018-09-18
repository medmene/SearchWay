using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchWay
{
    class getway
    {        
        static bool linked(Point one, Point two)
        {
            if (one.X == two.X)
            {
                //если они по одной орркдинате х и не далеко по у
                if (one.Y == (two.Y + 1) || one.Y == (two.Y - 1)) return true;
                else return false;
            }
            else
            {
                if (one.Y == two.Y)
                {
                    //если они по одной координате у и не далеко по х
                    if (one.X == (two.X + 1) || one.X == (two.X - 1)) return true;
                    else return false;
                }
                else return false;
            }
        }

        //строим путь в квадратной карте
        static List<Point> buildWay(int[][] map, int max)
        {
            int n = 10, mx = max; //размер поля и всего шагов сколько до цели
            List<Point> res = new List<Point>(); //итоговый путь
            List<List<Point>> pp = new List<List<Point>>(); //все существующие шаги
            int i = 0, j = 0;
            //инициализируем
            for (i = 0; i < max + 1; ++i)
                pp.Add(new List<Point>());

            //получаем все шаги впринципе написанные
            for (i = 0; i < n; ++i)
                for (j = 0; j < n; ++j)
                    if (map[i][j] != 0 && map[i][j] != 1)
                        pp[map[i][j]].Add(new Point(i, j));//.push_back(Point(i, j));

            int cheked = 0, jgood = 0;
            Point badInd = new Point(); //для возврата на предыдущий шаг
            res.Add(new Point(pp[pp.Count - 1][0].X, pp[pp.Count - 1][0].Y));
            for (i = pp.Count - 2; i > 2; --i)
            {
                if (pp[i].Count == 1) res.Add(new Point(pp[i][0].X, pp[i][0].Y));
                else
                {
                    for (j = jgood; j < pp[i].Count; ++j)
                    {
                        if (linked(res[res.Count-1], pp[i][j]))
                        {
                            badInd.X = i;
                            badInd.Y = j;
                            res.Add(new Point(pp[i][j].X, pp[i][j].Y));
                            break;
                        }
                        else cheked++; //на случай отсутствия пути
                    }
                    if (cheked == pp[i].Count)
                    {
                        jgood = badInd.Y;
                        while (i != badInd.X)
                        {
                            res.RemoveAt(res.Count - 1);
                            i++; //на шаг назад вернемся
                        }
                        cheked = 0;
                    }
                    else
                    {
                        cheked = 0;
                        jgood = 0;
                    }
                }
            }
            return res;
        }
        //ищем путь в квадратной карте
        public static List<Point> searchWay(Point st, Point end, int[][] map)
        {
            List<Point> p; //сам путь кладём сюды
            int n = 10, temp = 2; //n-размер поля
            bool fl = true; //флаг для             
            map[st.X][st.Y] = 2; //ставим на стартовую позицию 2
            while (map[end.X][end.Y] == 0 && fl)
            {
                fl = false;
                //проходим по всему полю
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        //если натыкаемся на нужный шаг путя
                        if (map[i][j] == temp)
                        {
                            //расставляем следующие шаги
                            if (j > 0 && map[i][j - 1] == 0)
                            {
                                map[i][j - 1] = temp + 1;
                                fl = true;
                            }
                            if (i > 0 && map[i - 1][j] == 0)
                            {
                                map[i - 1][j] = temp + 1;
                                fl = true;
                            }
                            if (j < n - 1 && map[i][j + 1] == 0)
                            {
                                map[i][j + 1] = temp + 1;
                                fl = true;
                            }
                            if (i < n - 1 && map[i + 1][j] == 0)
                            {
                                map[i + 1][j] = temp + 1;
                                fl = true;
                            }
                        }
                    }
                }
                temp++; //увеличиваем шаг путя
            }
            p = buildWay(map, temp);
            return p;
        }
    }
    class getway2
    {
        static bool linked(Point one, Point two)
        {
            if (one.X == two.X)
            {
                //если они по одной орркдинате х и не далеко по у
                if (one.Y == (two.Y + 1) || one.Y == (two.Y - 1)) return true;
            }
            else
            {
                if (one.Y == two.Y)
                {
                    //если они по одной координате у и не далеко по х
                    if (one.X == (two.X + 1) || one.X == (two.X - 1)) return true;
                }
            }

            if (one.X == two.X + 1) 
            {
                if (one.Y == (two.Y + 1) || one.Y == (two.Y - 1)) return true;
                else return false;
            }
            else
            {
                if (one.X == two.X - 1)
                {
                    if (one.Y == (two.Y + 1) || one.Y == (two.Y - 1)) return true;
                    else return false;
                }
                else return false;
            }
        }

        //строим путь в квадратной карте
        static List<Point> buildWay(int[][] map, int max)
        {
            int n = 10, mx = max; //размер поля и всего шагов сколько до цели
            List<Point> res = new List<Point>(); //итоговый путь
            List<List<Point>> pp = new List<List<Point>>(); //все существующие шаги
            int i = 0, j = 0;
            //инициализируем
            for (i = 0; i < max + 1; ++i)
                pp.Add(new List<Point>());

            //получаем все шаги впринципе написанные
            for (i = 0; i < n; ++i)
                for (j = 0; j < n; ++j)
                    if (map[i][j] != 0 && map[i][j] != 1)
                        pp[map[i][j]].Add(new Point(i, j));//.push_back(Point(i, j));

            int cheked = 0, jgood = 0;
            Point badInd = new Point(); //для возврата на предыдущий шаг
            res.Add(new Point(pp[pp.Count - 1][0].X, pp[pp.Count - 1][0].Y));
            for (i = pp.Count - 2; i > 2; --i)
            {
                if (pp[i].Count == 1) res.Add(new Point(pp[i][0].X, pp[i][0].Y));
                else
                {
                    for (j = jgood; j < pp[i].Count; ++j)
                    {
                        if (linked(res[res.Count - 1], pp[i][j]))
                        {
                            badInd.X = i;
                            badInd.Y = j;
                            res.Add(new Point(pp[i][j].X, pp[i][j].Y));
                            break;
                        }
                        else cheked++; //на случай отсутствия пути
                    }
                    if (cheked == pp[i].Count)
                    {
                        jgood = badInd.Y;
                        while (i != badInd.X)
                        {
                            res.RemoveAt(res.Count - 1);
                            i++; //на шаг назад вернемся
                        }
                        cheked = 0;
                    }
                    else
                    {
                        cheked = 0;
                        jgood = 0;
                    }
                }
            }
            return res;
        }
        //ищем путь в квадратной карте
        public static List<Point> searchWay(Point st, Point end, int[][] map)
        {
            List<Point> p; //сам путь кладём сюды
            int n = 10, temp = 2; //n-размер поля
            bool fl = true; //флаг для             
            map[st.X][st.Y] = 2; //ставим на стартовую позицию 2
            while (map[end.X][end.Y] == 0 && fl)
            {
                fl = false;
                //проходим по всему полю
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        //если натыкаемся на нужный шаг путя
                        if (map[i][j] == temp)
                        {
                            //расставляем следующие шаги
                            if (j > 0 && map[i][j - 1] == 0)  //вверх   
                            {
                                map[i][j - 1] = temp + 1;
                                fl = true; 
                            }
                            if (j > 0 && i > 0 && map[i - 1][j - 1] == 0
                                && map[i][j - 1] != 1 && map[i - 1][j] != 1)  //вверх и влево 
                            {
                                map[i - 1][j - 1] = temp + 1;
                                fl = true;
                            }
                            if (j > 0 && i < n - 1 && map[i + 1][j - 1] == 0 
                               && map[i][j - 1] != 1 && map[i + 1][j] != 1)  //вверх и вправо 
                            {
                                map[i + 1][j - 1] = temp + 1;
                                fl = true;
                            }
                            if (i > 0 && map[i - 1][j] == 0) //влево
                            {
                                map[i - 1][j] = temp + 1;
                                fl = true;
                            }
                            if (j < n - 1 && map[i][j + 1] == 0) //вниз
                            {
                                map[i][j + 1] = temp + 1;
                                fl = true;
                            }
                            if (j < n - 1 && i > 0 && map[i - 1][j + 1] == 0 
                                && map[i][j + 1] != 1 && map[i - 1][j] != 1) //вниз и влево
                            {
                                map[i - 1][j + 1] = temp + 1;
                                fl = true;
                            }
                            if (j < n - 1 && i < n - 1 && map[i + 1][j + 1] == 0 
                                && map[i][j + 1] != 1 && map[i + 1][j] != 1) //вниз и влево
                            {
                                map[i + 1][j + 1] = temp + 1;
                                fl = true;
                            }
                            if (i < n - 1 && map[i + 1][j] == 0) //вправо
                            {
                                map[i + 1][j] = temp + 1;
                                fl = true;
                            }
                        }
                    }
                }
                temp++; //увеличиваем шаг путя
            }
            p = buildWay(map, temp);
            return p;
        }
    }
}
