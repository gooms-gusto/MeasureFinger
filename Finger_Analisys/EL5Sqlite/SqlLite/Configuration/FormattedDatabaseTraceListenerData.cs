using System;
using System.Configuration;
using System.Diagnostics;
using EntLibContrib.Data.SqLite.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;

namespace EntLibContrib.Data.SQLite.Configuration
{
    /// <summary>
    /// Configuration object for a <see cref="FormattedDatabaseTraceListener"/>.
    /// </summary>
    [ResourceDescription(typeof(DesignResources), "FormattedDatabaseTraceListenerDataDescription")]
    [ResourceDisplayName(typeof(DesignResources), "FormattedDatabaseTraceListenerDataDisplayName")]
    [AddSateliteProviderCommand("connectionStrings", typeof(DatabaseSettings), "DefaultDatabase", "DatabaseInstanceName")]
    public class FormattedDatabaseTraceListenerData : TraceListenerData
    {
        private const string databaseInstanceNameProperty = "databaseInstanceName";
        private const string formatterNameProperty = "formatter";

        /// <summary>
        /// Initializes a <see cref="FormattedDatabaseTraceListenerData"/>.
        /// </summary>
        public FormattedDatabaseTraceListenerData()
            : base(typeof(FormattedDatabaseTraceListener))
        {
            this.ListenerDataType = typeof(FormattedDatabaseTraceListenerData);
        }

        /// <summary>
        /// Initializes a named instance of <see cref="FormattedDatabaseTraceListenerData"/> with 
        /// name, stored procedure name, databse instance name, and formatter name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="writeLogStoredProcName">The stored procedure name for writing the log.</param>
        /// <param name="addCategoryStoredProcName">The stored procedure name for adding a category for this log.</param>
        /// <param name="databaseInstanceName">The database instance name.</param>
        /// <param name="formatterName">The formatter name.</param>        
        public FormattedDatabaseTraceListenerData(string name,
                                                  string databaseInstanceName,
                                                  string formatterName)
            : this(
                name,
                databaseInstanceName,
                formatterName,
                TraceOptions.None,
                SourceLevels.All)
        {
        }

        /// <summary>
        /// Initializes a named instance of <see cref="FormattedDatabaseTraceListenerData"/> with 
        /// name, stored procedure name, databse instance name, and formatter name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="writeLogStoredProcName">The stored procedure name for writing the log.</param>
        /// <param name="addCategoryStoredProcName">The stored procedure name for adding a category for this log.</param>
        /// <param name="databaseInstanceName">The database instance name.</param>
        /// <param name="formatterName">The formatter name.</param>
        /// <param name="traceOutputOptions">The trace options.</param>
        /// <param name="filter">The filter to be applied</param>
        public FormattedDatabaseTraceListenerData(string name,
                                                  string databaseInstanceName,
                                                  string formatterName,
                                                  TraceOptions traceOutputOptions,
                                                  SourceLevels filter)
            : base(name, typeof(FormattedDatabaseTraceListener), traceOutputOptions, filter)
        {
            DatabaseInstanceName = databaseInstanceName;
            Formatter = formatterName;
        }

        /// <summary>
        /// Gets and sets the database instance name.
        /// </summary>
        [ConfigurationProperty(databaseInstanceNameProperty, IsRequired = true)]
        [ResourceDescription(typeof(DesignResources), "FormattedDatabaseTraceListenerDataDatabaseInstanceNameDescription")]
        [ResourceDisplayName(typeof(DesignResources), "FormattedDatabaseTraceListenerDataDatabaseInstanceNameDisplayName")]
        [Reference(typeof(ConnectionStringSettingsCollection), typeof(ConnectionStringSettings))]
        public string DatabaseInstanceName
        {
            get { return (string)base[databaseInstanceNameProperty]; }
            set { base[databaseInstanceNameProperty] = value; }
        }


        /// <summary>
        /// Gets and sets the formatter name.
        /// </summary>
        [ConfigurationProperty(formatterNameProperty, IsRequired = false)]
        [ResourceDescription(typeof(DesignResources), "FormattedDatabaseTraceListenerDataFormatterDescription")]
        [ResourceDisplayName(typeof(DesignResources), "FormattedDatabaseTraceListenerDataFormatterDisplayName")]
        [Reference(typeof(NameTypeConfigurationElementCollection<FormatterData, CustomFormatterData>), typeof(FormatterData))]
        public string Formatter
        {
            get { return (string)base[formatterNameProperty]; }
            set { base[formatterNameProperty] = value; }
        }

        /// <summary>
        /// Returns a lambda expression that represents the creation of the trace listener described by this
        /// configuration object.
        /// </summary>
        /// <returns>A lambda expression to create a trace listener.</returns>
        protected override System.Linq.Expressions.Expression<Func<TraceListener>> GetCreationExpression()
        {
            return () =>
                   new FormattedDatabaseTraceListener(
                       Container.Resolved<Database>(DatabaseInstanceName),
                       Container.ResolvedIfNotNull<ILogFormatter>(Formatter));
        }
    }
}
