namespace CSM_Foundation_Core;

/// <summary>
///     Stores common use constants.
/// </summary>
public struct Constants {

    /// <summary>
    ///     Stores constants related with .NET Framework unstored by them.
    /// </summary>
    public struct Framework {

        /// <summary>
        ///     ASPNETCORE environment variable key where the framework stores system environment.
        /// </summary>
        public const string ASPNETCORE_ENVIRONEMNT = "ASPNETCORE_ENVIRONMENT";
    }

    /// <summary>
    ///     Stores environment variables values identifications on system environment identification.
    /// </summary>
    /// <remarks>
    ///      These are evaluated matching with the value at <see cref="Framework.ASPNETCORE_ENVIRONEMNT"/> env var.
    /// </remarks>
    public struct Environments {

        /// <summary>
        ///     Specifies the value on development environment.
        /// </summary>
        public const string DEVELOPMENT = "development";

        /// <summary>
        ///     Specifies the value on development environment.
        /// </summary>
        public const string DEV = "dev";

        /// <summary>
        ///     Specifies the value on production environment.
        /// </summary>
        public const string PRODUCTION = "production";

        /// <summary>
        ///     Specifies the value on production environment.
        /// </summary>
        public const string PROD = "prod";

        /// <summary>
        ///     Specifies the value on quality environment.
        /// </summary>
        public const string QUALITY = "quality";

        /// <summary>
        ///     Specifies the value on quality environment.
        /// </summary>
        public const string QA = "qa";

        /// <summary>
        ///     Specifies the value on laboratory environment.
        /// </summary>
        public const string LABORATORY = "laboratory";

        /// <summary>
        ///     Specifies the value on laboratory environment.
        /// </summary>
        public const string LAB = "lab";
    }

    /// <summary>
    ///     Stores common constant user messages.
    /// </summary>
    public struct Messages {

        /// <summary>
        ///     Default user advise displayed when an unrecognized exception was caught.
        /// </summary>
        public const string DEFAULT_USER_ADVISE = "Exception unhandled, please contact your services administrator.";
    }


}
