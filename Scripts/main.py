import clr
clr.AddReference('CSharpPyMap')

from CSharpClass import Person
import numpy as np

p1 = Person("Shounak", 20)
myClass = Person("Jon", 27)

a = np.arange(15).reshape(3, 5)

print("---stdout FROM PYTHON---")
print(a)
print(a.shape)
