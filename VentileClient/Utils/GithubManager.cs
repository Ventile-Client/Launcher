using System.Threading.Tasks;

namespace VentileClient.Utils
{
    public static class GithubManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;

        //static int howManyCoreRequestsCanIMakePerHour;
        static int howManyCoreRequestsDoIHaveLeft;
        //static DateTimeOffset whenDoesTheCoreLimitReset;
        public static void UpdateLimits()
        {
            Task.Run(async () =>
            {
                var miscellaneousRateLimit = await MAIN.github.Miscellaneous.GetRateLimits();

                //  The "core" object provides your rate limit status except for the Search API.
                var coreRateLimit = miscellaneousRateLimit.Resources.Core;

                //howManyCoreRequestsCanIMakePerHour = coreRateLimit.Limit;
                howManyCoreRequestsDoIHaveLeft = coreRateLimit.Remaining;
                //whenDoesTheCoreLimitReset = coreRateLimit.Reset; // UTC time
            }).Wait();
        }

        public static bool HaveRequests()
        {
            UpdateLimits();
            if (howManyCoreRequestsDoIHaveLeft > 0) return true;

            MAIN.dLogger.Log("Access to github failed, no more requests");
            return false;
        }
    }
}
