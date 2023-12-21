# FacturasAPI

Instrucciones:

* Levantar el proyecto en Visual Studio 2022.
* Crear una base de datos MySQL llamada "facturasapi".
* Crear migración (tablas): dotnet ef migrations add primera_migracion (en terminal). Si no funciona, instalar CLI: dotnet tool install --global dotnet-ef --version 6.*
* Compilar y correr el proyecto. En Swagger probar POST:
```bash
{
  "correlativo": "123456789",
  "tipo": "comidas",
  "monto": 50.20,
  "items": [
    {
      "correlativo": "sopa",
      "monto": 20.20
    },
    {
      "correlativo": "arroz con pollo",
      "monto": 30.00
    }
  ]
}
```