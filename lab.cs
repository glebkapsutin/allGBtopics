public class Test
{
   static void Foo()
    {
        Stack<Tuple<int,int>> _path = new Stack<Tuple<int,int>>();
        int[,] labirinth1 = new int [,]
        {
            {1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0},
            {1,1,1,1,1,1,1},
            {1,0,0,0,0,2,1},
            {1,1,1,1,1,1,1}
        };
        FindPath(1,1);
        bool FindPath(int i,int j)
        {
            Console.WriteLine(labirinth1[i,j]);
            if (labirinth1[i,j]==0) _path.Push(new(i,j));
            _path.Push(new Tuple<int,int>(i,j));
            while(_path.Count>0)
            {
                var current = _path.Pop();
                Console.WriteLine($"{current.Item1},{current.Item2}");
                if(labirinth1[current.Item1,current.Item2]==2)
                {
                    Console.WriteLine($"Путь найден{current.Item1},{current.Item2}");
                    return true;
                }
                labirinth1[current.Item1,current.Item2]=1;
                
                if (labirinth1[current.Item1+1,current.Item2]!=1 && current.Item1+1<labirinth1.GetLength(0))
                    _path.Push(new(current.Item1+1,current.Item2));

                if (labirinth1[current.Item1,current.Item2+1]!=1 && current.Item2+1<labirinth1.GetLength(1))
                    _path.Push(new(current.Item1,current.Item2+1));

                if (labirinth1[current.Item1-1,current.Item2]!=1 && current.Item1>0)
                    _path.Push(new(current.Item1-1,current.Item2));

                if (labirinth1[current.Item1,current.Item2-1]!=1 && current.Item2>0)
                    _path.Push(new(current.Item1,current.Item2-1));
            }
            Console.WriteLine("Пути нет");
            return false;
        }
 
    }
}