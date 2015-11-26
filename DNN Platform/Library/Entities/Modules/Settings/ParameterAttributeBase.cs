﻿using System;

namespace DotNetNuke.Entities.Modules.Settings
{
    /// <summary>
    /// Base class for attributes that are used to decorate properties (parameters) related to 
    /// application settings (storage) or parameters (control) like query string parameters.
    /// </summary>
    public abstract class ParameterAttributeBase : Attribute
    {
        /// <summary>
        /// The prefix to use when naming the setting in the settings table.
        /// </summary>
        /// <remarks>
        /// The settings tables are shared by the core platform and the extensions. Extensions
        /// should use a unique prefix to ensure that name clashes do not occur with settings 
        /// defined by the core or other extensions.
        /// </remarks>
        public string Prefix { get; set; }

        /// <summary>
        /// The name of the setting that will be stored in the settings table.
        /// </summary>
        /// <remarks>
        /// If parametername is not defined, then the name of the property will be used.  If
        /// a prefix is defined, then that will be concatenated with the parametername (or the
        /// property name if no parametername is provided)
        /// </remarks>
        public string ParameterName { get; set; }

        /// <summary>
        /// The serializer to use when saving or retrieving the setting value.
        /// </summary>
        /// <remarks>
        /// The serializer must implement the <see cref="ISettingsSerializer{T}" /> interface.
        /// </remarks>
        public string Serializer { get; set; }
    }
}
