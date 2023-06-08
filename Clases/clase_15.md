
# Blockchain
    Vimos un repaso de los medios de intercambio de bienes: trueque, crédito, efectivo, moneda, ... Las características de una moneda son
    . Es fungible: ej todos los billetes de $100 son equivalemtes
    . Durable
    . Portable
    . Reconocible
    . Estable

    ¿Cómo hacemos una moneda virtual? Hay varios problemas:
    * Quién la emite
    * Double spending: cómo evitar que alguien (incluso quien lo emite) duplique la cantidad de dinero. En el caso del dinero físico hay que hacer mucho esfuerzo para falsificar un billete.
    * Cómo se registran los gastos
    * Cómo se le da valor a lo emitido?

    En los 90 se empezaron a resolver estos problemas.

    En primer lugar, para darle valor, la moneda tiene que ser escasa. Puede ser escaso por diseño (solo se emite determinada cantidad de monedas) o se emite continuamente pero se quema cuando se hacen transacciones.

    *Hash
    H(x) es un hash si
    . x (input) es un string de cualquier tamaño
    .H(x) = y es un arreglo de tamaño fijo de bits
    .Es eficiente computacionalmente. H(x) si x tiene n bits es de orden O(n)

    Por ejemplo:
    H(x) = x mod(7)
    Pero este no es resistente a colisiones
    . Un hash debe ser resistente a colisiones. Dado x!=y, H(x) != H(y)

    No hay forma de crear un hash que evite el problema anterior porque en el proceso hay una reducción de información. Pero sí es posible disminuir la probabilidad de una colisión

    . Hiding: si consigo y como y = H(x), no será posible resolver x por más que el algoritmo del Hash sea público. x tiene que ser una distribución muy grande. ¿Cómo se asegura el hiding? Se introduce una función que se llama Nonce: r||x, donde ||: concatenar y r es el nonce, un valor (típicamente) que se obtiene de una distribución muy desparramada (por ejemplo la uniforme)

    El hash es difícil de invertir porque hay una reducción de información

    . "Puzzle friendly": un "puzzle" o "rompecabezas" es un problema numérico, como un sudoku. Que sea "amigable con rompecabezas". Por ejemplo el Puzzle de BTC es, dado H y dado un valor (en general un conjunto de valores) y (target), el problema es determinar id tal que H(id||x) esté en el conjunto de y.
    Por ejemplo, supongamos que tenemos el hash SHA-256
    1. Si Y = todos los valores (2^256) posibles de H_{SHA-256}(x), entonces cualquier id que tire seguro cae
    2. Si Y = un valor en particular, la probabilidad de encontrar el id es prácticamente imposible
    3. En BTC se dan 256 bits y se pide Y = la configuración anterior pero con los 20 primeros dígitos cero. Esto es "algo así"
    El proceso de resolución es fuerza bruta, dado que la probabilidad de encontrarlo es muy baja.


    Transformada de Markle-Domgard
    Por ejemplo, si uso el hash del módulo, si x>7, necesito separarlo en bloques y hacer el hash de cada sección. En el caso de SHA-256, el input es es m = 768 bits y el output son n = 256 bits.

    1. Dado input de M elementos, se hace padding (se agregan bits) de modo que el nro total de bits sea múltiplo de 256.
    2. Se separa en bloques de 256
    3. Se tira un nro random de 256 bits
    4. Se concatena el primer bloque con el nro random y se aplica el Hash
    5. El resultado se toma como el nuevo nro para concatenar con el segundo bloque y aplicar el hash
    6. Así sucesivamente hasta el último bloque.

    Además, hay que definir
    * hash pointer. Dado un dato, guardo la dirección de memoria y el H(dato).
    * blockchain: una lista simplemente enlazada donde, en lugar de tener punteros a los datos, se tienen hash pointers a los datos.
    * Claves públicas y privadas: con estas claves se "firman" las transacciones. Se pueden generar tantas claves públicas como uno quiera. El conjunto de pares públicas y privadas de uno constituyen una "billetera virtual". Todo el dinero que uno tiene está despripto en la blockchain con una llave pública. Es fundamental que uno proteja la clave privada que es lo que valida las transacciones
    * Descentralización (consenso). En la red distribuída ((no recuerdo qué es esto)), hay una serie de nodos. El problema es que algunos son "honestos" y otros no. Además, puede haber nodos que fallen (por problemas). Los nodos tienen que acordar cuál es el estado de la red en cada tiempo, consensar y organizarse para procesar las siguientes transacciones. No hay manera de sincronizar los nodos porque no todos los nodos tienen la misma conexión a internet ni están cercanos. Esto no solo debe hacerse en blockchain, sino tmb en las redes sociales por ejemplo. La idea es que tarde o temprano todos los nodos puedan tener acceso a toda la información. Esto debe ser un concenso distribuído. Tiene 2 propiedades:
    -Aparece un nuevo dato en la red, nos ponemos de acuerdo.
    -El protocolo tiene que asegurar que el nuevo estado tiene que ser generado por un nodo honesto

    Cuando se propone una transacción, se le asigna a un nodo y este nodo se encarga de avisarle a los demás. Con el tiempo cada nodo tiene un conjunto de transacciones para procesar. Las transacciones se juntan en un bloque. Cada nodo tiene acceso a un conjunto de esas transacciones. Una vez armado el bloque, se ejecuta el protocolo de consenso. El algoritmo de consenso tiene 3 partes:
    1. Elegir un nodo al azar y, por lo tanto, el bloque que tiene preparado.
    2. El resto de los nodos validan el bloque mediante un proceso de validación.
    3. Se agrega el bloque validado al blockchain, ¿a cuál? No todo está sincronizado. Cada nodo tiene distinto orden de bloques porque no a todos le llegan al mismo tiempo. El criterio de elección es que el blockchain "verdadero" es aquel que tiene la mayor cantidad de bloques y, por lo tanto, es el "más validado"

    BTC genera bloques cada 10', Etherium cada 12''.

    Veamos cómo se elige el nodo al azar en la red que será el que da el bloque que luego se va a validar. Aquí es donde nace la "prueba de trabajo" o "proof of work". La idea es darle dinero cuando el bloque se valida. El dinero se consigue resolviendo el problema del hash mencionado anteriormente. 

    Un bloque se arma concatenando transacciones t1||t2||t3||t4||... Los mineros son nodos que buscan el id tal que H(id||t1||t2||t3||t4||...) < target. El target es un subconjunto de los 2^256 posibles resultados del Hash. La dificultad está en cuán grande o pequeño sea el target, es decir, si el target tiene 256 bits, entonces la dificultad está relacionada con cuántos ceros tengo a izquierda. La dificultad se va actualizando con el tiempo.  Entonces por fuerza bruta (tirando nros al azar), el minero busca el id. El nodo que primero encuentra el id es el que valida su bloque.

    La cantidad de transacciones en el bloque es arbitraria. Pero la cantidad de dinero que gana el minero está determinada por el "fee" que tiene cada transacción. De modo que se intenta elegir las transacciones con mayor fee para ganar mayor dinero. Sumado al fee, tmb gana una cantidad fija de dinero de 6.125 BTC que se divide por 2 cada 4 años.

    Además, como no tenemos la clave privada de un usuario, no podemos robarle plata porque no podemos firmar la transacción. PERO sí es posible hacer double spending.

