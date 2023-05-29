# Clase 12: Computación cuántica
    
    Toda la computación anterior se denomina computación clásica. El paradigma de programación para la computación cuántica es muy distinto al actual. Promete resolver problemas que con la computación actual tardaría mucho tiempo. Uno de los problemas que se promete resolver es la factorización de números grandes



## Computación clásica
    En computación clásica, la unidad de ((..)) es el bit que se representa en la PC mediante un voltaje que se puede medir. La electrónica puede representar operaciones entre 0 y 1 mediante puertas lógicas, por ejemplo, NOT, AND, OR, XOR, NAND. XOR y NAND se consideran operaciones universales porque cualquier operación se puede construir sólo con XOR o sólo con NAND. Por ejemplo, si uno quiere sumar 2 bits, usa XOR.

## Computación cuántica
    En computación cuántica, uno tiene cubits, siendo {|0>, |1>} una base computacional (en el sentido de álgebra lineal). A diferencia del caso anterior, el cubir no está en |0> o en |1>, sino en una combinación lineal de los estados de la base |psi> = alfa|0> + beta|1>, donde alfa y beta no son cualquier cosa: pueden ser nros complejos y su módulo cuadrado representa la probabilidad de encontrarse en un |0> y |1>, respectivamente. En este espacio uno puede definir un producto interno y como dijimos que "es una base", la base computacional es ortogonal y normalizada. Además, todos los estados tienen que estar normalizados, con lo cual se establece una relación entre alfa y beta.

    Otro modo de representar el estado cuántico es mediante la representación de bloch en la cual
    |psi> = e^{i\tita}(cos(phi/2)|0> + e^{i gamma} sin(phi/2)) |1>
    (era algo así la fórmula)

    Solo es posible determinar el estado del qubit midiendolo.

### Operaciones
    Las operaciones se representan con productos matriciales. Los operadores tienen que ser unitarios. Por ejemplo, el operador X que intercambia las componentes alfa y beta entre sí, el operador Z que |0> le asigna |0>, mientras que a |1> le asigna -|1>, la puerta de ((Hallaband)) que me lleva |0> y |1> a |+> y |->, respectivamente

## ¿Cómo construimos un circuito usando operadores?

En computación clásica se combinan puertas lógicas para representar operaciones. Por ejemplo, combinando AND, NOT y OR puedo hacer la operación XOR. El profesor dibujó el circuito en términos de puertas lógicas.

En computación cuántica, con una línea se representa un qubit. Los equivalentes a las compuertas se representan con letras (H, Z, X, ...). Como hasta que se mida no se conoce el estado, uno necesita una variable clásica o bit clásico llamado C, con el cual se mide y se obtiene un resultado clásico.


Es posible con un paquete de python acceder a una computadora cuántica de IBM. El módulo tmb tiene un simulador de una computadora cuántica.

Toda computadora cuántica va acumulando error asociado al proceso de medición (y al azar). No todos los qubits están conectados.



