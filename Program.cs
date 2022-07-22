using System.Drawing;
using System.Drawing.Imaging;
using ImageMagick;
using Python.Runtime;


const string SCRIPTPATH =  "Scripts/opencv-test.py";
const string PYBINPATH = "/usr/lib/x86_64-linux-gnu/libpython3.10.so";
const string PYTHONVARNAME = "p1";

Runtime.PythonDLL = PYBINPATH;
PythonEngine.Initialize();
using (Py.GIL())
{
   var scriptCode = System.IO.File.ReadAllText(SCRIPTPATH);
   using (var scope = Py.CreateScope())
   {
      scope.Set(PYTHONVARNAME, null);
      scope.Exec(scriptCode);
      var p1 = scope.Get<byte[]>(PYTHONVARNAME);
      var p2 = scope.Get<byte[]>("p2");
      // using (var image = new MagickImage(p2))
      // {
      //    image.Format = MagickFormat.Png;
      //    image.Write("sudoku-2.png");
      // }

		
      // Do more stuff here :)
   }
}
PythonEngine.Shutdown();

