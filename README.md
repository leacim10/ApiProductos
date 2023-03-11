# ApiProductos
Api para insertar, actualizar y listar productos.
---
## Comenzando 🚀
_Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas._

### Pre-requisitos 📋
Se debe tener las siguientes tecnologías instaladas en su equipo:
* NET 6
* MySql

_Ejecute el los siguientes querys para la instalación de la base de datos._

_Crear base de datos_
```
create  schema `db_productos`;
```

_Crear tablas "productos" y "stockProductos"._
```
create table `db_productos`.`productos`
(
	idProducto_IN int not null auto_increment,
    codProducto_VC varchar(8) not null,
    descripcion_VC varchar(50) not null,
    fechaCreacion_DT datetime not null,
    fechaModificacion_DT datetime not null,
    stock_IN int not null,
    primary key (`idProducto_IN`)
);

create table `db_productos`.`stockProductos`
(
	idStock_IN int not null auto_increment,
    idProducto_IN int not null,
    fechaModificacion_DT datetime not null,
    usuario_VC varchar(6) not null,
    stock_IN int not null,
    primary key (`idStock_IN`),
    index `FK_STOCK_PRODUCTOS_idx` (`idProducto_IN` ASC) visible,
    constraint `FK_STOCK_PRODUCTOS`
    foreign key (`idProducto_IN`)
    references `db_productos`.`productos` (`idProducto_IN`)
);
```

_Crear SP para añadir nuevo producto_
```
delimiter //
create procedure addProducto(
    in _codProducto_VC varchar(8),
    in _descripcion_VC varchar(50)
)

/* ********************************************
Descripcion: Añadir nuevo producto
Autor: Micael Rogerç
Fecha de creacion: 10/03/2023
Fecha de modificacion:
******************************************** */
begin
	insert into `db_productos`.`productos`
    (
		codProducto_VC,
        descripcion_VC,
        fechaCreacion_DT,
        fechaModificacion_DT,
        stock_IN
    )
    values
    (
		_codProducto_VC,
        _descripcion_VC,
        now(),
        now(),
        0
    );
end//
delimiter ;
```

_Crear SP para actualizar stock de los productos_
```
delimiter //
create procedure updateProducto(
    in _idProducto_IN int,
    in _codProducto_VC varchar(8),
    in _stock_IN int,
    in _usuario_VC varchar(6)
)

/* ********************************************
Descripcion: Actualizar producto
Autor: Micael Roger
Fecha de creacion: 10/03/2023
Fecha de modificacion:
******************************************** */
begin
	update `db_productos`.`productos`
    set stock_IN = _stock_IN
    where idProducto_IN = _idProducto_IN
    and codProducto_VC = _codProducto_VC;
    
    insert into `db_productos`.`stockProductos`
    (
		idProducto_IN,
		fechaModificacion_DT,
		usuario_VC,
		stock_IN
    )
    values
    (
		_idProducto_IN,
		now(),
		_usuario_VC,
		_stock_IN
    );
    
end//
delimiter ;
```

_Crear SP para listar los productos_
```
delimiter //
create procedure listProductos()

/* ********************************************
Descripcion: Listar todos los productos
Autor: Micael Roger
Fecha de creacion: 10/03/2023
Fecha de modificacion:
******************************************** */
begin
	Select 
		idProducto_IN,
		codProducto_VC,
		descripcion_VC,
		fechaCreacion_DT,
        fechaModificacion_DT,
		stock_IN 
    from `db_productos`.`productos`;
end//
delimiter ;
```

### Configurar el archivo appsettings.json ⚙️
_En el archivo appsettings configurar su servidor, usuario y contraseña._
```
{
  "api": {
    "name": "ApiProductos",
    "version": "v1"
  },
  "Logs": {
    "Path_Log_File": "D:/DEV_Logs/ApiProductos/LogApiProductos.txt",
    "Level": "DEBUG"
  },
  "dataBase": {
    "conecctions": [
      {
        "name": "dbPrueba",
        "server": "",
        "dataBase": "db_productos",
        "user": "",
        "password": ""
      },
      {
        "name": "dbPrueba2",
        "server": "",
        "dataBase": "db_productos",
        "user": "",
        "password": ""
      }
    ]
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```

## Ejecutando las pruebas ⚙️
Se tiene los siguientes ejemplos para los 3 metodos expuestos en el API.

_POST_
```
{
  "codProducto_VC": "OR-4",
  "descripcion_VC": "GALLETA OREO"
}
```

_PUT_
```
{
  "idProducto_IN": 1,
  "codProducto_VC": "OR-4",
  "stock_IN": 4,
  "usuario_VC": "USER00"
}
```

## Autor ✒️
_Mikael R. Chavez C._

---
⌨️ con ❤️ por [leacim10](https://github.com/leacim10) 😊