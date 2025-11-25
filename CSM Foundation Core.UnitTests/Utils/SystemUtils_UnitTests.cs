using CSM_Foundation_Core;
using CSM_Foundation_Core.Core.Utils;

namespace Unit_Tests.Utils;


/// <summary>
///     Tests class for <see cref="SystemUtils"/>.
/// </summary>
public class SystemUtils_UnitTests {

    const string _varKey = "randomVarKey";
    const string _varValue = "randomVarValue";


    [Fact(DisplayName = "[GetVar(varKey)]: Correctly gets a previous store variable")]
    public void GetVar_A() {

        Environment.SetEnvironmentVariable(_varKey, _varValue);

        Assert.Equal(_varValue, SystemUtils.GetVar(_varKey));
    }

    [Fact(DisplayName = "[SetVar(varKey, varValue)]: Correctly sets a variable and can be gathered by the system")]
    public void SetVar_A() {

        SystemUtils.SetVar(_varKey, _varValue);

        Assert.Equal(_varValue, Environment.GetEnvironmentVariable(_varKey));
    }

    [Fact(DisplayName = "[GetEnv(varKey)]: Correctly gets the environment (DEVELOPMENT | DEV)")]
    public void GetEnv_A() {
        SystemUtils.SetVar(Constants.Framework.ASPNETCORE_ENVIRONEMNT, Constants.Environments.DEVELOPMENT);

        SystemEnvs developmentEnv = SystemUtils.GetEnv();

        Assert.Equal(SystemEnvs.DEV, developmentEnv);

        SystemUtils.SetVar(Constants.Framework.ASPNETCORE_ENVIRONEMNT, Constants.Environments.DEV);

        SystemEnvs devEnv = SystemUtils.GetEnv();

        Assert.Equal(SystemEnvs.DEV, developmentEnv);
    }

    [Fact(DisplayName = "[GetEnv(varKey)]: Correctly gets the environment (PRODUCTION | PROD)")]
    public void GetEnv_B() {
        SystemUtils.SetVar(Constants.Framework.ASPNETCORE_ENVIRONEMNT, Constants.Environments.PRODUCTION);

        SystemEnvs productionEnv = SystemUtils.GetEnv();

        Assert.Equal(SystemEnvs.PROD, productionEnv);

        SystemUtils.SetVar(Constants.Framework.ASPNETCORE_ENVIRONEMNT, Constants.Environments.PROD);

        SystemEnvs prodEnv = SystemUtils.GetEnv();

        Assert.Equal(SystemEnvs.PROD, productionEnv);
    }

    [Fact(DisplayName = "[GetEnv(varKey)]: Correctly gets the environment (QUALITY | QA)")]
    public void GetEnv_C() {
        SystemUtils.SetVar(Constants.Framework.ASPNETCORE_ENVIRONEMNT, Constants.Environments.QUALITY);

        SystemEnvs qualityEnv = SystemUtils.GetEnv();

        Assert.Equal(SystemEnvs.QA, qualityEnv);

        SystemUtils.SetVar(Constants.Framework.ASPNETCORE_ENVIRONEMNT, Constants.Environments.QA);

        SystemEnvs qaEnv = SystemUtils.GetEnv();

        Assert.Equal(SystemEnvs.QA, qualityEnv);
    }

    [Fact(DisplayName = "[GetEnv(varKey)]: Correctly gets the environment (LABORATORY | LAB)")]
    public void GetEnv_D() {
        SystemUtils.SetVar(Constants.Framework.ASPNETCORE_ENVIRONEMNT, Constants.Environments.LABORATORY);

        SystemEnvs laboratoryEnv = SystemUtils.GetEnv();

        Assert.Equal(SystemEnvs.LAB, laboratoryEnv);

        SystemUtils.SetVar(Constants.Framework.ASPNETCORE_ENVIRONEMNT, Constants.Environments.LAB);

        SystemEnvs labEnv = SystemUtils.GetEnv();

        Assert.Equal(SystemEnvs.LAB, laboratoryEnv);
    }
}
