// See https://aka.ms/new-console-template for more information
// using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CommandLine;
using Python.Runtime;


Runtime.PythonDLL = "/usr/lib/x86_64-linux-gnu/libpython3.10.so";
PythonEngine.Initialize();
using (Py.GIL())
{
   var scriptCode = System.IO.File.ReadAllText("Scripts/main.py");
   using (var scope = Py.CreateScope())
   {
      scope.Set("p1", null);
      scope.Exec(scriptCode);
      var p1 = scope.Get<CSharpClass.Person>("p1");
      Console.WriteLine($"{p1}");
   }
}
PythonEngine.Shutdown();
