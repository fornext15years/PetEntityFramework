# PetEntityFramework
This is a project to review Microsoft Entity Framework 

Database first approach
  Data model library based on .Net framework
    - First add references (Microsoft.EntityFramework, Microsoft.EntityFramework.SqlServer)  to a project  
    - then, Select Add item -> data -> edmx
    - then, Select Database first
    - then, Setup connection
    - then, To secure connection string, use EntityConnectionStringBuilder
    - then, Add DbContext partial class to call a proper constructor.
    
   Data model library based on .Net core
     - No EDMX file support.
     - Therefore, use reverse engineering
        - Scaffold-DbContext [connectionstring] [provider] -OutputDir [directoryName]
     - Can't create entities for view, store prodedure

Key concept & tips
- EDMX file
  - SSDL
  - CSDL
  - MSL
 - Securing Connection string 
   - EntityConnectionStringBuilder
