using System;
using Python.Runtime;

const string SCRIPTPATH =  "Scripts/main.py";
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
      var p1 = scope.Get<CSharpClass.Person>(PYTHONVARNAME);
      Console.WriteLine($"{p1}");

      // Do more stuff here :)
   }
}
PythonEngine.Shutdown();
