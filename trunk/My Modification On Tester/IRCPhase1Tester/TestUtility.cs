using System;
using IRCPhase1Tester.Tests;

namespace IRCPhase1Tester
{
    public enum TestType
    {
        UserCommandHappy = 1,
        UserCommandMissingParams = 2,
        NickCommandHappy = 3,
        NickCommandNickInUse = 4,
        NickCommandNoNick = 5,
        UnknownCommand = 6,
        UserCommandAlreadyRegistered = 7,
        PrivmsgCommandHappy = 8,
        PrivmsgCommandNoRecipient = 9,
        PrivmsgCommandNoSuchNick = 10,
        PrivmsgCommandNoTextToSend = 11,
        PrivmsgCommandUnregistered = 12,
        PrivmsgCommandUnregisteredWithNickCommand = 13,
        PrivmsgCommandUnregisteredWithUserCommand = 14,
        PrivmsgCommandMultipleTargetsHappy = 15,
        PrivmsgCommandMultipleTargetsNoSuchNick = 16,
        PrivmsgCommandBackAndForth = 17,
        PrivmsgCommandLoad = 18,
        PrivmsgCommandSendToUnregisteredClient = 19,
    }

    public enum TestResult
    {
        Passed,
        Failed
    }

    public static class TestUtility
    {
        public static int NumOfTests
        {
            get { return Enum.GetNames(typeof(TestType)).Length; }
        }

        public static ITest GetTest(int testNumber)
        {
            TestType type;

            if (testNumber > NumOfTests)
            {
                return null;
            }

            type = (TestType)testNumber;

            return GetTest(type);
        }

        public static ITest GetTest(TestType type)
        {
            ITest testObject = null;

            switch (type)
            {
                case TestType.NickCommandHappy:
                    testObject = new NickCommandHappy();
                    break;
                case TestType.NickCommandNickInUse:
                    testObject = new NickCommandNickInUse();
                    break;
                case TestType.NickCommandNoNick:
                    testObject = new NickCommandNoNick();
                    break;
                case TestType.PrivmsgCommandBackAndForth:
                    testObject = new PrivmsgCommandBackAndForth();
                    break;
                case TestType.PrivmsgCommandHappy:
                    testObject = new PrivmsgCommandHappy();
                    break;
                case TestType.PrivmsgCommandLoad:
                    testObject = new PrivmsgCommandLoad();
                    break;
                case TestType.PrivmsgCommandMultipleTargetsHappy:
                    testObject = new PrivmsgCommandMultipleTargetsHappy();
                    break;
                case TestType.PrivmsgCommandMultipleTargetsNoSuchNick:
                    testObject = new PrivmsgCommandMultipleTargetsNoSuchNick();
                    break;
                case TestType.PrivmsgCommandNoRecipient:
                    testObject = new PrivmsgCommandNoRecipient();
                    break;
                case TestType.PrivmsgCommandNoSuchNick:
                    testObject = new PrivmsgCommandNoSuchNick();
                    break;
                case TestType.PrivmsgCommandNoTextToSend:
                    testObject = new PrivmsgCommandNoTextToSend();
                    break;
                case TestType.PrivmsgCommandSendToUnregisteredClient:
                    testObject = new PrivmsgCommandSendToUnregisteredClient();
                    break;
                case TestType.PrivmsgCommandUnregistered:
                    testObject = new PrivmsgCommandUnregistered();
                    break;
                case TestType.PrivmsgCommandUnregisteredWithNickCommand:
                    testObject = new PrivmsgCommandUnregisteredWithNickCommand();
                    break;
                case TestType.PrivmsgCommandUnregisteredWithUserCommand:
                    testObject = new PrivmsgCommandUnregisteredWithUserCommand();
                    break;
                case TestType.UnknownCommand:
                    testObject = new UnknownCommand();
                    break;
                case TestType.UserCommandAlreadyRegistered:
                    testObject = new UserCommandAlreadyRegistered();
                    break;
                case TestType.UserCommandHappy:
                    testObject = new UserCommandHappy();
                    break;
                case TestType.UserCommandMissingParams:
                    testObject = new UserCommandMissingParams();
                    break;
            }

            return testObject;
        }

        public static TestType[] GetArrayOfTestTypesFromIntegerArray(int[] intList)
        {
            if (intList.Length == 0)
            {
                return null;
            }

            TestType[] testTypes = new TestType[intList.Length];

            for (int i = 0; i < intList.Length; i++)
            {
                testTypes[i] = (TestType)intList[i];
            }

            return testTypes;
        }
    }
}