using System;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel;

namespace EntLibContrib.Data.SQLite.Configuration
{

    /// <summary>
    /// Represents the process to build an instance of <see cref="SQLiteDatabase"/> described by configuration information.
    /// </summary>
    public class SQLiteDatabaseData : DatabaseData
    {
        public SQLiteDatabaseData(ConnectionStringSettings connectionStringSettings, IConfigurationSource configurationSource)
            : base(connectionStringSettings, configurationSource)
        {
        }

        public override IEnumerable<TypeRegistration> GetRegistrations()
        {
            yield return new TypeRegistration<Database>(
                () =>  new SQLiteDatabase(ConnectionString))
            {
                Name = Name,
                Lifetime = TypeRegistrationLifetime.Transient
            };
        }
    }

}
