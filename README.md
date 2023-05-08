# ProgramacionAvanzada
 Repo propio del curso de programación avanzada en el IB


Página web de la materia
*Github
https://github.com/IBProgramacionAvanzada/IBProgramacionAvanzada.github.io
*Bibliografía
https://ibprogramacionavanzada.github.io/


Va a haber entregas de ejercicios semanales a partir de la próxima semana (semana 2 de cursado)

NOTAS A PROCESAR:
¿Por qué usar F# respecto a otros lenguajes?
F# se diferencia en que el compilador se encarga de mucha parte del trabajo de control. Sirve entonces para que los errores aparezcan en la etapa de compilación, antes de la de ejecución. En códigos simples puede no ser de mucha utilidad, pero sí lo es en códigos complejos. En algún sentido está bueno aprender el paradigma funcional para saber que existe y, una vez aprendido, entender sus ventajas. 

Clase 6:

Q: ¿Qué son las secuencias? ¿Cuál es la diferencia respecto a las listas?

A: Las secuencias (`seq`) son otro tipo de colecciones que ofrece F#, y se utilizan habitualmente cuando uno tiene una gran cantidad de datos. En efecto, a diferencia de las listas, los elementos de una secuencia se computan a medida que son requeridos.

Q: ¿Se puede trabajar con archivos en F#?

A: Sí. F# tiene funciones específicas para trabajar con archivos. Nosotros vimos algunas de ellas

Clase 7:

Q: Supongamos que está cargando pares de datos y se encuentra con un par de datos donde uno no existe. ¿Qué hacer?

A: En F# se puede tratar con datos que no existen usando el tipo option
-----
type Option<'a> =       
   | Some of 'a           // valid value
   | None                 // missing

Además, este tipo de datos nos permite no trabajar con "nros mágicos". Por ejemplo, si estoy midiendo algo y de repende deja de medir, no tengo que poner un "0" o un "-1" en la cadena