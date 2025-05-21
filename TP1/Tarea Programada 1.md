# Tarea Programada 1

| Curso                           | Programación Avanzada en Web |
| :------------------------------ | :--------------------------- |
| Código                          | SC-701                       |
| Profesor                        | Luis Andrés Rojas Matey      |
| Fecha y hora de entrega inicial | Martes 20 de mayo a las 9pm  |
| Fecha y hora de entrega final   | Martes 27 de mayo a las 6pm  |

<br />

## Introducción

El [_golden ratio_](https://en.wikipedia.org/wiki/Golden_ratio) (conocido por la letra griega `phi`: ![phi](phi.svg)) es un número especial de las matemáticas que se encuentra en muchos aspectos naturales. Este número puede ser calculado por medio de fórmulas o bien aproximaciones utilizando secuencias como la de [**Fibonacci**](https://en.wikipedia.org/wiki/Fibonacci_sequence).

<br />

## Objetivo

Familiarizarse con el lenguaje de programación `JavaScript`, con el motor `NodeJS`, y el editor `Visual Studio Code` creando un programa capaz de calcular el _golden ratio_ por medio de dos técnicas, así como conocer la diferencia entre ambas formas en cuanto a los valores calculados.

<br />

## Especificaciones funcionales

Al ejecutarse el programa en una **Consola** se solicitará al usuario un **número entero entre el 2 y el 45** (este número se indicará como `n` a lo largo de este enunciado). Una vez el usuario indica el número (estando este en el rango especificado) y presiona la tecla enter, el programa desplegará 3 secciones:

1. El valor aproximado de ![phi](phi.svg) usando la fórmula:

![Fórmula](formula.svg)

2. Todos los valores aproximados de ![phi](phi.svg), usando el resultado de la división de dos valores secuenciales de **Fibonacci** (desde `2` hasta `n`), así como la diferencia absoluta entre este valor aproximado y el de la fórmula del punto anterior.

3. Los valores de `Fib(n)` y `Fib(n - 1)`.

### Ejemplos

Cuando el programa inicia, solicita el número (`n`) al usuario:

```
Type an integer from 2 to 45:
```

Suponiendo que el usuario indica el número `5` (por lo tanto el valor de `n` es `5`), entonces se desplegaría así:

```
Type an integer from 2 to 45: 5

Phi ~ 1.618033988749895

Fib(2) / Fib(1) ~ 1 [+- 0.6180339887498949]
Fib(3) / Fib(2) ~ 2 [+- 0.3819660112501051]
Fib(4) / Fib(3) ~ 1.5 [+- 0.1180339887498949]
Fib(5) / Fib(4) ~ 1.6666666666666667 [+- 0.04863267791677184]

Fib(5) = 5
Fib(4) = 3
```

En detalle, esta línea indica el valor ![phi](phi.svg) usando la fórmula del punto **_#1_** del enunciado:

```
Phi ~ 1.618033988749895
```

La siguiente sección representa el punto **_#2_**, donde cada línea indica los valores desde `2` hasta `n`, así como el valor calculado de ![phi](phi.svg), con la diferencia entre paréntesis cuadrados (con el prefijo `+-`):

```
Fib(2) / Fib(1) ~ 1 [+- 0.6180339887498949]
Fib(3) / Fib(2) ~ 2 [+- 0.3819660112501051]
Fib(4) / Fib(3) ~ 1.5 [+- 0.1180339887498949]
Fib(5) / Fib(4) ~ 1.6666666666666667 [+- 0.04863267791677184]
```

Finalmente, según se indica en el punto **_#3_**, se deben desplegar los valores de `Fib(n)` y `Fib(n - 1)`:

```
Fib(5) = 5
Fib(4) = 3
```

Así mismo, este es un ejemplo cuando el número indicado por el usuario no está en el rango especificado (si el usuario indica un valor de `1`):

```
Type an integer from 2 to 45: 1
Input is out of range
```

<br />

## Especificaciones técnicas

- Los valores de **Fibonacci** se deben calcular utilizando un <ins>algoritmo iterativo</ins>, es decir, <ins>cada valor se debe calcular una única vez</ins>. Recuerde que este es el enunciado del algoritmo de **Fibonacci** en su versión recursiva:

  - `Fib(0) = 0`
  - `Fib(1) = 1`
  - `Fib(n) = Fib(n - 1) + Fib(n - 2)`

- Se debe utilizar el lenguaje de programación `JavaScript` con el motor [NodeJS](https://nodejs.org) versión `22.x.y` (`LTS`).

- Se recomienda utilizar el editor [Visual Studio Code](https://code.visualstudio.com).

<br />

## Entregables

Se debe entregar un único archivo comprimido **ZIP** con el siguiente nombre: `TP1-[Carné].zip`.

Ejemplo de nombre del archivo **ZIP**: `TP1-FH12345678.zip`.

El mismo debe tener <ins>únicamente</ins> tres archivos:

- `fib.js`. El archivo con el código en `JavaScript`.

- `package.json`. Archivo con las dependencias de `NodeJS`.

- `readme.md`. La documentación en [Markdown](https://www.markdownguide.org) donde se indique lo siguiente:

  - Enlace al repositorio si lo subió a `GitHub`, `GitLab` o algún otro proveedor.

  - Páginas web donde halló posibles soluciones a problemas encontrados o _snippets_ de código.

  - _Prompts_ (consultas y respuestas) de los _chatbots_ de IA (`Copilot`, `Gemini`, `ChatGPT`, etc.) que haya utilizado.

<br />

## Evaluación

El proyecto será calificado según la rúbrica que se presenta en el programa del curso.
