﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Original file name:
// Generation date: 03/10/2012 1:27:20 AM
namespace DentiClinic
{
    
    /// <summary>
    /// There are no comments for Model1Container in the schema.
    /// </summary>
    public partial class Model1Container : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new Model1Container object using the connection string found in the 'Model1Container' section of the application configuration file.
        /// </summary>
        public Model1Container() : 
                base("name=Model1Container", "Model1Container")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new Model1Container object.
        /// </summary>
        public Model1Container(string connectionString) : 
                base(connectionString, "Model1Container")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new Model1Container object.
        /// </summary>
        public Model1Container(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "Model1Container")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
    }
}