Inventory List Project Readme File.

The project contains 2 segments hereby follows below,

Segment 1: DataBase

 1. Database named as ShopBridge_DB.
 2. *The ShopBridge_DB contains Table "InventoryList" along with rows and columns.
 3. *The table column names should be as listed below,
      1.InventoryID (Primary Key)
      2.Name
      3.Description
      4.Price
      5.Quantity
      6.InventoryValue

Segement 2: .Net Solution

1. The .Net project Solution contains two projects,project names are
     1. Mvc
     2. WebApi
   Note: Set the above listed projects both as a startup project to run the solution.

  i).Mvc: 
    * GlobalVariable.cs is the file need to setup the base address(localhost address).
    
    Nuget packages Added in Mvc: 
    1. Web Api Client
    2. AlertifyJs

  ii)WebApi:
    *All the backend call are made through API Calls to perform the operations

** Once the application starts in Mvc application, We can perform the operations of Inventory List through Basic UI.



