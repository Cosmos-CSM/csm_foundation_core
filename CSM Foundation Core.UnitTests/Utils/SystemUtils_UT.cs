using CSM_Foundation_Core.Utils;

namespace CSM_Foundation_Core.UnitTests.Utils;


public class SystemUtils_UT {


    [Fact(DisplayName = "[GetVariable]: Correctly gets a previous store variable")]
    public void GetVariable_A() {
        const string varKey = "randomVarKey";
        const string varValue = "randomVarValue";

        Environment.SetEnvironmentVariable(varKey, varValue);

        Assert.Equal(varValue, SystemUtils.GetVar(varKey));
    }

    [Fact(DisplayName = "[SetVariable]: Correctly sets a variable and can be gathered by the system")]
    public void SetVariable_A() {
        const string varKey = "randomVarKey";
        const string varValue = "randomVarValue";

        SystemUtils.SetVar(varKey, varValue);

        Assert.Equal(varValue, Environment.GetEnvironmentVariable(varKey));
    }
}
