# Analizador lexico.

Este analizador lexico reconoce la siguiente lista de simbolos.
Identificadores= letra (letra|digito)*
Entero= digito+
Real= entero.entero
Operador de adición: + | -
Operador de multiplicación: * | /
Operador de asignación: =
Operador relacional: < | > | <= | >= | != | ==
Operador And: &&
Operador Or: ||
Operador Not: !
Parentesis: ( , )
Llave: { , }
Punto y coma: ;

Además de las siguientes palabras reservadas: if, while, return, else, int, float

Se hizo uso de automatas para poder anzalizar las antradas, a continuacion se muestra una captura de como es que funciona.
Aqui hay un error en la primera linea, por lo que muestra un mensaje de que se ha encontrado un error:


![Imagen1](https://user-images.githubusercontent.com/84942556/186260431-35077534-d287-4a6e-a863-3ba5f6ec1043.png)
Ademas de que se detendra el analisis al encontrar el primer error:
![Imagen2](https://user-images.githubusercontent.com/84942556/186260514-e9a3c751-b802-452f-9699-9d3574e9a740.png)
Aqui podemos ver como es que ha analizado exitosamente todos los elementos que se han ingresado:
![Imagen3](https://user-images.githubusercontent.com/84942556/186260592-2cd6a018-4488-42e7-bdf9-41ff57397d7d.png)
