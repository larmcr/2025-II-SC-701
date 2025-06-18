# Tarea Programada 3

| Curso                           | Programación Avanzada en Web     |
| :------------------------------ | :------------------------------- |
| Código                          | SC-701                           |
| Profesor                        | Luis Andrés Rojas Matey          |
| Fecha y hora de entrega inicial | Martes 17 de junio a las 9:00 pm |
| Fecha y hora de entrega final   | Martes 24 de junio a las 6:00 pm |

<br />

## Introducción

Las funciones son elementos esenciales del álgebra. Con ellas, es posible representar relaciones entre elementos y encontrar valores cuando se utilizan en forma de ecuación.

<br />

## Objetivo

Aplicar los conocimientos adquiridos de utilizar un _minimal API_ con la herramienta `ASP.NET Core Minimal API` del _framework_ `.NET 8.0`.

<br />

## Especificaciones funcionales

Al ser una **Web API**, una vez se ejecuta, este _web service_ podrá consumirse con cualquier cliente **HTTP**/**REST(ful)**, como lo son [Postman](https://www.postman.com/) o cualquier navegador web. Este servicio tendrá cuatro (4) _endpoints_ que se deben poder acceder por medio del método/verbo **GET**:

- "/"
- "/lineal"
- "/cuad"
- "/exp"

<br />

## _Endpoint_ "/"

Este _endpoint_ hará un _redirect_ al **UI** de **Swagger**, permitiendo observar la definición de los _endpoints_ en una página web.

<br />

## _Endpoint_ "/lineal"

Este permitirá identificar propiedades de una función lineal que define una recta de la forma `f(x) = mx + b`.

Para esto, permitirá los siguientes parámetros (del _query string_):

- **b** (obligatorio): valor numérico de la intersección con el eje `y`.
- **m** (opcional): valor numérico de la pendiente.
- **x1** (opcional): un valor numérico del eje `x` de la recta, asociado con **y1**.
- **y1** (opcional): un valor numérico del eje `y` de la recta, asociado con **x1**.
- **x2** (opcional): otro valor numérico del eje `x` de la recta, asociado con **y2**.
- **y2** (opcional): otro valor numérico del eje `y` de la recta, asociado con **x2**.
- **xml** (opcional): valor _boolean_ indicando si el resultado se debe retornar en XML en vez de JSON. Por defecto (_default_) es `false`, es decir, por defecto se debe retornar un JSON.

A pesar que el único valor obligatorio es **b**, para que retorne un resultado correcto (**_HTTP 200 Success_**), el _request_ debe incluir un valor en **m**, o bien, los dos puntos del plano cartesiano `(x1, y1)` y `(x2, y2)` representados por los cuatro valores de los ejes (**x1**, **y1**, **x2**, **y2**). En caso de que se provean los cinco valores, tomará prioridad **m**, obviando los demás cuatro. Si **m** no es proveido pero los otros cuatro sí, entonces se procederá a calcular el valor de **m** a partir de los dos puntos.

Una vez se tenga el valor del pendiente (**m**), el servicio devolverá un objeto (JSON) con cuatro campos (las tildes se pueden obviar y tanto los índices como los valores son de tipo _string_):

- **funcion**: `f(x) = mx + b`, con los respectivos valores de `m` y `b`.
- **pendiente**: `creciente` o `decreciente`.
- **interseccionConEjeX**: par ordenado `(x, 0)` con el valor correspondiente de `x`.
- **interseccionConEjeY**: par ordenado `(0, y)` con el valor correspondiente de `y`.

Por ejemplo, este _request_:

```
/lineal?b=3&m=-5
```

devolvería este _response_ (**_HTTP 200 Success_**):

```json
{
  "funcion": "f(x) = -5x + 3",
  "pendiente": "decreciente",
  "interseccionConEjeX": "(0.6, 0)",
  "interseccionConEjeY": "(0, 3)"
}
```

<br />

Así mismo, este otro _request_:

```
/lineal?b=3&m=-5&xml=true
```

retornaría este _response_ (**_HTTP 200 Success_**):

```xml
<?xml version="1.0" encoding="utf-16"?>
<Lineal xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Funcion>f(x) = -5x + 3</Funcion>
    <Pendiente>decreciente</Pendiente>
    <InterseccionConEjeX>(0.6, 0)</InterseccionConEjeX>
    <InterseccionConEjeY>(0, 3)</InterseccionConEjeY>
</Lineal>
```

<br />

Además, este otro _request_ que no contiene **m** ni los dos puntos necesarios para calcular la pendiente:

```
/lineal?b=3
```

debería devolver este _response_ (**_HTTP 400 Bad Request_**):

```json
{
  "error": "Debe proporcionar la pendiente (m) o dos puntos (x1, y1) y (x2, y2)."
}
```

<br />

## _Endpoint_ "/cuad"

Este permitirá conocer las propiedades de una función cuadrática que define una parábola. Esta está definida como `f(x) = ax² + bx + c`, con los siguientes parámetros:

- **a** (obligatorio): valor numérico diferente de cero.
- **b** (obligatorio): valor numérico.
- **c** (obligatorio): valor numérico.
- **xml** (opcional): valor _boolean_ indicando si el resultado se debe retornar en XML en vez de JSON. Por defecto (_default_) es `false`.

<br />

Si el valor de **a** es cero o alguno de los tres parámetros obligatorios (**a**, **b** y **c**) no son proveidos, se deberá retornar un **_Bad Request_**. Por el contrario, en el escenario válido, se deberá retornar un objeto JSON con los siguientes campos:

- **funcion**: `f(x) = ax² + bx + c`, con los valores correspondientes de `a`, `b` y `c`.
- **discriminante**: `Δ = #`, con `#` el valor calculado del discriminante.
- **ejeDeSimetria**: `x = #`, con `#` como el valor de `x`.
- **concavidad**: `hacia arriba` o `hacia abajo`.
- **vertice**: par ordenado `(x, y)` con sus respectivos valores.
- **interseccionConEjeX**: `no hay`, `(x, y)` o `(x1, y1) y (x2, y2)`.
- **interseccionConEjeY**: `(0, y)`, con el valor respectivo de `y`.
- **ambito**: intervalo `]-∞, #]` o `[#, +∞[`, con el respectivo valor de `#`.
- **monotonias**: intervalos `]#, +∞[` y `]-∞, #[` donde `crece` y `decrece`, con los respectivos valores de `#`.

Ejemplos:

_Request_:

```
/cuad?a=0.5&b=-6&c=10
```

_Response_:

```json
{
  "funcion": "f(x) = 0.5x² + -6x + 10",
  "discriminante": "Δ = 16",
  "ejeDeSimetria": "x = 6",
  "concavidad": "hacia arriba",
  "vertice": "(6, -8)",
  "interseccionConEjeX": "(10, 0) y (2, 0)",
  "interseccionConEjeY": "(0, 10)",
  "ambito": "[-8, +∞[",
  "monotonias": "crece en ]6, +∞[ y decrece en ]-∞, 6["
}
```

<br />

_Request_:

```
/cuad?a=0.5&b=-6&c=0&xml=true
```

<br />

_Response_:

```xml
<?xml version="1.0" encoding="utf-16"?>
<Cuadratica xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Funcion>f(x) = 0.5x² + -6x + 10</Funcion>
    <Discriminante>Δ = 16</Discriminante>
    <EjeDeSimetria>x = 6</EjeDeSimetria>
    <Concavidad>hacia arriba</Concavidad>
    <Vertice>(6, -8)</Vertice>
    <InterseccionConEjeX>(10, 0) y (2, 0)</InterseccionConEjeX>
    <InterseccionConEjeY>(0, 10)</InterseccionConEjeY>
    <Ambito>[-8, +∞[</Ambito>
    <Monotonias>crece en ]6, +∞[ y decrece en ]-∞, 6[</Monotonias>
</Cuadratica>
```

<br />

_Request_:

```
/cuad?a=0&b=-6&c=0
```

_Response_:

```json
{
  "error": "Parámetro 'a' debe ser diferente de cero."
}
```

<br />

## _Endpoint_ "/exp"

Al igual que los anteriores _endpoints_, este permite obtener algunas propiedades de una función exponencial de la forma `f(x) = bˣ`, con los siguientes parámetros:

- **b** (obligatorio): valor numérico que indica la base, el cual debe ser mayor que cero (0) y diferente de uno (1).
- **xml** (opcional): valor _boolean_ indicando si el resultado se debe retornar en XML en vez de JSON. Por defecto (_default_) es `false`.

El _response_ exitoso incluiría estos datos:

<br />

- **funcion**: `f(x) = bˣ`, con el valor correspondiente de `b`.
- **monotonia**: `creciente` o `decreciente`.

Ejemplos:

_Request_:

```
/exp?b=0.7
```

_Response_

```json
{
  "funcion": "f(x) = 0.7ˣ",
  "monotonia": "decreciente"
}
```

<br />

_Request_:

```
/exp?b=1
```

_Response_:

```json
{
  "error": "La base 'b' debe ser mayor que 0 y diferente de 1."
}
```

<br />

## Especificaciones técnicas

- El trabajo se debe realizar con el lenguaje de programación `C#`, la arquitectura `ASP.NET Core Minimal API` y el _framework_ `.NET 8.0`.

- Debe contener un _solution_ y un _project_, así como el _project_ incluido en el _solution_.

- Los parámetros de los _requests_ (los cuales son todos de "tipo" **GET**) deben ser enviados por medio del _query string_. Cualquier otro parámetro por otro medio (_header_, _form_, _body_, etc.) debe ser ignorado.

- Los _responses_ pueden no contener palabras con tilde, es decir, las tildes se pueden obviar.

- En caso de que el _response_ no sea **_HTTP 200 Success_** debido a una validación (por ejemplo, uno de los parámetros no cumple con la restricción del valor), entonces debe ser de tipo **_HTTP 400 Bad Request_** y retornar el mensaje de error en formato JSON.

- Se recomienda utilizar el editor [Visual Studio Code](https://code.visualstudio.com).

<br />

# Entregables

Al ser una tarea de carácter individual, se debe entregar un único archivo comprimido **ZIP** con el siguiente nombre: `TP3-[Carné].zip`. Ejemplo de nombre del archivo **ZIP**: `TP3-FH12345678.zip`.

El mismo debe contener lo siguiente:

- Todo el código fuente que incluya el archivo _solution_ y la carpeta del _project_. Sin embargo, no debe contener los archivos compilados, es decir, excluir las carpetas `bin` y `obj`.

- `README.md`. La documentación en [Markdown](https://www.markdownguide.org) donde se indique lo siguiente:

  - Su nombre, carné y el enlace al repositorio si lo subió a `GitHub`, `GitLab` o algún otro proveedor.

  - Los comandos de `dotnet` utilizados (**CLI**).

  - Páginas web donde halló posibles soluciones a problemas encontrados o _snippets_ de código.

  - _Prompts_ (consultas y respuestas) de los _chatbots_ de IA (`Copilot`, `Gemini`, `ChatGPT`, etc.) que haya utilizado.

<br />

## Evaluación

El proyecto será calificado según la rúbrica que se presenta en el programa del curso.
