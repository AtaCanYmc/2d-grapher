using System;
using System.Threading;
using System.IO;

namespace graph.mark.IIII
{
    class MainClass
    {
        //---------------------------------------------------------------------------------(Variables)

        //GRAPH VARİABLES
        static char[,] graph = new char[25, 40];
        static bool[] VertexControl = new bool[16];
        static char[] AllVertex = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P' };

        //DRAWİNG VARİABLES
        static int DrawerX = 4; static int DrawerY = 3;
        static ConsoleKeyInfo Drawer;
        static char drawerchar = '@';
        static DateTime draw = DateTime.Now;
        static DateTime draw2 = DateTime.Now;
        static int S_vertex_soft = 0; static int S_vertex_Hard = 16;
        static char largest = '#'; static int largestS_index = 15;

        //READER VARİABLES
        static string line = " ";
        static int index = 0;
        static string text = "/Users/atacan/";

        //MENU VARİABLES
        static int choice = 0;
        static bool again = false;

        //WRITER VARIABLES
        static string Write = null;
        static int Write_num = 0;
        static string[] allowedChoices = { "min", "*", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" };
        static string file_witer = null;
        static string adress = "/Users/atacan/desktop/GRAPHER.txt";

        //MATRİX VARİABLES
        static int[,] graphMatrix = new int[S_vertex_Hard, S_vertex_Hard];
        static char[] MatrixELEMENT = new char[16];
        static int[] MatrixELEMENTsWithIndex = new int[16];
        static int matrixWriter = 0;
        static int[,] RminMatrix = new int[S_vertex_Hard, S_vertex_Hard];

        //RELATİON CONTROL VARİABLES
        static int[] S_allVertexX = new int[16];
        static int[] S_allVertexPlus = new int[16];
        static int Relationer_I = 0; static int Relationer_J = 0;
        static int dir_I = 0; static int dir_J = 0;
        static char[,] Copygraph = new char[27, 42];
        static int[] allvertexI_CG = new int[16];
        static int[] allvertexJ_CG = new int[16];
        static int ErorControl = 0;

        //R* MAKİNG
        static int[,,] R_variatons = new int[16, 16, 17];
        static int sum = 0;
        static int matrix_loader = -1;

        //MİN STEPS
        static int[] searcher = new int[2];
        static char[] letter = new char[2];

        //---------------------------------------------------------------------------------(Functions)

        public static void Menu(int menu)
        {
            if (menu == 1)
            {
                Console.SetCursorPosition(48, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("WELCOME TO THE GRAPHER");
                Console.SetCursorPosition(47, 2);
                Console.Write("------------------------");
                Console.ResetColor();
                Console.SetCursorPosition(48, 4);
                Console.Write("1]Draw graph manually");
                Console.SetCursorPosition(48, 6);
                Console.Write("2]Read the graph from ");
                Console.SetCursorPosition(48, 8);
                Console.Write("3]Exit");
            }
            if (menu == 2)
            {
                Console.SetCursorPosition(48, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Where is the file?");
                Console.SetCursorPosition(47, 2);
                Console.Write("------------------------");
                Console.ResetColor();
                Console.SetCursorPosition(48, 4);
                Console.Write("1]Desktop ");
                Console.SetCursorPosition(48, 6);
                Console.Write("2]Downloads ");
                Console.SetCursorPosition(48, 8);
                Console.Write("3]Others...");
            }
            if (menu == 3)
            {
                Console.SetCursorPosition(46, 30);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Query for min steps:  from:   to:  (press 'M' for activate)");
                Console.ResetColor();
            }
            if (menu == 4)
            {
                Console.SetCursorPosition(49, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("DO YOU WANT TO ... ?");
                Console.SetCursorPosition(47, 2);
                Console.Write("------------------------");
                Console.ResetColor();
                Console.SetCursorPosition(48, 4);
                Console.Write("1]Save some infos");
                Console.SetCursorPosition(48, 6);
                Console.Write("2]Exit");
            }
            if (menu == 5)
            {
                Console.SetCursorPosition(49, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("WHICH INFO?");
                Console.SetCursorPosition(47, 2);
                Console.Write("------------------------");
                Console.ResetColor();
                Console.SetCursorPosition(48, 4);
                Console.Write("1]R? matrix");
                Console.SetCursorPosition(48, 6);
                Console.Write("2]Graph");
                Console.SetCursorPosition(48, 8);
                Console.Write("3]Exit");
                Choicer(5);
            }


        }

        public static void Choicer(int button)
        {
            if (button == 1)
            {
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        Drawer = Console.ReadKey(true);

                        if (Drawer.Key == ConsoleKey.D1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 4);
                            Console.Write("1]Draw graph manually");
                            Console.ResetColor();
                            choice = 1;
                            break;
                        }
                        if (Drawer.Key == ConsoleKey.D2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 6);
                            Console.Write("2]Read the graph from ");
                            Console.ResetColor();
                            choice = 2;
                            break;
                        }
                        if (Drawer.Key == ConsoleKey.D3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 8);
                            Console.Write("3]Exit");
                            Console.ResetColor();
                            Environment.Exit(exitCode: 666);
                            break;
                        }
                    }
                }
            }
            if (button == 2)
            {
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        Drawer = Console.ReadKey(true);

                        if (Drawer.Key == ConsoleKey.D1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 4);
                            Console.Write("1]Desktop ");
                            Console.ResetColor();
                            text = text + "desktop/";
                            break;
                        }
                        if (Drawer.Key == ConsoleKey.D2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 6);
                            Console.Write("2]Downloads ");
                            Console.ResetColor();
                            text = text + "download/";
                            break;
                        }
                        if (Drawer.Key == ConsoleKey.D3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 8);
                            Console.Write("3]Others...");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(48, 10);
                            Console.Write("Enter the adress: ");
                            Console.ResetColor();
                            text = text + Console.ReadLine() + "/";
                            break;
                        }
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(45, 12);
                Console.Write("Enter the file's name: ");
                Console.ResetColor(); text = text + Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(25, 13);
                Console.Write("your file's adress: " + text + " [press any key to comfirm] ");
                Console.ReadKey(); Console.ResetColor();
            }
            if (button == 3)
            {
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        Drawer = Console.ReadKey(true);

                        if (Drawer.Key == ConsoleKey.D1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 4);
                            Console.Write("1]Draw graph manually");
                            Console.ResetColor();
                            choice = 1;
                            break;
                        }
                        if (Drawer.Key == ConsoleKey.D2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 6);
                            Console.Write("2]Read the graph from ");
                            Console.ResetColor();
                            choice = 2;
                            break;
                        }
                        if (Drawer.Key == ConsoleKey.D3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 8);
                            Console.Write("3]Exit");
                            Console.ResetColor();
                            Environment.Exit(exitCode: 666);
                            break;
                        }
                    }
                }
            }
            if (button == 4)
            {
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        Drawer = Console.ReadKey(true);

                        if (Drawer.Key == ConsoleKey.D1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 4);
                            Console.Write("1]Save some infos ");
                            Console.ResetColor();
                            Erase(50, 15);
                            Menu(5);
                            break;
                        }
                        if (Drawer.Key == ConsoleKey.D2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 6);
                            Console.Write("2]Exit ");
                            Console.ResetColor();
                            Environment.Exit(exitCode: 666);
                            break;
                        }
                    }
                }
                
            }
            if (button == 5)
            {
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        Drawer = Console.ReadKey(true);

                        if (Drawer.Key == ConsoleKey.D1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 4);
                            Console.Write("1]R? matrix");
                            Console.ResetColor();
                            choice = 1;
                            break;
                        }
                        if (Drawer.Key == ConsoleKey.D2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 6);
                            Console.Write("2]Graph ");
                            Console.ResetColor();
                            choice = 2;
                            break;
                        }
                        if (Drawer.Key == ConsoleKey.D3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(48, 8);
                            Console.Write("3]Exit ");
                            Console.ResetColor();
                            Environment.Exit(exitCode: 666);
                            break;
                        }
                    }
                }
                Erase(100, 15);
                if (choice == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    do
                    {
                        Console.SetCursorPosition(15, 3);
                        Console.Write("Enter the matrix name[min / * / (1-16)]: ");
                        Write = Console.ReadLine();
                        Console.SetCursorPosition(15, 4);
                        Console.Write("Enter the new file's adress: ");
                        adress = Console.ReadLine();
                        if (adress.Length < 2)
                            adress = "/Users/atacan/desktop/GRAPHER.txt";
                        Console.ResetColor();
                        Write = Write.ToLower();
                        for (int a = 0; a < allowedChoices.Length; a++)
                        {
                            if (Write == allowedChoices[a])
                            { again = true; }
                        }
                        if(again == false)
                        { Console.ForegroundColor = ConsoleColor.Red; }

                    } while (again == false);
                    again = false;
                    if(Write != "min" && Write != "*")
                    { Write_num = Convert.ToInt16(Write); Write = null; }
                    Erase(50, 15);
                    if(Write != null && Write == "*")
                    {
                        StreamWriter f = File.CreateText(adress);
                        f.WriteLine("R* Matrix");
                        for (int a = 0; a < S_vertex_Hard + 2; a++)
                        {
                            if (a < S_vertex_Hard + 1)
                                f.Write("-");
                            else
                                f.WriteLine("-");
                        }
                        for (int a = 0; a < S_vertex_Hard; a++)
                        {
                            file_witer = "|";
                            for (int b = 0; b < S_vertex_Hard; b++)
                            {
                                file_witer += Convert.ToInt16(R_variatons[a, b, 16]);
                            }
                            file_witer += "|";
                            f.WriteLine(file_witer);
                        }
                        for (int a = 0; a < S_vertex_Hard + 2; a++)
                        {
                            f.Write("-");
                        }
                        Console.WriteLine("YOUR FILE IS READY AT DESKTOP");
                        Thread.Sleep(250);
                        f.Close();
                    }
                    else if(Write != null && Write == "min")
                    {
                        StreamWriter f = File.CreateText(adress);
                        f.WriteLine("Rmin Matrix");
                        f.Write(" ");
                        for (int a = 0; a < S_vertex_Hard; a++)
                        {
                            if (a < S_vertex_Hard-1)
                                f.Write(AllVertex[a]);
                            else
                                f.WriteLine(AllVertex[a]);
                        }
                        for (int a = 0; a < S_vertex_Hard; a++)
                        {
                            file_witer = Convert.ToString(AllVertex[a]);
                            for (int b = 0; b < S_vertex_Hard; b++)
                            {
                                file_witer += Convert.ToInt16(RminMatrix[a, b]);
                            }
                            f.WriteLine(file_witer);
                        }
                        Console.WriteLine("YOUR FILE IS READY AT DESKTOP");
                        Thread.Sleep(250);
                        f.Close();
                    }
                    else if (Write == null)
                    {
                        StreamWriter f = File.CreateText(adress);
                        f.WriteLine("R"+Write_num+" Matrix");
                        for (int a = 0; a < S_vertex_Hard + 2; a++)
                        {
                            if (a < S_vertex_Hard+1)
                            f.Write("-");
                            else
                            f.WriteLine("-");
                        }
                        for (int a = 0; a < S_vertex_Hard; a++)
                        {
                            file_witer = "|";
                            for (int b = 0; b < S_vertex_Hard; b++)
                            {
                                file_witer += Convert.ToInt16(R_variatons[a,b,(Write_num-1)]);
                            }
                            file_witer += "|";
                            f.WriteLine(file_witer);
                        }
                        for (int a = 0; a < S_vertex_Hard + 2; a++)
                        {
                                f.Write("-");
                        }
                        Console.WriteLine("YOUR FILE IS READY AT DESKTOP");
                        Thread.Sleep(250);
                        f.Close();
                    }

                }
                if (choice == 2)
                {
                    StreamWriter f = File.CreateText(adress);
                    for (int a = 0; a < graph.GetLength(0); a++)
                    {
                        file_witer = null;
                        for (int b = 0; b < graph.GetLength(1); b++)
                        {
                            file_witer += graph[a, b]; 
                        }
                        f.WriteLine(file_witer);
                    }
                    Console.WriteLine("YOUR FILE IS READY AT DESKTOP");
                    Thread.Sleep(250);
                    f.Close();
                }
            }
        }

        public static void Reader()
        {
            StreamReader SR = new StreamReader(text);
            do
            {
                line = SR.ReadLine();
                for (int i = 0; i < 40; i++)
                {
                    graph[index, i] = line[i];
                }
                index++;
            } while (!SR.EndOfStream);
            SR.Close();
        }

        public static void Empty_Creater(int key)
        {
            if (key == 1)
            {
                //CREATE A EMPTY DEGREE INFO
                for (int a = 0; a < S_allVertexX.Length; a++)
                {
                    S_allVertexX[a] = 0;
                    S_allVertexPlus[a] = 0;
                }
                //CREATE EMPTY RminMatrix
                for (int a = 0; a < RminMatrix.GetLength(0); a++)
                {
                    for (int b = 0; b < RminMatrix.GetLength(1); b++)
                    {
                        RminMatrix[a, b] = 0;
                    }
                }
            }
            if (key == 2)
            {//CREATE A EMPTY GRAPH 
                for (int vertexbooltrue = 0; vertexbooltrue < VertexControl.Length; vertexbooltrue++)
                {
                    VertexControl[vertexbooltrue] = true;
                }

                for (int a = 0; a < graph.GetLength(0); a++)
                {
                    for (int b = 0; b < graph.GetLength(1); b++)
                    {
                        graph[a, b] = '.';
                    }
                }
            }
            if (key == 3)
            {
                //CREATE A EMPTY VERTEX CONROLLER
                for (int vertexbooltrue = 0; vertexbooltrue < VertexControl.Length; vertexbooltrue++)
                {
                    VertexControl[vertexbooltrue] = true;
                }
            }
            if (key == 4)
            {
                //CREATE A EMPTY COPYGRAPH 
                for (int a = 0; a < Copygraph.GetLength(0); a++)
                {
                    for (int b = 0; b < Copygraph.GetLength(1); b++)
                    {
                        Copygraph[a, b] = '.';
                    }
                }
            }
        }

        public static void ControlHelper()
        {
            //CONTROL HELP
            Console.SetCursorPosition(60, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("DRAWING CONTROLS");
            Console.SetCursorPosition(48, 5);
            Console.Write("----------------------------------------");
            Console.ResetColor();
            Console.SetCursorPosition(48, 7);
            Console.Write(">>> Use movement keys to move cursor");
            Console.SetCursorPosition(48, 9);
            Console.Write(">>> Use 'letter keys(A-P)' to add vertex");
            Console.SetCursorPosition(48, 11);
            Console.Write(">>> Use 'space' key to add edge ['+']");
            Console.SetCursorPosition(48, 13);
            Console.Write(">>> Use 'X' key to add edge end ['X']");
            Console.SetCursorPosition(48, 15);
            Console.Write(">>> Use 'backspace' key to erase");
            Console.SetCursorPosition(48, 17);
            Console.Write(">>> Use 'enter' key to comfirm the graph");
        }

        public static void borderWriting()
        {
            //Writing borders
            Console.SetCursorPosition(0, 3); //COLUMN
            for (int d = 0; d < 3; d++)
            {
                for (int c = 1; c < 11; c++)
                {
                    if (c > 9)
                        Console.WriteLine(0);
                    else
                        Console.WriteLine(c);
                }
            }
            for (int clean = 0; clean < 5; clean++) // Cleaning
            {
                Console.SetCursorPosition(0, 28 + clean);
                Console.Write("          ");
            }
            Console.SetCursorPosition(4, 1); //ROW
            for (int d = 0; d < 4; d++)
            {
                for (int c = 1; c < 11; c++)
                {
                    if (c > 9)
                        Console.Write(0);
                    else
                        Console.Write(c);
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int e = 0; e < 40; e++) //# row
            {
                Console.SetCursorPosition(4 + e, 2);
                Console.Write('#');
                Console.SetCursorPosition(4 + e, 28);
                Console.Write('#');
            }
            for (int f = 0; f < 25; f++) //column
            {
                Console.SetCursorPosition(3, 3 + f);
                Console.Write('#');
                Console.SetCursorPosition(44, 3 + f);
                Console.Write('#');
            }
            Console.ResetColor();

                             //  Writing arrays
            for (int a = 0; a < graph.GetLength(0); a++)
            {
                for (int b = 0; b < graph.GetLength(1); b++)
                {
                    Console.SetCursorPosition(4 + b, 3 + a);
                    Console.Write(graph[a, b]);
                }
            }
        }

        public static void Erase(int time, int row)
        {
            Console.SetCursorPosition(0, 0);
            for (int a = 0; a < row; a++)
            {
                string space_50 = "                                                  ";
                Thread.Sleep(time);

                Console.WriteLine(space_50 + space_50 + "                  ");
            }
        }

        public static void ManualWriting()
        {
            //MANUEL MODE
            while (true)
            {
                //Write drawer
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(DrawerX, DrawerY);
                Console.Write(drawerchar);
                Console.ResetColor();

                draw2 = DateTime.Now;
                TimeSpan ts = draw2 - draw;
                if ((ts.TotalMilliseconds / 300) >= 1)
                {
                    //  Writing arrays
                    for (int a = 0; a < graph.GetLength(0); a++)
                    {
                        for (int b = 0; b < graph.GetLength(1); b++)
                        {
                            if (graph[a, b] != '.' && graph[a, b] != 'X' && graph[a, b] != '+')
                            { Console.ForegroundColor = ConsoleColor.Green; }
                            if (graph[a, b] == 'X' || graph[a, b] == '+')
                            { Console.ForegroundColor = ConsoleColor.Red; }

                            Console.SetCursorPosition(4 + b, 3 + a);
                            Console.Write(graph[a, b]);
                            Console.ResetColor();
                        }
                    }
                    draw = draw2;
                }

                //Write drawer(pt.2)
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(DrawerX, DrawerY);
                Console.Write(drawerchar);
                Console.ResetColor();

                if (Console.KeyAvailable)
                {
                    Drawer = Console.ReadKey(true);

                    for (int a = 0; a < 16; a++)
                    {
                        if ((graph[DrawerY - 3, DrawerX - 4] == AllVertex[a]) &&
                            !(Drawer.Key == ConsoleKey.LeftArrow || Drawer.Key == ConsoleKey.RightArrow || Drawer.Key == ConsoleKey.UpArrow || Drawer.Key == ConsoleKey.DownArrow))
                            VertexControl[a] = true;
                    }

                    if (Drawer.Key == ConsoleKey.LeftArrow && DrawerX != 4)
                    {
                        Console.SetCursorPosition(DrawerX, DrawerY);
                        Console.Write(graph[DrawerY - 3, DrawerX - 4]);
                        DrawerX--;
                    }
                    else if (Drawer.Key == ConsoleKey.RightArrow && DrawerX != 43)
                    {
                        Console.SetCursorPosition(DrawerX, DrawerY);
                        Console.Write(graph[DrawerY - 3, DrawerX - 4]);
                        DrawerX++;
                    }
                    else if (Drawer.Key == ConsoleKey.UpArrow && DrawerY != 3)
                    {
                        Console.SetCursorPosition(DrawerX, DrawerY);
                        Console.Write(graph[DrawerY - 3, DrawerX - 4]);
                        DrawerY--;
                    }
                    else if (Drawer.Key == ConsoleKey.DownArrow && DrawerY != 27)
                    {
                        Console.SetCursorPosition(DrawerX, DrawerY);
                        Console.Write(graph[DrawerY - 3, DrawerX - 4]);
                        DrawerY++;
                    }
                    else if (Drawer.Key == ConsoleKey.Spacebar)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = '+';
                    }
                    else if (Drawer.Key == ConsoleKey.Backspace)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = '.';
                    }
                    else if (Drawer.Key == ConsoleKey.X)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'X';
                    }
                    else if (Drawer.Key == ConsoleKey.A && VertexControl[0] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'A';
                    }
                    else if (Drawer.Key == ConsoleKey.B && VertexControl[1] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'B';
                    }
                    else if (Drawer.Key == ConsoleKey.C && VertexControl[2] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'C';
                    }
                    else if (Drawer.Key == ConsoleKey.D && VertexControl[3] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'D';
                    }
                    else if (Drawer.Key == ConsoleKey.E && VertexControl[4] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'E';
                    }
                    else if (Drawer.Key == ConsoleKey.F && VertexControl[5] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'F';
                    }
                    else if (Drawer.Key == ConsoleKey.G && VertexControl[6] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'G';
                    }
                    else if (Drawer.Key == ConsoleKey.H && VertexControl[7] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'H';
                    }
                    else if (Drawer.Key == ConsoleKey.I && VertexControl[8] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'I';
                    }
                    else if (Drawer.Key == ConsoleKey.J && VertexControl[9] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'J';
                    }
                    else if (Drawer.Key == ConsoleKey.K && VertexControl[10] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'K';
                    }
                    else if (Drawer.Key == ConsoleKey.L && VertexControl[11] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'L';
                    }
                    else if (Drawer.Key == ConsoleKey.M && VertexControl[12] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'M';
                    }
                    else if (Drawer.Key == ConsoleKey.N && VertexControl[13] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'N';
                    }
                    else if (Drawer.Key == ConsoleKey.O && VertexControl[14] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'O';
                    }
                    else if (Drawer.Key == ConsoleKey.P && VertexControl[15] == true)
                    {
                        graph[DrawerY - 3, DrawerX - 4] = 'P';
                    }
                    else if (Drawer.Key == ConsoleKey.Enter && (S_vertex_Hard == largestS_index + 1))
                    {
                        break;
                    }
                    else if (Drawer.Key == ConsoleKey.Enter && (S_vertex_Hard != largestS_index + 1))
                    {
                        Console.SetCursorPosition(5, 29);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("You have missing vertex!");
                        Console.ResetColor();
                    }
                }

                //Easy control for is there any vertex?
                for (int a = 0; a < graph.GetLength(0); a++)
                {
                    for (int b = 0; b < graph.GetLength(1); b++)
                    {
                        for (int c = 0; c < VertexControl.Length; c++)
                        {
                            if ((AllVertex[c] == graph[a, b]))
                            { VertexControl[c] = false; }
                        }
                    }
                }

                //Vertex sayisi ve en büyük vertex belirle!
                for (int a = 0; a < AllVertex.Length; a++)
                {
                    if (VertexControl[a] == false)
                    {
                        S_vertex_soft++; largestS_index = 0;
                        if (a > largestS_index)
                        { largestS_index = a; }
                    }
                }
                S_vertex_Hard = S_vertex_soft;
                S_vertex_soft = 0;
                largest = AllVertex[largestS_index];

                if (S_vertex_Hard == 1)
                {
                    for (int a = 0; a < AllVertex.Length; a++)
                    {
                        if (VertexControl[a] == false)
                        { largestS_index = a; largest = AllVertex[a]; }
                    }
                }

                //Control for exist no Vertex
                if (S_vertex_Hard == 0)
                {
                    for (int vertexbooltrue = 0; vertexbooltrue < VertexControl.Length; vertexbooltrue++)
                    {
                        VertexControl[vertexbooltrue] = true;
                        largest = '#';
                        largestS_index = 15;
                    }
                }

                ControlHelper();
            }
        }

        public static void CreateMatrix()
        {
            // CREATE A MATRİX ELEMENTS FOR GRAPH

            for (int a = 0; a < graphMatrix.GetLength(0); a++) //make all elements zero at matrix
            {
                for (int b = 0; b < graphMatrix.GetLength(1); b++)
                {
                    graphMatrix[a, b] = 0;
                }
            }

            for (int a = 0; a < largestS_index + 1; a++) //determine all elements at graph's matrix
            {
                if (VertexControl[a] == false)
                {
                    MatrixELEMENT[matrixWriter] = AllVertex[a];
                    MatrixELEMENTsWithIndex[matrixWriter] = a;
                    matrixWriter++;
                }
            }


        }

        public static void CreateCopyGraph()
        {
            //CREATE A CLONE GRAPH
            for (int a = 0; a < graph.GetLength(0); a++)
            {
                for (int b = 0; b < graph.GetLength(1); b++)
                {
                    Copygraph[a + 1, b + 1] = graph[a, b];
                }
            }

            //Determine the vertex's position(i,j) *for clone graph*
            for (int a = 0; a < Copygraph.GetLength(0); a++) //i
            {
                for (int b = 0; b < Copygraph.GetLength(1); b++) //j
                {
                    for (int c = 0; c < S_vertex_Hard; c++)
                    {
                        if (Copygraph[a, b] == MatrixELEMENT[c])
                        { allvertexI_CG[c] = a; allvertexJ_CG[c] = b; }
                    }
                }
            }

            //Find the degrees
            for (int a = 0; a < S_vertex_Hard; a++)
            {
                for (int c = -1; c < 2; c++)//i
                {
                    for (int b = -1; b < 2; b++)//j
                    {
                        if (Copygraph[allvertexI_CG[a] + c, allvertexJ_CG[a] + b] == '+')
                        { S_allVertexPlus[a]++; }
                        if (Copygraph[allvertexI_CG[a] + c, allvertexJ_CG[a] + b] == 'X')
                        { S_allVertexX[a]++; }
                    }
                }

            }
        }

        public static void ControlForRelations()
        {
            //RELATİONER TİMMEEEE
            for (int a = 0; a < S_vertex_Hard; a++) //matrix element
            {
                Relationer_I = allvertexI_CG[a]; Relationer_J = allvertexJ_CG[a];

                while (Copygraph[allvertexI_CG[a] - 1, allvertexJ_CG[a] - 1] == '+' || Copygraph[allvertexI_CG[a] - 1, allvertexJ_CG[a]] == '+' ||
                    Copygraph[allvertexI_CG[a] - 1, allvertexJ_CG[a] + 1] == '+' || Copygraph[allvertexI_CG[a], allvertexJ_CG[a] - 1] == '+' ||
                    Copygraph[allvertexI_CG[a], allvertexJ_CG[a] + 1] == '+' || Copygraph[allvertexI_CG[a] + 1, allvertexJ_CG[a] - 1] == '+' ||
                    Copygraph[allvertexI_CG[a] + 1, allvertexJ_CG[a]] == '+' || Copygraph[allvertexI_CG[a] + 1, allvertexJ_CG[a] + 1] == '+')
                {
                    dir_I = 0; dir_J = 0;

                    //FİND DİRECTİON
                    for (int g = -1; g < 2; g++)
                    {
                        for (int h = -1; h < 2; h++)
                        {
                            dir_I = g; dir_J = h;

                            if (Copygraph[allvertexI_CG[a] + dir_I, allvertexJ_CG[a] + dir_J] == '+')
                            {
                                Relationer_I = allvertexI_CG[a] + dir_I; Relationer_J = allvertexJ_CG[a] + dir_J;
                                Copygraph[Relationer_I, Relationer_J] = '@';
                                while (true) //Find x
                                {
                                    if ((Copygraph[Relationer_I + dir_I, Relationer_J + dir_J] == '+'))
                                    { Relationer_I = Relationer_I + dir_I; Relationer_J = Relationer_J + dir_J; }

                                    else if ((Copygraph[Relationer_I + dir_I, Relationer_J + dir_J] == '.'))
                                    {
                                        Copygraph[Relationer_I, Relationer_J] = '@'; Copygraph[Relationer_I - dir_I, Relationer_J - dir_J] = '@';
                                        ErorControl = 0;
                                        for (int x = -1; x < 2; x++)
                                        {
                                            for (int z = -1; z < 2; z++)
                                            {
                                                if(Copygraph[Relationer_I+x, Relationer_J+z] == '+' || Copygraph[Relationer_I + x, Relationer_J + z] == 'X')
                                                { ErorControl++; }
                                            }
                                        }
                                        if(ErorControl != 1)//EROR CONTROL HERE!!!!!!!
                                        { Console.SetCursorPosition(10,2); Console.ForegroundColor = ConsoleColor.Red; Console.Write("BROKEN GRAPH"); Environment.Exit(exitCode: 666); }

                                        for (int b = 0; b < 3; b++)
                                        {
                                            for (int c = 0; c < 3; c++)
                                            {
                                                if (Copygraph[(Relationer_I - 1) + b, (Relationer_J - 1) + c] == '+')
                                                {
                                                    if (b == 0 && c == 0)
                                                    { dir_I = -1; dir_J = -1; }
                                                    if (b == 0 && c == 1)
                                                    { dir_I = -1; dir_J = 0; }
                                                    if (b == 0 && c == 2)
                                                    { dir_I = -1; dir_J = +1; }
                                                    if (b == 1 && c == 0)
                                                    { dir_I = 0; dir_J = -1; }
                                                    if (b == 1 && c == 1)
                                                    { dir_I = 0; dir_J = 0; }
                                                    if (b == 1 && c == 2)
                                                    { dir_I = 0; dir_J = +1; }
                                                    if (b == 2 && c == 0)
                                                    { dir_I = +1; dir_J = -1; }
                                                    if (b == 2 && c == 1)
                                                    { dir_I = +1; dir_J = 0; }
                                                    if (b == 2 && c == 2)
                                                    { dir_I = +1; dir_J = +1; }
                                                    b = 3; break;
                                                }

                                                else if (Copygraph[(Relationer_I - 1) + b, (Relationer_J - 1) + c] == 'X')
                                                {
                                                    dir_I = b - 1; dir_J = c - 1;
                                                }
                                            }
                                        }

                                    }
                                    else if ((Copygraph[Relationer_I + dir_I, Relationer_J + dir_J] == 'X'))
                                    {
                                        Relationer_I = Relationer_I + dir_I; Relationer_J = Relationer_J + dir_J;
                                        for (int b = 0; b < 3; b++)
                                        {
                                            for (int c = 0; c < 3; c++)
                                            {
                                                for (int d = 0; d < S_vertex_Hard; d++)
                                                {
                                                    if (Copygraph[(Relationer_I - 1) + b, (Relationer_J - 1) + c] == MatrixELEMENT[d])
                                                    { graphMatrix[a, MatrixELEMENTsWithIndex[d]] = 1; c = 3; b = 3; }
                                                }
                                            }
                                        }
                                        break;
                                    }


                                }
                            }
                        }
                    }
                }
            }

        }

        public static void FindAllRMatrices()
        {
            //R Matrix
            for (int a = 0; a < S_vertex_Hard; a++)
            {
                for (int b = 0; b < S_vertex_Hard; b++)
                {
                    R_variatons[a, b, 0] = graphMatrix[a, b];
                }
            }
            //Find All R Matrices
            for (int a = 0; a < S_vertex_Hard-1; a++)
            {
                sum = 0;
                for (int i = 0; i < S_vertex_Hard; i++)
                {
                    for (int j = 0; j < S_vertex_Hard; j++)

                    {
                        sum = 0;

                        for (int k = 0; k < S_vertex_Hard; k++)
                        { sum = sum + R_variatons[i, k, 0] * R_variatons[k, j, a]; }

                        if (sum >= 1)
                        { sum = 1; }
                        R_variatons[i, j, (a + 1)] = sum;

                    }
                }
            }
            //Find R* Matrix
            for (int a = 0; a < S_vertex_Hard; a++) //i
            {
                for (int b = 0; b < S_vertex_Hard; b++) //j
                {
                    for (int c = 0; c < S_vertex_Hard; c++) //k
                    {
                        if (R_variatons[a, b, c] == 1)
                        { R_variatons[a, b, 16] = 1; }
                    }
                }
            }
            //RMİN MATRİX
            for (int a = 0; a < R_variatons.GetLength(0); a++)
            {
                for (int b = 0; b < R_variatons.GetLength(1); b++)
                {
                    for (int c = 0; c < R_variatons.GetLength(2); c++)
                    {
                        if (R_variatons[a, b, c] == 1 && RminMatrix[a, b] == 0)
                        {
                            RminMatrix[a, b] = (c+1);
                        }
                    }
                }
            }

        }

        public static void InfoScreen()
        {
            //WRİTE GRAPH
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(17, 1);
            Console.Write("-GRAPH-");
            Console.SetCursorPosition(1, 2);
            for (int a = 0; a < 40; a++)
            {
                Console.Write("-");
            }
            Console.ResetColor();
            for (int a = 0; a < graph.GetLength(0); a++)
            {
                for (int b = 0; b < graph.GetLength(1); b++)
                {
                    if (graph[a, b] == '+' || graph[a, b] == 'X')
                    { Console.ForegroundColor = ConsoleColor.Red; }
                    if (!(graph[a, b] == '+' || graph[a, b] == 'X' || graph[a, b] == '.'))
                    { Console.ForegroundColor = ConsoleColor.Green; }
                    Console.SetCursorPosition(1 + b, 3 + a);
                    Console.Write(graph[a, b]);
                    Console.ResetColor();
                }
            }

            //WRİTE MATRİX
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(70, 1);
            Console.Write("R* MATRIX");
            Console.SetCursorPosition(69, 2);
            for (int a = 0; a < 18; a++)
            {
                Console.Write("-");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(46, 1);
            Console.Write("R MATRIX");
            Console.SetCursorPosition(45, 2);
            for (int a = 0; a < 18; a++)
            {
                Console.Write("-");
            }
            Console.ResetColor();
            for (int a = 0; a < S_vertex_Hard; a++)
            {
                for (int b = 0; b < S_vertex_Hard; b++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(46 + b, 3);
                    Console.Write(MatrixELEMENT[b]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(45, 4 + b);
                    Console.Write(MatrixELEMENT[b]);
                    Console.ResetColor();
                    Console.SetCursorPosition(46 + b, 4 + a);
                    Console.Write(R_variatons[a, b, 0]);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(69 + b, 3);
                    Console.Write(MatrixELEMENT[b]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(68, 4 + b);
                    Console.Write(MatrixELEMENT[b]);
                    Console.ResetColor();
                    Console.SetCursorPosition(69 + b, 4 + a);
                    Console.Write(R_variatons[a, b, 16]);
                }
            }

            //WRİTE OTHER İNFOS
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(60, 23);
            Console.Write("Other Infos");
            Console.SetCursorPosition(45, 24);
            for (int a = 0; a < 51; a++)
            {
                Console.Write("-");
            }
            Console.ResetColor();
            Console.SetCursorPosition(46, 25);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("S(vertex): ");
            Console.ResetColor();
            Console.Write(S_vertex_Hard);
            Console.SetCursorPosition(46, 27);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("S(dgr-): ");
            Console.SetCursorPosition(46, 28);
            Console.Write("S(dgr+): ");
            Console.ResetColor();
            for (int b = 0; b < S_vertex_Hard; b++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(55 + 2 * b, 26);
                Console.Write(MatrixELEMENT[b]);
                Console.ResetColor();
                Console.SetCursorPosition(55 + 2 * b, 27);
                Console.Write(S_allVertexX[b]);
                Console.SetCursorPosition(55 + 2 * b, 28);
                Console.Write(S_allVertexPlus[b]);

            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(94, 1);
            Console.Write("R? MATRIX");
            Console.SetCursorPosition(93, 2);
            for (int a = 0; a < 25; a++)
            {
                Console.Write("-");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(104, 1);
            Console.Write("(Press space)");
            Console.ResetColor();
        }

        public static void FindMinQuery()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Drawer = Console.ReadKey(true);
                    if (Drawer.Key == ConsoleKey.M)
                    {
                        for (int a = 0; a < 2; a++)
                        {
                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.SetCursorPosition(73 + S_vertex_soft, 30);
                                Console.Write("~");
                                Thread.Sleep(100);
                                Console.SetCursorPosition(73 + S_vertex_soft, 30);
                                Console.Write(" ");
                                Console.ResetColor();

                                if (Console.KeyAvailable)
                                {
                                    Drawer = Console.ReadKey(true);
                                    if (Drawer.Key == ConsoleKey.A)
                                    { searcher[a] = 0; S_vertex_soft = 6; letter[a] = 'A'; break; }
                                    else if (Drawer.Key == ConsoleKey.B)
                                    { searcher[a] = 1; S_vertex_soft = 6; letter[a] = 'B'; break; }
                                    else if (Drawer.Key == ConsoleKey.C)
                                    { searcher[a] = 2; S_vertex_soft = 6; letter[a] = 'C'; break; }
                                    else if (Drawer.Key == ConsoleKey.D)
                                    { searcher[a] = 3; S_vertex_soft = 6; letter[a] = 'D'; break; }
                                    else if (Drawer.Key == ConsoleKey.E)
                                    { searcher[a] = 4; S_vertex_soft = 6; letter[a] = 'E'; break; }
                                    else if (Drawer.Key == ConsoleKey.F)
                                    { searcher[a] = 5; S_vertex_soft = 6; letter[a] = 'F'; break; }
                                    else if (Drawer.Key == ConsoleKey.G)
                                    { searcher[a] = 6; S_vertex_soft = 6; letter[a] = 'G'; break; }
                                    else if (Drawer.Key == ConsoleKey.H)
                                    { searcher[a] = 7; S_vertex_soft = 6; letter[a] = 'H'; break; }
                                    else if (Drawer.Key == ConsoleKey.I)
                                    { searcher[a] = 8; S_vertex_soft = 6; letter[a] = 'I'; break; }
                                    else if (Drawer.Key == ConsoleKey.J)
                                    { searcher[a] = 9; S_vertex_soft = 6; letter[a] = 'J'; break; }
                                    else if (Drawer.Key == ConsoleKey.K)
                                    { searcher[a] = 10; S_vertex_soft = 6; letter[a] = 'K'; break; }
                                    else if (Drawer.Key == ConsoleKey.L)
                                    { searcher[a] = 11; S_vertex_soft = 6; letter[a] = 'L'; break; }
                                    else if (Drawer.Key == ConsoleKey.M)
                                    { searcher[a] = 12; S_vertex_soft = 6; letter[a] = 'M'; break; }
                                    else if (Drawer.Key == ConsoleKey.N)
                                    { searcher[a] = 13; S_vertex_soft = 6; letter[a] = 'N'; break; }
                                    else if (Drawer.Key == ConsoleKey.O)
                                    { searcher[a] = 14; S_vertex_soft = 6; letter[a] = 'O'; break; }
                                    else if (Drawer.Key == ConsoleKey.P)
                                    { searcher[a] = 15; S_vertex_soft = 6; letter[a] = 'P'; break; }
                                }
                            }
                        }
                        S_vertex_soft = 0;
                        Console.SetCursorPosition(46, 30);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Query for min steps:  from:" + letter[0] + "   to:" + letter[1] + "                                     ");
                        Console.ResetColor();
                        if (R_variatons[searcher[0], searcher[1], 16] == 0)
                        {
                            Console.SetCursorPosition(46, 31);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ANSWER: Not Possible");
                            Console.ResetColor();
                        }
                        else
                        {
                            for (int a = 0; a < S_vertex_Hard; a++)
                            {
                                if (R_variatons[searcher[0], searcher[1], a] == 1)
                                {
                                    Console.SetCursorPosition(46, 31);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("ANSWER:" + (a + 1) + " steps");
                                    Console.ResetColor();
                                    break;
                                }
                            }
                        }
                    }
                    else if (Drawer.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (Drawer.Key == ConsoleKey.Spacebar)
                    {
                        if (matrix_loader < S_vertex_Hard+1)
                            matrix_loader++;
                        else
                            matrix_loader = 0;


                        if (matrix_loader != 0 && matrix_loader != S_vertex_Hard+1)
                        {
                            Console.SetCursorPosition(94, 1);
                            Console.Write("          ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(94, 1);
                            Console.Write("R" + (matrix_loader) + "MATRIX ");
                            for (int a = 0; a < S_vertex_Hard; a++)
                            {
                                for (int b = 0; b < S_vertex_Hard; b++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.SetCursorPosition(94 + b, 3);
                                    Console.Write(MatrixELEMENT[b]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.SetCursorPosition(93, 4 + b);
                                    Console.Write(MatrixELEMENT[b]);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(94 + b, 4 + a);
                                    Console.Write(R_variatons[a, b, matrix_loader-1]);
                                }
                            }
                        }
                        else if (matrix_loader == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(94, 1);
                            Console.Write("RminMATRIX");
                            for (int a = 0; a < S_vertex_Hard; a++)
                            {
                                for (int b = 0; b < S_vertex_Hard; b++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.SetCursorPosition(94 + b, 3);
                                    Console.Write(MatrixELEMENT[b]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.SetCursorPosition(93, 4 + b);
                                    Console.Write(MatrixELEMENT[b]);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(94 + b, 4 + a);
                                    Console.Write(RminMatrix[a,b]);
                                }
                            }
                        }
                        else if (matrix_loader == S_vertex_Hard+1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(94, 1);
                            Console.Write("R* MATRIX ");
                            for (int a = 0; a < S_vertex_Hard; a++)
                            {
                                for (int b = 0; b < S_vertex_Hard; b++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.SetCursorPosition(94 + b, 3);
                                    Console.Write(MatrixELEMENT[b]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.SetCursorPosition(93, 4 + b);
                                    Console.Write(MatrixELEMENT[b]);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(94 + b, 4 + a);
                                    Console.Write(R_variatons[a, b, 16]);
                                }
                            }
                        }
                    }
                }
            }


        }

        public static void Main(string[] args)
        {
            do
            {
                //---------------------------------------------------------------------------------------(START)
                Console.CursorVisible = false; //Make cursor invisible
                //---------------------------------------------------------------------------------------(CREATİNG EMPTY TOOLS)
                Empty_Creater(1); Empty_Creater(2); Empty_Creater(3); Empty_Creater(4);
                //---------------------------------------------------------------------------------------(MENU)
                Menu(1);
                Choicer(1);
                //---------------------------------------------------------------------------------------------(ERASE ALL)
                Erase(50, 10);
                //---------------------------------------------------------------------------------------------(READ THE FILE AND ASK FOR CHANGE ANYTHİNG)
                if (choice == 2)
                {
                    Menu(2);
                    Choicer(2);
                    Reader(); //Read graph from the file
                }
                //---------------------------------------------------------------------------------------------(ERASE ALL)
                if (choice == 2)
                {
                    Erase(50, 15);
                    choice = 1;
                }
                //--------------------------------------------------------------------------------------- (WRİTE BY MANUALLY)
                if (choice == 1)
                {
                    borderWriting(); //Borders
                    ManualWriting(); //Manual writing for graph by hand
                }
                //---------------------------------------------------------------------------------------------(ERASE ALL)
                Erase(50, 30);
                //---------------------------------------------------------------------------------------------(CREATE MATRİX FOR GRAPH)
                CreateMatrix();
                //----------------------------------------------------------------------------------------------(CONTROL FOR RELATİONS)
                CreateCopyGraph();//Copy the main graph for treacing!
                ControlForRelations();//Trace
                //----------------------------------------------------------------------------------------------(R* MATRİX)
                FindAllRMatrices();
                //----------------------------------------------------------------------------------------------(WRİTE ALL İNFO)
                InfoScreen();
                //----------------------------------------------------------------------------------------------(QUESTİONS AND ANSWERS)
                Menu(3);
                FindMinQuery();
                //----------------------------------------------------------------------------------------------(ERASE ALL)
                Erase(50, 50);
                //----------------------------------------------------------------------------------------------(WRİTE TO THE FILE SCENE)
                Menu(4);
                Choicer(4);
                Erase(50, 15);
                //----------------------------------------------------------------------------------------------(END)
            } while (again);
        }
    }
}
